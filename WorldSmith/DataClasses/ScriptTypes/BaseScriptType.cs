using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    class BaseScriptType : DotaDataObject
    {
        [Category("Base")]
        [Description("Class name for this object")]
        public string BaseClass
        {
            get;
            set;
        }        
    }
}
