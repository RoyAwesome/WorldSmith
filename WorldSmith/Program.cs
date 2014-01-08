using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
            assets.ShowDialog(AssetLoadingDialog.InitialLoad);
            if (Properties.Settings.Default.AddonPath != "")
            {
                assets = new AssetLoadingDialog();
                assets.ShowDialog(AssetLoadingDialog.AddonLoadTasks);
            }
            Application.ApplicationExit += Application_ApplicationExit;

            Application.Run(new MainForm());

            Properties.Settings.Default.Save();


        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }      
    }
}
