using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public enum FieldType
    {
        FIELD_INTEGER,
        FIELD_FLOAT,

    }
    [EditorGrammar("Variable with name %Name and type %Type with value %Value")]
    public class BaseActionVariable : DotaDataObject
    {
        public string Name
        {
            get
            {
                KeyValue kv = KeyValue.Children.FirstOrDefault(x => x.Key != "var_type");
                return kv.Key;
            }
            set
            {
                KeyValue kv = KeyValue.Children.FirstOrDefault(x => x.Key != "var_type");
                KeyValue.RemoveChild(kv);

                KeyValue newkv = new KeyValue(value) + kv.GetString();
                KeyValue.AddChild(newkv);
            }
        }


        public FieldType Type
        {
            get
            {
                KeyValue kv = GetSubkey("var_type");
                return kv.GetEnum<FieldType>();
            }
            set
            {
                KeyValue kv = GetSubkey("var_type");
                if (kv == null)
                {
                    kv = new KeyValue("var_type");
                    KeyValue.AddChild(kv);
                }
                kv.Set(value);
            }
        }

        public string Value
        {
            get
            {
                KeyValue kv = KeyValue.Children.FirstOrDefault(x => x.Key != "var_type");
                return kv.GetString();
            }
            set
            {
                KeyValue kv = KeyValue.Children.FirstOrDefault(x => x.Key != "var_type");
                kv.Set(value);
            }
        }
             
     
        public BaseActionVariable(KeyValue kv)
            : base(kv)
        {

        }


    }
}
