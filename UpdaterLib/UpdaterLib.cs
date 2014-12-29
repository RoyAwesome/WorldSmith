using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace UpdaterLib
{
    public enum UpdateChannel
    {
        Stable,
        Beta,
        Dev,
    }

    static class Updater
    {

        public static Manifest GetChannelManifest(UpdateChannel channel)
        {
            string url = UpdaterLib.Properties.Settings.Default.ManifestLocation;

            Manifest[] Manifests = JsonConvert.DeserializeObject<Manifest[]>(QuickDownloadJson(url));

            Manifest chn = Manifests.FirstOrDefault(x => x.Channel == channel.ToString());

            return chn;
        }

        public static IEnumerable<Build> GetBuildsForChannel(UpdateChannel channel)
        {
            Manifest mn = GetChannelManifest(channel);

            Build[] Builds = JsonConvert.DeserializeObject<Build[]>(QuickDownloadJson(mn.BuildListURL));

            return Builds;

        }

        public static bool CheckForUpdate(UpdateChannel channel, DateTime LastUpdate)
        {
            Manifest mn = GetChannelManifest(channel);

            return mn.LastUpdate > LastUpdate;           

        }



        private static string QuickDownloadJson(string url)
        {
            WebClient wc = new WebClient();
            string str = wc.DownloadString(url);
            return str;
        }


       
    }
}
