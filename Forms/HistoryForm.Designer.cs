namespace AOOP_HABI.Forms
{
    partial class HistoryForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbFilterType = new System.Windows.Forms.ComboBox();
            this.cmbFilterValue = new System.Windows.Forms.ComboBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClearFIlter = new System.Windows.Forms.Button();
            this.dgvLogs = new System.Windows.Forms.DataGridView();
            this.pnlSummary = new System.Windows.Forms.Panel();
            this.lblSummary = new System.Windows.Forms.Label();
            this.lblHeatmapTitle = new System.Windows.Forms.Label();
            this.cmbHeatmapHabit = new System.Windows.Forms.ComboBox();
            this.btnRefreshHeatmap = new System.Windows.Forms.Button();
            this.pnlHeatmap = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).BeginInit();
            this.pnlSummary.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(162, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Habit History";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 45);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(155, 16);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "View your past habit logs";
            // 
            // pnlLine
            // 
            this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlLine.Location = new System.Drawing.Point(20, 75);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(1020, 2);
            this.pnlLine.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Filter By:";
            // 
            // cmbFilterType
            // 
            this.cmbFilterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterType.FormattingEnabled = true;
            this.cmbFilterType.Location = new System.Drawing.Point(90, 88);
            this.cmbFilterType.Name = "cmbFilterType";
            this.cmbFilterType.Size = new System.Drawing.Size(110, 24);
            this.cmbFilterType.TabIndex = 4;
            this.cmbFilterType.SelectedIndexChanged += new System.EventHandler(this.cmbFilterType_SelectedIndexChanged);
            // 
            // cmbFilterValue
            // 
            this.cmbFilterValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterValue.FormattingEnabled = true;
            this.cmbFilterValue.Location = new System.Drawing.Point(210, 88);
            this.cmbFilterValue.Name = "cmbFilterValue";
            this.cmbFilterValue.Size = new System.Drawing.Size(110, 24);
            this.cmbFilterValue.TabIndex = 14;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(330, 86);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(85, 28);
            this.btnFilter.TabIndex = 5;
            this.btnFilter.Text = "🔍 Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClearFIlter
            // 
            this.btnClearFIlter.Location = new System.Drawing.Point(425, 86);
            this.btnClearFIlter.Name = "btnClearFIlter";
            this.btnClearFIlter.Size = new System.Drawing.Size(75, 28);
            this.btnClearFIlter.TabIndex = 6;
            this.btnClearFIlter.Text = "✖ Clear";
            this.btnClearFIlter.UseVisualStyleBackColor = true;
            this.btnClearFIlter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(510, 86);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(125, 28);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "📥 Export to CSV";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvLogs
            // 
            this.dgvLogs.AllowUserToAddRows = false;
            this.dgvLogs.AllowUserToDeleteRows = false;
            this.dgvLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLogs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLogs.Location = new System.Drawing.Point(20, 125);
            this.dgvLogs.Name = "dgvLogs";
            this.dgvLogs.ReadOnly = true;
            this.dgvLogs.RowHeadersWidth = 51;
            this.dgvLogs.RowTemplate.Height = 24;
            this.dgvLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLogs.Size = new System.Drawing.Size(1020, 300);
            this.dgvLogs.TabIndex = 7;
            // 
            // pnlSummary
            // 
            this.pnlSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSummary.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSummary.Controls.Add(this.lblSummary);
            this.pnlSummary.Location = new System.Drawing.Point(20, 438);
            this.pnlSummary.Name = "pnlSummary";
            this.pnlSummary.Size = new System.Drawing.Size(1020, 60);
            this.pnlSummary.TabIndex = 8;
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.ForeColor = System.Drawing.Color.Gray;
            this.lblSummary.Location = new System.Drawing.Point(10, 10);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(179, 18);
            this.lblSummary.TabIndex = 0;
            this.lblSummary.Text = "Select a habit to summary";
            this.lblSummary.Click += new System.EventHandler(this.lblSummary_Click);
            // 
            // lblHeatmapTitle
            // 
            this.lblHeatmapTitle.AutoSize = true;
            this.lblHeatmapTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeatmapTitle.Location = new System.Drawing.Point(20, 515);
            this.lblHeatmapTitle.Name = "lblHeatmapTitle";
            this.lblHeatmapTitle.Size = new System.Drawing.Size(368, 25);
            this.lblHeatmapTitle.TabIndex = 9;
            this.lblHeatmapTitle.Text = "📅 Activity Heatmap — Last 12 Weeks";
            // 
            // cmbHeatmapHabit
            // 
            this.cmbHeatmapHabit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeatmapHabit.FormattingEnabled = true;
            this.cmbHeatmapHabit.Location = new System.Drawing.Point(20, 542);
            this.cmbHeatmapHabit.Name = "cmbHeatmapHabit";
            this.cmbHeatmapHabit.Size = new System.Drawing.Size(200, 24);
            this.cmbHeatmapHabit.TabIndex = 10;
            // 
            // btnRefreshHeatmap
            // 
            this.btnRefreshHeatmap.Location = new System.Drawing.Point(230, 540);
            this.btnRefreshHeatmap.Name = "btnRefreshHeatmap";
            this.btnRefreshHeatmap.Size = new System.Drawing.Size(85, 28);
            this.btnRefreshHeatmap.TabIndex = 11;
            this.btnRefreshHeatmap.Text = "🔄 Refresh";
            this.btnRefreshHeatmap.UseVisualStyleBackColor = true;
            this.btnRefreshHeatmap.Click += new System.EventHandler(this.btnRefreshHeatmap_Click);
            // 
            // pnlHeatmap
            // 
            this.pnlHeatmap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeatmap.BackColor = System.Drawing.Color.White;
            this.pnlHeatmap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeatmap.Location = new System.Drawing.Point(20, 578);
            this.pnlHeatmap.Name = "pnlHeatmap";
            this.pnlHeatmap.Size = new System.Drawing.Size(1020, 230);
            this.pnlHeatmap.TabIndex = 12;
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1060, 853);
            this.Controls.Add(this.cmbFilterValue);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pnlHeatmap);
            this.Controls.Add(this.btnRefreshHeatmap);
            this.Controls.Add(this.cmbHeatmapHabit);
            this.Controls.Add(this.lblHeatmapTitle);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.dgvLogs);
            this.Controls.Add(this.btnClearFIlter);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.cmbFilterType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "HistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habit History";
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLogs)).EndInit();
            this.pnlSummary.ResumeLayout(false);
            this.pnlSummary.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbFilterType;
        private System.Windows.Forms.ComboBox cmbFilterValue;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClearFIlter;
        private System.Windows.Forms.DataGridView dgvLogs;
        private System.Windows.Forms.Panel pnlSummary;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label lblHeatmapTitle;
        private System.Windows.Forms.ComboBox cmbHeatmapHabit;
        private System.Windows.Forms.Button btnRefreshHeatmap;
        private System.Windows.Forms.Panel pnlHeatmap;
        private System.Windows.Forms.Button btnExport;
    }
}