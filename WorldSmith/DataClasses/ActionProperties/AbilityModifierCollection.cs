using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVLib;

namespace WorldSmith.DataClasses
{
    public class AbilityModifierCollection : List<DotaModifier>
    {

        public KeyValue ToKV()
        {
            KeyValue doc = new KeyValue("Modifiers");
            
            foreach(DotaModifier mod in this)
            {
                doc += mod.SaveToKV();
            }

            return doc;
            
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
