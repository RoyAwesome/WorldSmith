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
using System.Reflection;

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
                n.Nodes.Clear();
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

            TreeNode varNode = treeView1.Nodes[1];
            foreach(BaseActionVariable variable in actions.Variables)
            {
                varNode.Nodes.Add(new TreeNode()
                    {
                        Name = variable.Name,
                        Text = variable.Name,
                        Tag = variable,
                    });

            }

            TreeNode modNode = treeView1.Nodes[2];

            foreach(DotaModifier modifier in actions.Modifiers)
            {
                modNode.Nodes.Add(new TreeNode()
                    {
                        Name = modifier.ClassName,
                        Text = modifier.ClassName,
                        Tag = modifier,
                    });
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
            if (treeView1.SelectedNode.Tag is string)
            {
                propertyGrid1.SelectedObject = null;
                return;
            }

            object o = treeView1.SelectedNode.Tag;

            if(treeView1.SelectedNode.Parent != null)
            {
                objectLinkEdit1.ActionContext = treeView1.SelectedNode.Parent.Text;
            }            
           
            EditorGrammarAttribute attrib = o.GetType().GetCustomAttribute<EditorGrammarAttribute>();
            if(attrib != null)
            {
                objectLinkEdit1.Grammer = attrib.Grammar;
                
            }
            else
            {
                objectLinkEdit1.Grammer = "No Grammar Found";
            }

            objectLinkEdit1.Object = o;


            propertyGrid1.SelectedObject = o;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if ((treeView1.SelectedNode.Tag as string) == "Root")
            {

                return;
            }
            if (!actions.Actions.ContainsKey(treeView1.SelectedNode.Text)) return;
            ActionCollection bin = actions.Actions[treeView1.SelectedNode.Text];

            NewActionDialog dialog = new NewActionDialog();
            if(dialog.ShowDialog(treeView1.SelectedNode.Text, actions) == DialogResult.OK)
            {
                bin.Add(dialog.SelectedAction);
                treeView1.SelectedNode.Nodes.Add(new TreeNode()
                    {
                        Text = dialog.SelectedAction.ClassName,
                        Name = dialog.SelectedAction.ClassName,
                        Tag = dialog.SelectedAction,
                    });
                treeView1.SelectedNode.Expand();
            }

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
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
                    AbilityActionCollection actionCollection = (AbilityActionCollection)value;
                    actionEditor.Actions = actionCollection;
                    if (actionEditor.ShowDialog() == DialogResult.OK)
                    {
                                              
                    }
                  
                    return actionCollection;
                }
            }
            return null;
        }

     }
}
