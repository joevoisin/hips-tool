using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HIPControl
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                switch (arg.ToLower())
                {
                    case "-shutdown":
                        Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStopParams);
                        return;
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Controller.Run();
            Utils.CleanUp();
            Utils.RunProcessSync(Constants.HIPControlPath, Constants.HIPStartParams);
        }
    }
}
