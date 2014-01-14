using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            

           // KeyValue hooks = kv["Actions"]["Actions"];
           // foreach(KeyValue act in hooks.Children)
           // {
                //ActionList.Actions[act.Key] = 

           // }

        }
    }
}
