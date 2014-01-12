using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs;


namespace WorldSmith.Panels
{
    public partial class CategoryEditor: UserControl
    {
        public CategoryEditor()
        {
            InitializeComponent();
        }

        //HACK HACK
        //I can't store the CustomList or DefaultList as a generic list (T is lost outside of Init)
        //So I store it as it's non-generic interface.  The types will match up anyway.
        System.Collections.IList CustomList;

        System.Collections.IList DefaultList;

        public void Init<T>(string type, List<T> DefaultList, List<T> CustomList) where T : DotaDataObject
        {
            treeView1.Nodes.Clear();

            AddDataSourceToNode("default" + type, "Default " + type, 0, DefaultList);
            AddDataSourceToNode("custom" + type, "Custom " + type, 1, CustomList);
            this.CustomList = CustomList;
            this.DefaultList = DefaultList;
        }

        private void AddDataSourceToNode<T>(string internalName, string displayName, int imageIndex, List<T> List) where T : DotaDataObject
        {
            TreeNode root = new TreeNode()
            {
                Name = internalName,
                Text = displayName,
                Tag = "Folder",
                ImageIndex = imageIndex,
                SelectedImageIndex = imageIndex
            };

            foreach(T item in List)
            {
                root.Nodes.Add(new TreeNode()
                    {
                        Name = item.ClassName,
                        Text = item.ClassName,
                        Tag = "Item",
                        ImageIndex = 3,
                        SelectedImageIndex = 3,
                    });
            }

            treeView1.Nodes.Add(root);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if((string)treeView1.SelectedNode.Tag != "Item") return;

            string classname = treeView1.SelectedNode.Name;
            DotaDataObject obj = DotaData.AllClasses.First(x => x.ClassName == classname);
            itemPropertyGrid.SelectedObject = obj;
        }

        private void itemPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            if (!treeView1.SelectedNode.Parent.Name.Contains("Default")) return;
            DotaDataObject customObject = (itemPropertyGrid.SelectedObject as DotaDataObject).Clone() as DotaDataObject;

            

            //Get a new classname for this overriden item               
            TextPrompt prompt = new TextPrompt();
            prompt.Text = "Create New Ability Classname";
            prompt.PromptText = customObject.ClassName + "_custom";

            CustomList.Add(customObject);
            TreeNode n = new TreeNode()
            {
                Name = customObject.ClassName,
                Text = customObject.ClassName,
                Tag = "Item",
                SelectedImageIndex = 3,
                ImageIndex = 3,
            };
            treeView1.Nodes[1].Nodes.Add(n);

            treeView1.SelectedNode = n;            
            treeView1.CollapseAll();
            n.Parent.ExpandAll();

            e.ChangedItem.PropertyDescriptor.SetValue(itemPropertyGrid.SelectedObject, e.OldValue); //Reset the value


        }
    }
}
