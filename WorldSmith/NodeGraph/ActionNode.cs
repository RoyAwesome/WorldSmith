using Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;
using System.Reflection;
using Graph.Items;
using WorldSmith.NodeGraph.Items;

namespace WorldSmith.NodeGraph
{
    class ActionNode : Node
    {
        BaseAction DotaAction;

        public ExecuteNodeItem OutputExecute
        {
            get;
            private set;
        }

        public ExecuteNodeItem InputExecute
        {
            get;
            private set;
        }


        public ActionNode(BaseAction action)
            : base(action.ClassName)
        {
            DotaAction = action;
            AddNodeElements();

            this.HeaderColor = System.Drawing.Brushes.SteelBlue;
        }

        private void AddNodeElements()
        {
            Type t = DotaAction.GetType();

            InputExecute = new ExecuteNodeItem("Execute", NodeItemType.Input);
            this.AddItem(InputExecute);

            OutputExecute = new ExecuteNodeItem("Execute", NodeItemType.Output);
            this.AddItem(OutputExecute);

            //Loop through all of this action's properties and add node elements for each property type
            PropertyInfo[] properties = t.GetProperties();

            //Target should always be ordered first
            var target = properties.FirstOrDefault(x => x.Name == "Target");
            if (target != null)
            {
                var item = new TargetNodeItem(target.Name, NodeItemType.Input);
                this.AddItem(item);
            }


            foreach (PropertyInfo prop in properties)
            {
                //Skip DotaDataObject's properties as they don't go into the node
                if (prop.Name == "ClassName") continue;
                if (prop.Name == "KeyValue") continue;
                if (prop.Name == "ObjectInfo") continue;
                if (prop.Name == "Target") continue; //Skip target because we handled it already

                NodeItem item = null;
                if (prop.PropertyType == typeof(NumberValue))
                {
                    item = new NodeNumericSliderItem(prop.Name, 20, 20, 0, 100, 0, NodeItemType.Input);
                }
                if(prop.PropertyType == typeof(TargetKey))
                {
                    item = new TargetNodeItem(prop.Name, NodeItemType.Input);
                }
                if(prop.PropertyType == typeof(ActionCollection))
                {
                    item = new ExecuteNodeItem(prop.Name, NodeItemType.Output);
                }

                if(item == null) item = new NodeLabelItem(prop.Name, NodeItemType.Input);
                this.AddItem(item);

            }
        }
    }
}
