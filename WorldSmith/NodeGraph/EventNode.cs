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
    public class EventNode : AbilityGraphNode
    {
             
        public DotaEvent Event
        {
            get;
            set;
        }

        public DotaActionCollection ActionCollection
        {
            get;
            set;
        }
            

        public EventNode(DotaEvent Event, DotaActionCollection BackingCollection)
            : base(Event.ClassName)
        {
            this.Event = Event;
            this.ActionCollection = BackingCollection;


            this.HeaderColor = System.Drawing.Brushes.Brown;

            AddExecPin();
            AddTargetNodes();
            AddSpecialPins();


        }

        private void AddTargetNodes()
        {
            string s = Event.Targets.ToString();
            var split = s.Split(',');

            foreach(string t in split)
            {
                var TargetPin = new TargetNodeItem(new TargetKey(t));
                AddItem(TargetPin);
            }
                      
        }
        
        private void AddSpecialPins()
        {
            if(Event.ProvidesAttackDamage)
            {
                var AttackDamagePin = new NodeLabelItem("Attack Damage", NodeItemType.Output);
                AddItem(AttackDamagePin);

            }
        }   

        public TargetNodeItem GetTargetNodeFor(string Preset)
        {
            return Items.Where(x => x is TargetNodeItem).Cast<TargetNodeItem>().FirstOrDefault(x => x.Text.Equals(Preset.ToString(), StringComparison.OrdinalIgnoreCase));
        }

        public void AddExecPin()
        {
            OutputExecute = new ExecuteNodeItem("Event", NodeItemType.Output);
            OutputExecute.ActionCollection = ActionCollection; //Assign our action collection, as we are an endpoint
            this.AddItem(OutputExecute);          
        }
              
       
    }
}
