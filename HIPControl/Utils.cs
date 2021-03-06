﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HIPControl
{
    internal class Utils
    {
        internal static void RunProcessSync(string Path, string Args)
        {
            var options = new ProcessStartInfo();
            options.Arguments = Args;
            options.FileName = Path;
            options.CreateNoWindow = true;
            options.RedirectStandardOutput = false;
            options.WindowStyle = ProcessWindowStyle.Hidden;
            //MessageBox.Show(Path + " " + Args);
            try
            {
                var proc = Process.Start(options);
                if (proc != null)
                    proc.WaitForExit();
            }
            catch (Exception)
            { }
        }

        internal static void ShowAlert(bool Reset)
        {
            if (Globals.AlertForm == null || Globals.AlertForm.IsDisposed || !Globals.AlertForm.Visible)
                Globals.AlertForm = new frmAlert();
            if (!Globals.AlertForm.Visible)
                Application.Run(Globals.AlertForm);
        }

        internal static void HideAlert()
        {
            if (Globals.AlertForm != null && !Globals.AlertForm.IsDisposed)
            {
                if (Globals.AlertForm.InvokeRequired)
                {
                    Globals.AlertForm.Invoke(new Action(HideAlert));
                    return;
                }

                Globals.AlertForm.Close();  
            }
                
            Globals.AlertForm = null;
        }

        internal static void CleanUp()
        {
            Globals.AlertStart = null;

            if (Globals.AlertTimer != null)
            {
                Globals.AlertTimer.Stop();
                Globals.AlertTimer = null;
            }
            HideAlert();
        }

        internal static bool HasGateway()
        {
            return System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
        }

    }
}
