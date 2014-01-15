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
                            Tag = "Item",
                        });
                }

            }
            treeView1.ExpandAll();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
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
