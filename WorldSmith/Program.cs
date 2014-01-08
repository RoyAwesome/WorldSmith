using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs;

namespace WorldSmith
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Properties.Settings.Default.ranonce)
            {
                Form initial = new InitialSetup();
                initial.ShowDialog();
                Properties.Settings.Default.ranonce = true;
                Properties.Settings.Default.Save();
            }

            AssetLoadingDialog assets = new AssetLoadingDialog();
            assets.ShowDialog();
            Application.ApplicationExit += Application_ApplicationExit;

            Application.Run(new MainForm());

            
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }
    }
}
