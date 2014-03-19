using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public partial class DotaModifier
    {


        public override void LoadFromKeyValues(KeyValue kv)
        {
            base.LoadFromKeyValues(kv);

            //Load the modifier properties
            KeyValue properties = kv["Properties"];
            if(properties != null)
            {
                Properties = new ModifierPropertyCollection();

                Properties.ReadKV(properties);
            }

            //Load the modifier events

            PropertyInfo[] eventprops = this.GetType().GetProperties().Where(t => t.PropertyType == typeof(ActionCollection)).ToArray();
            foreach(PropertyInfo prop in eventprops)
            {
                string name = prop.Name;

                KeyValue action = kv[name];
                if (action == null) continue;


                ActionCollection actions = new ActionCollection(name);
                BaseAction act = DotaActionFactory.CreateNewAction(action.Key);
                actions.Add(act);

                prop.SetMethod.Invoke(this, new object[] { actions });

            }
            
        }
    }
}
