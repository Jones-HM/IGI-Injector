using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace IGI_Injector
{
    static class MainClass
    {
        [STAThread]
        static void Main()
        {
            try
            {
                bool instanceCount = false;
                Mutex mutex = null;
                var projAppName = AppDomain.CurrentDomain.FriendlyName;
                AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnAppExit);

                mutex = new Mutex(true, projAppName, out instanceCount);
                if (instanceCount)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new IGIInjectorUI());
                    mutex.ReleaseMutex();
                }
                else
                {
                    Utils.ShowSystemFatalError("IGI Injector is already running");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowSystemFatalError("Exception:" + ex.Message + "\nStack: " + ex.StackTrace);
            }
        }

        private static void OnAppExit(object sender, EventArgs e)
        {
            Utils.CreateConfig(Utils.cfgFile);
        }
    }
}
