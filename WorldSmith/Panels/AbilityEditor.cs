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

        private void ReadList<T>(string treeKey, List<T> abilityList) where T : DotaDataObject
        {
            TreeNode n = abilityTreeView.Nodes.Find(treeKey, false)[0];
            n.Nodes.Clear();

            foreach (T ability in abilityList)
            {
                TreeNode newnode = new TreeNode()
                {
                    Name = ability.ClassName,
                    Text = ability.ClassName,
                    Tag = "Item"
                };
                n.Nodes.Add(newnode);
            }
        }

        private void abilityTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            abilityPropertyGrid.SelectedObject = DotaData.AllClasses.FirstOrDefault(x => x.ClassName == e.Node.Name);
        }

        private void itemPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        }
    }
}
