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

            foreach(DotaDataObject ddo in ObjectList)
            {
                int imageIndex = 1;
                if(ddo.ObjectInfo.ObjectClass == DotaDataObject.DataObjectInfo.ObjectDataClass.Custom)
                {
                    imageIndex = 2;
                }

                TreeNode newNode = new TreeNode()
                {
                    Name = ddo.ClassName,
                    Text = ddo.ClassName,
                    Tag = ddo,
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,
                };
                Root.Nodes.Add(newNode);
            }
        }

        private void assetTreeView_DoubleClick(object sender, EventArgs e)
        {
            TreeNode SelectedNode = assetTreeView.SelectedNode;
            DotaDataObject ddo = SelectedNode.Tag as DotaDataObject;

            if (ddo == null) return; //We selected a root node.  Don't do anything here

            //TODO: Search the document registry for this object's document. 
            Document doc = DocumentRegistry.AllDocuments.FirstOrDefault(x => x.Name == ddo.ClassName);
            if(doc == null)
            {
                //If we don't have this document open, create it and add it to the registry
                doc = new DotaObjectDocument(ddo);
                DocumentRegistry.OpenDocument(doc);
            }
            
            doc.OpenDefaultEditor();

        }
    }
}
