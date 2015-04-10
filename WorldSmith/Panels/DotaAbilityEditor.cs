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

            List<string> AllActions = new List<string>() //TODO: Move this to a script
            {
                "OnSpellStart",
                "OnChannelSucceeded",
                "OnChannelInterrupted",
                "OnChannelFinish",
                "OnToggleOn",
                "OnToggleOff",
                "OnAbilityPhaseStart",
                "OnOwnerDied",
                "OnOwnerSpawned",
                "OnUpgrade",
                "OnProjectileHitUnit",
                "OnProjectileFinish",
            };

            foreach (string Action in AllActions)
            {
                TreeNode n = root.Nodes.Add(Action);
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
                Node = new EventNode((string)SelectedNode.Text);
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


        private void PlaceEvents()
        {
            PointF Position = new PointF(EventColumn, 0);
            Graphics g = graphControl1.GetLayoutGraphics();


            foreach (ActionCollection kvEvents in Ability.ActionList)
            {
                var ev = new EventNode(kvEvents.EventName);
                ev.Location = Position;

                ev.PerformLayout(g);

                graphControl1.AddNode(ev);

                PointF col = Position;
                col.X = ev.Bounds.Right + ColumnSpacing; //Move this node to the left of the event node + spacing

                ExecuteNodeItem ExNode = ev.OutputExecute;

                float columnHeight = ev.Bounds.Height;
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

                    //Move the pen right to place the next action node
                    col.X = ActionNode.Bounds.Right + ColumnSpacing;
                    columnHeight = Math.Max(ActionNode.Bounds.Height, columnHeight);
                }


                Position.Y += columnHeight + EventSpacing;

            }

        }



        #endregion
    }
}
