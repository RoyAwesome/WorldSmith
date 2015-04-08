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

        public ActionNode(BaseAction action)
            : base(action.ClassName)
        {
            DotaAction = action;
            AddNodeElements();
        }

        private void AddNodeElements()
        {
            Type t = DotaAction.GetType();

            var Ex = new ExecuteNodeItem("Execute", true, false);
            this.AddItem(Ex);

            //Loop through all of this action's properties and add node elements for each property type
            PropertyInfo[] properties = t.GetProperties(); 
            foreach (PropertyInfo prop in properties)
            {
                //Skip DotaDataObject's properties as they don't go into the node
                if (prop.Name == "ClassName") continue;
                if (prop.Name == "BaseAction.KeyValue") continue;
                if (prop.Name == "BaseAction.ObjectInfo") continue;

                NodeItem item = null;
                if (prop.PropertyType == typeof(NumberValue))
                {
                    item = new NodeNumericSliderItem(prop.Name, 20, 20, 0, 100, 0, true, false);
                }

                if(item == null) item = new NodeLabelItem(prop.Name, true, false);
                this.AddItem(item);

            }
        }
    }
}
