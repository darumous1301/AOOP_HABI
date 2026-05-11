namespace AOOP_HABI.Forms
{
    partial class EditHabitForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlIntent = new System.Windows.Forms.Panel();
            this.rbBuild = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.rbBreak = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlTracking = new System.Windows.Forms.Panel();
            this.rbBinary = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.rbQuantitative = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSaveEdit = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbTimeRange = new System.Windows.Forms.ComboBox();
            this.cmbPeriod = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.nudTarget = new System.Windows.Forms.NumericUpDown();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtHabitName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.lblReminder = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.pnlSep1 = new System.Windows.Forms.Panel();
            this.pnlSep2 = new System.Windows.Forms.Panel();
            this.pnlSep3 = new System.Windows.Forms.Panel();
            this.pnlSep4 = new System.Windows.Forms.Panel();
            this.pnlIntent.SuspendLayout();
            this.pnlTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "What do you want to do?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label2.Location = new System.Drawing.Point(30, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(172, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Change your habit intent";
            // 
            // pnlIntent
            // 
            this.pnlIntent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.pnlIntent.Controls.Add(this.rbBuild);
            this.pnlIntent.Controls.Add(this.label3);
            this.pnlIntent.Controls.Add(this.rbBreak);
            this.pnlIntent.Controls.Add(this.label4);
            this.pnlIntent.Location = new System.Drawing.Point(30, 142);
            this.pnlIntent.Name = "pnlIntent";
            this.pnlIntent.Size = new System.Drawing.Size(460, 65);
            this.pnlIntent.TabIndex = 20;
            // 
            // rbBuild
            // 
            this.rbBuild.AutoSize = true;
            this.rbBuild.BackColor = System.Drawing.Color.Transparent;
            this.rbBuild.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbBuild.ForeColor = System.Drawing.Color.White;
            this.rbBuild.Location = new System.Drawing.Point(12, 10);
            this.rbBuild.Name = "rbBuild";
            this.rbBuild.Size = new System.Drawing.Size(137, 27);
            this.rbBuild.TabIndex = 2;
            this.rbBuild.TabStop = true;
            this.rbBuild.Text = "Build a Habit";
            this.rbBuild.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label3.Location = new System.Drawing.Point(12, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Form a new positive habit";
            // 
            // rbBreak
            // 
            this.rbBreak.AutoSize = true;
            this.rbBreak.BackColor = System.Drawing.Color.Transparent;
            this.rbBreak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbBreak.ForeColor = System.Drawing.Color.White;
            this.rbBreak.Location = new System.Drawing.Point(242, 10);
            this.rbBreak.Name = "rbBreak";
            this.rbBreak.Size = new System.Drawing.Size(141, 27);
            this.rbBreak.TabIndex = 4;
            this.rbBreak.TabStop = true;
            this.rbBreak.Text = "Break a Habit";
            this.rbBreak.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label4.Location = new System.Drawing.Point(242, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Eliminate a negative habit";
            // 
            // pnlTracking
            // 
            this.pnlTracking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(29)))), ((int)(((byte)(39)))));
            this.pnlTracking.Controls.Add(this.rbBinary);
            this.pnlTracking.Controls.Add(this.label7);
            this.pnlTracking.Controls.Add(this.rbQuantitative);
            this.pnlTracking.Controls.Add(this.label8);
            this.pnlTracking.Location = new System.Drawing.Point(30, 280);
            this.pnlTracking.Name = "pnlTracking";
            this.pnlTracking.Size = new System.Drawing.Size(460, 65);
            this.pnlTracking.TabIndex = 21;
            // 
            // rbBinary
            // 
            this.rbBinary.AutoSize = true;
            this.rbBinary.BackColor = System.Drawing.Color.Transparent;
            this.rbBinary.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbBinary.ForeColor = System.Drawing.Color.White;
            this.rbBinary.Location = new System.Drawing.Point(12, 10);
            this.rbBinary.Name = "rbBinary";
            this.rbBinary.Size = new System.Drawing.Size(83, 27);
            this.rbBinary.TabIndex = 2;
            this.rbBinary.TabStop = true;
            this.rbBinary.Text = "Binary";
            this.rbBinary.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label7.Location = new System.Drawing.Point(12, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 3;
            this.label7.Text = "Done / Not done";
            // 
            // rbQuantitative
            // 
            this.rbQuantitative.AutoSize = true;
            this.rbQuantitative.BackColor = System.Drawing.Color.Transparent;
            this.rbQuantitative.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.rbQuantitative.ForeColor = System.Drawing.Color.White;
            this.rbQuantitative.Location = new System.Drawing.Point(242, 10);
            this.rbQuantitative.Name = "rbQuantitative";
            this.rbQuantitative.Size = new System.Drawing.Size(131, 27);
            this.rbQuantitative.TabIndex = 4;
            this.rbQuantitative.TabStop = true;
            this.rbQuantitative.Text = "Quantitative";
            this.rbQuantitative.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label8.Location = new System.Drawing.Point(242, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Track by amount";
            // 
            // btnSaveEdit
            // 
            this.btnSaveEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(110)))), ((int)(((byte)(247)))));
            this.btnSaveEdit.FlatAppearance.BorderSize = 0;
            this.btnSaveEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveEdit.ForeColor = System.Drawing.Color.White;
            this.btnSaveEdit.Location = new System.Drawing.Point(376, 552);
            this.btnSaveEdit.Name = "btnSaveEdit";
            this.btnSaveEdit.Size = new System.Drawing.Size(114, 36);
            this.btnSaveEdit.TabIndex = 16;
            this.btnSaveEdit.Text = "Save Changes";
            this.btnSaveEdit.UseVisualStyleBackColor = false;
            this.btnSaveEdit.Click += new System.EventHandler(this.btnSaveEdit_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.btnCancelEdit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.btnCancelEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelEdit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.btnCancelEdit.Location = new System.Drawing.Point(256, 552);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(108, 36);
            this.btnCancelEdit.TabIndex = 15;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpEnd.Location = new System.Drawing.Point(262, 500);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(228, 29);
            this.dtpEnd.TabIndex = 14;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpStart.Location = new System.Drawing.Point(30, 500);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(215, 29);
            this.dtpStart.TabIndex = 13;
            // 
            // cmbTimeRange
            // 
            this.cmbTimeRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.cmbTimeRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeRange.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTimeRange.ForeColor = System.Drawing.Color.White;
            this.cmbTimeRange.FormattingEnabled = true;
            this.cmbTimeRange.Location = new System.Drawing.Point(334, 443);
            this.cmbTimeRange.Name = "cmbTimeRange";
            this.cmbTimeRange.Size = new System.Drawing.Size(156, 29);
            this.cmbTimeRange.TabIndex = 12;
            // 
            // cmbPeriod
            // 
            this.cmbPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.cmbPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriod.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPeriod.ForeColor = System.Drawing.Color.White;
            this.cmbPeriod.FormattingEnabled = true;
            this.cmbPeriod.Location = new System.Drawing.Point(186, 443);
            this.cmbPeriod.Name = "cmbPeriod";
            this.cmbPeriod.Size = new System.Drawing.Size(130, 29);
            this.cmbPeriod.TabIndex = 11;
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCategory.ForeColor = System.Drawing.Color.White;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(30, 443);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(140, 29);
            this.cmbCategory.TabIndex = 10;
            // 
            // nudTarget
            // 
            this.nudTarget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.nudTarget.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudTarget.ForeColor = System.Drawing.Color.White;
            this.nudTarget.Location = new System.Drawing.Point(30, 375);
            this.nudTarget.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudTarget.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTarget.Name = "nudTarget";
            this.nudTarget.Size = new System.Drawing.Size(155, 30);
            this.nudTarget.TabIndex = 7;
            this.nudTarget.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudTarget.Visible = false;
            // 
            // txtUnit
            // 
            this.txtUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUnit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUnit.ForeColor = System.Drawing.Color.White;
            this.txtUnit.Location = new System.Drawing.Point(202, 375);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(288, 30);
            this.txtUnit.TabIndex = 9;
            this.txtUnit.Visible = false;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblUnit.Location = new System.Drawing.Point(202, 358);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(184, 19);
            this.lblUnit.TabIndex = 8;
            this.lblUnit.Text = "UNIT  (e.g. glasses, pages)";
            this.lblUnit.Visible = false;
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblTarget.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblTarget.Location = new System.Drawing.Point(30, 358);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(127, 19);
            this.lblTarget.TabIndex = 6;
            this.lblTarget.Text = "TARGET AMOUNT";
            this.lblTarget.Visible = false;
            // 
            // txtHabitName
            // 
            this.txtHabitName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(38)))), ((int)(((byte)(58)))));
            this.txtHabitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHabitName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHabitName.ForeColor = System.Drawing.Color.White;
            this.txtHabitName.Location = new System.Drawing.Point(30, 38);
            this.txtHabitName.Name = "txtHabitName";
            this.txtHabitName.Size = new System.Drawing.Size(460, 30);
            this.txtHabitName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label9.Location = new System.Drawing.Point(30, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "HABIT NAME";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.label6.Location = new System.Drawing.Point(30, 260);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(205, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Change your tracking method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(30, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "How will you track it?";
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblCategory.Location = new System.Drawing.Point(30, 426);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(81, 19);
            this.lblCategory.TabIndex = 22;
            this.lblCategory.Text = "CATEGORY";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblFrequency.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblFrequency.Location = new System.Drawing.Point(186, 426);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(89, 19);
            this.lblFrequency.TabIndex = 23;
            this.lblFrequency.Text = "FREQUENCY";
            // 
            // lblReminder
            // 
            this.lblReminder.AutoSize = true;
            this.lblReminder.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblReminder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblReminder.Location = new System.Drawing.Point(334, 426);
            this.lblReminder.Name = "lblReminder";
            this.lblReminder.Size = new System.Drawing.Size(115, 19);
            this.lblReminder.TabIndex = 24;
            this.lblReminder.Text = "REMINDER TIME";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblStartDate.Location = new System.Drawing.Point(30, 483);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(89, 19);
            this.lblStartDate.TabIndex = 25;
            this.lblStartDate.Text = "START DATE";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(153)))));
            this.lblEndDate.Location = new System.Drawing.Point(262, 483);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(75, 19);
            this.lblEndDate.TabIndex = 26;
            this.lblEndDate.Text = "END DATE";
            // 
            // pnlSep1
            // 
            this.pnlSep1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.pnlSep1.Location = new System.Drawing.Point(30, 82);
            this.pnlSep1.Name = "pnlSep1";
            this.pnlSep1.Size = new System.Drawing.Size(460, 1);
            this.pnlSep1.TabIndex = 30;
            // 
            // pnlSep2
            // 
            this.pnlSep2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.pnlSep2.Location = new System.Drawing.Point(30, 220);
            this.pnlSep2.Name = "pnlSep2";
            this.pnlSep2.Size = new System.Drawing.Size(460, 1);
            this.pnlSep2.TabIndex = 31;
            // 
            // pnlSep3
            // 
            this.pnlSep3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.pnlSep3.Location = new System.Drawing.Point(30, 414);
            this.pnlSep3.Name = "pnlSep3";
            this.pnlSep3.Size = new System.Drawing.Size(460, 1);
            this.pnlSep3.TabIndex = 32;
            // 
            // pnlSep4
            // 
            this.pnlSep4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(80)))));
            this.pnlSep4.Location = new System.Drawing.Point(30, 540);
            this.pnlSep4.Name = "pnlSep4";
            this.pnlSep4.Size = new System.Drawing.Size(460, 1);
            this.pnlSep4.TabIndex = 33;
            // 
            // EditHabitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(17)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(520, 605);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtHabitName);
            this.Controls.Add(this.pnlSep1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlIntent);
            this.Controls.Add(this.pnlSep2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pnlTracking);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.nudTarget);
            this.Controls.Add(this.lblUnit);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.pnlSep3);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblFrequency);
            this.Controls.Add(this.cmbPeriod);
            this.Controls.Add(this.lblReminder);
            this.Controls.Add(this.cmbTimeRange);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.pnlSep4);
            this.Controls.Add(this.btnCancelEdit);
            this.Controls.Add(this.btnSaveEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "EditHabitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Habit";
            this.Load += new System.EventHandler(this.EditHabitForm_Load);
            this.pnlIntent.ResumeLayout(false);
            this.pnlIntent.PerformLayout();
            this.pnlTracking.ResumeLayout(false);
            this.pnlTracking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlIntent;
        private System.Windows.Forms.RadioButton rbBuild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbBreak;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlTracking;
        private System.Windows.Forms.RadioButton rbBinary;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbQuantitative;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtHabitName;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.NumericUpDown nudTarget;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Button btnSaveEdit;
        private System.Windows.Forms.Button btnCancelEdit;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbTimeRange;
        private System.Windows.Forms.ComboBox cmbPeriod;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.Label lblReminder;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Panel pnlSep1;
        private System.Windows.Forms.Panel pnlSep2;
        private System.Windows.Forms.Panel pnlSep3;
        private System.Windows.Forms.Panel pnlSep4;
    }
}