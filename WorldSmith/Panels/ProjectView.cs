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
using WorldSmith.Documents;
using System.Text.RegularExpressions;

namespace WorldSmith.Panels
{
    public partial class ProjectView : DockableForm
    {
        public string currentCopyPath = null;
        public bool currentCut = false;
        public bool createFileMode = false;
        public ProjectView()
        {
            InitializeComponent();
            
            //without this line, right-clicks don't change focus.
            treeView1.NodeMouseClick += (sender, args) => treeView1.SelectedNode = args.Node;

            //show the selection passively
            treeView1.HideSelection = false;

            //allow renaming
            treeView1.LabelEdit = true;

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
                        Tag = ((string)parent.Tag) + name + "/",
                        ContextMenu = folder_context_menu,
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
                        ContextMenu = file_context_menu,
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
                    ContextMenu = folder_context_menu,
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
                        ContextMenu = file_context_menu,
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

        private bool CanOpenDocument(string path)
        {
            //TODO: Disallow opening files that the object browser modifies - or just have it open them in the object browser

            if (Path.GetExtension(path) == ".txt") return true;
            if (Path.GetExtension(path) == ".lua") return true;

            return false;
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;

            //The path of the file double clicked is stored in the treenode's tag
            string path = selectedNode.Tag as string;
            if(!CanOpenDocument(path))
            {
                return;
            }
            TreeNode root = GetRootNode(selectedNode); 
            bool FromVPK = root.Name == "vpk";

            TextDocument document = DocumentRegistry.GetDocumentFor(path) as TextDocument;
            if(document == null)
            {
                document = new TextDocument(path, FromVPK);
                DocumentRegistry.OpenDocument(path, document);
            }

            document.OpenDefaultEditor();          
        }

        private void context_add_lua_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            createFileMode = true;
            TreeNode newfile = new TreeNode()
            {
                Name = "untitled.lua",
                Text = "untitled.lua",
                ImageIndex = 0,
                SelectedImageIndex = 0,
                Tag = path + "untitled.lua",
            };
            selectedNode.Nodes.Add(newfile);
            treeView1.SelectedNode = newfile;
            newfile.BeginEdit();
            // Note that we haven't actually created the file yet... that's done after we let the user change the name
        }

        private void context_openInExplorer_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            //TODO: put the folder path in the treenode, then look it up from there when we use this
            System.Diagnostics.Process.Start("explorer.exe", path);
        }

        private void context_cut_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            currentCopyPath = path;
            currentCut = true;
        }

        private void context_copy_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            currentCopyPath = path;
            currentCut = false;
        }

        private void context_paste_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            //TODO: functionality
        }

        private void context_delete_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            string path = selectedNode.Tag as string;
            if (MessageBox.Show("Are you sure you want to delete " + path + " and all files contained therein?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //TODO: remove all contained files from any file-dependent analyses
                Directory.Delete(path,true);
                selectedNode.Remove();
            }
        }

        private void context_rename_simple_Click(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null && selectedNode.Parent != null)
            {
                treeView1.SelectedNode = selectedNode;
                selectedNode.BeginEdit();
            }
        }

        private void treeView1_afterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                if (e.Node.Parent != null)
                {
                    if (e.Label.Length > 0)
                    {
                        if (e.Label.IndexOfAny(new char[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' }) == -1)
                        {
                            // get the absolute file/folder location
                            Regex directorygetter = new Regex("/[^/]*$");
                            //TODO: fix directory stuff
                            string directory = Path.GetFullPath(e.Node.Tag as string);
                            string oldfilename = Path.GetFileName(e.Node.Tag as string);
                            MessageBox.Show(directory + " | " + oldfilename);
                            /* TODO:
                             * if (targetfileexists) {
                             *     e.CancelEdit = true;
                             *     e.Node.BeginEdit();
                             *     return;
                             * }
                             */
                            if (createFileMode)
                            {
                                // We're in the process of making a new file

                                // Done making the file; leave this whole shebang.
                                createFileMode = false;
                                e.Node.EndEdit(false);
                            }
                            else
                            {
                                try
                                {
                                    File.Move(directory + (e.Node.Tag as string), directory + e.Label);
                                }
                                catch (Exception ex)
                                {
                                    e.CancelEdit = true;
                                    MessageBox.Show("File rename failed: " + ex.ToString());
                                    e.Node.EndEdit(true);
                                    return;
                                }
                                // No error, so stop editing without canceling the label change.
                                e.Node.EndEdit(false);
                            }
                        }
                        else
                        {
                            /* Cancel the label edit action, inform the user, and 
                               place the node in edit mode again. */
                            e.CancelEdit = true;
                            MessageBox.Show("Invalid tree node label.\n" +
                               "The invalid characters are: '<', '>', ':', '\"', '/', '\\', '|', '?', '*'",
                               "Node Label Edit");
                            e.Node.BeginEdit();
                        }
                    }
                    else
                    {
                        /* Cancel the label edit action, inform the user, and 
                           place the node in edit mode again. */
                        e.CancelEdit = true;
                        MessageBox.Show("Invalid tree node label.\nThe label cannot be blank",
                           "Node Label Edit");
                        e.Node.BeginEdit();
                    }
                }
                else
                {
                    e.CancelEdit = true;
                    MessageBox.Show("Top level renaming not currently supported");
                }
            }
        }

        private void folder_context_menu_Popup(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                TreeNode root = GetRootNode(selectedNode);
                bool FromVPK = root.Name == "vpk";
                // VPK is read-only for now
                context_delete.Enabled = !FromVPK;
                // These two are disabled regardless right now
                //context_cut.Enabled = !FromVPK;
                //context_paste.Enabled = !FromVPK && currentCopyPath != null;
                context_add.Enabled = !FromVPK;
                context_rename.Enabled = !FromVPK;
                context_openInExplorer.Enabled = !FromVPK;
            }
        }

        private void file_context_menu_Popup(object sender, EventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                TreeNode root = GetRootNode(selectedNode);
                bool FromVPK = root.Name == "vpk";
                // VPK is read-only for now
                file_context_delete.Enabled = !FromVPK;
                // This one is disabled regardless right now
                //file_context_cut.Enabled = !FromVPK;
                file_context_rename.Enabled = !FromVPK;
            }
        }
    }
}
