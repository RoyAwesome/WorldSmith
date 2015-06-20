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
        public BaseAction DotaAction
        {
            get;
            private set;
        }

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

        public TargetNodeItem TargetPin
        {
            get;
            set;
        }

        public class VariableRefInfo
        {
            public string VariableName;
            public NodeItem[] InputPins;
        }

        public List<VariableRefInfo> VariableReferences = new List<VariableRefInfo>();

        public ActionNode(BaseAction action)
            : base(action.ClassName)
        {
            DotaAction = action;
            AddNodeElements();

            this.HeaderColor = System.Drawing.Brushes.SteelBlue;

            RefreshVariableRefs();

           
        }

        public void PinConnectedToVariable(VariableNode otherNode, string property)
        {
            Type t = DotaAction.GetType();
            var prop = t.GetProperty(property);

            if (prop == null)
            {
                throw new ArgumentException("Property must be a valid KV property");
            }

            if(prop.PropertyType == typeof(NumberValue))
            {
                var nv = new NumberValue("%" + otherNode.Variable.Name);

                prop.SetMethod.Invoke(DotaAction, new object[] { nv });
                
            }

        }


        public void RefreshVariableRefs()
        {
            VariableReferences.Clear();

            Type t = DotaAction.GetType();

            //Loop through all of this action's properties and add node elements for each property type
            PropertyInfo[] properties = t.GetProperties();

            foreach (PropertyInfo prop in properties)
            {
                //Skip DotaDataObject's properties as they don't go into the node
                if (prop.Name == "ClassName") continue;
                if (prop.Name == "KeyValue") continue;
                if (prop.Name == "ObjectInfo") continue;
                if (prop.Name == "Target") continue; //Skip target because we handled it already


                if (prop.PropertyType == typeof(NumberValue))
                {
                    NumberValue nv = prop.GetMethod.Invoke(DotaAction, new object[] { }) as NumberValue;

                    if(nv.IsVariable)
                    {
                        //Check to see if we have a variable reference in our list
                        VariableRefInfo varRef = VariableReferences.FirstOrDefault(x => x.VariableName == nv.Value);
                        if (varRef != null) //varRef is not null, so we can just add this pin to the reference list
                        {
                            //Get the pin for this property
                            NodeItem pin = this.Items.FirstOrDefault(x => (string)x.Tag == prop.Name);

                            List<NodeItem> pins = new List<NodeItem>(varRef.InputPins);
                            pins.Add(pin);
                            varRef.InputPins = pins.ToArray();                            
                        }
                        else //We don't have a reference entry fo this one.  Lets add it
                        {
                            varRef = new VariableRefInfo();
                            varRef.VariableName = nv.Value;

                            //Get the pin for this property
                            NodeItem pin = this.Items.FirstOrDefault(x => (string)x.Tag == prop.Name);

                            varRef.InputPins = new NodeItem[] { pin };

                            VariableReferences.Add(varRef);
                        }

                    }

                }
            }
            
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
                TargetPin = new TargetNodeItem(target.Name, NodeItemType.Input);
                this.AddItem(TargetPin);
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
                    item = new NumberValueItem(prop.Name, 20, 20, 0, 100, 0, NodeItemType.Input);                    
                }
                if(prop.PropertyType == typeof(TargetKey))
                {
                    item = new TargetNodeItem(prop.Name, NodeItemType.Input);
                }
                if(prop.PropertyType == typeof(DotaActionCollection))
                {
                    item = new ExecuteNodeItem(prop.Name, NodeItemType.Output);
                }

                if(item == null) item = new NodeLabelItem(prop.Name, NodeItemType.Input);

                item.Tag = prop.Name;
                this.AddItem(item);

            }
        }
    }
}
