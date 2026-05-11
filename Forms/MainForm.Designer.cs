namespace AOOP_HABI.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.pnlLogoSpace = new System.Windows.Forms.Panel();
            this.lblNavLogo = new System.Windows.Forms.Label();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavToday = new System.Windows.Forms.Button();
            this.btnNavHistory = new System.Windows.Forms.Button();
            this.btnNavAddHabit = new System.Windows.Forms.Button();
            this.btnNavLogout = new System.Windows.Forms.Button();
            this.lblNavUser = new System.Windows.Forms.Label();
            this.pnlNav.SuspendLayout();
            this.pnlLogoSpace.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.White;
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 80);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1382, 813);
            this.pnlContent.TabIndex = 1;
            this.pnlContent.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContent_Paint);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.pnlNav.Controls.Add(this.btnNavAddHabit);
            this.pnlNav.Controls.Add(this.btnNavHistory);
            this.pnlNav.Controls.Add(this.btnNavToday);
            this.pnlNav.Controls.Add(this.btnNavDashboard);
            this.pnlNav.Controls.Add(this.pnlLogoSpace);
            this.pnlNav.Controls.Add(this.btnNavLogout);
            this.pnlNav.Controls.Add(this.lblNavUser);
            this.pnlNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNav.Location = new System.Drawing.Point(0, 0);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1382, 80);
            this.pnlNav.TabIndex = 0;
            // 
            // pnlLogoSpace
            // 
            this.pnlLogoSpace.Controls.Add(this.lblNavLogo);
            this.pnlLogoSpace.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLogoSpace.Location = new System.Drawing.Point(0, 0);
            this.pnlLogoSpace.Name = "pnlLogoSpace";
            this.pnlLogoSpace.Size = new System.Drawing.Size(250, 80);
            this.pnlLogoSpace.TabIndex = 0;
            // 
            // lblNavLogo
            // 
            this.lblNavLogo.AutoSize = true;
            this.lblNavLogo.Location = new System.Drawing.Point(20, 25);
            this.lblNavLogo.Name = "lblNavLogo";
            this.lblNavLogo.Size = new System.Drawing.Size(128, 16);
            this.lblNavLogo.TabIndex = 5;
            this.lblNavLogo.Text = "H.A.B.I";
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNavDashboard.Location = new System.Drawing.Point(250, 0);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Size = new System.Drawing.Size(140, 80);
            this.btnNavDashboard.TabIndex = 1;
            this.btnNavDashboard.Text = "📊 Dashboard";
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavToday
            // 
            this.btnNavToday.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNavToday.Location = new System.Drawing.Point(390, 0);
            this.btnNavToday.Name = "btnNavToday";
            this.btnNavToday.Size = new System.Drawing.Size(120, 80);
            this.btnNavToday.TabIndex = 2;
            this.btnNavToday.Text = "📅 Today";
            this.btnNavToday.UseVisualStyleBackColor = true;
            this.btnNavToday.Click += new System.EventHandler(this.btnNavToday_Click);
            // 
            // btnNavHistory
            // 
            this.btnNavHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNavHistory.Location = new System.Drawing.Point(510, 0);
            this.btnNavHistory.Name = "btnNavHistory";
            this.btnNavHistory.Size = new System.Drawing.Size(120, 80);
            this.btnNavHistory.TabIndex = 3;
            this.btnNavHistory.Text = "📋 History";
            this.btnNavHistory.UseVisualStyleBackColor = true;
            this.btnNavHistory.Click += new System.EventHandler(this.btnNavHistory_Click);
            // 
            // btnNavAddHabit
            // 
            this.btnNavAddHabit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnNavAddHabit.ForeColor = System.Drawing.Color.White;
            this.btnNavAddHabit.Location = new System.Drawing.Point(650, 20);
            this.btnNavAddHabit.Name = "btnNavAddHabit";
            this.btnNavAddHabit.Size = new System.Drawing.Size(120, 40);
            this.btnNavAddHabit.TabIndex = 4;
            this.btnNavAddHabit.Text = "+ Add Habit";
            this.btnNavAddHabit.UseVisualStyleBackColor = false;
            this.btnNavAddHabit.Click += new System.EventHandler(this.btnNavAddHabit_Click);
            // 
            // btnNavLogout
            // 
            this.btnNavLogout.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnNavLogout.Location = new System.Drawing.Point(1082, 0);
            this.btnNavLogout.Name = "btnNavLogout";
            this.btnNavLogout.Size = new System.Drawing.Size(100, 80);
            this.btnNavLogout.TabIndex = 7;
            this.btnNavLogout.Text = "🚪 Log Out";
            this.btnNavLogout.UseVisualStyleBackColor = true;
            this.btnNavLogout.Click += new System.EventHandler(this.btnNavLogout_Click);
            // 
            // lblNavUser
            // 
            this.lblNavUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblNavUser.Location = new System.Drawing.Point(1182, 0);
            this.lblNavUser.Name = "lblNavUser";
            this.lblNavUser.Padding = new System.Windows.Forms.Padding(0, 0, 20, 0);
            this.lblNavUser.Size = new System.Drawing.Size(200, 80);
            this.lblNavUser.TabIndex = 6;
            this.lblNavUser.Text = "USER";
            this.lblNavUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 893);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlNav);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "H.A.B.I";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.pnlNav.ResumeLayout(false);
            this.pnlLogoSpace.ResumeLayout(false);
            this.pnlLogoSpace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Panel pnlLogoSpace;
        private System.Windows.Forms.Label lblNavLogo;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavToday;
        private System.Windows.Forms.Button btnNavHistory;
        private System.Windows.Forms.Button btnNavAddHabit;
        private System.Windows.Forms.Button btnNavLogout;
        private System.Windows.Forms.Label lblNavUser;
    }
}