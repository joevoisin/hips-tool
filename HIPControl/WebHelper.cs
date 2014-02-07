using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;

namespace HIPControl
{
    internal class WebHelper
    {
        public static bool HasWebTraffic()
        {
            try
            {
                var req = WebRequest.Create(Constants.TestURL);
                req.Timeout = Constants.TestURLTimeout;

                var resp = req.GetResponse();

                using (var stream = resp.GetResponseStream())
                {
                    if (stream == null)
                        return false;

                    var reader = new StreamReader(stream, Encoding.UTF8);
                    var responseString = reader.ReadToEnd();

                    responseString = responseString.Replace("\r", "");
                    responseString = responseString.Replace("\n", "");
                    responseString = responseString.Replace("\t", "");
                    var test = new Regex(Constants.URLContentCheckRegEx);
                    return test.IsMatch(responseString);
               }
            }
            catch
            { }
            return false;
        }
    }
}
