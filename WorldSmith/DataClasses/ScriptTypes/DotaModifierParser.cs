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

        /*
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

                KeyValue actions = kv[name];
                if (actions == null) continue;

                ActionCollection actionCollection = new ActionCollection(name);
                
                foreach(KeyValue act in actions.Children)
                {
                    BaseAction action = DotaActionFactory.CreateNewAction(act.Key);
                    if (action == null) continue;
                    actionCollection.Add(action);
                }
 
                prop.SetMethod.Invoke(this, new object[] { actionCollection});

            }
        
            
        }
         */
    }
}
