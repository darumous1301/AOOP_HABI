namespace AOOP_HABI.Forms
{
    partial class DashboardForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblToday = new System.Windows.Forms.Label();
            this.pnlLine = new System.Windows.Forms.Panel();
            this.pnlTotalHabits = new System.Windows.Forms.Panel();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.pnlCompletedToday = new System.Windows.Forms.Panel();
            this.lblDoneLabel = new System.Windows.Forms.Label();
            this.lblDoneCount = new System.Windows.Forms.Label();
            this.pnlBestStreak = new System.Windows.Forms.Panel();
            this.lblStreakLabel = new System.Windows.Forms.Label();
            this.lblStreakCount = new System.Windows.Forms.Label();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.chartWeekly = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlQuote = new System.Windows.Forms.Panel();
            this.lblQuote = new System.Windows.Forms.Label();
            this.lblQuoteIcon = new System.Windows.Forms.Label();
            this.pnlCalendar1 = new System.Windows.Forms.Panel();
            this.pnlCalendar2 = new System.Windows.Forms.Panel();
            this.pnlCalendar3 = new System.Windows.Forms.Panel();
            this.pnlCalendar4 = new System.Windows.Forms.Panel();
            this.pnlTotalHabits.SuspendLayout();
            this.pnlCompletedToday.SuspendLayout();
            this.pnlBestStreak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeekly)).BeginInit();
            this.pnlQuote.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "My Habit Dashboard";
            // 
            // lblToday
            // 
            this.lblToday.AutoSize = true;
            this.lblToday.ForeColor = System.Drawing.Color.Gray;
            this.lblToday.Location = new System.Drawing.Point(20, 52);
            this.lblToday.Name = "lblToday";
            this.lblToday.Size = new System.Drawing.Size(140, 16);
            this.lblToday.TabIndex = 1;
            this.lblToday.Text = "Today — April 23, 2026";
            // 
            // pnlLine
            // 
            this.pnlLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlLine.Location = new System.Drawing.Point(20, 75);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(620, 2);
            this.pnlLine.TabIndex = 2;
            // 
            // pnlTotalHabits
            // 
            this.pnlTotalHabits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.pnlTotalHabits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTotalHabits.Controls.Add(this.lblTotalLabel);
            this.pnlTotalHabits.Controls.Add(this.lblTotalCount);
            this.pnlTotalHabits.Location = new System.Drawing.Point(20, 88);
            this.pnlTotalHabits.Name = "pnlTotalHabits";
            this.pnlTotalHabits.Size = new System.Drawing.Size(200, 72);
            this.pnlTotalHabits.TabIndex = 3;
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalLabel.Location = new System.Drawing.Point(10, 45);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(80, 16);
            this.lblTotalLabel.TabIndex = 1;
            this.lblTotalLabel.Text = "Total Habits";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(10, 8);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(36, 38);
            this.lblTotalCount.TabIndex = 0;
            this.lblTotalCount.Text = "0";
            // 
            // pnlCompletedToday
            // 
            this.pnlCompletedToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(245)))), ((int)(((byte)(233)))));
            this.pnlCompletedToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCompletedToday.Controls.Add(this.lblDoneLabel);
            this.pnlCompletedToday.Controls.Add(this.lblDoneCount);
            this.pnlCompletedToday.Location = new System.Drawing.Point(230, 88);
            this.pnlCompletedToday.Name = "pnlCompletedToday";
            this.pnlCompletedToday.Size = new System.Drawing.Size(200, 72);
            this.pnlCompletedToday.TabIndex = 4;
            // 
            // lblDoneLabel
            // 
            this.lblDoneLabel.AutoSize = true;
            this.lblDoneLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblDoneLabel.Location = new System.Drawing.Point(10, 45);
            this.lblDoneLabel.Name = "lblDoneLabel";
            this.lblDoneLabel.Size = new System.Drawing.Size(83, 16);
            this.lblDoneLabel.TabIndex = 1;
            this.lblDoneLabel.Text = "Done Today";
            // 
            // lblDoneCount
            // 
            this.lblDoneCount.AutoSize = true;
            this.lblDoneCount.ForeColor = System.Drawing.Color.Gray;
            this.lblDoneCount.Location = new System.Drawing.Point(10, 8);
            this.lblDoneCount.Name = "lblDoneCount";
            this.lblDoneCount.Size = new System.Drawing.Size(14, 16);
            this.lblDoneCount.TabIndex = 0;
            this.lblDoneCount.Text = "0";
            // 
            // pnlBestStreak
            // 
            this.pnlBestStreak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(248)))), ((int)(((byte)(225)))));
            this.pnlBestStreak.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBestStreak.Controls.Add(this.lblStreakLabel);
            this.pnlBestStreak.Controls.Add(this.lblStreakCount);
            this.pnlBestStreak.Location = new System.Drawing.Point(440, 88);
            this.pnlBestStreak.Name = "pnlBestStreak";
            this.pnlBestStreak.Size = new System.Drawing.Size(200, 72);
            this.pnlBestStreak.TabIndex = 5;
            // 
            // lblStreakLabel
            // 
            this.lblStreakLabel.AutoSize = true;
            this.lblStreakLabel.ForeColor = System.Drawing.Color.Gray;
            this.lblStreakLabel.Location = new System.Drawing.Point(10, 45);
            this.lblStreakLabel.Name = "lblStreakLabel";
            this.lblStreakLabel.Size = new System.Drawing.Size(76, 16);
            this.lblStreakLabel.TabIndex = 1;
            this.lblStreakLabel.Text = "Best Streak";
            // 
            // lblStreakCount
            // 
            this.lblStreakCount.AutoSize = true;
            this.lblStreakCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStreakCount.Location = new System.Drawing.Point(10, 8);
            this.lblStreakCount.Name = "lblStreakCount";
            this.lblStreakCount.Size = new System.Drawing.Size(36, 38);
            this.lblStreakCount.TabIndex = 0;
            this.lblStreakCount.Text = "0";
            // 
            // pnlCards
            // 
            this.pnlCards.AutoScroll = true;
            this.pnlCards.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlCards.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pnlCards.Location = new System.Drawing.Point(20, 185);
            this.pnlCards.Name = "pnlCards";
            this.pnlCards.Size = new System.Drawing.Size(620, 592);
            this.pnlCards.TabIndex = 6;
            this.pnlCards.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlCards_Paint);
            // 
            // chartWeekly
            // 
            chartArea1.Name = "ChartArea1";
            this.chartWeekly.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartWeekly.Legends.Add(legend1);
            this.chartWeekly.Location = new System.Drawing.Point(680, 673);
            this.chartWeekly.Name = "chartWeekly";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartWeekly.Series.Add(series1);
            this.chartWeekly.Size = new System.Drawing.Size(664, 157);
            this.chartWeekly.TabIndex = 8;
            this.chartWeekly.Text = "chart1";
            this.chartWeekly.Click += new System.EventHandler(this.chartWeekly_Click);
            // 
            // pnlQuote
            // 
            this.pnlQuote.Controls.Add(this.lblQuote);
            this.pnlQuote.Controls.Add(this.lblQuoteIcon);
            this.pnlQuote.Location = new System.Drawing.Point(680, 25);
            this.pnlQuote.Name = "pnlQuote";
            this.pnlQuote.Size = new System.Drawing.Size(664, 52);
            this.pnlQuote.TabIndex = 0;
            // 
            // lblQuote
            // 
            this.lblQuote.Location = new System.Drawing.Point(45, 8);
            this.lblQuote.Name = "lblQuote";
            this.lblQuote.Size = new System.Drawing.Size(540, 38);
            this.lblQuote.TabIndex = 0;
            // 
            // lblQuoteIcon
            // 
            this.lblQuoteIcon.Location = new System.Drawing.Point(10, 8);
            this.lblQuoteIcon.Name = "lblQuoteIcon";
            this.lblQuoteIcon.Size = new System.Drawing.Size(30, 38);
            this.lblQuoteIcon.TabIndex = 1;
            this.lblQuoteIcon.Text = "❝";
            // 
            // pnlCalendar1
            // 
            this.pnlCalendar1.Location = new System.Drawing.Point(659, 97);
            this.pnlCalendar1.Name = "pnlCalendar1";
            this.pnlCalendar1.Size = new System.Drawing.Size(341, 275);
            this.pnlCalendar1.TabIndex = 9;
            // 
            // pnlCalendar2
            // 
            this.pnlCalendar2.Location = new System.Drawing.Point(1016, 97);
            this.pnlCalendar2.Name = "pnlCalendar2";
            this.pnlCalendar2.Size = new System.Drawing.Size(343, 275);
            this.pnlCalendar2.TabIndex = 10;
            // 
            // pnlCalendar3
            // 
            this.pnlCalendar3.Location = new System.Drawing.Point(659, 378);
            this.pnlCalendar3.Name = "pnlCalendar3";
            this.pnlCalendar3.Size = new System.Drawing.Size(341, 275);
            this.pnlCalendar3.TabIndex = 11;
            // 
            // pnlCalendar4
            // 
            this.pnlCalendar4.Location = new System.Drawing.Point(1016, 378);
            this.pnlCalendar4.Name = "pnlCalendar4";
            this.pnlCalendar4.Size = new System.Drawing.Size(343, 275);
            this.pnlCalendar4.TabIndex = 12;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1382, 893);
            this.Controls.Add(this.pnlCalendar1);
            this.Controls.Add(this.pnlCalendar2);
            this.Controls.Add(this.pnlCalendar3);
            this.Controls.Add(this.pnlCalendar4);
            this.Controls.Add(this.pnlQuote);
            this.Controls.Add(this.chartWeekly);
            this.Controls.Add(this.pnlCards);
            this.Controls.Add(this.pnlBestStreak);
            this.Controls.Add(this.pnlCompletedToday);
            this.Controls.Add(this.pnlTotalHabits);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.lblToday);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlTotalHabits.ResumeLayout(false);
            this.pnlTotalHabits.PerformLayout();
            this.pnlCompletedToday.ResumeLayout(false);
            this.pnlCompletedToday.PerformLayout();
            this.pnlBestStreak.ResumeLayout(false);
            this.pnlBestStreak.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartWeekly)).EndInit();
            this.pnlQuote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblToday;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Panel pnlTotalHabits;
        private System.Windows.Forms.Panel pnlCompletedToday;
        private System.Windows.Forms.Panel pnlBestStreak;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblDoneLabel;
        private System.Windows.Forms.Label lblDoneCount;
        private System.Windows.Forms.Label lblStreakLabel;
        private System.Windows.Forms.Label lblStreakCount;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartWeekly;
        private System.Windows.Forms.Panel pnlQuote;
        private System.Windows.Forms.Label lblQuote;
        private System.Windows.Forms.Label lblQuoteIcon;
        private System.Windows.Forms.Panel pnlCalendar1;
        private System.Windows.Forms.Panel pnlCalendar2;
        private System.Windows.Forms.Panel pnlCalendar3;
        private System.Windows.Forms.Panel pnlCalendar4;
    }
}