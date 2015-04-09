using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using Graph.Items;
using WorldSmith.NodeGraph.Items;

namespace WorldSmith.NodeGraph
{
    class EventNode : Node
    {
        NodeLabelItem AddPin;

        public EventNode(string Actions)
            : base(Actions)
        {
           


            var OutputNode1 = new ExecuteNodeItem("1", NodeItemType.Output);

            this.AddItem(OutputNode1);


            AddPin = new NodeLabelItem("Add Pin +", NodeItemType.Input);
            AddPin.Clicked += AddPin_Clicked;
            this.AddItem(AddPin);
            
        }

        private void AddPin_Clicked(object sender, NodeItemEventArgs e)
        {
            this.RemoveItem(AddPin); //Remove the addpin node, we'll add it again so it's always on bottom

            var OutputNode = new ExecuteNodeItem((this.Items.Count() + 1).ToString(), NodeItemType.Output);            
            this.AddItem(OutputNode);

            this.AddItem(AddPin); //Add AddPin back so it's at the bottom

        }
       
    }
}
