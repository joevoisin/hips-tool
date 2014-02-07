namespace HIPControl
{
    partial class frmAlert
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
            this.components = new System.ComponentModel.Container();
            this.lblCountdown = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LabelInstruction1 = new System.Windows.Forms.Label();
            this.LabInstruction2 = new System.Windows.Forms.Label();
            this.LabelImportantNotice = new System.Windows.Forms.Label();
            this.WorkOffineButton = new System.Windows.Forms.Button();
            this.LabelOfflineWarning = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCountdown
            // 
            this.lblCountdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountdown.Location = new System.Drawing.Point(7, 166);
            this.lblCountdown.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountdown.Name = "lblCountdown";
            this.lblCountdown.Size = new System.Drawing.Size(228, 30);
            this.lblCountdown.TabIndex = 2;
            this.lblCountdown.Text = "Time Remaining: ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LabelInstruction1
            // 
            this.LabelInstruction1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInstruction1.Location = new System.Drawing.Point(0, 26);
            this.LabelInstruction1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelInstruction1.Name = "LabelInstruction1";
            this.LabelInstruction1.Size = new System.Drawing.Size(378, 26);
            this.LabelInstruction1.TabIndex = 0;
            this.LabelInstruction1.Text = "Connect to the internet before starting VDI.";
            this.LabelInstruction1.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // LabInstruction2
            // 
            this.LabInstruction2.Location = new System.Drawing.Point(3, 46);
            this.LabInstruction2.Name = "LabInstruction2";
            this.LabInstruction2.Size = new System.Drawing.Size(375, 77);
            this.LabInstruction2.TabIndex = 3;
            this.LabInstruction2.Text = "If you are connecting from a hotel you may need to log into the Hotel hotspot bef" +
    "ore access is granted.   You have 5 minutes to connect before access controls ar" +
    "e engaged.";
            this.LabInstruction2.Click += new System.EventHandler(this.label1_Click);
            // 
            // LabelImportantNotice
            // 
            this.LabelImportantNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelImportantNotice.ForeColor = System.Drawing.Color.Red;
            this.LabelImportantNotice.Location = new System.Drawing.Point(0, 3);
            this.LabelImportantNotice.Name = "LabelImportantNotice";
            this.LabelImportantNotice.Size = new System.Drawing.Size(378, 23);
            this.LabelImportantNotice.TabIndex = 4;
            this.LabelImportantNotice.Text = "Important Notice";
            this.LabelImportantNotice.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WorkOffineButton
            // 
            this.WorkOffineButton.Location = new System.Drawing.Point(283, 140);
            this.WorkOffineButton.Name = "WorkOffineButton";
            this.WorkOffineButton.Size = new System.Drawing.Size(81, 51);
            this.WorkOffineButton.TabIndex = 5;
            this.WorkOffineButton.Text = "Work Offline";
            this.WorkOffineButton.UseVisualStyleBackColor = true;
            // 
            // LabelOfflineWarning
            // 
            this.LabelOfflineWarning.Location = new System.Drawing.Point(2, 118);
            this.LabelOfflineWarning.Name = "LabelOfflineWarning";
            this.LabelOfflineWarning.Size = new System.Drawing.Size(375, 39);
            this.LabelOfflineWarning.TabIndex = 6;
            this.LabelOfflineWarning.Text = "If you click \'Work Offline\' the counter will stop immediately and access controls" +
    " will be enabled.";
            // 
            // frmAlert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.ClientSize = new System.Drawing.Size(378, 201);
            this.Controls.Add(this.WorkOffineButton);
            this.Controls.Add(this.LabelOfflineWarning);
            this.Controls.Add(this.LabelImportantNotice);
            this.Controls.Add(this.lblCountdown);
            this.Controls.Add(this.LabInstruction2);
            this.Controls.Add(this.LabelInstruction1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAlert";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Important Notice";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmAlert_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCountdown;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label LabelInstruction1;
        private System.Windows.Forms.Label LabInstruction2;
        private System.Windows.Forms.Label LabelImportantNotice;
        private System.Windows.Forms.Button WorkOffineButton;
        private System.Windows.Forms.Label LabelOfflineWarning;
    }
}

