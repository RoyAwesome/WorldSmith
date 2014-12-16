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

        private void assetTreeView_DoubleClick(object sender, EventArgs e)
        {
            if (assetTreeView.SelectedNode == null) return;

            TreeNode SelectedNode = assetTreeView.SelectedNode;
            DotaDataObject ddo = SelectedNode.Tag as DotaDataObject;

            if (ddo == null) return; //We selected a root node.  Don't do anything here

            //TODO: Search the document registry for this object's document. 
            Document doc = DocumentRegistry.GetDocumentFor(ddo);
            if(doc == null)
            {
                //If we don't have this document open, create it and add it to the registry
                doc = new DotaObjectDocument(ddo);
                DocumentRegistry.OpenDocument(ddo, doc);
            }
            
            doc.OpenDefaultEditor();

        }

        private void assetTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Get the item and the context menu options available to it
        }
    }
}
