using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AOOP_HABI.Models;
using AOOP_HABI.Services;

namespace AOOP_HABI.Forms
{
    public partial class HistoryForm : Form
    {
        private readonly CsvDataService _dataService = new CsvDataService();
        private List<Habit> _habits = new List<Habit>();
        private List<HabitLog> _allLogs = new List<HabitLog>();

        public HistoryForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            LoadData();
            SetupGrid();
            PopulateFilter();
            DisplayLogs(_allLogs);
            PopulateHeatmapFilter();
            BuildHeatmap(_allLogs);
        }

        // Load data
        private void LoadData()
        {
            _habits = _dataService.LoadHabits();
            _allLogs = _dataService.LoadLogs();
        }

        // Setting up grid columns
        private void SetupGrid()
        {
            dgvLogs.Columns.Clear();
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colDate", HeaderText = "Date", DataPropertyName = "Date" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colHabit", HeaderText = "Habit", DataPropertyName = "Habit" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Category", DataPropertyName = "Category" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colFrequency", HeaderText = "Frequency", DataPropertyName = "Frequency" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colIntent", HeaderText = "Intent", DataPropertyName = "Intent" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colType", HeaderText = "Type", DataPropertyName = "Type" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colResult", HeaderText = "Result", DataPropertyName = "Result" });
            dgvLogs.Columns.Add(new DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Status", DataPropertyName = "Status" });

            dgvLogs.EnableHeadersVisualStyles = false;
            dgvLogs.RowHeadersVisible = false;

            dgvLogs.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.SurfaceBg;

            dgvLogs.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.NavBg;
            dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor = ThemeManager.TextSecondary;
            dgvLogs.ColumnHeadersDefaultCellStyle.Font = ThemeManager.FontBody;
        }

        // Populate dynamic filter dropdowns
        private void PopulateFilter()
        {
            cmbFilterType.Items.Clear();
            cmbFilterType.Items.Add("All Habits");
            cmbFilterType.Items.Add("Category");
            cmbFilterType.Items.Add("Intent");

            cmbFilterType.SelectedIndex = 0;
        }

        // Update secondary dropdown based on primary selection
        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFilterValue.Items.Clear();
            string selected = cmbFilterType.SelectedItem.ToString();

            if (selected == "All Habits")
            {
                cmbFilterValue.Enabled = false;
            }
            else if (selected == "Category")
            {
                cmbFilterValue.Enabled = true;
                foreach (var cat in Enum.GetValues(typeof(HabitCategory)))
                    cmbFilterValue.Items.Add(cat.ToString());
                if (cmbFilterValue.Items.Count > 0) cmbFilterValue.SelectedIndex = 0;
            }
            else if (selected == "Intent")
            {
                cmbFilterValue.Enabled = true;
                foreach (var intent in Enum.GetValues(typeof(Intent)))
                    cmbFilterValue.Items.Add(intent.ToString());
                if (cmbFilterValue.Items.Count > 0) cmbFilterValue.SelectedIndex = 0;
            }
        }

        // Display logs in grid
        private void DisplayLogs(List<HabitLog> logs)
        {
            dgvLogs.Rows.Clear();
            var sorted = logs.OrderByDescending(l => l.LogDate).ToList();

            foreach (var log in sorted)
            {
                var habit = _habits.FirstOrDefault(h => h.HabitID == log.HabitID);
                if (habit == null) continue;

                string result = habit.TrackingType == TrackingType.Binary
                    ? (log.IsCompleted ? "Completed" : "Not Completed")
                    : $"{log.AmountLogged} / {habit.TargetAmount} {habit.Unit}";

                string status = GetStatus(log, habit);

                int rowIndex = dgvLogs.Rows.Add(
                    log.LogDate.ToString("MMM dd, yyyy"),
                    habit.HabitName,
                    habit.Category.ToString(),
                    habit.GoalPeriod.ToString(),
                    habit.Intent.ToString(),
                    habit.TrackingType.ToString(),
                    result,
                    status
                );

                // Color code status column
                var statusCell = dgvLogs.Rows[rowIndex].Cells["colStatus"];
                if (status == "✅ Done")
                    statusCell.Style.ForeColor = Color.FromArgb(76, 175, 80);
                else if (status == "❌ Missed")
                    statusCell.Style.ForeColor = Color.FromArgb(244, 67, 54);
                else
                    statusCell.Style.ForeColor = Color.FromArgb(255, 152, 0);
            }

            UpdateSummary(logs);
        }

