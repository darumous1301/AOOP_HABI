using System;
using System.Drawing;
using System.Windows.Forms;
using AOOP_HABI.Services;

namespace AOOP_HABI.Forms
{
    public partial class NameEntryForm : Form
    {
        private readonly CsvDataService _dataService = new CsvDataService();
        private Panel pnlContainer, pnlIcon;
        private Label lblTitle, lblSubtitle, lblError, lblHint, lblIcon;
        private TextBox txtName;
        private Button btnStart;

        public NameEntryForm()
        {
            InitializeComponent();
            this.ClientSize = new Size(920, 330);
            this.StartPosition = FormStartPosition.CenterScreen;

            BuildUI();
            ApplyTheme();
            PreFillName();
        }

        private void BuildUI()
        {
            pnlContainer = new Panel { Size = new Size(260, 270), Name = "pnlContainer" };

            pnlContainer.Location = new Point(
                620,
                (this.ClientSize.Height - pnlContainer.Height) / 2  
            );

            pnlIcon = new Panel
            {
                Size = new Size(36, 36),
                Location = new Point((pnlContainer.Width - 36) / 2, 14)
            };
            lblIcon = new Label { Text = "H", TextAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill };
            pnlIcon.Controls.Add(lblIcon);

            lblTitle = new Label { Text = "Welcome back!", Location = new Point(10, 58), Size = new Size(240, 22), TextAlign = ContentAlignment.MiddleCenter };
            lblSubtitle = new Label { Text = "Enter your name to continue", Location = new Point(10, 82), Size = new Size(240, 16), TextAlign = ContentAlignment.MiddleCenter };
            txtName = new TextBox { Location = new Point(25, 112), Size = new Size(210, 24), TextAlign = HorizontalAlignment.Center };
            lblError = new Label { Text = "", Location = new Point(10, 145), Size = new Size(240, 16), Visible = false, TextAlign = ContentAlignment.MiddleCenter };
            btnStart = new Button { Text = "Continue →", Location = new Point(25, 165), Size = new Size(210, 36) };
            btnStart.Click += btnStart_Click;
            lblHint = new Label { Text = "Your name will be saved for next time", Location = new Point(10, 218), Size = new Size(240, 16), TextAlign = ContentAlignment.MiddleCenter };

            pnlContainer.Controls.Add(pnlIcon);
            pnlContainer.Controls.Add(lblTitle);
            pnlContainer.Controls.Add(lblSubtitle);
            pnlContainer.Controls.Add(txtName);
            pnlContainer.Controls.Add(lblError);
            pnlContainer.Controls.Add(btnStart);
            pnlContainer.Controls.Add(lblHint);

            this.Controls.Add(pnlContainer);
        }

        private void ApplyTheme()
        {
            // Card
            pnlContainer.BackColor = ThemeManager.CardBg;
            MakeRounded(pnlContainer, 16);

            // Icon bubble
            pnlIcon.BackColor = ThemeManager.AccentGreen;
            MakeRounded(pnlIcon, 14);
            lblIcon.Font = new Font("Segoe UI", 16f, FontStyle.Bold); 
            lblIcon.ForeColor = ThemeManager.NavBg;

            // Text styles
            lblTitle.ForeColor = ThemeManager.TextPrimary;
            lblTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold);
            lblSubtitle.ForeColor = ThemeManager.TextSecondary;
            lblSubtitle.Font = ThemeManager.FontBody;
            lblError.ForeColor = ThemeManager.AccentRed;
            lblError.Font = ThemeManager.FontSmall;
            lblHint.ForeColor = ThemeManager.TextMuted;
            lblHint.Font = ThemeManager.FontSmall;

            // Input & button
            ThemeManager.StyleTextBox(txtName);
            WrapTextBox(txtName);
            ThemeManager.StyleButton(btnStart, "primary");
            btnStart.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            MakeRounded(btnStart, 10);
        }

        private void WrapTextBox(TextBox txt)
        {
            if (txt.Parent == null) return;
            var wrapper = new Panel
            {
                Location = new Point(txt.Left - 10, txt.Top - 8),
                Size = new Size(txt.Width + 20, txt.Height + 16),
                BackColor = ThemeManager.SurfaceBg
            };
            MakeRounded(wrapper, 8);
            var parent = txt.Parent;
            txt.Location = new Point(10, 8);
            parent.Controls.Remove(txt);
            wrapper.Controls.Add(txt);
            parent.Controls.Add(wrapper);
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

        private void PreFillName()
        {
            var saved = _dataService.LoadUserName();
            if (!string.IsNullOrEmpty(saved))
            {
                txtName.Text = saved;
                txtName.SelectAll();
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                lblError.Text = "⚠️ Please enter your name to continue.";
                lblError.Visible = true;
                return;
            }
            _dataService.SaveUserName(txtName.Text.Trim());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void NameEntryForm_Load(object sender, EventArgs e) { }
    }
}