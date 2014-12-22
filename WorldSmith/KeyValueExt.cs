using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith
{
    public static class KeyValueExt
    {
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

        public static void Set(this KeyValue kv, Enum e)
        {
            kv.Set(e.ToString().Replace(',', '|')); //Replace the commas with pipes.  C# seperates flags with ,
        }

    }
}
