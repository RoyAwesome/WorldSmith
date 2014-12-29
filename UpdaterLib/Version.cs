using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpdaterLib
{
    public class Version
    {
        public string Name
        {
            get;
            set;
        }

        public UpdateChannel Channel
        {
            get;
            set;
        }

        public string Sha
        {
            get;
            set;
        }

        public string Origin
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }
    }
}
