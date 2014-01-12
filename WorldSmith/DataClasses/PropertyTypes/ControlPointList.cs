using KVLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses.PropertyTypes
{
    class ControlPointVec
    {
        //Strings, because these can also be variable IDs.  

        public string X
        {
            get;
            set;
        }

        public string Y
        {
            get;
            set;
        }

        public string Z
        {
            get;
            set;
        }
    }

    class ControlPointList : CollectionBase
    {
        public ControlPointList(string KVstring)
        {
            KeyValue doc = KVParser.ParseKeyValueText(KVstring);
            
            foreach(KeyValue kv in doc.Children)
            {
                string[] split = kv.GetString().Split(' ');
                this.Add(new ControlPointVec()
                    {
                        X = split[0],
                        Y = split[1],
                        Z = split[2],
                    });
            }

        }

        public void Add(ControlPointVec f)
        {
            this.List.Add(f);
        }
        public void Remove(ControlPointVec f)
        {
            this.List.Remove(f);
        }
        public ControlPointVec this[int index]
        {
            get
            {
                return (ControlPointVec)this.List[index];
            }
            set { this.List[index] = value; }
        }



    }
}
