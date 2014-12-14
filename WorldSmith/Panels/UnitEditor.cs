using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs;
using DigitalRune.Windows.Docking;

namespace WorldSmith.Panels
{
    public partial class UnitEditor : DockableForm
    {
        public UnitEditor()
        {
            InitializeComponent();
            LoadFromData();
        }

        public void LoadFromData()
        {
            ReadList("defaultUnits", DotaData.DefaultUnits);
            ReadList("defaultHeroes", DotaData.DefaultHeroes);
            ReadList("overrideHero", DotaData.OverridenHeroes);
            ReadList("customUnits", DotaData.CustomUnits);
        }


        private void ReadList<T>(string treeKey, List<T> unitList) where T : DotaDataObject
        {
            TreeNode n = unitTreeView.Nodes.Find(treeKey, false)[0];
            n.Nodes.Clear();

            foreach (T unit in unitList)
            {
                TreeNode newnode = new TreeNode()
                {
                    Name = unit.ClassName,
                    Text = unit.ClassName,
                    Tag = "Item"
                };
                n.Nodes.Add(newnode);
            }
        }

        private void unitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            unitPropertyGrid.SelectedObject = DotaData.AllUnits.FirstOrDefault(x => x.ClassName == e.Node.Name);
        }

        private void unitPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TreeNode n = unitTreeView.SelectedNode;
            //Grab the unit out of the default list and put it in the Override list
            DotaBaseUnit b = DotaData.DefaultUnits.FirstOrDefault(x => x.ClassName == n.Name);
            if (b == null) return;
            if (b is DotaUnit)
            {
                TreeNode root = unitTreeView.Nodes.Find("overrideUnits", false)[0];
                root.Nodes.Add(n);

                DotaData.DefaultUnits.Remove(b as DotaUnit);
                DotaData.OverriddenUnits.Add(b as DotaUnit);
            }
            if (b is DotaHero)
            {
                //Remove the custom hero from the unit list
                n.Remove();
                DotaData.DefaultUnits.Remove(b as DotaUnit);

                //Get a new classname for this overriden hero               
                TextPrompt prompt = new TextPrompt();
                prompt.Text = "Create New Hero Classname";
                prompt.PromptText = b.ClassName + "_custom";

                DialogResult r = prompt.ShowDialog();
                if (r == DialogResult.OK)
                {
                    //Create a new Dota hero for this guy
                    DotaHero newHero = b.Clone() as DotaHero;
                    newHero.ClassName = prompt.PromptText;
                    newHero.override_hero = b.ClassName;

                    //Put him in the hero override list
                    DotaData.OverridenHeroes.Add(newHero);

                    //Add him to the tree view
                    TreeNode root = unitTreeView.Nodes.Find("overrideHero", false)[0];
                    TreeNode newNode = new TreeNode()
                    {
                        Name = newHero.ClassName,
                        Text = newHero.ClassName,
                        Tag = "Item",
                    };
                    root.Nodes.Add(newNode);
                    unitTreeView.SelectedNode = newNode;

                    //Switch to the Override view for this unit
                    unitTreeView.CollapseAll();
                    newNode.Parent.ExpandAll();
                }
            }
        }


     
    }
}
