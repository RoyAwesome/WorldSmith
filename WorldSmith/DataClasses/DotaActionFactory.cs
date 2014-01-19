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

        static Dictionary<string, CreateAction> FactoryDictionary = new Dictionary<string, CreateAction>();

        public static IEnumerable<string> ActionNames
        {
            get { return FactoryDictionary.Keys; }
        }

        public static void BuildFactory()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            foreach(Type t in asm.GetTypes().Where(t => t.GetCustomAttribute<DotaActionAttribute>() != null))
            {
                FactoryDictionary[t.Name] = () =>
                    {
                        BaseAction action = (BaseAction)t.GetConstructor(Type.EmptyTypes).Invoke(null);
                        return action;
                    };
            }

        }

        public static BaseAction CreateNewAction(string name)
        {
            if (!FactoryDictionary.ContainsKey(name)) return null;
            return FactoryDictionary[name]();
        }

    }
}
