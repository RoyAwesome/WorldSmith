using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace WorldSmith.DataClasses
{
    public partial class BaseAction
    {


        public IEnumerable<string> VariableReferences()
        {

            PropertyInfo[] p = this.GetType().GetProperties();
            foreach (var prop in p)
            {
                if (prop.PropertyType == typeof(NumberValue))
                {
                    var nv = prop.GetValue(this) as NumberValue;
                    if (nv.IsVariable) yield return nv.Value;
                }
            }

        }

    }
}