        // Status helper
        private string GetStatus(HabitLog log, Habit habit)
        {
            if (habit.TrackingType == TrackingType.Binary)
                return log.IsCompleted ? "✅ Done" : "❌ Missed";

            if (log.AmountLogged >= habit.TargetAmount)
                return "✅ Done";
            else if (log.AmountLogged > 0)
                return "⚠️ Partial";
            else
                return "❌ Missed";
        }

        // Summary bar
        private void UpdateSummary(List<HabitLog> logs)
        {
            if (logs.Count == 0)
            {
                lblSummary.Text = "No logs found for the selected filter.";
                return;
            }

            int total = logs.Count;
            int done = logs.Count(l =>
            {
                var h = _habits.FirstOrDefault(x => x.HabitID == l.HabitID);
                return h != null && GetStatus(l, h) == "✅ Done";
            });
            int missed = total - done;
            double rate = total > 0 ? Math.Round((done / (double)total) * 100, 1) : 0;

            lblSummary.Text =
                $"📊 Total Logs: {total}     " +
                $"✅ Completed: {done}     " +
                $"❌ Missed: {missed}     " +
                $"📈 Completion Rate: {rate}%";
        }

        // Filter logic using Category/Intent
        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterType = cmbFilterType.SelectedItem?.ToString();

            if (filterType == "All Habits" || string.IsNullOrEmpty(filterType))
            {
                DisplayLogs(_allLogs);
                return;
            }

