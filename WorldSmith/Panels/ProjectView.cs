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


            ReloadTreeView();
        }


        public void ReloadTreeView()
        {
            PopulateFromProject();
            PopulateFromVPK();
        }

        protected void PopulateFromVPK()
        {
            TreeNode rootNode = treeView1.Nodes["vpk"];
            rootNode.Tag = "/";
            rootNode.Text = "Dota 2 VPK";
            rootNode.Nodes.Clear();
            IntPtr rootptr = HLLib.hlPackageGetRoot();

            RecursivePopulateFromVPK(ref rootNode, rootptr);

            rootNode.Expand();

        }

        protected void RecursivePopulateFromVPK(ref TreeNode parent, IntPtr CurrentFolder)
        {
            uint folderCount = HLLib.hlFolderGetCount(CurrentFolder);

            for (uint i = 0; i < folderCount; i++)
            {
                IntPtr subItem = HLLib.hlFolderGetItem(CurrentFolder, i);
                string name = HLLib.hlItemGetName(subItem);

                if (HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FOLDER)
                {
                    TreeNode folder = new TreeNode()
                    {
                        Name = name,
                        Text = name,
                        ImageIndex = 2,
                        SelectedImageIndex = 2,
                        Tag = ((string)parent.Tag) + name,
                    };

                    parent.Nodes.Add(folder);

                    RecursivePopulateFromVPK(ref folder, subItem);


                }
                else if (HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FILE)
                {
                    TreeNode folder = new TreeNode()
                    {
                        Name = name,
                        Text = name,
                        ImageIndex = 0,
                        Tag = ((string)parent.Tag) + name,
                    };

                    parent.Nodes.Add(folder);
                }

            }
        }

        protected void PopulateFromProject()
        {
            TreeNode rootNode = treeView1.Nodes["project"];
            string projectPath = Properties.Settings.Default.LoadedAddonDirectory;
            string projectName = Path.GetFileName(projectPath.Remove(projectPath.Length - 1));
            rootNode.Text = projectName;
            rootNode.Tag = projectPath;
            rootNode.Nodes.Clear();

            RecursivePopulateFromProject(ref rootNode, projectPath);

            rootNode.Expand();
        }

        protected void RecursivePopulateFromProject(ref TreeNode node, string path)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (string dir in directories)
            {
                string name = Path.GetFileName(dir);
                //Create a Folder node
                TreeNode folder = new TreeNode()
                {
                    Name = name,
                    Text = name,
                    ImageIndex = 2,
                    SelectedImageIndex = 2,
                    Tag = dir,
                };
                node.Nodes.Add(folder);

                RecursivePopulateFromProject(ref folder, dir);

                string[] files = Directory.GetFiles(dir);
                foreach (string f in files)
                {
                    name = Path.GetFileName(f);
                    TreeNode file = new TreeNode()
                    {
                        Name = name,
                        Text = name,
                        ImageIndex = 0,
                        Tag = f,
                    };
                    folder.Nodes.Add(file);
                }


            }
        }

        private TreeNode GetRootNode(TreeNode Node)
        {
            TreeNode cur = Node;
            while(cur.Parent != null)
            {
                cur = cur.Parent;
            }

            return cur;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;


            //The path of the file double clicked is stored in the treenode's tag
            string path = selectedNode.Tag as string;
            
            if (Path.GetExtension(path) == ".txt")
            {
                TextEditor editor = new TextEditor();
                editor.Text = selectedNode.Text;
                editor.EditorStyle = TextEditor.TextEditorStyle.KeyValues;

                TreeNode root = GetRootNode(selectedNode); 
                editor.OpenFile(path, root.Name == "vpk");

                editor.Show(MainForm.PrimaryDockingPanel, DigitalRune.Windows.Docking.DockState.Document);
            }
        }
        
    }
}
