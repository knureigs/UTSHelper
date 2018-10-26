namespace UTSHelper
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.utsControl1 = new UTSHelper.UTSControl();
            this.SuspendLayout();
            // 
            // utsControl1
            // 
            this.utsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.utsControl1.Location = new System.Drawing.Point(0, 0);
            this.utsControl1.Name = "utsControl1";
            this.utsControl1.Size = new System.Drawing.Size(784, 438);
            this.utsControl1.TabIndex = 0;
            this.utsControl1.UTSController = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 438);
            this.Controls.Add(this.utsControl1);
            this.Name = "MainForm";
            this.Text = "University Timesheet Helper";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UTSControl utsControl1;
    }
}

