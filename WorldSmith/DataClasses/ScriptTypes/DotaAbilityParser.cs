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
            

            foreach(string key in ActionList.Actions.Keys)
            {
                KeyValue kvActions = kv[key];
                if (kvActions == null) continue; //We don't have any actions there so skip
                foreach(KeyValue actionChild in kvActions.Children)
                {
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


        }
    }
}
