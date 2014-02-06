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
        internal const string HIPStopParams = "/stop epolicy3.5";
        internal const string HIPStartParams = "/start";

        //internal const string PingHosts = "DC01,DC02,DRDC01,DRDC02";
        //internal const string PingHosts = "10.128.33.177,10.128.33.170,10.116.10.10,10.116.10.11";
        internal const string PingHosts = "1.2.3.4";

        internal const string TestURL = "http://www.meridiancu.ca/Pages/welcome.aspx"; //url to test
        internal const string URLContentCheckRegEx = "asdfMeridian"; //use any regex
        internal const int TestURLTimeout = 4000; //milliseconds for web site to load

        internal const int TimeOut = 1; //firewall re-enable seconds
        internal const int TimeOutWarnInterval = 1; //minutes between alerts
    }
}
