using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KVLib;
using System.ComponentModel;
using System.Reflection;

namespace WorldSmith.DataClasses
{
    public class DotaDataObject : ICloneable
    {
        [Category("Base")]
        [Description("Class name for this object")]
        public string ClassName
        {
            get;
            set;
        }

        public virtual void LoadFromKeyValues(KeyValue kv)
        {
            PropertyInfo[] properties = this.GetType().GetProperties();

            ClassName = kv.Key;

            foreach(PropertyInfo info in properties)
            {
                if (info.Name == "ClassName") continue;
                if (info.Name == "WasModified") continue;

                KeyValue subkey = kv[info.Name];
                if (subkey == null)
                {                  
                    continue;
                }
                if (subkey.HasChildren) continue; //TODO parse children because this is AbilitySpecial
                
                object data = null;
                if(info.PropertyType == typeof(int))
                {
                    data = subkey.GetInt();
                }
                if(info.PropertyType == typeof(float))
                {
                    data = subkey.GetFloat();
                }
                if(info.PropertyType == typeof(bool))
                {
                    data = subkey.GetBool();
                }
                if(info.PropertyType == typeof(string))
                {
                    data = subkey.GetString();
                }
                if (typeof(Enum).IsAssignableFrom(info.PropertyType) && subkey.GetString() != "")
                {
                    if (info.PropertyType.GetCustomAttribute(typeof(FlagsAttribute)) != null)
                    {
                        string[] flags = subkey.GetString().Replace(" ", "").Split('|').Where(x => x != "").ToArray();
                        string p = String.Join(", ", flags);

                        data = Enum.Parse(info.PropertyType, p);                        
                    }
                    else
                    {
                        data = Enum.Parse(info.PropertyType, subkey.GetString());
                    }
                }
                if (info.PropertyType == typeof(PerLevel))
                {
                    data = new PerLevel(subkey.GetString().Trim());
                }
                if(data != null) info.SetMethod.Invoke(this, new object[] { data });

            } 
        }

        public virtual KeyValue SaveToKV()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();

            KeyValue kv = new KeyValue(ClassName);

            foreach (PropertyInfo info in properties)
            {
                //Don't want to write ClassName to the file since it's the key
                if (info.Name == "ClassName") continue;
                if (info.Name == "WasModified") continue;


                object data = info.GetMethod.Invoke(this, new object[] { });
                //If the value is default, skip it.
                DefaultValueAttribute attib = info.GetCustomAttribute<DefaultValueAttribute>();
                if ( attib != null && attib.Value == data) continue;
               

                KeyValue subkey = new KeyValue(info.Name);    
                if (info.PropertyType == typeof(int))
                {                    
                    subkey.Set((int)data);
                }
                if (info.PropertyType == typeof(float))
                {                    
                    subkey.Set((float)data);
                }
                if (info.PropertyType == typeof(bool))
                {                    
                    subkey.Set((bool)data);
                }
                if (info.PropertyType == typeof(string))
                {                   
                    subkey.Set((string)data);
                }
                if (typeof(Enum).IsAssignableFrom(info.PropertyType))
                {
                    subkey.Set(data.ToString().Replace(",", " |"));
                }
                if (info.PropertyType == typeof(PerLevel))
                {
                    if (data == null) subkey.Set("");
                    else subkey.Set(((PerLevel)data).ToString());
                }
                kv += subkey;

            }

            return kv;

        }


        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
