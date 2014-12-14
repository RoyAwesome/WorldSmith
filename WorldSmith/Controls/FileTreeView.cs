using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WorldSmith.Controls
{
    public enum FileViewSource
    {
        Vpk,
        Project,
    }
    public delegate void TreeViewDoubleClicked(object sender, TreeNode selectedNode);


    public partial class FileTreeView : UserControl
    {      
        public FileTreeView()
        {
            InitializeComponent();

            treeView.DoubleClick += treeView_DoubleClick;
        }

        public event TreeViewDoubleClicked ItemDoubleClicked;

        void treeView_DoubleClick(object sender, EventArgs e)
        {
            if(ItemDoubleClicked != null)
            {                
                ItemDoubleClicked.Invoke(this, treeView.SelectedNode);
            }
        }

        

        public void Populate(FileViewSource source)
        {
            if(source == FileViewSource.Vpk)
            {
                //This is slow.  TODO: Pop up a loading screen when this happens
                PopulateFromVPK();
            }
            else if(source == FileViewSource.Project)
            {
                PopulateFromProject();
            }

            
        }


        protected void PopulateFromVPK()
        {
            TreeNode rootNode = treeView.Nodes[0];
            rootNode.Tag = "/";
            rootNode.Text = "Dota 2 VPK";
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
            TreeNode rootNode = treeView.Nodes[0];
            string projectPath = Properties.Settings.Default.LoadedAddonDirectory;
            string projectName = Path.GetFileName(projectPath.Remove(projectPath.Length - 1));
            rootNode.Text = projectName;
            rootNode.Tag = projectPath;

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
        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
