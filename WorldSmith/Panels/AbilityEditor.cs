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
    public partial class AbilityEditor : DockableForm
    {
        public AbilityEditor()
        {
            InitializeComponent();
            LoadFromData();
        }

        public void LoadFromData()
        {
            ReadList("defaultAbilities", DotaData.DefaultAbilities);
            ReadList("customAbilities", DotaData.CustomAbilities);
            ReadList("overriddenAbilities", DotaData.OverridenAbilities);
        }

        private void ReadList<T>(string treeKey, List<T> unitList) where T : DotaDataObject
        {
            TreeNode n = abilityTreeView.Nodes.Find(treeKey, false)[0];
            //n.Nodes.Clear();

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if((string)abilityTreeView.SelectedNode.Tag != "Item") return;

            string classname = abilityTreeView.SelectedNode.Name;
            DotaDataObject obj = DotaData.AllClasses.First(x => x.ClassName == classname);
            abilityPropertyGrid.SelectedObject = obj;
        }

        private void itemPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
