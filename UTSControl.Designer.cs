namespace UTSHelper
{
    partial class UTSControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.facultyComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.setDatesCurrentMonthButton = new System.Windows.Forms.Button();
            this.setDatesNextMonthButton = new System.Windows.Forms.Button();
            this.setDatesButton = new System.Windows.Forms.Button();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.getTimesheetButton = new System.Windows.Forms.Button();
            this.getConsultationButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.timeSheetTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.filterSubjectComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 110;
            this.label1.Text = "Факультет";
            // 
            // facultyComboBox
            // 
            this.facultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.facultyComboBox.FormattingEnabled = true;
            this.facultyComboBox.Location = new System.Drawing.Point(6, 23);
            this.facultyComboBox.Name = "facultyComboBox";
            this.facultyComboBox.Size = new System.Drawing.Size(403, 21);
            this.facultyComboBox.TabIndex = 1;
            this.facultyComboBox.SelectedIndexChanged += new System.EventHandler(this.facultyComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Кафедра";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(6, 66);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(138, 21);
            this.departmentComboBox.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 110;
            this.label3.Text = "Преподаватель";
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(6, 116);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(138, 21);
            this.teacherComboBox.TabIndex = 3;
            this.teacherComboBox.SelectedIndexChanged += new System.EventHandler(this.teacherComboBox_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.setDatesCurrentMonthButton);
            this.groupBox1.Controls.Add(this.setDatesNextMonthButton);
            this.groupBox1.Controls.Add(this.setDatesButton);
            this.groupBox1.Controls.Add(this.toDatePicker);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.fromDatePicker);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(6, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 193);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Временные рамки";
            // 
            // setDatesCurrentMonthButton
            // 
            this.setDatesCurrentMonthButton.Location = new System.Drawing.Point(6, 71);
            this.setDatesCurrentMonthButton.Name = "setDatesCurrentMonthButton";
            this.setDatesCurrentMonthButton.Size = new System.Drawing.Size(126, 38);
            this.setDatesCurrentMonthButton.TabIndex = 16;
            this.setDatesCurrentMonthButton.Text = "С 1-го по 31-е текущего месяца";
            this.setDatesCurrentMonthButton.UseVisualStyleBackColor = true;
            this.setDatesCurrentMonthButton.Click += new System.EventHandler(this.setDatesCurrentMonthButton_Click);
            // 
            // setDatesNextMonthButton
            // 
            this.setDatesNextMonthButton.Location = new System.Drawing.Point(6, 115);
            this.setDatesNextMonthButton.Name = "setDatesNextMonthButton";
            this.setDatesNextMonthButton.Size = new System.Drawing.Size(126, 41);
            this.setDatesNextMonthButton.TabIndex = 16;
            this.setDatesNextMonthButton.Text = "С 1-го по 31-е следующего месяца";
            this.setDatesNextMonthButton.UseVisualStyleBackColor = true;
            this.setDatesNextMonthButton.Click += new System.EventHandler(this.setDatesNextMonthButton_Click);
            // 
            // setDatesButton
            // 
            this.setDatesButton.Location = new System.Drawing.Point(6, 162);
            this.setDatesButton.Name = "setDatesButton";
            this.setDatesButton.Size = new System.Drawing.Size(126, 23);
            this.setDatesButton.TabIndex = 16;
            this.setDatesButton.Text = "С 26-го по 25-е";
            this.setDatesButton.UseVisualStyleBackColor = true;
            this.setDatesButton.Click += new System.EventHandler(this.setDatesButton_Click);
            // 
            // toDatePicker
            // 
            this.toDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.toDatePicker.Location = new System.Drawing.Point(33, 45);
            this.toDatePicker.Name = "toDatePicker";
            this.toDatePicker.Size = new System.Drawing.Size(99, 20);
            this.toDatePicker.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(25, 13);
            this.label5.TabIndex = 110;
            this.label5.Text = "До:";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(33, 19);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(99, 20);
            this.fromDatePicker.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 110;
            this.label4.Text = "От:";
            // 
            // getTimesheetButton
            // 
            this.getTimesheetButton.Location = new System.Drawing.Point(12, 347);
            this.getTimesheetButton.Name = "getTimesheetButton";
            this.getTimesheetButton.Size = new System.Drawing.Size(126, 36);
            this.getTimesheetButton.TabIndex = 17;
            this.getTimesheetButton.Text = "Получить";
            this.getTimesheetButton.UseVisualStyleBackColor = true;
            this.getTimesheetButton.Click += new System.EventHandler(this.getTimesheetButton_Click);
            // 
            // getConsultationButton
            // 
            this.getConsultationButton.Enabled = false;
            this.getConsultationButton.Location = new System.Drawing.Point(12, 389);
            this.getConsultationButton.Name = "getConsultationButton";
            this.getConsultationButton.Size = new System.Drawing.Size(126, 23);
            this.getConsultationButton.TabIndex = 18;
            this.getConsultationButton.Text = "Консультации";
            this.getConsultationButton.UseVisualStyleBackColor = true;
            this.getConsultationButton.Visible = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 488);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(601, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(118, 17);
            this.statusStripLabel.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.getConsultationButton);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.getTimesheetButton);
            this.splitContainer1.Panel1.Controls.Add(this.departmentComboBox);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.teacherComboBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(601, 488);
            this.splitContainer1.SplitterDistance = 155;
            this.splitContainer1.TabIndex = 61;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.facultyComboBox);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.timeSheetTextBox);
            this.splitContainer2.Panel2.Controls.Add(this.label7);
            this.splitContainer2.Panel2.Controls.Add(this.label8);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.filterTypeComboBox);
            this.splitContainer2.Panel2.Controls.Add(this.filterSubjectComboBox);
            this.splitContainer2.Size = new System.Drawing.Size(442, 488);
            this.splitContainer2.SplitterDistance = 83;
            this.splitContainer2.TabIndex = 0;
            // 
            // timeSheetTextBox
            // 
            this.timeSheetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timeSheetTextBox.Enabled = false;
            this.timeSheetTextBox.Location = new System.Drawing.Point(7, 72);
            this.timeSheetTextBox.Multiline = true;
            this.timeSheetTextBox.Name = "timeSheetTextBox";
            this.timeSheetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timeSheetTextBox.Size = new System.Drawing.Size(414, 195);
            this.timeSheetTextBox.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(4, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 111;
            this.label7.Text = "Расписание";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Enabled = false;
            this.label8.Location = new System.Drawing.Point(224, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 111;
            this.label8.Text = "Тип занятия";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Enabled = false;
            this.label6.Location = new System.Drawing.Point(4, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 111;
            this.label6.Text = "Предмет";
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeComboBox.Enabled = false;
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Location = new System.Drawing.Point(226, 28);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(195, 21);
            this.filterTypeComboBox.TabIndex = 9;
            this.filterTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.filterTypeComboBox_SelectedIndexChanged);
            // 
            // filterSubjectComboBox
            // 
            this.filterSubjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterSubjectComboBox.Enabled = false;
            this.filterSubjectComboBox.FormattingEnabled = true;
            this.filterSubjectComboBox.Location = new System.Drawing.Point(6, 28);
            this.filterSubjectComboBox.Name = "filterSubjectComboBox";
            this.filterSubjectComboBox.Size = new System.Drawing.Size(195, 21);
            this.filterSubjectComboBox.TabIndex = 8;
            this.filterSubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.filterSubjectComboBox_SelectedIndexChanged);
            // 
            // UTSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Name = "UTSControl";
            this.Size = new System.Drawing.Size(601, 510);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox facultyComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button setDatesButton;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button getTimesheetButton;
        private System.Windows.Forms.Button getConsultationButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.TextBox timeSheetTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.ComboBox filterSubjectComboBox;
        private System.Windows.Forms.Button setDatesCurrentMonthButton;
        private System.Windows.Forms.Button setDatesNextMonthButton;
    }
}
