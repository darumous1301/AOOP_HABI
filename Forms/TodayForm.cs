using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AOOP_HABI.Models;
using AOOP_HABI.Services;

namespace AOOP_HABI.Forms
{
    public partial class TodayForm : Form
    {
        private readonly CsvDataService _dataService = new CsvDataService();
        private List<Habit> _habits = new List<Habit>();
        private List<HabitLog> _todayLogs = new List<HabitLog>();

        private Dictionary<string, CheckBox> _binaryControls = new Dictionary<string, CheckBox>();
        private Dictionary<string, NumericUpDown> _quantControls = new Dictionary<string, NumericUpDown>();
        private Dictionary<string, TextBox> _notesControls = new Dictionary<string, TextBox>();

        private string _selectedHabitId = null;

        public TodayForm()
        {
            InitializeComponent();
            ApplyTheme();
            lblDate.Text = "Today - " + DateTime.Today.ToString("MMMM dd, yyyy");
        }

        private void TodayForm_Load(object sender, EventArgs e)
        {
            LoadTodayHabits();
        }

        // ──────────────────────────────────────────
        //  LOAD HABITS AND BUILD UI CARDS
        // ──────────────────────────────────────────
        private void LoadTodayHabits()
        {
            pnlHabits.Controls.Clear();
            _binaryControls.Clear();
            _quantControls.Clear();
            _notesControls.Clear();
            _selectedHabitId = null;

            _habits = _dataService.LoadHabits();
            var allLogs = _dataService.LoadLogs();

            _todayLogs = allLogs.FindAll(l => l.LogDate.Date == DateTime.Today);

            if (_habits.Count == 0)
            {
                var lbl = new Label
                {
                    Text = "No habits yet. Click '+ Add Habit' to get started!",
                    ForeColor = Color.Gray,
                    Location = new Point(10, 10),
                    Size = new Size(400, 30)
                };
                pnlHabits.Controls.Add(lbl);
                return;
            }

            int yPos = 10;

            foreach (var habit in _habits)
            {
                var existingLog = _todayLogs.Find(l => l.HabitID == habit.HabitID);
                int streak = CalculateStreak(habit.HabitID, allLogs);

                // ── Card ──
                var card = new Panel
                {
                    Location = new Point(8, yPos),
                    Size = new Size(pnlHabits.Width - 35, 130),
                    BackColor = ThemeManager.CardBg,
                    Cursor = Cursors.Hand,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                // ── Left accent ──
                var accent = new Panel
                {
                    Location = new Point(0, 0),
                    Size = new Size(4, card.Height),
                    BackColor = habit.Intent == Intent.Build ? ThemeManager.AccentGreen : ThemeManager.AccentRed
                };
                card.Controls.Add(accent);

                // ── Category Badge ──
                var badge = new Label
                {
                    Text = habit.Category.ToString().ToUpper(),
                    BackColor = ThemeManager.SurfaceBg,
                    ForeColor = ThemeManager.TextSecondary,
                    Font = ThemeManager.FontBadge,
                    Location = new Point(14, 10),
                    Size = new Size(70, 18),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Cursor = Cursors.Hand
                };

                // ── Habit Name ──
                var lblName = new Label
                {
                    Text = habit.HabitName,
                    Font = ThemeManager.FontBold,
                    ForeColor = ThemeManager.TextPrimary,
                    BackColor = Color.Transparent,
                    Location = new Point(90, 8),
                    Size = new Size(400, 22),
                    Cursor = Cursors.Hand
                };

                // ── Details ──
                var lblDetails = new Label
                {
                    Text = $"{habit.GoalPeriod} | {habit.TimeRange} | Ends: {habit.EndDate:MMM dd}",
                    ForeColor = ThemeManager.TextSecondary,
                    BackColor = Color.Transparent,
                    Font = ThemeManager.FontSmall,
                    Location = new Point(90, 30),
                    Size = new Size(400, 18),
                    Cursor = Cursors.Hand
                };

                // ── Streak ──
                var lblStreak = new Label
                {
                    Text = $"🔥 {streak} day streak",
                    Font = ThemeManager.FontSmall,
                    ForeColor = streak > 0 ? ThemeManager.AccentAmber : ThemeManager.TextMuted,
                    BackColor = Color.Transparent,
                    Location = new Point(90, 50),
                    Size = new Size(200, 18),
                    Cursor = Cursors.Hand
                };

                // ── Notes Section ──
                var lblNote = new Label
                {
                    Text = "Note:",
                    Font = ThemeManager.FontSmall,
                    ForeColor = ThemeManager.TextMuted,
                    BackColor = Color.Transparent,
                    Location = new Point(90, 80),
                    Size = new Size(38, 20)
                };

                var txtNotes = new TextBox
                {
                    Location = new Point(135, 78),
                    Size = new Size(card.Width - 300, 22),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = ThemeManager.SurfaceBg,
                    ForeColor = ThemeManager.TextPrimary,
                    Font = ThemeManager.FontSmall,
                    Text = existingLog?.Notes ?? "",
                    Name = "notes_" + habit.HabitID,
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                card.Controls.Add(lblNote);
                card.Controls.Add(txtNotes);
                _notesControls[habit.HabitID] = txtNotes;

                // ── Binary or Quantitative (Right-Aligned) ──
                if (habit.TrackingType == TrackingType.Binary)
                {
                    var chk = new CheckBox
                    {
                        Text = "Done",
                        Font = ThemeManager.FontBody,
                        ForeColor = ThemeManager.TextPrimary,
                        BackColor = Color.Transparent,
                        Location = new Point(card.Width - 110, 45),
                        Size = new Size(80, 24),
                        Checked = existingLog != null && existingLog.IsCompleted,
                        Cursor = Cursors.Hand,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };
                    card.Controls.Add(chk);
                    _binaryControls[habit.HabitID] = chk;
                }
                else
                {
                    var lblUnit = new Label
                    {
                        Text = habit.Unit,
                        ForeColor = ThemeManager.TextSecondary,
                        BackColor = Color.Transparent,
                        Font = ThemeManager.FontSmall,
                        Location = new Point(card.Width - 130, 30),
                        Size = new Size(110, 18),
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };
                    var nud = new NumericUpDown
                    {
                        Minimum = 0,
                        Maximum = 9999,
                        Value = existingLog != null ? (decimal)existingLog.AmountLogged : 0,
                        Location = new Point(card.Width - 130, 50),
                        Size = new Size(100, 24),
                        BackColor = ThemeManager.SurfaceBg,
                        ForeColor = ThemeManager.TextPrimary,
                        BorderStyle = BorderStyle.None,
                        Anchor = AnchorStyles.Top | AnchorStyles.Right
                    };
                    card.Controls.Add(lblUnit);
                    card.Controls.Add(nud);
                    _quantControls[habit.HabitID] = nud;
                }

                card.Controls.Add(badge);
                card.Controls.Add(lblName);
                card.Controls.Add(lblDetails);
                card.Controls.Add(lblStreak);

                // ── SELECTION EVENT WIRING ──
                EventHandler selectAction = (s, ev) => SelectCard(card, habit.HabitID);
                card.Click += selectAction;
                lblName.Click += selectAction;
                lblDetails.Click += selectAction;
                lblStreak.Click += selectAction;
                badge.Click += selectAction;

                // ── Context Menu ──
                var ctx = new ContextMenuStrip();
                var mEdit = new ToolStripMenuItem("✏️ Edit Habit") { Tag = habit };
                mEdit.Click += (s, ev) =>
                {
                    var h = (Habit)((ToolStripMenuItem)s).Tag;
                    if (new EditHabitForm(h).ShowDialog() == DialogResult.OK)
                        LoadTodayHabits();
                };
                var mDelete = new ToolStripMenuItem("🗑️ Delete Habit")
                {
                    Tag = habit,
                    ForeColor = Color.FromArgb(244, 67, 54)
                };
                mDelete.Click += (s, ev) =>
                {
                    var h = (Habit)((ToolStripMenuItem)s).Tag;
                    if (MessageBox.Show($"Delete '{h.HabitName}'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        _dataService.DeleteHabitAndLogs(h.HabitID);
                        LoadTodayHabits();
                    }
                };
                ctx.Items.Add(mEdit);
                ctx.Items.Add(new ToolStripSeparator());
                ctx.Items.Add(mDelete);
                card.ContextMenuStrip = ctx;

                pnlHabits.Controls.Add(card);
                yPos += 140;
            }
        }

        // ──────────────────────────────────────────
        //  SELECTION LOGIC
        // ──────────────────────────────────────────
        private void SelectCard(Panel selectedCard, string habitId)
        {
            foreach (Control ctrl in pnlHabits.Controls)
            {
                if (ctrl is Panel pnl)
                    pnl.BackColor = ThemeManager.CardBg;
            }
            selectedCard.BackColor = ThemeManager.SurfaceBg;
            _selectedHabitId = habitId;
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

        // ──────────────────────────────────────────
        //  BOTTOM BUTTON ACTIONS
        // ──────────────────────────────────────────
        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            var allLogs = _dataService.LoadLogs();
            int saved = 0;
            int updated = 0;

            foreach (var habit in _habits)
            {
                var existingLog = _todayLogs.Find(l => l.HabitID == habit.HabitID);

                if (habit.TrackingType == TrackingType.Binary)
                {
                    bool isChecked = _binaryControls[habit.HabitID].Checked;

                    if (existingLog != null)
                    {
                        existingLog.IsCompleted = isChecked;
                        existingLog.Notes = _notesControls.ContainsKey(habit.HabitID) ? _notesControls[habit.HabitID].Text.Trim() : existingLog.Notes;
                        _dataService.UpdateLog(existingLog);
                        updated++;
                    }
                    else
                    {
                        _dataService.SaveLog(new HabitLog
                        {
                            LogID = Guid.NewGuid().ToString(),
                            HabitID = habit.HabitID,
                            LogDate = DateTime.Today,
                            IsCompleted = isChecked,
                            AmountLogged = 0,
                            Notes = _notesControls.ContainsKey(habit.HabitID) ? _notesControls[habit.HabitID].Text.Trim() : ""
                        });
                        saved++;
                    }
                }
                else
                {
                    double amount = (double)_quantControls[habit.HabitID].Value;

                    if (existingLog != null)
                    {
                        existingLog.AmountLogged = amount;
                        existingLog.Notes = _notesControls.ContainsKey(habit.HabitID) ? _notesControls[habit.HabitID].Text.Trim() : existingLog.Notes;
                        _dataService.UpdateLog(existingLog);
                        updated++;
                    }
                    else
                    {
                        _dataService.SaveLog(new HabitLog
                        {
                            LogID = Guid.NewGuid().ToString(),
                            HabitID = habit.HabitID,
                            LogDate = DateTime.Today,
                            IsCompleted = false,
                            AmountLogged = amount,
                            Notes = _notesControls.ContainsKey(habit.HabitID) ? _notesControls[habit.HabitID].Text.Trim() : ""
                        });
                        saved++;
                    }
                }
            }

            MessageBox.Show($"✅ {saved} habit(s) logged, {updated} updated for today!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadTodayHabits();
        }

        private void btnAddHabit_Click(object sender, EventArgs e)
        {
            var addForm = new AddHabitForm();
            addForm.ShowDialog();
            LoadTodayHabits();
        }

        private void btnEditHabit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedHabitId))
            {
                MessageBox.Show("Please select a habit to edit by clicking its card first.", "Select a Habit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var habitToEdit = _habits.FirstOrDefault(h => h.HabitID == _selectedHabitId);
            if (habitToEdit != null)
            {
                if (new EditHabitForm(habitToEdit).ShowDialog() == DialogResult.OK)
                    LoadTodayHabits();
            }
        }

        private void btnDeleteHabit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedHabitId))
            {
                MessageBox.Show("Please select a habit to delete by clicking its card first.", "Select a Habit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var habitToDelete = _habits.FirstOrDefault(h => h.HabitID == _selectedHabitId);
            if (habitToDelete != null)
            {
                if (MessageBox.Show($"Are you sure you want to delete '{habitToDelete.HabitName}' and all its history?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    _dataService.DeleteHabitAndLogs(habitToDelete.HabitID);
                    LoadTodayHabits();
                }
            }
        }

        // ──────────────────────────────────────────
        //  THEME & STYLING
        // ──────────────────────────────────────────
        private void ApplyTheme()
        {
            this.BackColor = ThemeManager.PageBg;

            lblDate.ForeColor = ThemeManager.TextPrimary;
            lblDate.BackColor = Color.Transparent;
            lblDate.Font = ThemeManager.FontTitle;
            lblSubtitle.ForeColor = ThemeManager.TextSecondary;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = ThemeManager.FontBody;

            pnlLine.BackColor = ThemeManager.BorderColor;

            pnlHabits.BackColor = ThemeManager.PageBg;
            pnlHabits.BorderStyle = BorderStyle.None;

            ThemeManager.StyleButton(btnSaveAll, "primary");
            ThemeManager.StyleButton(btnAddHabit, "secondary");
            ThemeManager.StyleButton(btnEditHabit, "secondary");
            ThemeManager.StyleButton(btnDeleteHabit, "danger");

            MakeRounded(btnSaveAll, 10);
            MakeRounded(btnAddHabit, 10);
            MakeRounded(btnEditHabit, 10);
            MakeRounded(btnDeleteHabit, 10);
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