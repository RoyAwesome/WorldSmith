using Graph;
using Graph.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;
using WorldSmith.NodeGraph.Items;

namespace WorldSmith.NodeGraph
{
    class CustomTargetNode : AbilityGraphNode
    {

        public TargetKey Target
        {
            get;
            set;
        }

        public TargetNodeItem OutputTarget
        {
            get;
            set;
        }


        public CustomTargetNode(string Name, TargetKey Target)
            : base(Name.ToTitleCase())
        {
            this.Target = Target;
            OutputTarget = new TargetNodeItem("Target", Graph.NodeItemType.Output);
            OutputTarget.Target = Target;

            this.AddItem(OutputTarget);

            AddInputPins();
        }


        protected void AddInputPins()
        {
            //We have different pins based on the properties of of the Target, so lets create them!

            TargetKey.ShapeE Shape = Target.Shape;

            var Properties = Target.GetType().GetProperties();

            foreach(var prop in Properties)
            {
                if (prop.Name == "ClassName") continue;               
                if (prop.Name == "ObjectInfo") continue;
                if (prop.Name == "KeyValue") continue; //Skip the KV property
                if (prop.Name == "Preset") continue; //We aren't a preset, skip this property
                if (prop.Name == "IsPreset") continue; //Same as preset
                if (prop.Name == "Shape") continue; //The title of the node displays this

                if(Shape == TargetKey.ShapeE.CIRCLE) //Skip the Line properties
                {
                    if (prop.Name == "Length") continue;
                    if (prop.Name == "Thickness") continue;
                }
                if(Shape == TargetKey.ShapeE.LINE) //Skip the circle properties
                {
                    if (prop.Name == "Center") continue;
                    if (prop.Name == "Radius") continue;
                }

                NodeItem item = null;
                if (prop.PropertyType == typeof(NumberValue))
                {
                    item = new NumberValueItem(prop.Name, 20, 20, 0, 100, 0, NodeItemType.Input);
                }
                if (item == null) item = new NodeLabelItem(prop.Name, NodeItemType.Input);

                item.Tag = prop.Name;

                this.AddItem(item);

            }



        }


    }
}
