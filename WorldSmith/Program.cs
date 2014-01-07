using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
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

           
            Application.Run(new MainForm());
        }
    }
}
