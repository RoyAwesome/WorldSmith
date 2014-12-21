using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class BaseScriptType : DotaDataObject
    {
        
        public BaseScriptType(KeyValue kv)
            : base(kv)
        {

        }

        public BaseScriptType(string className)
            : base(className)
        {

        }

        [Category("Base")]
        [Description("Class name for this object")]
        public string BaseClass
        {
            get;
            set;
        }        
    }
}
