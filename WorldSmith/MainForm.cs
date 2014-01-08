using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;

namespace WorldSmith
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadFromData();
        }

        private void LoadFromData()
        {
            TreeNode n = unitTreeView.Nodes.Find("defaultUnits", false)[0];

            foreach(DotaUnit unit in DotaData.DefaultUnits)
            {
                TreeNode newnode = new TreeNode()
                {
                    Name = unit.ClassName,
                    Text = unit.ClassName,
                    Tag = "Item"
                };
                n.Nodes.Add(newnode);
            }

            n = unitTreeView.Nodes.Find("defaultHeroes", false)[0];
            foreach (DotaHero unit in DotaData.DefaultHeroes)
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void unitPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            TreeNode n = unitTreeView.SelectedNode;
            //Grab the unit out of the default list and put it in the Override list
            DotaBaseUnit b = DotaData.AllDefaultUnits.FirstOrDefault(x => x.ClassName == n.Name);
            if (b == null) return;
            n.Remove();
            if (b is DotaUnit)
            {                
                TreeNode root = unitTreeView.Nodes.Find("overrideUnits", false)[0];
                root.Nodes.Add(n);

                DotaData.DefaultUnits.Remove(b as DotaUnit);
                DotaData.OverriddenUnits.Add(b as DotaUnit);
            }
            if(b is DotaHero)
            {                
                TreeNode root = unitTreeView.Nodes.Find("overrideHeroes", false)[0];
                root.Nodes.Add(n);
                DotaData.DefaultHeroes.Remove(b as DotaHero);
                DotaData.OverridenHeroes.Add(b as DotaHero);
            }
            
        }
    }
}
