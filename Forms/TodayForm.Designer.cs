namespace AOOP_HABI.Forms
{
    partial class TodayForm
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
            this.lblDate = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.pnlHabits = new System.Windows.Forms.Panel();
            this.btnSaveAll = new System.Windows.Forms.Button();
            this.btnAddHabit = new System.Windows.Forms.Button();
            this.btnEditHabit = new System.Windows.Forms.Button();
            this.btnDeleteHabit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblDate.Location = new System.Drawing.Point(20, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(316, 37);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Today — April 23, 2026";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 58);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(153, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Log your habits for today";
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlLine.Location = new System.Drawing.Point(20, 82);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1000, 2);
            this.pnlLine.TabIndex = 2;
            // 
            // pnlHabits
            // 
            this.pnlHabits.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHabits.AutoScroll = true;
            this.pnlHabits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHabits.Location = new System.Drawing.Point(20, 92);
            this.pnlHabits.Name = "pnlHabits";
            this.pnlHabits.Size = new System.Drawing.Size(1000, 630);
            this.pnlHabits.TabIndex = 3;
            // 
            // btnSaveAll
            // 
            this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnSaveAll.ForeColor = System.Drawing.Color.White;
            this.btnSaveAll.Location = new System.Drawing.Point(900, 738);
            this.btnSaveAll.Name = "btnSaveAll";
            this.btnSaveAll.Size = new System.Drawing.Size(120, 35);
            this.btnSaveAll.TabIndex = 4;
            this.btnSaveAll.Text = "💾 Save All";
            this.btnSaveAll.UseVisualStyleBackColor = false;
            this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
            // 
            // btnAddHabit
            // 
            this.btnAddHabit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddHabit.Location = new System.Drawing.Point(20, 738);
            this.btnAddHabit.Name = "btnAddHabit";
            this.btnAddHabit.Size = new System.Drawing.Size(120, 35);
            this.btnAddHabit.TabIndex = 5;
            this.btnAddHabit.Text = "+ Add Habit";
            this.btnAddHabit.UseVisualStyleBackColor = true;
            this.btnAddHabit.Click += new System.EventHandler(this.btnAddHabit_Click);
            // 
            // btnEditHabit
            // 
            this.btnEditHabit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditHabit.Location = new System.Drawing.Point(150, 738);
            this.btnEditHabit.Name = "btnEditHabit";
            this.btnEditHabit.Size = new System.Drawing.Size(120, 35);
            this.btnEditHabit.TabIndex = 6;
            this.btnEditHabit.Text = "✏️ Edit Habit";
            this.btnEditHabit.UseVisualStyleBackColor = true;
            this.btnEditHabit.Click += new System.EventHandler(this.btnEditHabit_Click);
            // 
            // btnDeleteHabit
            // 
            this.btnDeleteHabit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteHabit.Location = new System.Drawing.Point(280, 738);
            this.btnDeleteHabit.Name = "btnDeleteHabit";
            this.btnDeleteHabit.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteHabit.TabIndex = 7;
            this.btnDeleteHabit.Text = "🗑️ Delete Habit";
            this.btnDeleteHabit.UseVisualStyleBackColor = true;
            this.btnDeleteHabit.Click += new System.EventHandler(this.btnDeleteHabit_Click);
            // 
            // TodayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 800);
            this.Controls.Add(this.btnDeleteHabit);
            this.Controls.Add(this.btnEditHabit);
            this.Controls.Add(this.btnAddHabit);
            this.Controls.Add(this.btnSaveAll);
            this.Controls.Add(this.pnlHabits);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "TodayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Today\'s Habit";
            this.Load += new System.EventHandler(this.TodayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Panel pnlHabits;
        private System.Windows.Forms.Button btnSaveAll;
        private System.Windows.Forms.Button btnAddHabit;
        private System.Windows.Forms.Button btnEditHabit;
        private System.Windows.Forms.Button btnDeleteHabit;
    }
}