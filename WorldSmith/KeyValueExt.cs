using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;

namespace WorldSmith
{
    public static class KeyValueExt
    {
        /// <summary>
        /// Returns the value of this KeyValue surrounded by " "
        /// </summary>
        /// <param name="kv"></param>
        /// <returns></returns>
        public static string GetLiteralString(this KeyValue kv)
        {
            return "\"" + kv.GetString() + "\"";
        }

        public static T GetEnum<T>(this KeyValue kv)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an Enum!");
            }

            string flagstr = kv.GetString().Replace('|', ','); //Replace pipes with commas... since C# requires comma seperate flags

            T value = (T)Enum.Parse(typeof(T), flagstr);
            return value;
        }

        /// <summary>
        /// Enum Set to fix the C# seperating flags with ,
        /// </summary>
        /// <param name="kv"></param>
        /// <param name="e"></param>
        public static void Set(this KeyValue kv, Enum e)
        {
            kv.Set(e.ToString().Replace(',', '|')); //Replace the commas with pipes.  C# seperates flags with ,
        }

        /// <summary>
        /// Catchall Set for generic objects
        /// </summary>
        /// <param name="kv"></param>
        /// <param name="o"></param>
        public static void Set(this KeyValue kv, object o)
        {
            kv.Set(o.ToString());
        }

        public static NumberValue GetNumberValue(this KeyValue kv)
        {
            return new NumberValue(kv.GetString());
        }
        
    }
}
