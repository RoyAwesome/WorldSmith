using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using Graph.Items;
using WorldSmith.NodeGraph.Items;
using WorldSmith.DataClasses;


namespace WorldSmith.NodeGraph
{
    class VariableNode : Node
    {
        public BaseActionVariable Variable
        {
            get;
            set;
        }

        public NodeItem OutputPin
        {
            get;
            private set;
        }

        public VariableNode(BaseActionVariable var)
            : base(var.Name)
        {
            Variable = var;
            HeaderColor = System.Drawing.Brushes.DarkGreen;

            OutputPin = new NumberValueItem("Value", NodeItemType.Output);
            AddItem(OutputPin);
        }

    }
}
