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

        public DotaAbility Ability
        {
            get;
            set;
        }

        public KeyValue KeyValues
        {
            get;
            set;
        }

        public ActionCollection(string eventName)
        {
            EventName = eventName;
            KeyValues = new KeyValue(EventName);
        }

        public ActionCollection(string eventName, KeyValue kvs)
        {
            EventName = eventName;
            KeyValues = kvs;
        }

        public int Count()
        {
            return KeyValues.Children.Count();
        }


        public void Add(BaseAction f)
        {
            if (f == null) throw new ArgumentException("Action cannot be null");
            KeyValues.AddChild(f.KeyValue);
        }
        public void Remove(BaseAction f)
        {
            if (f == null) throw new ArgumentException("Action cannot be null");
            KeyValues.RemoveChild(f.KeyValue);
        }

        public BaseAction GetAtIndex(int index)
        {
            KeyValue actionKV = KeyValues.Children.ElementAtOrDefault(index);

            if (actionKV == null) return null;

            BaseAction action = DotaActionFactory.CreateNewAction(actionKV.Key, actionKV);
            return action;            
        }

        public void AddIntoIndex(int index, BaseAction action)
        {
            if(index >= KeyValues.Children.Count())
            {
                throw new IndexOutOfRangeException("index is out of range");
            }

            //Get the action at the that index
            KeyValue actionKV = KeyValues.Children.ElementAtOrDefault(index);

            KeyValues.RemoveChild(actionKV);
            KeyValues.AddChild(action.KeyValue);
        }

        public BaseAction this[int index]
        {
            get
            {
                return GetAtIndex(index);
            }
            set { AddIntoIndex(index, value); }
        }
               

        public override string ToString()
        {
            return KeyValues.ToString();
        }

        public new IEnumerator<BaseAction> GetEnumerator()
        {
            for (int i = 0; i < Count(); i++ )
            {
                yield return this[i];
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
            return (value as ActionCollection).ToString();
        }
    }
}
