using DigitalRune.Windows.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WorldSmith.Panels
{
    public partial class ProjectView : DockableForm
    {
        public ProjectView()
        {
            InitializeComponent();
            fileTreeView1.Populate(WorldSmith.Controls.FileViewSource.Project);

            fileTreeView1.ItemDoubleClicked += fileTreeView1_ItemDoubleClicked;
        }

        void fileTreeView1_ItemDoubleClicked(object sender, TreeNode selectedNode)
        {
            //The path of the file double clicked is stored in the treenode's tag
            string path = selectedNode.Tag as string;

            if(Path.GetExtension(path) == ".txt")
            {
                TextEditor editor = new TextEditor();
                editor.EditorStyle = TextEditor.TextEditorStyle.KeyValues;
                editor.OpenFile(path, false);
             
                editor.Show(MainForm.PrimaryDockingPanel, DigitalRune.Windows.Docking.DockState.Document);
            }

        }
    }
}
