using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.Dialogs;

namespace WorldSmith.DataClasses
{
    public partial class DotaAbility
    {
        [Editor(typeof(AbilityActionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Misc")]
        [Description("No Description Set")]
        [DefaultValue(typeof(AbilityActionCollection), "")]
        public AbilityActionCollection ActionList
        {
            get;
            set;
        }

        public override void LoadFromKeyValues(KeyValue kv)
        {
            base.LoadFromKeyValues(kv);

            ActionList = new AbilityActionCollection();
            
            //Load the actions in the ActionList
            foreach(string key in ActionList.Actions.Keys)
            {
                KeyValue kvActions = kv[key];
                if (kvActions == null) continue; //We don't have any actions there so skip
                foreach(KeyValue actionChild in kvActions.Children)
                {
                    if (!actionChild.HasChildren) continue; //TODO: Handle the Dontdestroy key
                    BaseAction action = DotaActionFactory.CreateNewAction(actionChild.Key);
                    if(action == null)
                    {
                        MessageBox.Show("WARNING: Action " + actionChild.Key + " not found in factory when creating ability: " + this.ClassName, "Loading Warning", MessageBoxButtons.OK);
                        continue;
                    }

                    action.LoadFromKeyValues(actionChild);

                    ActionList.Actions[key].Add(action);
                }
            }

            //Load the variables in AbilitySpecial
            KeyValue abilitySpecial = kv["AbilitySpecial"];
            if (abilitySpecial != null)
            {
                foreach (KeyValue absp in abilitySpecial.Children)
                {
                    BaseActionVariable var = new BaseActionVariable();
                    var.LoadFromKV(absp);
                    ActionList.Variables.Add(var);
                }
            }

            KeyValue modifiers = kv["Modifiers"];
            if(modifiers != null)
            {
                foreach(KeyValue mod in modifiers.Children)
                {
                    DotaModifier modifier = new DotaModifier();
                    modifier.LoadFromKeyValues(mod);
                    ActionList.Modifiers.Add(modifier);
                }

            }

        }

        public override KeyValue SaveToKV()
        {
            KeyValue kv = base.SaveToKV();

            //Loop through each of the possible actions in the ActionList and add them to the doc
            foreach(KeyValuePair<string, ActionCollection> kvs in ActionList.Actions)
            {
                if (kvs.Value.Count == 0) continue; //Skip empty action collections

                kv += kvs.Value.ToKV(kvs.Key); 
            }
            KeyValue abilitySpecial = new KeyValue("AbilitySpecial");

            for (int i = 0; i < ActionList.Variables.Count; i++ )
            {
                BaseActionVariable var = ActionList.Variables[i];

                abilitySpecial += var.ToKV((i + 1).ToString("D2"));
            }

            

            kv += abilitySpecial;
            kv += ActionList.Modifiers.ToKV();

            return kv;
        }
    }
}
