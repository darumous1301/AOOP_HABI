using AOOP_HABI.Models;
using AOOP_HABI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AOOP_HABI.Forms
{
    public partial class EditHabitForm : Form
    {
        private readonly CsvDataService _dataService = new CsvDataService();
        private Habit _habit;

        public EditHabitForm(Habit habit)
        {
            InitializeComponent();
            _habit = habit;
            ApplyTheme();

            rbQuantitative.CheckedChanged += TrackingType_CheckedChanged;
            rbBinary.CheckedChanged += TrackingType_CheckedChanged;

            LoadHabitData();
        }

        private void LoadHabitData()
        {
            cmbCategory.DataSource = Enum.GetValues(typeof(HabitCategory));
            cmbPeriod.DataSource = Enum.GetValues(typeof(GoalPeriod));
            cmbTimeRange.DataSource = Enum.GetValues(typeof(TimeRange));

            // Load basic info
            txtHabitName.Text = _habit.HabitName;

            // Load intent
            if (_habit.Intent == Intent.Build) rbBuild.Checked = true;
            else rbBreak.Checked = true;

            // Load tracking type
            if (_habit.TrackingType == TrackingType.Binary) rbBinary.Checked = true;
            else rbQuantitative.Checked = true;

            // Load target and unit
            nudTarget.Value = _habit.TargetAmount > 0 ? (decimal)_habit.TargetAmount : 1;
            txtUnit.Text = _habit.Unit;

            // Load enums
            cmbCategory.SelectedItem = _habit.Category;
            cmbPeriod.SelectedItem = _habit.GoalPeriod;
            cmbTimeRange.SelectedItem = _habit.TimeRange;

            // Load dates safely
            if (_habit.StartDate >= dtpStart.MinDate && _habit.StartDate <= dtpStart.MaxDate)
                dtpStart.Value = _habit.StartDate;

            if (_habit.EndDate >= dtpEnd.MinDate && _habit.EndDate <= dtpEnd.MaxDate)
                dtpEnd.Value = _habit.EndDate;

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

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtHabitName.Text))
                {
                    MessageBox.Show("Habit name cannot be empty.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (rbQuantitative.Checked && string.IsNullOrWhiteSpace(txtUnit.Text))
                {
                    MessageBox.Show("Unit cannot be empty.", "Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Update habit object with new values
                _habit.HabitName = txtHabitName.Text.Trim();
                _habit.Intent = rbBuild.Checked ? Intent.Build : Intent.Break;
                _habit.TrackingType = rbBinary.Checked ? TrackingType.Binary : TrackingType.Quantitative;
                _habit.TargetAmount = rbQuantitative.Checked ? (double)nudTarget.Value : 0;
                _habit.Unit = rbQuantitative.Checked ? txtUnit.Text.Trim() : "";

                _habit.Category = (HabitCategory)cmbCategory.SelectedItem;
                _habit.GoalPeriod = (GoalPeriod)cmbPeriod.SelectedItem;
                _habit.TimeRange = (TimeRange)cmbTimeRange.SelectedItem;
                _habit.StartDate = dtpStart.Value.Date;
                _habit.EndDate = dtpEnd.Value.Date;

                // Save to CSV
                _dataService.UpdateHabit(_habit);

                MessageBox.Show($"✅ Habit '{_habit.HabitName}' updated successfully!", "Saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating habit:\n\n{ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Theme ─────────────────────────────────────────────────────────────
        private void ApplyTheme()
        {
            ThemeManager.MakeRounded(btnSaveEdit, 10);
            ThemeManager.MakeRounded(btnCancelEdit, 10);

            if (cmbCategory != null) ThemeManager.StyleComboBox(cmbCategory);
            if (cmbPeriod != null) ThemeManager.StyleComboBox(cmbPeriod);
            if (cmbTimeRange != null) ThemeManager.StyleComboBox(cmbTimeRange);
        }

        private void EditHabitForm_Load(object sender, EventArgs e) { }
    }
}