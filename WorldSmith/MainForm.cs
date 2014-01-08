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

        }     

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void unitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            unitPropertyGrid.SelectedObject = DotaData.DefaultUnits.FirstOrDefault(x => x.ClassName == e.Node.Name);
        }
    }
}
