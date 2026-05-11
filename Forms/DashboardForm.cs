using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using AOOP_HABI.Models;
using AOOP_HABI.Services;

namespace AOOP_HABI.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly CsvDataService _dataService = new CsvDataService();
        private DateTime _currentCalendarMonth = DateTime.Today;

        public DashboardForm()
        {
            InitializeComponent();
            ApplyTheme();
            lblToday.Text = "Today - " + DateTime.Today.ToString("MMMM dd, yyyy");
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            LoadDashboard();

            // The 4-Month Calendar Grid
            BuildSingleCalendar(pnlCalendar1, _currentCalendarMonth);               
            BuildSingleCalendar(pnlCalendar2, _currentCalendarMonth.AddMonths(1));  
            BuildSingleCalendar(pnlCalendar3, _currentCalendarMonth.AddMonths(2));  
            BuildSingleCalendar(pnlCalendar4, _currentCalendarMonth.AddMonths(3));  
        }

        // ──────────────────────────────────────────
        //  MAIN LOAD
        // ──────────────────────────────────────────
        private void LoadDashboard()
        {
            LoadDailyQuote();

            var userName = _dataService.LoadUserName();
            lblTitle.Text = string.IsNullOrEmpty(userName)
                ? "My Habit Dashboard"
                : $"👋 Welcome back, {userName}!";

            var habits = _dataService.LoadHabits();
            var allLogs = _dataService.LoadLogs();
            var todayLogs = allLogs
                .Where(l => l.LogDate.Date == DateTime.Today)
                .ToList();

            lblTotalCount.Text = habits.Count.ToString();

            int doneToday = todayLogs.Count(l =>
                l.IsCompleted ||
                IsQuantitativeComplete(l, habits));
            lblDoneCount.Text = doneToday.ToString();

            int bestStreak = habits.Count > 0
                ? habits.Max(h => CalculateStreak(h.HabitID, allLogs))
                : 0;
            lblStreakCount.Text = bestStreak.ToString() + " 🔥";

            BuildHabitCards(habits, allLogs, todayLogs);
            BuildWeeklyChart(allLogs, habits);
        }

        // ──────────────────────────────────────────
        //  BUILD HABIT CARDS (WITH ROUNDED EDGES)
        // ──────────────────────────────────────────
        private void BuildHabitCards(List<Habit> habits, List<HabitLog> allLogs, List<HabitLog> todayLogs)
        {
            pnlCards.Controls.Clear();
            if (habits.Count == 0) return;

            int yPos = 10;
            foreach (var habit in habits)
            {
                var todayLog = todayLogs.FirstOrDefault(l => l.HabitID == habit.HabitID);
                int streak = CalculateStreak(habit.HabitID, allLogs);
                bool isDoneToday = todayLog != null && (todayLog.IsCompleted || IsQuantitativeComplete(todayLog, new List<Habit> { habit }));

                var card = new Panel
                {
                    Location = new Point(8, yPos),
                    Size = new Size(pnlCards.Width - 30, 120),
                    BackColor = isDoneToday ? ThemeManager.AccentGreenBg : ThemeManager.CardBg
                };

                var accent = new Panel { Location = new Point(0, 0), Size = new Size(4, card.Height), BackColor = habit.Intent == Intent.Build ? ThemeManager.AccentGreen : ThemeManager.AccentRed };
                var badge = new Label { Text = habit.Category.ToString().ToUpper(), BackColor = ThemeManager.SurfaceBg, ForeColor = ThemeManager.TextSecondary, Font = ThemeManager.FontBadge, Location = new Point(14, 10), Size = new Size(70, 18), TextAlign = ContentAlignment.MiddleCenter };
                var lblName = new Label { Text = habit.HabitName, Font = ThemeManager.FontBold, ForeColor = ThemeManager.TextPrimary, BackColor = Color.Transparent, Location = new Point(90, 8), Size = new Size(250, 22) };
                var lblDetails = new Label { Text = $"{habit.GoalPeriod} | {habit.TimeRange} | Ends: {habit.EndDate:MMM dd}", ForeColor = ThemeManager.TextSecondary, BackColor = Color.Transparent, Font = ThemeManager.FontSmall, Location = new Point(90, 30), Size = new Size(300, 18) };
                var lblStreak = new Label { Text = $"🔥 {streak} day streak", Font = ThemeManager.FontSmall, ForeColor = streak > 0 ? ThemeManager.AccentAmber : ThemeManager.TextMuted, BackColor = Color.Transparent, Location = new Point(90, 50), Size = new Size(200, 18) };

                card.Controls.Add(accent);
                card.Controls.Add(badge);
                card.Controls.Add(lblName);
                card.Controls.Add(lblDetails);
                card.Controls.Add(lblStreak);

                if (habit.TrackingType == TrackingType.Binary)
                {
                    var chkDone = new CheckBox
                    {
                        Text = "Done Today",
                        Checked = isDoneToday,
                        Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                        ForeColor = isDoneToday ? ThemeManager.AccentGreen : ThemeManager.TextPrimary,
                        Location = new Point(card.Width - 130, 45),
                        Size = new Size(110, 24),
                        Cursor = Cursors.Hand
                    };

                    chkDone.Click += (s, ev) => { QuickLogBinary(habit, chkDone.Checked); };
                    card.Controls.Add(chkDone);
                }
                else
                {
                    int pct = todayLog != null && habit.TargetAmount > 0 ? (int)Math.Min((todayLog.AmountLogged / habit.TargetAmount) * 100, 100) : 0;
                    var pbOuter = new Panel { Location = new Point(90, 80), Size = new Size(200, 8), BackColor = ThemeManager.SurfaceBg };
                    pbOuter.Controls.Add(new Panel { Location = new Point(0, 0), Size = new Size((int)(200 * pct / 100.0), 8), BackColor = ThemeManager.AccentGreen });
                    var lblProgress = new Label { Text = $"{pct}% ({todayLog?.AmountLogged ?? 0}/{habit.TargetAmount} {habit.Unit})", Font = new Font("Segoe UI", 8f), ForeColor = ThemeManager.TextSecondary, Location = new Point(300, 75), Size = new Size(150, 16) };

                    card.Controls.Add(pbOuter);
                    card.Controls.Add(lblProgress);
                }

                MakeRounded(card, 15);

                pnlCards.Controls.Add(card);
                yPos += 130;
            }
        }

        private void QuickLogBinary(Habit habit, bool isCompleted)
        {
            var allLogs = _dataService.LoadLogs();
            var todayLog = allLogs.FirstOrDefault(l => l.HabitID == habit.HabitID && l.LogDate.Date == DateTime.Today);

            if (todayLog != null)
            {
                todayLog.IsCompleted = isCompleted;
                _dataService.UpdateLog(todayLog);
            }
            else
            {
                _dataService.SaveLog(new HabitLog
                {
                    LogID = Guid.NewGuid().ToString(),
                    HabitID = habit.HabitID,
                    LogDate = DateTime.Today,
                    IsCompleted = isCompleted,
                    AmountLogged = isCompleted ? 1 : 0,
                    Notes = "Quick logged from Dashboard"
                });
            }
            LoadDashboard();
        }

        private int CalculateStreak(string habitId, List<HabitLog> allLogs)
        {
            var logs = allLogs.Where(l => l.HabitID == habitId).OrderByDescending(l => l.LogDate).ToList();
            int streak = 0;
            DateTime checkDate = DateTime.Today;

            foreach (var log in logs)
            {
                if (log.LogDate.Date == checkDate)
                {
                    if (log.IsCompleted || log.AmountLogged > 0)
                    {
                        streak++;
                        checkDate = checkDate.AddDays(-1);
                    }
                    else break;
                }
                else if (log.LogDate.Date < checkDate) break;
            }
            return streak;
        }

        private void BuildWeeklyChart(List<HabitLog> allLogs, List<Habit> habits)
        {
            chartWeekly.Series.Clear();
            chartWeekly.ChartAreas.Clear();
            chartWeekly.Legends.Clear();
            chartWeekly.Titles.Clear();

            var chartArea = new ChartArea("main");
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(230, 230, 230);
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartArea.AxisY.Title = "Completion %";
            chartArea.AxisX.Title = "Day";
            chartArea.AxisY.TitleFont = new Font("Segoe UI", 8f);
            chartArea.AxisX.TitleFont = new Font("Segoe UI", 8f);
            chartWeekly.ChartAreas.Add(chartArea);
            chartArea.BackColor = ThemeManager.CardBg;
            chartArea.BackSecondaryColor = ThemeManager.CardBg;
            chartArea.AxisX.LabelStyle.ForeColor = ThemeManager.TextSecondary;
            chartArea.AxisY.LabelStyle.ForeColor = ThemeManager.TextSecondary;
            chartArea.AxisX.TitleForeColor = ThemeManager.TextSecondary;
            chartArea.AxisY.TitleForeColor = ThemeManager.TextSecondary;
            chartArea.AxisX.LineColor = ThemeManager.BorderColor;
            chartArea.AxisY.LineColor = ThemeManager.BorderColor;
            chartArea.AxisX.MajorTickMark.LineColor = ThemeManager.BorderColor;
            chartArea.AxisY.MajorTickMark.LineColor = ThemeManager.BorderColor;

            chartWeekly.Titles.Add(new Title
            {
                Text = "📈 Weekly Completion Rate (Last 7 Days)",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = ThemeManager.TextPrimary
            });

            var series = new Series("Completion")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "main",
                IsValueShownAsLabel = true,
                LabelFormat = "{0}%",
                Font = new Font("Segoe UI", 7f)
            };

            for (int i = 6; i >= 0; i--)
            {
                DateTime day = DateTime.Today.AddDays(-i);
                string dayLabel = day.ToString("ddd\nMMM d");

                var dayLogs = allLogs.Where(l => l.LogDate.Date == day.Date).ToList();
                double rate = 0;

                if (habits.Count > 0 && dayLogs.Count > 0)
                {
                    int completed = dayLogs.Count(l =>
                    {
                        var h = habits.FirstOrDefault(x => x.HabitID == l.HabitID);
                        if (h == null) return false;
                        if (h.TrackingType == TrackingType.Binary) return l.IsCompleted;
                        return l.AmountLogged >= h.TargetAmount;
                    });
                    rate = Math.Round((completed / (double)habits.Count) * 100, 0);
                }

                var point = series.Points.Add(rate);
                point.AxisLabel = dayLabel;

                if (rate >= 80) point.Color = Color.FromArgb(76, 175, 80);
                else if (rate >= 50) point.Color = Color.FromArgb(255, 152, 0);
                else if (rate > 0) point.Color = Color.FromArgb(244, 67, 54);
                else point.Color = Color.FromArgb(200, 200, 200);
            }

            chartWeekly.Series.Add(series);

            var legend = new Legend
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 8f),
                BackColor = ThemeManager.CardBg,
                ForeColor = ThemeManager.TextSecondary
            };
            chartWeekly.Legends.Add(legend);
        }

        private bool IsQuantitativeComplete(HabitLog log, List<Habit> habits)
        {
            var habit = habits.FirstOrDefault(h => h.HabitID == log.HabitID);
            if (habit == null) return false;
            if (habit.TrackingType != TrackingType.Quantitative) return false;
            return log.AmountLogged >= habit.TargetAmount;
        }

        private void pnlCards_Paint(object sender, PaintEventArgs e) { }
        private void chartWeekly_Click(object sender, EventArgs e) { }

        // ──────────────────────────────────────────
        //  MOTIVATIONAL QUOTES
        // ──────────────────────────────────────────
        private static readonly string[] Quotes = new string[]
        {
            "The secret of getting ahead is getting started. — Mark Twain",
            "Small daily improvements are the key to staggering long-term results.",
            "You don't have to be great to start, but you have to start to be great.",
            "Success is the sum of small efforts repeated day in and day out. — R. Collier",
            "Motivation is what gets you started. Habit is what keeps you going.",
            "The only bad workout is the one that didn't happen.",
            "Don't watch the clock; do what it does. Keep going. — Sam Levenson",
            "A year from now you may wish you had started today. — Karen Lamb",
            "Your habits will determine your future. — Jack Canfield",
            "We are what we repeatedly do. Excellence is not an act but a habit. — Aristotle"
        };

        private void LoadDailyQuote()
        {
            int index = DateTime.Today.DayOfYear % Quotes.Length;
            string quote = Quotes[index];
            int dashIndex = quote.LastIndexOf("—");
            if (dashIndex > 0)
            {
                string text = quote.Substring(0, dashIndex).Trim();
                string author = quote.Substring(dashIndex).Trim();
                lblQuote.Text = $"\"{text}\" {author}";
            }
            else
            {
                lblQuote.Text = $"\"{quote}\"";
            }
        }

        // ──────────────────────────────────────────
        //  CUSTOM DYNAMIC CALENDAR (4-MONTH GRID)
        // ──────────────────────────────────────────
        private void BuildSingleCalendar(Panel pnl, DateTime month)
        {
            pnl.Controls.Clear();
            pnl.BackColor = ThemeManager.CardBg;

            // 1. Add Month Label
            var lblMonth = new Label
            {
                Text = month.ToString("MMMM yyyy"),
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = ThemeManager.TextPrimary,
                Location = new Point(15, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            pnl.Controls.Add(lblMonth);

            int buttonSize = 25;
            int spacing = 4;
            int xOffset = 26;
            int yOffset = 65;

            // 2. Weekday Labels (Size 10, Monday to Sunday)
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (int i = 0; i < 7; i++)
            {
                var lblDay = new Label
                {
                    Text = days[i],
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = ThemeManager.TextSecondary,
                    Location = new Point(xOffset + (i * (buttonSize + spacing)) - 3, 40),
                    Size = new Size(buttonSize + 6, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = Color.Transparent
                };
                pnl.Controls.Add(lblDay);
            }

            // 3. Grid Logic
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            DateTime firstDayOfMonth = new DateTime(month.Year, month.Month, 1);

            int startDayOfWeek = (int)firstDayOfMonth.DayOfWeek;
            int adjustedStartDay = (startDayOfWeek == 0) ? 6 : startDayOfWeek - 1;

            var habits = _dataService.LoadHabits();
            var allLogs = _dataService.LoadLogs();

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime currentDate = new DateTime(month.Year, month.Month, day);

                int row = (day + adjustedStartDay - 1) / 7;
                int col = (day + adjustedStartDay - 1) % 7;

                Button btnDay = new Button
                {
                    Text = "", 
                    Size = new Size(buttonSize, buttonSize),
                    Location = new Point(xOffset + (col * (buttonSize + spacing)), yOffset + (row * (buttonSize + spacing))),
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = currentDate
                };
                btnDay.FlatAppearance.BorderSize = 0;

                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(btnDay, currentDate.ToString("MMMM dd, yyyy"));

                var dayLogs = allLogs.Where(l => l.LogDate.Date == currentDate.Date).ToList();
                int completedCount = 0;
                foreach (var habit in habits)
                {
                    var log = dayLogs.FirstOrDefault(l => l.HabitID == habit.HabitID);
                    if (log != null)
                    {
                        if (habit.TrackingType == TrackingType.Binary && log.IsCompleted) completedCount++;
                        else if (habit.TrackingType == TrackingType.Quantitative && log.AmountLogged >= habit.TargetAmount) completedCount++;
                    }
                }

                if (habits.Count > 0 && completedCount == habits.Count)
                {
                    btnDay.BackColor = ThemeManager.AccentGreen;
                }
                else
                {
                    btnDay.BackColor = ThemeManager.SurfaceBg;
                }

                MakeRounded(btnDay, 15);

                btnDay.Click += CalendarDay_Click;
                pnl.Controls.Add(btnDay);
            }

            MakeRounded(pnl, 15);
        }

        private void CalendarDay_Click(object sender, EventArgs e)
        {
            Button clickedBtn = sender as Button;
            if (clickedBtn == null || clickedBtn.Tag == null) return;

            DateTime selectedDate = (DateTime)clickedBtn.Tag;

            var habits = _dataService.LoadHabits();
            var allLogs = _dataService.LoadLogs();
            var dayLogs = allLogs.Where(l => l.LogDate.Date == selectedDate.Date).ToList();

            if (dayLogs.Count == 0)
            {
                MessageBox.Show($"No habits logged on {selectedDate:MMMM dd, yyyy}.", "Daily Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string summary = $"Habits for {selectedDate:MMMM dd, yyyy}:\n\n";

            foreach (var log in dayLogs)
            {
                var habit = habits.FirstOrDefault(h => h.HabitID == log.HabitID);
                if (habit == null) continue;

                bool isDone = false;
                string detail = "";

                if (habit.TrackingType == TrackingType.Binary)
                {
                    isDone = log.IsCompleted;
                    detail = isDone ? "Done" : "Missed";
                }
                else
                {
                    isDone = log.AmountLogged >= habit.TargetAmount;
                    detail = $"{log.AmountLogged} / {habit.TargetAmount} {habit.Unit}";
                }

                string icon = isDone ? "✅" : "❌";
                summary += $"{icon} {habit.HabitName} ({detail})\n";
            }

            MessageBox.Show(summary, "Daily Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ──────────────────────────────────────────
        //  THEMING AND ROUNDING
        // ──────────────────────────────────────────
        private void ApplyTheme()
        {
            this.BackColor = ThemeManager.PageBg;

            lblTitle.ForeColor = ThemeManager.TextPrimary;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = ThemeManager.FontTitle;
            lblToday.ForeColor = ThemeManager.TextSecondary;
            lblToday.BackColor = Color.Transparent;
            lblToday.Font = ThemeManager.FontBody;

            pnlLine.BackColor = ThemeManager.BorderColor;

            StyleStatCard(pnlTotalHabits, lblTotalCount, lblTotalLabel);
            StyleStatCard(pnlCompletedToday, lblDoneCount, lblDoneLabel);
            StyleStatCard(pnlBestStreak, lblStreakCount, lblStreakLabel);

            lblDoneCount.ForeColor = ThemeManager.AccentGreen;
            lblStreakCount.ForeColor = ThemeManager.AccentAmber;

            pnlCards.BackColor = ThemeManager.PageBg;
            pnlCards.BorderStyle = BorderStyle.None;

            chartWeekly.BackColor = ThemeManager.CardBg;
            chartWeekly.BorderlineColor = ThemeManager.CardBg;

            pnlQuote.BackColor = Color.FromArgb(20, 50, 80);
            pnlQuote.BorderStyle = BorderStyle.None;

            MakeRounded(pnlQuote, 10);

            var accent = new Panel { Location = new Point(0, 0), Size = new Size(4, pnlQuote.Height), BackColor = ThemeManager.AccentGreen };
            pnlQuote.Controls.Add(accent);

            lblQuoteIcon.ForeColor = ThemeManager.AccentGreen;
            lblQuoteIcon.BackColor = Color.Transparent;
            lblQuoteIcon.Font = new Font("Segoe UI", 20f, FontStyle.Bold);

            lblQuote.ForeColor = ThemeManager.TextSecondary;
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);
        }

        private void StyleStatCard(Panel card, Label numLabel, Label textLabel)
        {
            card.BackColor = ThemeManager.CardBg;
            card.BorderStyle = BorderStyle.None;

            MakeRounded(card, 12);

            numLabel.ForeColor = ThemeManager.TextPrimary;
            numLabel.BackColor = Color.Transparent;
            numLabel.Font = new Font("Segoe UI", 22f, FontStyle.Bold);

            textLabel.ForeColor = ThemeManager.TextSecondary;
            textLabel.BackColor = Color.Transparent;
            textLabel.Font = ThemeManager.FontSmall;
        }

        private void MakeRounded(Control ctrl, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(ctrl.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(ctrl.Width - radius * 2, ctrl.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, ctrl.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            ctrl.Region = new Region(path);
        }
    }
}