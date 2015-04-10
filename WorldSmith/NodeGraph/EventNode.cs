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

        public ExecuteNodeItem OutputExecute
        {
            get;
            set;
        }

        public EventNode(string Actions)
            : base(Actions)
        {           
           

            this.HeaderColor = System.Drawing.Brushes.Brown;

            AddExecPin();
            AddTargetNodes();
            
            
        }

        private void AddTargetNodes()
        {
            var TargetPin = new TargetNodeItem("Caster", NodeItemType.Output);
            AddItem(TargetPin);
        }

        public void AddExecPin()
        {
            OutputExecute = new ExecuteNodeItem("Event", NodeItemType.Output);
            this.AddItem(OutputExecute);          
        }
              
       
    }
}
