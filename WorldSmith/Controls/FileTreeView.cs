using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSmith.Controls
{
    public enum FileViewSource
    {
        Vpk,
        Project,
    }

    public partial class FileTreeView : UserControl
    {      
        public FileTreeView()
        {
            InitializeComponent();
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

            }

            
        }

     
        protected void PopulateFromVPK()
        {
            TreeNode rootNode = treeView.Nodes[0];
            rootNode.Tag = "/";
            IntPtr rootptr = HLLib.hlPackageGetRoot();

            RecursivePopulateFromVPK(ref rootNode, rootptr);

            rootNode.Expand();

        }

        protected void RecursivePopulateFromVPK(ref TreeNode parent, IntPtr CurrentFolder)
        {
            uint folderCount = HLLib.hlFolderGetCount(CurrentFolder);

            for(uint i = 0; i < folderCount; i++)
            {
                IntPtr subItem = HLLib.hlFolderGetItem(CurrentFolder, i);
                string name = HLLib.hlItemGetName(subItem);

                if(HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FOLDER)
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
                else if(HLLib.hlItemGetType(subItem) == HLLib.HLDirectoryItemType.HL_ITEM_FILE)
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
        

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
