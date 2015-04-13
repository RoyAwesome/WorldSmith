using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace WorldSmith.DataClasses
{
    /// <summary>
    /// Represents either a Numical value or Variable identifier
    /// </summary>
    /// 
    [TypeConverter(typeof(NumberValueConverter))]
    public class NumberValue : IEnumerable<float>
    {
        KeyValue KV
        {
            get;
            set;
        }

        public string Value
        {
            get
            {
                return KV.GetString();
            }
            set
            {
                KV.Set(value);
            }
        }

        public bool IsVariable
        {
            get { return KV.GetString().StartsWith("%"); }
        }

        public float this[int level]
        {
            get
            {
                if (IsVariable) return 0; //We can't index a variable.  
                string[] levels = KV.GetString().Split(' ');
                if (level >= levels.Length) return 0; //We don't have enough levels.

                return float.Parse(levels[level]);
            }
            set
            {
                if (IsVariable) return; //Can't set a variable
                string[] levels = KV.GetString().Split(' ');
                if (level >= levels.Length) //We don't have enough levels, expand to that point
                {
                    List<string> newLevels = new List<string>();
                    newLevels.AddRange(levels);
                    //Fill the array with the last value
                    for(int i = levels.Length; i < level - 1; i++)
                    {
                        newLevels.Add(levels[levels.Length - 1]);
                    }
                    newLevels.Add(value.ToString());
                    levels = newLevels.ToArray();
                }
                else
                {
                    levels[level] = value.ToString();
                }

                KV.Set(String.Join(" ", levels));
            }
        }

        public NumberValue(KeyValue kv)
        {
            KV = kv;
        }

        public NumberValue(string value)
        {
            this.KV = new KeyValue(value);
        }

        public NumberValue()
        {
            KV = new KeyValue("ErrNoKey");
        }
              

        public override string ToString()
        {
            return KV.GetString();
        }

        public IEnumerator<float> GetEnumerator()
        {
            if (IsVariable) yield return 0;

            string[] levels = KV.GetString().Split(' ');

            foreach(string s in levels)
            {
                yield return float.Parse(s);
            }

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (IsVariable) yield return 0;

            string[] levels = KV.GetString().Split(' ');

            foreach (string s in levels)
            {
                yield return float.Parse(s);
            }
        }
    }

    class NumberValueConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return typeof(string) == sourceType;
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return typeof(string) == destinationType;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            return new NumberValue((string)value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }
}
