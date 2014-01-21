using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs.Actions;
using WorldSmith.Panels;

namespace WorldSmith.Dialogs
{
    public partial class ActionEditor : Form
    {
        AbilityActionCollection actions;
        public AbilityActionCollection Actions
        {
            get { return actions; }
            set
            {
                actions = value;
                SetupActions();
            }
        }

        public ActionEditor()
        {
            InitializeComponent();
            treeView1.ExpandAll();
        }

        private void SetupActions()
        {
            foreach(KeyValuePair<string, ActionCollection> kv in actions.Actions)
            {
                TreeNode n = treeView1.Nodes.Find(kv.Key, true)[0];

                foreach(BaseAction action in kv.Value)
                {
                    n.Nodes.Add(new TreeNode()
                        {
                            Name = action.ClassName,
                            Text = action.ClassName,
                            Tag = action,
                        });
                }

            }
            treeView1.ExpandAll();
        }

        public new DialogResult ShowDialog()
        {
            //set the title of the dialog based on which property we are editing
            TabPage selectedTab = Program.mainForm.tabControl1.SelectedTab;
            for (int i = 0; i < selectedTab.Controls.Count; i++)
            {
                Control c = selectedTab.Controls[i];
                if (c is CategoryEditor)
                {
                    CategoryEditor editor = c as CategoryEditor;
                    this.Text = "Action Editor - " + editor.treeView1.SelectedNode.Text;
                }
            }
            base.ShowDialog();
            return DialogResult.OK;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!(treeView1.SelectedNode.Tag is BaseAction))
            {
                propertyGrid1.SelectedObject = null;
                return;
            }

            BaseAction action = treeView1.SelectedNode.Tag as BaseAction;

            propertyGrid1.SelectedObject = action;        
            

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if ((treeView1.SelectedNode.Tag as string) == "Root")
            {

                return;
            }


            NewActionDialog dialog = new NewActionDialog();
            dialog.ShowDialog(treeView1.SelectedNode.Text, actions);
        }
    }


    public class AbilityActionEditor : UITypeEditor
    {
        ActionEditor actionEditor;

        public AbilityActionEditor()
        {
            actionEditor = new ActionEditor();
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc != null)
                {
                    actionEditor.Actions = (AbilityActionCollection)value;
                    if (actionEditor.ShowDialog() == DialogResult.OK)
                    {
                        return actionEditor.Actions;
                    }
                    else
                    {
                        return value;
                    }

                }
            }
            return null;
        }

     }
}
