using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class DotaActionCollection : DotaScriptCollection<BaseAction>
    {
        public DotaActionCollection(KeyValue kv)
            : base(kv)
        {

        }

        public DotaActionCollection(string Event)
            : base(Event)
        {

        }


        public override IEnumerator<BaseAction> GetEnumerator()
        {
            foreach (KeyValue kv in KeyValue.Children)
            {
                if (!kv.HasChildren) continue;
                BaseAction obj = DotaActionFactory.CreateNewAction(kv.Key, kv);
                yield return obj;
            }
        }

    }
}
