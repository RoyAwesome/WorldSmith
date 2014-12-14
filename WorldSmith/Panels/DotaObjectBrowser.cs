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
                TreeNode newNode = new TreeNode()
                {
                    Name = ddo.ClassName,
                    Text = ddo.ClassName,

                };
                Root.Nodes.Add(newNode);
            }
        }
    }
}
