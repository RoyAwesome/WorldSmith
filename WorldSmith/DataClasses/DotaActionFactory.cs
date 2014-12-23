using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public static class DotaActionFactory
    {
        public delegate BaseAction CreateAction();

        static Dictionary<string, Type> FactoryDictionary = new Dictionary<string, Type>();

        public static IEnumerable<string> ActionNames
        {
            get { return FactoryDictionary.Keys; }
        }

        public static void BuildFactory()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            foreach(Type t in asm.GetTypes().Where(t => t.GetCustomAttribute<DotaActionAttribute>() != null))
            {
                FactoryDictionary[t.Name] = t;
            }

        }

        public static BaseAction CreateNewAction(string name, KeyValue kv = null)
        {
            if (!FactoryDictionary.ContainsKey(name)) return null;

            Type actionType = FactoryDictionary[name];

            if(kv == null)
            {
                return actionType.GetConstructor(new Type[] { typeof(string) }).Invoke(new object[] { name }) as BaseAction;
            }
            else
            {
                return actionType.GetConstructor(new Type[] { typeof(KeyValue) }).Invoke(new object[] { kv }) as BaseAction;
            }
        }

    }
}
