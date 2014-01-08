using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVLib;

namespace WorldSmith.DataClasses
{
    class DotaDataObject
    {
        public string ClassName
        {
            get;
            set;
        }

        public string BaseClass
        {
            get;
            set;
        }

        public virtual void LoadFromKeyValues(KeyValue kv)
        {
            ClassName = kv.Key;
            BaseClass = kv["BaseClass"].GetString();
        }
    }
}
