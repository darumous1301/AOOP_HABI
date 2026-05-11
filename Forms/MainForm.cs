using AOOP_HABI.Models;
using AOOP_HABI.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AOOP_HABI.Forms
{
    public partial class MainForm : Form
    {
        private Form _activeForm = null;
        private Button _activeNavBtn = null;

        public MainForm()
        {
            InitializeComponent();
            ApplyTheme();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var dataService = new CsvDataService();
            var userName = dataService.LoadUserName();
            if (!string.IsNullOrEmpty(userName))
                lblNavUser.Text = userName.ToUpper();

            OpenChildForm(new DashboardForm(), btnNavDashboard);
        }

        private void ApplyTheme()
        {
            lblNavLogo.ForeColor = ThemeManager.AccentGreen;
            lblNavLogo.Font = new Font("Segoe UI", 16f, FontStyle.Bold);
            lblNavLogo.BackColor = Color.Transparent;

            lblNavUser.ForeColor = ThemeManager.NavText;
            lblNavUser.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
            lblNavUser.BackColor = Color.Transparent;

            StyleNavButton(btnNavDashboard);
            StyleNavButton(btnNavToday);
            StyleNavButton(btnNavHistory);

            btnNavAddHabit.FlatStyle = FlatStyle.Flat;
            btnNavAddHabit.FlatAppearance.BorderSize = 0;
            btnNavAddHabit.Cursor = Cursors.Hand;
            btnNavAddHabit.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnNavAddHabit.BackColor = ThemeManager.AccentGreen;
            btnNavAddHabit.ForeColor = Color.White;

            ThemeManager.MakeRounded(btnNavAddHabit, 10);
        }

        private void StyleNavButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = ThemeManager.NavText;
            btn.Font = ThemeManager.FontNav;
            btn.Cursor = Cursors.Hand;
            btn.BackColor = Color.Transparent;
        }

        private void OpenChildForm(Form childForm, Button activeBtn)
        {
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm = null;
            }

            if (_activeNavBtn != null)
            {
                _activeNavBtn.ForeColor = ThemeManager.NavText;
                _activeNavBtn.Font = ThemeManager.FontNav;
            }

            activeBtn.ForeColor = ThemeManager.NavTextActive;
            activeBtn.Font = ThemeManager.FontNavBold;
            _activeNavBtn = activeBtn;

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new DashboardForm(), btnNavDashboard);
        }

        private void btnNavToday_Click(object sender, EventArgs e)
        {
            OpenChildForm(new TodayForm(), btnNavToday);
        }

        private void btnNavHistory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new HistoryForm(), btnNavHistory);
        }

        private void btnNavAddHabit_Click(object sender, EventArgs e)
        {
            var addForm = new AddHabitForm();
            addForm.ShowDialog();

            if (_activeForm is DashboardForm)
                OpenChildForm(new DashboardForm(), btnNavDashboard);
            else if (_activeForm is TodayForm)
                OpenChildForm(new TodayForm(), btnNavToday);
        }

        // ──────────────────────────────────────────
        //  LOGOUT LOGIC
        // ──────────────────────────────────────────
        private void btnNavLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                // Clear the saved username from config
                var dataService = new CsvDataService();
                dataService.SaveUserName("");

                // Restart the application to trigger the NameEntryForm again
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void pnlContent_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}