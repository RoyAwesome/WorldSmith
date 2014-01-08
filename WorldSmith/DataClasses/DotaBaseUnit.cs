using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    class DotaBaseUnit : DotaDataObject
    {
        public string Model
        {
            get;
            set;
        }


        public override void LoadFromKeyValues(KVLib.KeyValue kv)
        {
            base.LoadFromKeyValues(kv);
            Model = kv["Model"].GetString();
        }
    }
}
