using KVLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class ActionCollection : CollectionBase
    {

        public KeyValue ToKV(string Key)
        {
            return new KeyValue(Key) + "TODO";
        }

        public override string ToString()
        {
            return ToKV("nokey").ToString();
        }
    }
}
