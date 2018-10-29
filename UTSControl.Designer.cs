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
            this.facultyLabel = new System.Windows.Forms.Label();
            this.facultyComboBox = new System.Windows.Forms.ComboBox();
            this.departmentLabel = new System.Windows.Forms.Label();
            this.departmentComboBox = new System.Windows.Forms.ComboBox();
            this.teacherLabel = new System.Windows.Forms.Label();
            this.teacherComboBox = new System.Windows.Forms.ComboBox();
            this.dateFramesGroupBox = new System.Windows.Forms.GroupBox();
            this.setDatesCurrentMonthButton = new System.Windows.Forms.Button();
            this.setDatesNextMonthButton = new System.Windows.Forms.Button();
            this.setDatesButton = new System.Windows.Forms.Button();
            this.toDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dateToLabel = new System.Windows.Forms.Label();
            this.fromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.dateFromLabel = new System.Windows.Forms.Label();
            this.getTimesheetButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timesheetSettingsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.cistGroupBox = new System.Windows.Forms.GroupBox();
            this.forcedNetCheckBox = new System.Windows.Forms.CheckBox();
            this.timesheetSplitContainer = new System.Windows.Forms.SplitContainer();
            this.timesheetTextBox = new System.Windows.Forms.TextBox();
            this.subjectLabel = new System.Windows.Forms.Label();
            this.timesheetLabel = new System.Windows.Forms.Label();
            this.filterSubjectComboBox = new System.Windows.Forms.ComboBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.filterTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tasklistTextBox = new System.Windows.Forms.TextBox();
            this.tasklistLabel = new System.Windows.Forms.Label();
            this.getTasklistButton = new System.Windows.Forms.Button();
            this.orderTopLastCheckBox = new System.Windows.Forms.CheckBox();
            this.dateFramesGroupBox.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.timesheetSettingsSplitContainer.Panel1.SuspendLayout();
            this.timesheetSettingsSplitContainer.Panel2.SuspendLayout();
            this.timesheetSettingsSplitContainer.SuspendLayout();
            this.cistGroupBox.SuspendLayout();
            this.timesheetSplitContainer.Panel1.SuspendLayout();
            this.timesheetSplitContainer.Panel2.SuspendLayout();
            this.timesheetSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // facultyLabel
            // 
            this.facultyLabel.AutoSize = true;
            this.facultyLabel.Location = new System.Drawing.Point(6, 34);
            this.facultyLabel.Name = "facultyLabel";
            this.facultyLabel.Size = new System.Drawing.Size(66, 13);
            this.facultyLabel.TabIndex = 110;
            this.facultyLabel.Text = "Факультет:";
            // 
            // facultyComboBox
            // 
            this.facultyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.facultyComboBox.FormattingEnabled = true;
            this.facultyComboBox.Location = new System.Drawing.Point(9, 50);
            this.facultyComboBox.Name = "facultyComboBox";
            this.facultyComboBox.Size = new System.Drawing.Size(138, 21);
            this.facultyComboBox.TabIndex = 1;
            this.facultyComboBox.SelectedIndexChanged += new System.EventHandler(this.facultyComboBox_SelectedIndexChanged);
            // 
            // departmentLabel
            // 
            this.departmentLabel.AutoSize = true;
            this.departmentLabel.Location = new System.Drawing.Point(6, 80);
            this.departmentLabel.Name = "departmentLabel";
            this.departmentLabel.Size = new System.Drawing.Size(55, 13);
            this.departmentLabel.TabIndex = 110;
            this.departmentLabel.Text = "Кафедра:";
            // 
            // departmentComboBox
            // 
            this.departmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentComboBox.FormattingEnabled = true;
            this.departmentComboBox.Location = new System.Drawing.Point(9, 96);
            this.departmentComboBox.Name = "departmentComboBox";
            this.departmentComboBox.Size = new System.Drawing.Size(138, 21);
            this.departmentComboBox.TabIndex = 12;
            // 
            // teacherLabel
            // 
            this.teacherLabel.AutoSize = true;
            this.teacherLabel.Location = new System.Drawing.Point(6, 124);
            this.teacherLabel.Name = "teacherLabel";
            this.teacherLabel.Size = new System.Drawing.Size(89, 13);
            this.teacherLabel.TabIndex = 110;
            this.teacherLabel.Text = "Преподаватель:";
            // 
            // teacherComboBox
            // 
            this.teacherComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.teacherComboBox.FormattingEnabled = true;
            this.teacherComboBox.Location = new System.Drawing.Point(9, 140);
            this.teacherComboBox.Name = "teacherComboBox";
            this.teacherComboBox.Size = new System.Drawing.Size(138, 21);
            this.teacherComboBox.TabIndex = 3;
            this.teacherComboBox.SelectedIndexChanged += new System.EventHandler(this.teacherComboBox_SelectedIndexChanged);
            // 
            // dateFramesGroupBox
            // 
            this.dateFramesGroupBox.Controls.Add(this.setDatesCurrentMonthButton);
            this.dateFramesGroupBox.Controls.Add(this.setDatesNextMonthButton);
            this.dateFramesGroupBox.Controls.Add(this.setDatesButton);
            this.dateFramesGroupBox.Controls.Add(this.toDatePicker);
            this.dateFramesGroupBox.Controls.Add(this.dateToLabel);
            this.dateFramesGroupBox.Controls.Add(this.fromDatePicker);
            this.dateFramesGroupBox.Controls.Add(this.dateFromLabel);
            this.dateFramesGroupBox.Location = new System.Drawing.Point(9, 181);
            this.dateFramesGroupBox.Name = "dateFramesGroupBox";
            this.dateFramesGroupBox.Size = new System.Drawing.Size(138, 193);
            this.dateFramesGroupBox.TabIndex = 20;
            this.dateFramesGroupBox.TabStop = false;
            this.dateFramesGroupBox.Text = "Временные рамки";
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
            // dateToLabel
            // 
            this.dateToLabel.AutoSize = true;
            this.dateToLabel.Location = new System.Drawing.Point(9, 48);
            this.dateToLabel.Name = "dateToLabel";
            this.dateToLabel.Size = new System.Drawing.Size(25, 13);
            this.dateToLabel.TabIndex = 110;
            this.dateToLabel.Text = "До:";
            // 
            // fromDatePicker
            // 
            this.fromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fromDatePicker.Location = new System.Drawing.Point(33, 19);
            this.fromDatePicker.Name = "fromDatePicker";
            this.fromDatePicker.Size = new System.Drawing.Size(99, 20);
            this.fromDatePicker.TabIndex = 14;
            // 
            // dateFromLabel
            // 
            this.dateFromLabel.AutoSize = true;
            this.dateFromLabel.Location = new System.Drawing.Point(9, 22);
            this.dateFromLabel.Name = "dateFromLabel";
            this.dateFromLabel.Size = new System.Drawing.Size(23, 13);
            this.dateFromLabel.TabIndex = 110;
            this.dateFromLabel.Text = "От:";
            // 
            // getTimesheetButton
            // 
            this.getTimesheetButton.Location = new System.Drawing.Point(7, 10);
            this.getTimesheetButton.Name = "getTimesheetButton";
            this.getTimesheetButton.Size = new System.Drawing.Size(79, 79);
            this.getTimesheetButton.TabIndex = 17;
            this.getTimesheetButton.Text = "Получить расписание занятий для табеля";
            this.getTimesheetButton.UseVisualStyleBackColor = true;
            this.getTimesheetButton.Click += new System.EventHandler(this.getTimesheetButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 418);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(704, 22);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(118, 17);
            this.statusStripLabel.Text = "toolStripStatusLabel1";
            // 
            // timesheetSettingsSplitContainer
            // 
            this.timesheetSettingsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timesheetSettingsSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.timesheetSettingsSplitContainer.IsSplitterFixed = true;
            this.timesheetSettingsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.timesheetSettingsSplitContainer.Name = "timesheetSettingsSplitContainer";
            // 
            // timesheetSettingsSplitContainer.Panel1
            // 
            this.timesheetSettingsSplitContainer.Panel1.Controls.Add(this.cistGroupBox);
            // 
            // timesheetSettingsSplitContainer.Panel2
            // 
            this.timesheetSettingsSplitContainer.Panel2.Controls.Add(this.timesheetSplitContainer);
            this.timesheetSettingsSplitContainer.Size = new System.Drawing.Size(704, 418);
            this.timesheetSettingsSplitContainer.SplitterDistance = 173;
            this.timesheetSettingsSplitContainer.TabIndex = 61;
            // 
            // cistGroupBox
            // 
            this.cistGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cistGroupBox.Controls.Add(this.forcedNetCheckBox);
            this.cistGroupBox.Controls.Add(this.dateFramesGroupBox);
            this.cistGroupBox.Controls.Add(this.facultyLabel);
            this.cistGroupBox.Controls.Add(this.teacherComboBox);
            this.cistGroupBox.Controls.Add(this.facultyComboBox);
            this.cistGroupBox.Controls.Add(this.teacherLabel);
            this.cistGroupBox.Controls.Add(this.departmentComboBox);
            this.cistGroupBox.Controls.Add(this.departmentLabel);
            this.cistGroupBox.Location = new System.Drawing.Point(8, 8);
            this.cistGroupBox.Name = "cistGroupBox";
            this.cistGroupBox.Size = new System.Drawing.Size(157, 403);
            this.cistGroupBox.TabIndex = 111;
            this.cistGroupBox.TabStop = false;
            this.cistGroupBox.Text = "Параметры расписания преподавателей";
            // 
            // forcedNetCheckBox
            // 
            this.forcedNetCheckBox.AutoSize = true;
            this.forcedNetCheckBox.Location = new System.Drawing.Point(9, 380);
            this.forcedNetCheckBox.Name = "forcedNetCheckBox";
            this.forcedNetCheckBox.Size = new System.Drawing.Size(137, 17);
            this.forcedNetCheckBox.TabIndex = 111;
            this.forcedNetCheckBox.Text = "Не использовать кеш";
            this.forcedNetCheckBox.UseVisualStyleBackColor = true;
            // 
            // timesheetSplitContainer
            // 
            this.timesheetSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timesheetSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.timesheetSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.timesheetSplitContainer.Name = "timesheetSplitContainer";
            // 
            // timesheetSplitContainer.Panel1
            // 
            this.timesheetSplitContainer.Panel1.Controls.Add(this.getTimesheetButton);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.timesheetTextBox);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.subjectLabel);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.timesheetLabel);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.filterSubjectComboBox);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.typeLabel);
            this.timesheetSplitContainer.Panel1.Controls.Add(this.filterTypeComboBox);
            // 
            // timesheetSplitContainer.Panel2
            // 
            this.timesheetSplitContainer.Panel2.Controls.Add(this.orderTopLastCheckBox);
            this.timesheetSplitContainer.Panel2.Controls.Add(this.tasklistTextBox);
            this.timesheetSplitContainer.Panel2.Controls.Add(this.tasklistLabel);
            this.timesheetSplitContainer.Panel2.Controls.Add(this.getTasklistButton);
            this.timesheetSplitContainer.Size = new System.Drawing.Size(527, 418);
            this.timesheetSplitContainer.SplitterDistance = 300;
            this.timesheetSplitContainer.TabIndex = 0;
            // 
            // timesheetTextBox
            // 
            this.timesheetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timesheetTextBox.Enabled = false;
            this.timesheetTextBox.Location = new System.Drawing.Point(7, 113);
            this.timesheetTextBox.Multiline = true;
            this.timesheetTextBox.Name = "timesheetTextBox";
            this.timesheetTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.timesheetTextBox.Size = new System.Drawing.Size(290, 298);
            this.timesheetTextBox.TabIndex = 11;
            // 
            // subjectLabel
            // 
            this.subjectLabel.AutoSize = true;
            this.subjectLabel.Enabled = false;
            this.subjectLabel.Location = new System.Drawing.Point(90, 12);
            this.subjectLabel.Name = "subjectLabel";
            this.subjectLabel.Size = new System.Drawing.Size(55, 13);
            this.subjectLabel.TabIndex = 111;
            this.subjectLabel.Text = "Предмет:";
            // 
            // timesheetLabel
            // 
            this.timesheetLabel.AutoSize = true;
            this.timesheetLabel.Enabled = false;
            this.timesheetLabel.Location = new System.Drawing.Point(4, 97);
            this.timesheetLabel.Name = "timesheetLabel";
            this.timesheetLabel.Size = new System.Drawing.Size(115, 13);
            this.timesheetLabel.TabIndex = 111;
            this.timesheetLabel.Text = "Расписание занятий:";
            // 
            // filterSubjectComboBox
            // 
            this.filterSubjectComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterSubjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterSubjectComboBox.Enabled = false;
            this.filterSubjectComboBox.FormattingEnabled = true;
            this.filterSubjectComboBox.Location = new System.Drawing.Point(92, 28);
            this.filterSubjectComboBox.Name = "filterSubjectComboBox";
            this.filterSubjectComboBox.Size = new System.Drawing.Size(205, 21);
            this.filterSubjectComboBox.TabIndex = 8;
            this.filterSubjectComboBox.SelectedIndexChanged += new System.EventHandler(this.filterSubjectComboBox_SelectedIndexChanged);
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Enabled = false;
            this.typeLabel.Location = new System.Drawing.Point(90, 52);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(73, 13);
            this.typeLabel.TabIndex = 111;
            this.typeLabel.Text = "Тип занятия:";
            // 
            // filterTypeComboBox
            // 
            this.filterTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterTypeComboBox.Enabled = false;
            this.filterTypeComboBox.FormattingEnabled = true;
            this.filterTypeComboBox.Location = new System.Drawing.Point(92, 68);
            this.filterTypeComboBox.Name = "filterTypeComboBox";
            this.filterTypeComboBox.Size = new System.Drawing.Size(205, 21);
            this.filterTypeComboBox.TabIndex = 9;
            this.filterTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.filterTypeComboBox_SelectedIndexChanged);
            // 
            // tasklistTextBox
            // 
            this.tasklistTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tasklistTextBox.Location = new System.Drawing.Point(7, 113);
            this.tasklistTextBox.Multiline = true;
            this.tasklistTextBox.Name = "tasklistTextBox";
            this.tasklistTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tasklistTextBox.Size = new System.Drawing.Size(213, 298);
            this.tasklistTextBox.TabIndex = 11;
            // 
            // tasklistLabel
            // 
            this.tasklistLabel.AutoSize = true;
            this.tasklistLabel.Location = new System.Drawing.Point(10, 97);
            this.tasklistLabel.Name = "tasklistLabel";
            this.tasklistLabel.Size = new System.Drawing.Size(79, 13);
            this.tasklistLabel.TabIndex = 111;
            this.tasklistLabel.Text = "Список задач:";
            // 
            // getTasklistButton
            // 
            this.getTasklistButton.Location = new System.Drawing.Point(7, 10);
            this.getTasklistButton.Name = "getTasklistButton";
            this.getTasklistButton.Size = new System.Drawing.Size(79, 79);
            this.getTasklistButton.TabIndex = 111;
            this.getTasklistButton.Text = "Получить из расписания список задач";
            this.getTasklistButton.UseVisualStyleBackColor = true;
            this.getTasklistButton.Click += new System.EventHandler(this.getTasklistButton_Click);
            // 
            // orderTopLastCheckBox
            // 
            this.orderTopLastCheckBox.AutoSize = true;
            this.orderTopLastCheckBox.Checked = true;
            this.orderTopLastCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.orderTopLastCheckBox.Location = new System.Drawing.Point(92, 12);
            this.orderTopLastCheckBox.Name = "orderTopLastCheckBox";
            this.orderTopLastCheckBox.Size = new System.Drawing.Size(118, 17);
            this.orderTopLastCheckBox.TabIndex = 112;
            this.orderTopLastCheckBox.Text = "Вверху последние";
            this.orderTopLastCheckBox.UseVisualStyleBackColor = true;
            // 
            // UTSControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.timesheetSettingsSplitContainer);
            this.Controls.Add(this.statusStrip);
            this.MinimumSize = new System.Drawing.Size(200, 440);
            this.Name = "UTSControl";
            this.Size = new System.Drawing.Size(704, 440);
            this.dateFramesGroupBox.ResumeLayout(false);
            this.dateFramesGroupBox.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.timesheetSettingsSplitContainer.Panel1.ResumeLayout(false);
            this.timesheetSettingsSplitContainer.Panel2.ResumeLayout(false);
            this.timesheetSettingsSplitContainer.ResumeLayout(false);
            this.cistGroupBox.ResumeLayout(false);
            this.cistGroupBox.PerformLayout();
            this.timesheetSplitContainer.Panel1.ResumeLayout(false);
            this.timesheetSplitContainer.Panel1.PerformLayout();
            this.timesheetSplitContainer.Panel2.ResumeLayout(false);
            this.timesheetSplitContainer.Panel2.PerformLayout();
            this.timesheetSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label facultyLabel;
        private System.Windows.Forms.ComboBox facultyComboBox;
        private System.Windows.Forms.Label departmentLabel;
        private System.Windows.Forms.ComboBox departmentComboBox;
        private System.Windows.Forms.Label teacherLabel;
        private System.Windows.Forms.ComboBox teacherComboBox;
        private System.Windows.Forms.GroupBox dateFramesGroupBox;
        private System.Windows.Forms.Button setDatesButton;
        private System.Windows.Forms.DateTimePicker toDatePicker;
        private System.Windows.Forms.Label dateToLabel;
        private System.Windows.Forms.DateTimePicker fromDatePicker;
        private System.Windows.Forms.Label dateFromLabel;
        private System.Windows.Forms.Button getTimesheetButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer timesheetSettingsSplitContainer;
        private System.Windows.Forms.SplitContainer timesheetSplitContainer;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.TextBox timesheetTextBox;
        private System.Windows.Forms.Label timesheetLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label subjectLabel;
        private System.Windows.Forms.ComboBox filterTypeComboBox;
        private System.Windows.Forms.ComboBox filterSubjectComboBox;
        private System.Windows.Forms.Button setDatesCurrentMonthButton;
        private System.Windows.Forms.Button setDatesNextMonthButton;
        private System.Windows.Forms.Button getTasklistButton;
        private System.Windows.Forms.TextBox tasklistTextBox;
        private System.Windows.Forms.Label tasklistLabel;
        private System.Windows.Forms.GroupBox cistGroupBox;
        private System.Windows.Forms.CheckBox forcedNetCheckBox;
        private System.Windows.Forms.CheckBox orderTopLastCheckBox;
    }
}
