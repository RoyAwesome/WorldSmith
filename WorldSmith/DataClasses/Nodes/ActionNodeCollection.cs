using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Graph;
using Graph.Items;

namespace WorldSmith.DataClasses
{
    class ActionNodeCollection : Node
    {
        NodeLabelItem AddPin;

        public ActionNodeCollection(string Actions)
            : base(Actions)
        {
           


            NodeLabelItem OutputNode1 = new NodeLabelItem("1", false, true);

            this.AddItem(OutputNode1);


            AddPin = new NodeLabelItem("Add Pin +", false, false);
            AddPin.Clicked += AddPin_Clicked;
            this.AddItem(AddPin);
            
        }

        private void AddPin_Clicked(object sender, NodeItemEventArgs e)
        {
            this.RemoveItem(AddPin); //Remove the addpin node, we'll add it again so it's always on bottom

            NodeLabelItem OutputNode = new NodeLabelItem((this.Items.Count() + 1).ToString(), false, true);            
            this.AddItem(OutputNode);

            this.AddItem(AddPin); //Add AddPin back so it's at the bottom

        }
    }
}
