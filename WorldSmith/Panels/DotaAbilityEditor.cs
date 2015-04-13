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
    public partial class DotaAbilityEditor : DockContent, IEditor
    {
        public DotaAbilityEditor()
        {
            InitializeComponent();

            graphControl1.CompatibilityStrategy = new AlwaysCompatible();

            AddEvents();
            AddActions();

            this.FormClosing += DotaAbilityEditor_FormClosing;
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

            Node Node = null;

            if ((string)SelectedNode.Tag == "Action")
            {
                var Action = DotaActionFactory.CreateNewAction(SelectedNode.Text);
                Node = new ActionNode(Action);

            }
            if ((string)SelectedNode.Tag == "Event")
            {
                var Event = DotaData.Events.FirstOrDefault(x => x.ClassName == SelectedNode.Text);
                Node = new EventNode(Event);
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

                var EventNode = new EventNode(Event);
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

                    var Vars = ActionVariables(kvAction, Ability);
                    foreach(var actionVariable in Vars)
                    {
                        
                        var pos = previousCol;
                        pos.Y += columnHeight;

                        var varNode = new VariableNode(actionVariable);
                        varNode.Location = pos;
                        varNode.PerformLayout(g);
                        graphControl1.AddNode(varNode);


                        columnHeight += varNode.Bounds.Height + VariableSpacing;
                    }

                    //Move the pen right to place the next action node
                    previousCol = col;
                    col.X = ActionNode.Bounds.Right + ColumnSpacing;
                    columnHeight = Math.Max(ActionNode.Bounds.Height, columnHeight);
                }


                Position.Y += columnHeight + EventSpacing;

            }

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

        private IEnumerable<BaseActionVariable> ActionVariables(BaseAction action, DotaAbility ability)
        {
            foreach (var VariableRef in action.VariableReferences())
            {
                var v = ability.ActionList.Variables.FirstOrDefault(x => x.Name == VariableRef.Replace("%", ""));
                if (v == null) continue;
                yield return v;
            }

        }



        #endregion
    }
}
