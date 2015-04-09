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

        int ExecPins = 0;

        public EventNode(string Actions)
            : base(Actions)
        {           
            AddPin = new NodeLabelItem("Add Pin +", NodeItemType.Input);
            AddPin.Clicked += AddPin_Clicked;
            this.AddItem(AddPin);

            this.HeaderColor = System.Drawing.Brushes.Brown;


            AddTargetNodes();
            AddExecPin(); //Add the first Exec pin
            
        }

        private void AddTargetNodes()
        {
            var TargetPin = new TargetNodeItem("Caster", NodeItemType.Output);
            AddItem(TargetPin);
        }

        public void AddExecPin()
        {        
            var OutputNode = new ExecuteNodeItem((++ExecPins).ToString(), NodeItemType.Output);
            this.AddItem(OutputNode);          
        }


        private void AddPin_Clicked(object sender, NodeItemEventArgs e)
        {
            AddExecPin();
        }
       
    }
}
