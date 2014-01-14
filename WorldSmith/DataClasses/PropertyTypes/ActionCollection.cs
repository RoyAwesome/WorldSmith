using KVLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public class ActionCollection : CollectionBase
    {

        public void Add(BaseAction f)
        {
            this.List.Add(f);
        }
        public void Remove(BaseAction f)
        {
            this.List.Remove(f);
        }
        public BaseAction this[int index]
        {
            get
            {
                return (BaseAction)this.List[index];
            }
            set { this.List[index] = value; }
        }


        public KeyValue ToKV(string Key)
        {
            KeyValue doc = new KeyValue(Key);
            foreach(BaseAction action in this.List.Cast<BaseAction>())
            {
                KeyValue child = new KeyValue(action.ClassName);
                child += action.SaveToKV();

            }
            return doc;
        }

        public override string ToString()
        {
            return ToKV("nokey").ToString();
        }
    }
}
