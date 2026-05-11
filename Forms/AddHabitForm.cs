using AOOP_HABI.Models;
using AOOP_HABI.Services;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace AOOP_HABI.Forms
{
    public partial class AddHabitForm : Form
    {
        private CsvDataService _dataService;

        public AddHabitForm()
        {
            InitializeComponent();
            ApplyTheme();

            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
            {
                _dataService = new CsvDataService();
            }

            rbQuantitative.CheckedChanged += TrackingType_CheckedChanged;
            rbBinary.CheckedChanged += TrackingType_CheckedChanged;

            ToggleQuantitativeFields();
        }

        private void TrackingType_CheckedChanged(object sender, EventArgs e)
        {
            ToggleQuantitativeFields();
        }

        private void ToggleQuantitativeFields()
        {
            bool isQuant = rbQuantitative.Checked;
            lblTarget.Visible = isQuant;
            nudTarget.Visible = isQuant;
            lblUnit.Visible = isQuant;
            txtUnit.Visible = isQuant;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validate Form
                if (string.IsNullOrWhiteSpace(txtHabitName.Text))
                {
                    MessageBox.Show("Please enter a habit name.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbBuild.Checked && !rbBreak.Checked)
                {
                    MessageBox.Show("Please select whether to Build or Break a habit.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!rbBinary.Checked && !rbQuantitative.Checked)
                {
                    MessageBox.Show("Please select a tracking method.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rbQuantitative.Checked && string.IsNullOrWhiteSpace(txtUnit.Text))
                {
                    MessageBox.Show("Please enter a unit (e.g. glasses, pages).", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbCategory.SelectedItem == null || cmbPeriod.SelectedItem == null || cmbTimeRange.SelectedItem == null)
                {
                    MessageBox.Show("Please select a Category, Goal Period, and Time Range.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Build the new Habit object
                var habit = new Habit
                {
                    HabitID = Guid.NewGuid().ToString(),
                    HabitName = txtHabitName.Text.Trim(),
                    Intent = rbBuild.Checked ? Intent.Build : Intent.Break,
                    TrackingType = rbBinary.Checked ? TrackingType.Binary : TrackingType.Quantitative,
                    TargetAmount = rbQuantitative.Checked ? (double)nudTarget.Value : 0,
                    Unit = rbQuantitative.Checked ? txtUnit.Text.Trim() : "",
                    DateCreated = DateTime.Today,
                    Category = (HabitCategory)cmbCategory.SelectedItem,
                    GoalPeriod = (GoalPeriod)cmbPeriod.SelectedItem,
                    TimeRange = (TimeRange)cmbTimeRange.SelectedItem,
                    StartDate = dtpStart.Value.Date,
                    EndDate = dtpEnd.Value.Date
                };

                // 3. Save
                _dataService.SaveHabit(habit);

                MessageBox.Show($"✅ Habit '{habit.HabitName}' saved successfully!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Whoops! Something went wrong:\n\n{ex.Message}", "Error Saving",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Theme ──────────────────────────────────────────────────────────────
        private void ApplyTheme()
        {
            ThemeManager.MakeRounded(btnSave, 10);

            if (cmbCategory != null) ThemeManager.StyleComboBox(cmbCategory);
            if (cmbPeriod != null) ThemeManager.StyleComboBox(cmbPeriod);
            if (cmbTimeRange != null) ThemeManager.StyleComboBox(cmbTimeRange);
        }

        private void AddHabitForm_Load(object sender, EventArgs e)
        {
            cmbCategory.DataSource = Enum.GetValues(typeof(HabitCategory));
            cmbPeriod.DataSource = Enum.GetValues(typeof(GoalPeriod));
            cmbTimeRange.DataSource = Enum.GetValues(typeof(TimeRange));
        }

        private void label10_Click(object sender, EventArgs e) { }
        private void label13_Click(object sender, EventArgs e) { }
    }
}