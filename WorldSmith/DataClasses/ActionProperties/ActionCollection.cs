using KVLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class ActionCollection : CollectionBase, IEnumerable<BaseAction>
    {
        public string EventName
        {
            get;
            set;
        }

        public ActionCollection(string eventName)
        {
            EventName = eventName;
        }


        public void Add(BaseAction f)
        {
            if (f == null)
            {
                throw new Exception(EventName); //Dirty I know, but meh
            }
            this.List.Add(f);
        }
        public void Remove(BaseAction f)
        {
            this.List.Remove(f);
        }
        public BaseAction this[int index]
        {
            get
            {
                return (BaseAction)this.List[index];
            }
            set { this.List[index] = value; }
        }


        public KeyValue ToKV()
        {
            return ToKV(EventName);
        }

        public KeyValue ToKV(string Key)
        {
            KeyValue doc = new KeyValue(Key);
            foreach(BaseAction action in this.List.Cast<BaseAction>())
            {
                KeyValue child = new KeyValue(action.ClassName);
                doc += action.KeyValue;

            }
            return doc;
        }

        public override string ToString()
        {
            return "Collection";
        }

        public new IEnumerator<BaseAction> GetEnumerator()
        {
            foreach(BaseAction o in this.List)
            {
                yield return o;
            }
        }
    }


    class ActionCollectionConverter : TypeConverter
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
            return new ActionCollection((string)value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) return "";
            return (value as ActionCollection).ToKV().ToString();
        }
    }
}
