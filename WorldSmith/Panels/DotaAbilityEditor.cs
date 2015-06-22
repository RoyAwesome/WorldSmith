using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WorldSmith.DataClasses;
using WorldSmith.Documents;
using WorldSmith.NodeGraph;
using Graph;
using Graph.Compatibility;
using WorldSmith.NodeGraph.Items;

namespace WorldSmith.Panels
{

    public class ActionCompatStrategy : ICompatibilityStrategy
    {
        public bool CanConnect(NodeConnector from, NodeConnector to)
        {
            if (from.Item.ItemType == to.Item.ItemType) return false;
            if (from.Item.GetType() == to.Item.GetType()) return true;            
            return false;
        }
    }

    public partial class DotaAbilityEditor : DockContent, IEditor
    {
        public DotaAbilityEditor()
        {
            InitializeComponent();

            graphControl1.CompatibilityStrategy = new ActionCompatStrategy();

            AddEvents();
            AddActions();

            this.FormClosing += DotaAbilityEditor_FormClosing;

            graphControl1.ConnectionAdded += GraphControl1_ConnectionAdded;
         
           
        }

      

        bool GeneratingGraph = false;

        private NodeItem GetInputItem(NodeItem A, NodeItem B)
        {
            if (A.ItemType == B.ItemType) throw new ArgumentException("A and B are the same connection type!");
            if (A.ItemType == NodeItemType.Input) return A;
            if (B.ItemType == NodeItemType.Input) return B;
            throw new ArgumentException("No Input type!");
        }
        private NodeItem GetOutputItem(NodeItem A, NodeItem B)
        {
            if (A.ItemType == B.ItemType) throw new ArgumentException("A and B are the same connection type!");
            if (A.ItemType == NodeItemType.Output) return A;
            if (B.ItemType == NodeItemType.Output) return B;
            throw new ArgumentException("No Output type!");
        }

        private void GraphControl1_ConnectionAdded(object sender, AcceptNodeConnectionEventArgs e)
        {
            if (GeneratingGraph) return;
           
            var to = GetInputItem(e.Connection.From.Item, e.Connection.To.Item);
            var from = GetOutputItem(e.Connection.From.Item, e.Connection.To.Item);

            //Clear all other connections.  This is to prevent multiple connections from attaching to the same pin.  
            //Only the latest connection will provide data. 
            List<NodeConnection> connections = new List<NodeConnection>(to.Connector.Connectors);                
            foreach (var con in connections)
            {
                if (con == e.Connection) continue; // Skip our connection, we want to keep it
                graphControl1.Disconnect(con);
            }
            

            Console.WriteLine("Connected " + from.Node.Title + " to " + to.Node.Title + "'s " + to.Tag);

            if(!(to is ExecuteNodeItem) && to.Node is ActionNode) //If the to node is an action node, notify it that a pin was connected
            {
                var an = to.Node as ActionNode;

                an.PinConnected(from, (string)to.Tag);
            }      
            
            //If we are connecting execute nodes, lets walk back                
            if(from is ExecuteNodeItem)
            {

                var executeItem = from as ExecuteNodeItem;

              
                if (executeItem.ActionCollection != null) //We are directly connected to the root
                {
                    OnExecuteNodeChanged(from as ExecuteNodeItem);
                }
                else   //Walk back the connection chain to find the execute node with the action collection
                {
                    executeItem = (executeItem.Node as AbilityGraphNode).InputExecute;

                    while (executeItem != null && executeItem.ActionCollection == null) //Keep moving backwards until we either are null or we have a action collection
                    {
                        var connection = executeItem.Connector.Connectors.FirstOrDefault();
                        if (connection == null)
                        {
                            executeItem = null;
                            break;
                        }
                       
                         executeItem = connection.From.Item as ExecuteNodeItem;

                        if(executeItem.ActionCollection == null)
                        {
                            executeItem = (executeItem.Node as AbilityGraphNode).InputExecute;
                        }

                    }

                    if (executeItem != null && executeItem.ActionCollection != null) //We've walked back to an action node and we aren't null, so it's an Event node.  
                    {
                        OnExecuteNodeChanged(executeItem); 
                    }

                }

                
               

              

            }

            
            ActiveDocument.DocumentEdited(this);
        }



        public void OnExecuteNodeChanged(ExecuteNodeItem RootExecuteNode)
        {

            //DotaEvent dotaEvent = eventNode.Event;

            


        }

        private void DotaAbilityEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            ActiveDocument.NotifyEditorClosed(this);
        }

        DotaAbility ability;
        public DotaAbility Ability
        {
            get { return ability; }
            set
            {
                ability = value;
                AbilityChanged();
            }
        }

        private void AddActions()
        {
            TreeNode root = treeView1.Nodes.Add("Actions");
            root.Tag = "Folder";

            foreach (string action in DotaActionFactory.ActionNames)
            {
                TreeNode n = root.Nodes.Add(action);
                n.Tag = "Action";
            }
        }

        private void AddEvents()
        {
            TreeNode root = treeView1.Nodes.Add("Events");
            root.Tag = "Folder";



            foreach (var action in DotaData.Events.Where(x => x.EventAppliesTo.HasFlag(DotaEvent.EventAppliesToFlags.ABILITY))) 
            {
                TreeNode n = root.Nodes.Add(action.ClassName);
                n.Tag = "Event";
            }

        }

        private void AddVariables()
        {           
            TreeNode n = treeView1.Nodes["Variables"];
            if (n == null)
            {
                n = treeView1.Nodes.Add("Variables");
                n.Tag = "Folder";
            }

            n.Nodes.Clear();

            foreach (var Variable in Ability.ActionList.Variables)
            {
                var v = n.Nodes.Add(Variable.Name);
                v.Tag = "Variable";
            }

        }

