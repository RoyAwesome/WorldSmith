using DigitalRune.Windows.Docking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Documents;

namespace WorldSmith.Panels
{
    public partial class DotaObjectBrowser : DockableForm
    {
        public DotaObjectBrowser()
        {
            InitializeComponent();

            RefreshTreeView();
        }

        public void RefreshTreeView()
        {

            FillInFromList("heroes", DotaData.DefaultHeroes); //TODO: Create a list of 'valid' heroes.  Remove Default heroes that are overridden            
            FillInFromList("units", DotaData.AllUnits);            
            FillInFromList("abilities", DotaData.AllAbilities);
            FillInFromList("items", DotaData.AllItems);


        }

        private void FillInFromList(string Type, IEnumerable<DotaDataObject> ObjectList)
        {
            TreeNode Root = assetTreeView.Nodes[Type];
            Root.Nodes.Clear();

            TreeNode DefaultFolder = new TreeNode()
            {
                Name = "defaultFolder",
                Text = "Default",
                ImageIndex = 0,
                SelectedImageIndex = 0,
            };
            Root.Nodes.Add(DefaultFolder);

            foreach(DotaDataObject ddo in ObjectList)
            {
                bool Default = ddo.ObjectInfo.ObjectClass == DotaDataObject.DataObjectInfo.ObjectDataClass.Default;

                //If we are a custom unit, display the custom unit icon.  If we are default, display the dota icon and put us in the default folder
                int imageIndex = 2;
                TreeNode parent = Root;
                if(Default)
                {
                    imageIndex = 1;
                    parent = DefaultFolder;
                }

                TreeNode newNode = new TreeNode()
                {
                    Name = ddo.ClassName,
                    Text = ddo.ClassName,
                    Tag = ddo,
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,
                };

                parent.Nodes.Add(newNode);
            }
        }

        private void OpenObjectEditor(DotaDataObject ddo)
        {                        
            Document doc = DocumentRegistry.GetDocumentFor(ddo);
            if (doc == null)
            {
                //If we don't have this document open, create it and add it to the registry
                doc = new DotaObjectDocument(ddo);
                DocumentRegistry.OpenDocument(ddo, doc);
            }

            doc.OpenDefaultEditor();
        }

        private void OpenTextEditor(DotaDataObject ddo)
        {
            Document doc = DocumentRegistry.GetDocumentFor(ddo);
            if (doc == null)
            {
                //If we don't have this document open, create it and add it to the registry
                doc = new DotaObjectDocument(ddo);
                DocumentRegistry.OpenDocument(ddo, doc);
            }

            (doc as DotaObjectDocument).OpenTextEditor();
        }

        private void assetTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (assetTreeView.SelectedNode == null) return;
            
            TreeNode SelectedNode = assetTreeView.SelectedNode;
            DotaDataObject ddo = SelectedNode.Tag as DotaDataObject;

            if (ddo == null) return; //We selected a root node.  Don't do anything here

            OpenObjectEditor(ddo);
        }

        private TreeNode SelectedNode()
        {
            return assetTreeView.SelectedNode;
        }

        private void assetTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Get the item and the context menu options available to it
            
        }


        private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TreeNode node = SelectedNode();
            if (node == null) return;

            DotaDataObject ddo = node.Tag as DotaDataObject;
            if(ddo == null) //We are a folder.  Disable all of the options
            {
                foreach(ToolStripItem item in contextMenuStrip.Items)
                {
                    item.Enabled = false;
                }

                return;
            }
            else
            { //We are not a folder, so lets enable everything then decide what to disable

                openAsTextToolStripMenuItem.Enabled = true;
                openToolStripMenuItem.Enabled = true;
            }

            //Enable the delete option if not from the VPK.  Disable override if we are not default
           deleteToolStripMenuItem.Enabled = !ddo.ObjectInfo.FromVPK;
           overrideToolStripMenuItem.Enabled = ddo.ObjectInfo.ObjectClass == DotaDataObject.DataObjectInfo.ObjectDataClass.Default;


        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SelectedNode();
            if (node == null) return;
            DotaDataObject ddo = node.Tag as DotaDataObject;

            if (ddo == null) return; //It's a folder!

            OpenObjectEditor(ddo);
        }

        private void openAsTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SelectedNode();
            if (node == null) return;
            DotaDataObject ddo = node.Tag as DotaDataObject;

            if (ddo == null) return; //It's a folder!

            OpenTextEditor(ddo);
        }

       

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SelectedNode();
            if (node == null) return;
            DotaDataObject ddo = node.Tag as DotaDataObject;

            if (ddo == null) return; //It's a folder, we cant delete this.
            if (ddo.ObjectInfo.ObjectClass == DotaDataObject.DataObjectInfo.ObjectDataClass.Default) return; //Can't delete default objects

            if(MessageBox.Show("Are you sure?  This cannot be undone", "Delete Object", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                //Get the document for this and close the editors
                Document doc = DocumentRegistry.GetDocumentFor(ddo);
                if(doc != null)
                {
                    doc.CloseAllEditors(false);
                }


                IList list = DotaData.FindListThatHasObject(ddo);
                list.Remove(ddo);

                //remove this node from the tree view
                node.Parent.Nodes.Remove(node);
                //And it's gone!  
            }
            

        }

        private void overrideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = SelectedNode();
            if (node == null) return;
            DotaDataObject ddo = node.Tag as DotaDataObject;
            if (ddo == null) return; //It's a folder, we cant override this.

            
        }
    }
}
