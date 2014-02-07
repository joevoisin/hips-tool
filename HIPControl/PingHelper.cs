using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;

namespace HIPControl
{
    internal class PingHelper
    {
        private const string Data = "abcdefghijklmnopqrstuvwxyz123456";
        internal static long? PingHosts(List<string> hosts)
        {
            foreach (var host in hosts)
            {
                var ping = new Ping();
                var opt = new PingOptions {DontFragment = false};
                var buffer = Encoding.ASCII.GetBytes(Data);

                try
                {
                    var reply = ping.Send(host, 120, buffer, opt);
                    System.Console.WriteLine(reply);
                    if (reply != null && reply.Status == IPStatus.Success)
                        return reply.RoundtripTime;
                }
                catch 
                { }
            }
            return null;
        }
    }
}