            string filterValue = cmbFilterValue.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(filterValue)) return;

            var filtered = new List<HabitLog>();

            foreach (var log in _allLogs)
            {
                var habit = _habits.FirstOrDefault(h => h.HabitID == log.HabitID);
                if (habit == null) continue;

                if (filterType == "Category" && habit.Category.ToString() == filterValue)
                    filtered.Add(log);
                else if (filterType == "Intent" && habit.Intent.ToString() == filterValue)
                    filtered.Add(log);
            }

            DisplayLogs(filtered);
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            cmbFilterType.SelectedIndex = 0;
            DisplayLogs(_allLogs);
        }

        // ──────────────────────────────────────────
        //  EXPORT TO CSV
        // ──────────────────────────────────────────
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_allLogs.Count == 0)
            {
                MessageBox.Show("No logs to export yet.", "Nothing to Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Title = "Export Habit Logs",
                Filter = "CSV Files (*.csv)|*.csv",
                FileName = $"HabitLogs_{DateTime.Today:yyyy-MM-dd}.csv",
                DefaultExt = "csv"
            };

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                var lines = new List<string> { "Date,Habit Name,Category,Frequency,Intent,Tracking Type,Result,Status" };
                var sorted = _allLogs.OrderByDescending(l => l.LogDate).ToList();

                foreach (var log in sorted)
                {
                    var habit = _habits.FirstOrDefault(h => h.HabitID == log.HabitID);
                    if (habit == null) continue;

                    string result = habit.TrackingType == TrackingType.Binary
                        ? (log.IsCompleted ? "Completed" : "Not Completed")
                        : $"{log.AmountLogged}/{habit.TargetAmount} {habit.Unit}";

                    string status = GetStatus(log, habit).Replace("✅ ", "").Replace("❌ ", "").Replace("⚠️ ", "");

                    lines.Add(string.Join(",", new string[]
                    {
                        log.LogDate.ToString("yyyy-MM-dd"),
                        $"\"{habit.HabitName}\"",
                        habit.Category.ToString(),
                        habit.GoalPeriod.ToString(),
                        habit.Intent.ToString(),
                        habit.TrackingType.ToString(),
                        $"\"{result}\"",
                        status
                    }));
                }

                File.WriteAllLines(saveDialog.FileName, lines);
                MessageBox.Show($"✅ Successfully exported {sorted.Count} logs to:\n{saveDialog.FileName}", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ──────────────────────────────────────────
        //  HEATMAP LOGIC
        // ──────────────────────────────────────────
        private void PopulateHeatmapFilter()
        {
            cmbHeatmapHabit.Items.Clear();
            cmbHeatmapHabit.Items.Add("All Habits");
            foreach (var habit in _habits) cmbHeatmapHabit.Items.Add(habit.HabitName);
            cmbHeatmapHabit.SelectedIndex = 0;
        }

        private void BuildHeatmap(List<HabitLog> logs)
        {
            pnlHeatmap.Controls.Clear();
            int cellSize = 14, cellPadding = 3, totalSize = cellSize + cellPadding, weeks = 12;

            int heatmapContentWidth = 32 + (weeks * totalSize);
            int offsetX = (pnlHeatmap.Width - heatmapContentWidth) / 2;
            if (offsetX < 0) offsetX = 0;
            int offsetY = 20;

            string[] dayLabels = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };
            for (int d = 0; d < 7; d++)
            {
                var lbl = new Label
                {
                    Text = dayLabels[d],
                    Font = new Font("Segoe UI", 7f),
                    ForeColor = ThemeManager.TextSecondary,
                    BackColor = Color.Transparent,
                    Location = new Point(offsetX, offsetY + 18 + d * totalSize),
                    Size = new Size(28, cellSize)
                };
                pnlHeatmap.Controls.Add(lbl);
            }

            DateTime today = DateTime.Today;
            DateTime startDate = today.AddDays(-(weeks * 7));
            while (startDate.DayOfWeek != DayOfWeek.Monday) startDate = startDate.AddDays(-1);

            var logsByDate = logs.GroupBy(l => l.LogDate.Date).ToDictionary(g => g.Key, g => g.ToList());

            for (int w = 0; w < weeks; w++)
            {
                DateTime weekStart = startDate.AddDays(w * 7);
                if (w == 0 || weekStart.Day <= 7)
                {
                    var monthLbl = new Label
                    {
                        Text = weekStart.ToString("MMM"),
                        Font = new Font("Segoe UI", 7f),
                        ForeColor = ThemeManager.TextSecondary,
                        BackColor = Color.Transparent,
                        Location = new Point(offsetX + 32 + w * totalSize, offsetY),
                        Size = new Size(30, 14)
                    };
                    pnlHeatmap.Controls.Add(monthLbl);
                }

                for (int d = 0; d < 7; d++)
                {
                    DateTime cellDate = weekStart.AddDays(d);
                    if (cellDate > today) continue;

                    Color cellColor = GetHeatmapColor(cellDate, logsByDate);
                    var cell = new Panel
                    {
                        Location = new Point(offsetX + 32 + w * totalSize, offsetY + 18 + d * totalSize),
                        Size = new Size(cellSize, cellSize),
                        BackColor = cellColor,
                        Tag = cellDate
                    };

                    var toolTip = new ToolTip();
                    toolTip.SetToolTip(cell, GetHeatmapTooltip(cellDate, logsByDate));
                    pnlHeatmap.Controls.Add(cell);
                }
            }
            DrawHeatmapLegend(offsetY, totalSize);
        }

        private Color GetHeatmapColor(DateTime date, Dictionary<System.DateTime, List<HabitLog>> logsByDate)
        {
            if (!logsByDate.ContainsKey(date)) return ThemeManager.HeatNone;
            var dayLogs = logsByDate[date];
            int completed = dayLogs.Count(l => { var h = _habits.FirstOrDefault(x => x.HabitID == l.HabitID); return h != null && GetStatus(l, h) == "✅ Done"; });
            if (_habits.Count == 0) return ThemeManager.HeatNone;
            double rate = (double)completed / _habits.Count;
            if (rate >= 0.8) return ThemeManager.HeatHigh;
            else if (rate >= 0.6) return ThemeManager.HeatMid;
            else if (rate >= 0.4) return ThemeManager.HeatLow;
            else if (rate > 0) return Color.FromArgb(30, 58, 50);
            else return ThemeManager.HeatMissed;
        }

        private string GetHeatmapTooltip(DateTime date, Dictionary<System.DateTime, List<HabitLog>> logsByDate)
        {
            if (!logsByDate.ContainsKey(date)) return date.ToString("MMM dd, yyyy") + "\nNo logs";
            var dayLogs = logsByDate[date];
            int completed = dayLogs.Count(l => {
                var h = _habits.FirstOrDefault(x => x.HabitID == l.HabitID);
                if (h == null) return false;
                if (h.TrackingType == TrackingType.Binary) return l.IsCompleted;
                return l.AmountLogged >= h.TargetAmount;
            });
            return $"{date:MMM dd, yyyy}\n{completed}/{_habits.Count} habits completed";
        }

        private void DrawHeatmapLegend(int offsetY, int totalSize)
        {
            var legendColors = new[] { (ThemeManager.HeatNone, "None"), (ThemeManager.HeatLow, "Low"), (ThemeManager.HeatMid, "OK"), (ThemeManager.HeatHigh, "Great"), (ThemeManager.HeatMissed, "Missed") };

            int legendWidth = 28 + (5 * 18) + 28;
            int xPos = (pnlHeatmap.Width - legendWidth) / 2;
            int yPos = offsetY + 18 + (7 * totalSize) + 15; 

            var lblLess = new Label { Text = "Less", Font = new Font("Segoe UI", 7f), ForeColor = ThemeManager.TextSecondary, BackColor = Color.Transparent, Location = new Point(xPos, yPos + 1), Size = new Size(28, 14) };
            pnlHeatmap.Controls.Add(lblLess);

            xPos += 30;

            foreach (var (color, label) in legendColors)
            {
                var cell = new Panel { Location = new Point(xPos, yPos), Size = new Size(14, 14), BackColor = color };
                pnlHeatmap.Controls.Add(cell);
                xPos += 18;
            }
            var lblMore = new Label { Text = "More", Font = new Font("Segoe UI", 7f), ForeColor = ThemeManager.TextSecondary, BackColor = Color.Transparent, Location = new Point(xPos + 2, yPos + 1), Size = new Size(28, 14) };
            pnlHeatmap.Controls.Add(lblMore);
        }

        private void btnRefreshHeatmap_Click(object sender, EventArgs e)
        {
            if (cmbHeatmapHabit.SelectedIndex <= 0) { BuildHeatmap(_allLogs); return; }
            string selected = cmbHeatmapHabit.SelectedItem.ToString();
            var habit = _habits.FirstOrDefault(h => h.HabitName == selected);
            if (habit == null) return;
            var filtered = _allLogs.Where(l => l.HabitID == habit.HabitID).ToList();
            BuildHeatmap(filtered);
        }

        // ──────────────────────────────────────────
        //  THEMING
        // ──────────────────────────────────────────
        private void ApplyTheme()
        {
            this.BackColor = ThemeManager.PageBg;

            lblTitle.ForeColor = ThemeManager.TextPrimary;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = ThemeManager.FontTitle;
            lblSubtitle.ForeColor = ThemeManager.TextSecondary;
            lblSubtitle.BackColor = Color.Transparent;
            lblSubtitle.Font = ThemeManager.FontBody;

            pnlLine.BackColor = ThemeManager.BorderColor;

            ThemeManager.StyleComboBox(cmbFilterType);
            ThemeManager.StyleComboBox(cmbFilterValue);

            ThemeManager.StyleButton(btnFilter, "secondary");
            ThemeManager.StyleButton(btnClearFIlter, "secondary");
            ThemeManager.StyleButton(btnExport, "blue");
            ThemeManager.MakeRounded(btnFilter, 8);
            ThemeManager.MakeRounded(btnClearFIlter, 8);
            ThemeManager.MakeRounded(btnExport, 8);

            ThemeManager.StyleDataGridView(dgvLogs);

            pnlSummary.BackColor = ThemeManager.CardBg;
            pnlSummary.BorderStyle = BorderStyle.None;
            lblSummary.ForeColor = ThemeManager.TextSecondary;
            lblSummary.BackColor = Color.Transparent;
            lblSummary.Font = ThemeManager.FontBody;
            ThemeManager.MakeRounded(pnlSummary, 10);

            lblHeatmapTitle.ForeColor = ThemeManager.TextPrimary;
            lblHeatmapTitle.BackColor = Color.Transparent;
            lblHeatmapTitle.Font = ThemeManager.FontBold;

            ThemeManager.StyleComboBox(cmbHeatmapHabit);
            ThemeManager.StyleButton(btnRefreshHeatmap, "secondary");
            ThemeManager.MakeRounded(btnRefreshHeatmap, 8);

            pnlHeatmap.BackColor = ThemeManager.CardBg;
            pnlHeatmap.BorderStyle = BorderStyle.None;
            ThemeManager.MakeRounded(pnlHeatmap, 10);
        }

        private void lblSummary_Click(object sender, EventArgs e) { }
    }
}