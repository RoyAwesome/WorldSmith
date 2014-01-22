using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    /// <summary>
    /// Represents either a Numical value or Variable identifier
    /// </summary>
    /// 
    [TypeConverter(typeof(NumberValueConverter))]
    public class NumberValue
    {
        public NumberValue(string value)
        {
            this.Value = value;
        }

        public NumberValue()
        {
            Value = "";
        }

        public string Value
        {
            get;
            set;
        }

        public override string ToString()
        {
            return Value;
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
