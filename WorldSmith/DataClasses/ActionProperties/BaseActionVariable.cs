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

    public class BaseActionVariable
    {
        public string Name
        {
            get;
            set;
        }


        public FieldType Type
        {
            get;
            set;
        }

        public string DefaultValue
        {
            get;
            set;
        }




        public KeyValue ToKV(string key)
        {
            KeyValue parent = new KeyValue(key);
            parent += new KeyValue("var_type") + Type.ToString();
            parent += new KeyValue(Name) + DefaultValue;

            return parent;
        }

        public override string ToString()
        {
            return ToString("00");
        }

        public string ToString(string key)
        {
            return Name;
            //return ToKV(key).ToString();
        }

        public void LoadFromKV(KeyValue kv)
        {
            Type = (FieldType)Enum.Parse(typeof(FieldType), kv["var_type"].GetString());
            KeyValue v = kv.Children.First(x => x.Key != "var_type");
            Name = v.Key;
            DefaultValue = v.GetString();
        }

    }
}
