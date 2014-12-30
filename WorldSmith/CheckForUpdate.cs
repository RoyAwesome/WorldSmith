using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace WorldSmith
{
    public static class CheckForUpdate
    {
        const string UpdateURL = "http://rhoyne.cloudapp.net:8010/UpdateManifest.txt";
        public static void Check()
        {
            //Check for a version file.  
            if(!File.Exists("version.txt"))
            {
                Console.WriteLine("[UpdateChecker] There is no Version.txt in the worldsmith directory");
                Console.WriteLine("[UpdateChecker] This means you probably built Worldsmith from source.");
                Console.WriteLine("[UpdateChecker] If you didn't, Redownload Worldsmith from www.worldsmith.net");

                return;
            }

            //Get the version file
            UpdaterLib.Version v = UpdaterLib.Updater.GetCurrentVersion();

            //Check for an update with our version
            bool update = UpdaterLib.Updater.CheckForUpdate(v.Channel, v.BuildDate, UpdateURL);

            if(!update)
            {
                Console.WriteLine("[UpdateChecker] You are running the latest version of Worldsmith!");
                return;
            }

            if(MessageBox.Show("There is an update to Worldsmith!  Would you like to download it?", "Update Available", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //Close worldsmith
                
                //TODO: Close the project cleanly


                //Launch the updater
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = "WorldsmithUpdater.exe";
                p.Arguments = "update -c " + v.Channel.ToString() + " -u " + UpdateURL + " -l";
                p.UseShellExecute = true;
                Process.Start(p);

                Environment.Exit(0);

            }
            else
            {
                var builds = UpdaterLib.Updater.GetBuildsForChannel(v.Channel, UpdateURL);
                var b = builds.OrderByDescending(x => x.Date).FirstOrDefault();
                Console.WriteLine("[UpdateChecker] There is an update to worldsmith!  ");
                Console.WriteLine("[UpdateChecker] " + b.Version + " released on " + b.Date.ToShortDateString() + ".  Build notes: " + b.Notes);
            }


        }
    }
}
