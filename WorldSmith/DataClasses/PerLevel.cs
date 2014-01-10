using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    
    class PerLevelConverter : TypeConverter
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
            return new PerLevel((string) value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (value == null) return "";
            return value.ToString();
        }
    }

    public class PerLevelPropertyDescriptor : PropertyDescriptor
    {
        private PerLevel item = null;
        private int index = -1;

        public PerLevelPropertyDescriptor(PerLevel data, int index)
            : base( "#" + index.ToString(), null )
        {
            this.item = data;
            this.index = index;
        }

        public override string DisplayName
        {
            get
            {
                return "Level " + index;        
            }
        }

        public override bool CanResetValue(object component)
        {
            return true;
        }

        public override Type ComponentType
        {
            get { return this.item.GetType(); }
        }

        public override object GetValue(object component)
        {
            return this.item.LevelData[index];
        }

        public override bool IsReadOnly
        {
            get { return false; }
        }

        public override Type PropertyType
        {
            get { return this.item.LevelData[index].GetType(); }
        }

        public override void ResetValue(object component)
        {
            this.item.LevelData[index] = 0;
        }

        public override void SetValue(object component, object value)
        {
            this.item.LevelData[index] = (int)value;
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }


    //[TypeConverter(typeof(PerLevelConverter))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class PerLevel : ICustomTypeDescriptor
    {
        public PerLevel(string value)
        {
            LevelData = new List<float>();

            if (value == "")
            {
                LevelData.Add(0);
                LevelData.Add(0);
                LevelData.Add(0);
                LevelData.Add(0);
            }
            else
            {
                string[] split = value.Trim().Split(' ');

                foreach (string s in split)
                {
                    LevelData.Add(float.Parse(s));
                }
            }

            
        }

        public void Add(float f)
        {
            this.LevelData.Add(f);
        }
        public void Remove( float f)
        {
            this.LevelData.Remove(f);
        }
        public float this [int index]
        {
            get { return this.LevelData[index]; }
        }
        
        public List<float> LevelData
        {
            get;
            set;
        }

        public override string ToString()
        {
            return string.Join(" ", LevelData);
        }


        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return TypeDescriptor.GetDefaultProperty(this, true);
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return GetProperties();
        }

        public PropertyDescriptorCollection GetProperties()
        {
            PropertyDescriptorCollection pds = new PropertyDescriptorCollection(null);
           
            for(int i = 0; i < LevelData.Count; i++)
            {           
                PerLevelPropertyDescriptor pd = new PerLevelPropertyDescriptor(this, i);
                pds.Add(pd);
            }
            return pds;
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }
    }
}
