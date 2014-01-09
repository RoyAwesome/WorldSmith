using System;
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
            return false;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {            
            return new PerLevel((string) value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }

    [TypeConverter(typeof(PerLevelConverter))]
    class PerLevel
    {
        public PerLevel(string value)
        {
            string[] split = value.Trim().Split(' ');

            foreach(string s in split)
            {
                LevelData.Add(float.Parse(s));
            }

        }
        public List<float> LevelData = new List<float>();

        public override string ToString()
        {
            return string.Join(" ", LevelData);
        }
    }
}
