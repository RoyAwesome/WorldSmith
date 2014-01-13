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

        public AbilityActionCollection Actions;

        public ActionEditor()
        {
            InitializeComponent();
        }
    }


    public class AbilityActionEditor : UITypeEditor
    {
        ActionEditor actionEditor;

        public AbilityActionEditor()
        {
            actionEditor = new ActionEditor();
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
