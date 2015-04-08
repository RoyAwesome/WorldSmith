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
using WorldSmith.NodeGraph;
using Graph.Compatibility;
using Graph;

namespace WorldSmith.Panels
{
    public partial class ActionNodeEditor : DockContent
    {
       
        public ActionNodeEditor()
        {
            InitializeComponent();

            graphControl1.CompatibilityStrategy = new AlwaysCompatible();

            AddEvents();
            AddActions();

            EventNode ac = new EventNode("OnSpellStart");
            ac.Location = new PointF(200, 50);


            graphControl1.AddNode(ac);           

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

            foreach(string Action in AllActions)
            {
                TreeNode n = root.Nodes.Add(Action);
                n.Tag = "Event";
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


            Node.Location = new PointF(0, 0);
            this.DoDragDrop(Node, DragDropEffects.Copy);

        }

    
    }
}
