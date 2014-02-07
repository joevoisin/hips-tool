using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIPControl
{
    internal class Constants
    {
        internal const string HIPControlPath = @"C:\Program Files\McAfee\Host Intrusion Prevention\ClientControl.exe";
        internal const string HIPStopParams = "/stop epolicy3.5"; //change 'epolicy3.5' to actual password not the test password.
        internal const string HIPStartParams = "/start";

        internal const string PingHosts = "10.128.33.1,10.128.34.1,10.116.10.1";

        internal const string TestURL = "http://www.meridiancu.ca"; //url to test
        internal const string URLContentCheckRegEx = "<title>Meridian Credit Union</title>"; //use any regex
        internal const int TestURLTimeout = 5000; //milliseconds for web site to load

        internal const int TimeOut = 5; //firewall re-enable minutes
        internal const int RecheckInterval = 20; //seconds between rechecking for ICMP and webserver.
    }
}
