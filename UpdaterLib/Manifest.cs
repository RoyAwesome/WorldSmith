using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdaterLib
{
    public class Manifest
    {
        public string Channel
        {
            get;
            set;
        }

        public DateTime LastUpdate
        {
            get;
            set;
        }

        public string BuildListURL
        {
            get;
            set;
        }

        public string LatestVersion
        {
            get;
            set;
        }

    }

    public class Build
    {
        public string Version
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string Sha
        {
            get;
            set;
        }

        public string DownloadURL
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public string DetailURL
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

    }
}
