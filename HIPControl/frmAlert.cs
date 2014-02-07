using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIPControl
{
    public partial class frmAlert : Form
    {
        public frmAlert()
        {
            InitializeComponent();
        }

        public frmAlert(string Message) : this()
        {
            LabelInstruction1.Text = Message;
        }

        public string WarningText { get { return LabelInstruction1.Text; } set { LabelInstruction1.Text = value; } }

        private void BtnWorkOffline_Click(object sender, EventArgs e)
        {
            Globals.AlertTimer.Stop();
            Utils.HideAlert();
            Globals.AlertStart = null;
        }

        private void frmAlert_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Globals.AlertStart == null)
                return;

            var remain = (Globals.AlertStart.Value.AddMinutes(Constants.TimeOut) - DateTime.Now);

            lblCountdown.Text = String.Format("Time Remaining: {0:00}:{1:00}", remain.Minutes, remain.Seconds);
        }
        private void label1_Click(object sender, EventArgs e)
        { }
        private void lblMessage_Click(object sender, EventArgs e)
        { }
    }
}
