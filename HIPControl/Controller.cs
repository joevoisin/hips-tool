using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace HIPControl
{
    internal class Controller
    {

        public static void Run()
        {
            //ping hosts
            var resp = PingHelper.PingHosts(new List<string>(Constants.PingHosts.Split(',')));
            if (resp.HasValue)
                return;

            Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStopParams);

            var isOnline = WebHelper.HasWebTraffic();
            if (isOnline)
            {
                Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStartParams);
                return;
            }
            Globals.AlertStart = DateTime.Now;

            Globals.AlertTimer = new Timer(Constants.RecheckInterval * 1000);
            Globals.AlertTimer.Enabled = true;
            Globals.AlertTimer.AutoReset = true;
            Globals.AlertTimer.Elapsed += AlertTimer_Elapsed;
            Globals.AlertTimer.Start();
            Utils.ShowAlert(true);

            do
            {
                Application.DoEvents();
                if (Globals.AlertStart == null) 
                    break;
            } while ((DateTime.Now - Globals.AlertStart.Value).TotalMinutes < Constants.TimeOut);


            Utils.HideAlert();

            if (Globals.AlertTimer != null)
            {
                Globals.AlertTimer.Stop();    
            }
        }

        static void AlertTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Globals.AlertStart == null)
            {
                Globals.AlertTimer.Stop();
                return;
            }

            var resp = PingHelper.PingHosts(new List<string>(Constants.PingHosts.Split(',')));
            if (resp.HasValue) //back on the domain
            {
                Globals.AlertTimer.Stop();
                Utils.HideAlert();
                Globals.AlertStart = null;
                //Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStartParams);
            }

            var isOnline = WebHelper.HasWebTraffic();
            if (isOnline || (DateTime.Now - Globals.AlertStart.Value).TotalMinutes >= Constants.TimeOut)
            {
                Globals.AlertTimer.Stop();
                Utils.HideAlert();
                Globals.AlertStart = null;
                //Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStartParams);

            }
            else
            {
                Utils.ShowAlert(false);
            }

        }

    }
}
