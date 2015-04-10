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
            var OutputNode = new ExecuteNodeItem("Event", NodeItemType.Output);
            this.AddItem(OutputNode);          
        }
              
       
    }
}