        private void treeView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            var SelectedNode = treeView1.SelectedNode;

            if (SelectedNode == null) return; //If we don't have a selection, don't bother with this.  

            Node Node = null;


            if ((string)SelectedNode.Tag == "Action")
            {
                var Action = DotaActionFactory.CreateNewAction(SelectedNode.Text);
                Node = new ActionNode(Action);

            }
            if ((string)SelectedNode.Tag == "Event")
            {
                var Event = DotaData.Events.FirstOrDefault(x => x.ClassName == SelectedNode.Text);
                Node = new EventNode(Event, Ability.ActionList.GetOrCreateCollection(Event));
            }
            if ((string)SelectedNode.Tag == "Variable")
            {
                var Var = Ability.ActionList.Variables.First(x => x.Name == (string)SelectedNode.Text);
                Node = new VariableNode(Var);

            }

            Node.Location = new PointF(0, 0);
            this.DoDragDrop(Node, DragDropEffects.Copy);

        }

        private void AbilityChanged()
        {
            propertyGrid1.SelectedObject = Ability;

            graphControl1.RemoveNodes(graphControl1.Nodes);

            AddVariables();

            PlaceEvents();
        }




        public Document ActiveDocument
        {
            get;
            set;
        }

        public void CloseDocument(bool ConfirmChanges)
        {
            this.Close();
        }

        public void NotifyDocumentModified(IEditor source)
        {
            
        }

        public void NotifyDocumentSaved(IEditor source)
        {
            
        }




        #region Layouting
        const int EventColumn = 200;
        const int EventSpacing = 150;
        const int ColumnSpacing = 50;
        const int VariableSpacing = 20;


        private void PlaceEvents()
        {
            GeneratingGraph = true;

            PointF Position = new PointF(EventColumn, 0);
            Graphics g = graphControl1.GetLayoutGraphics();


            foreach (DotaActionCollection kvEvents in Ability.ActionList)
            {
                var Event = DotaData.Events.FirstOrDefault(x => x.ClassName == kvEvents.ClassName);

                if (Event.RespectsTargetFlag && Ability.AbilityBehavior.HasFlag(DotaAbility.AbilityBehaviorFlags.DOTA_ABILITY_BEHAVIOR_UNIT_TARGET))
                {
                    //Add the target pin
                    Event.Targets = Event.Targets | DotaEvent.TargetsFlags.TARGET;
                }

                var EventNode = new EventNode(Event, Ability.ActionList.GetActionCollection(Event));
                EventNode.Location = Position;

               

                EventNode.PerformLayout(g);

                graphControl1.AddNode(EventNode);

                PointF col = Position;
                col.X = EventNode.Bounds.Right + ColumnSpacing; //Move this node to the left of the event node + spacing
                PointF previousCol = col;

                ExecuteNodeItem ExNode = EventNode.OutputExecute;

                float columnHeight = EventNode.Bounds.Height;
                foreach(var kvAction in kvEvents)
                {
                    if (kvAction == null) continue;
                       
                    var ActionNode = new ActionNode(kvAction);
                    ActionNode.Location = col;
                    
                    graphControl1.AddNode(ActionNode);
                    ActionNode.PerformLayout(g);

                    //Connect the execute nodes
                    var inputNode = ActionNode.InputExecute;
                    graphControl1.Connect(ExNode, inputNode);
                    ExNode = ActionNode.OutputExecute;

                    ConnectTargets(EventNode, ActionNode);


                    var varRefs = ActionNode.VariableReferences;

                    foreach(var Ref in varRefs)
                    {
                        var pos = previousCol;
                        pos.Y += columnHeight;

                        //Get the data variable for this reference
                        var actionVariable = ability.ActionList.Variables.FirstOrDefault(x => x.Name == Ref.VariableName.Replace("%", ""));
                        if (actionVariable == null)
                        {
                            MessageBox.Show("Found a reference to " + Ref.VariableName + "but could not find it in the variable table!");
                            continue;
                        }

                        //Create the variable node and add it to the graph
                        VariableNode varNode = new VariableNode(actionVariable);
                        varNode.Location = pos;
                        varNode.PerformLayout(g);
                        graphControl1.AddNode(varNode);

                        //Connect it's output to the referenced input pins

                        foreach(var inputPin in Ref.InputPins)
                        {
                            graphControl1.Connect(varNode.OutputPin, inputPin);
                        }

                        columnHeight += varNode.Bounds.Height + VariableSpacing;
                    }

                  
                    //Move the pen right to place the next action node
                    previousCol = col;
                    col.X = ActionNode.Bounds.Right + ColumnSpacing;
                    columnHeight = Math.Max(ActionNode.Bounds.Height, columnHeight);
                }


                Position.Y += columnHeight + EventSpacing;

            }

            GeneratingGraph = false;
        }

        private void ConnectTargets(EventNode Event, ActionNode Action)
        {
            if (!(Action.DotaAction is TargetedAction)) return; //An action without targets doesn't need it's nodes resolved
            TargetedAction ta = Action.DotaAction as TargetedAction;


            if (ta.Target.Preset == null) return; //Not a preset.  TODO: Generated a Make Target node with the details of this target key

            var outputItem = Event.GetTargetNodeFor(ta.Target.Preset);

            if (outputItem == null) return;

            graphControl1.Connect(outputItem, Action.TargetPin);
            
            
        }

       


        #endregion
    }
}
