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
            //pings have failed, so they aren't on the domain.. but lets check to see if we can get to meridiancu.ca
            //without having to disable HIPS.  If they are behind a captive portal or hotspot they may need to login.
            var isOnline = WebHelper.HasWebTraffic();
            if (isOnline)
            {
                //Website is reachable as required, exiting enable hips just to make sure it's enabled.
                Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStartParams);
                return;
            }
            //Website is not reachable or is not sending data back as expected.
            //It is possible that they need to log into a captive portal (hotspot)
            //disable hips and tell user to log into the network.
            Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStopParams);
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
                Thread.Sleep(50); //don't chew up resources
            } while (Globals.AlertStart != null && (DateTime.Now - Globals.AlertStart.Value).TotalMinutes < Constants.TimeOut);
        }

        static void AlertTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Globals.AlertStart == null)
                return;

            var resp = PingHelper.PingHosts(Constants.PingHosts.Split(',').ToList());
            if (resp.HasValue) //back on the domain
            {
                Globals.AlertTimer.Stop();
                Utils.HideAlert();
                Globals.AlertStart = null;
                return;
            }

            var isOnline = WebHelper.HasWebTraffic();
            if (isOnline || (DateTime.Now - Globals.AlertStart.Value).TotalMinutes >= Constants.TimeOut)
            {
                Globals.AlertTimer.Stop();
                Utils.HideAlert();
                Globals.AlertStart = null;
            }

            else
                Utils.ShowAlert(false);
        }
    }
}
