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
        BaseActionVariable Variable
        {
            get;
            set;
        }

        public VariableNode(BaseActionVariable var)
            : base(var.Name)
        {
            Variable = var;
            HeaderColor = System.Drawing.Brushes.DarkGreen;

            var OutputItem = new NodeLabelItem("Value", NodeItemType.Output);
            AddItem(OutputItem);
        }

    }
}
