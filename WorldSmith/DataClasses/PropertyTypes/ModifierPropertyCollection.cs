using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class ModifierPropertyCollection : List<ModifierProperty>
    {

        public void ReadKV(KeyValue kv)
        {
            foreach(KeyValue child in kv.Children)
            {
                ModifierProperty property = new ModifierProperty();
                property.PropertyType = (ModifierPropertyType)Enum.Parse(typeof(ModifierPropertyType), child.Key);
                property.Value = new NumberValue(child.GetString());

                this.Add(property);
            }
        }

        public KeyValue ToKV()
        {
            KeyValue kv = new KeyValue("Properties");

            foreach(ModifierProperty p in this)
            {
                kv += new KeyValue(p.PropertyType.ToString()) + p.Value.Value;
            }

            return kv;
        }
    }
}
