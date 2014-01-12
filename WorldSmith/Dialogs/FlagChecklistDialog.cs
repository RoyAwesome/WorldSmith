using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Design;
using System.Windows.Forms.Design;
using WorldSmith.DataClasses.UI;
using WorldSmith.Dialogs;

namespace WorldSmith.Panels
{
    public partial class FlagChecklistDialog : Form
    {
        DialogResult result;

        public FlagChecklistDialog()
        {
            InitializeComponent();
            result = DialogResult.Cancel;
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            result = DialogResult.Cancel;
            this.Close();
        }

        public new DialogResult ShowDialog()
        {
            Console.WriteLine(ListBox.Items.Count);
            base.ShowDialog();
            return result;
        }

        //resize the dialog based on the number of values in the list
        public void resize()
        {
            int border = 10;

            int newHeight, newWidth;
            if (ListBox.Items.Count >= 20)
            {
                newHeight = (ListBox.Items.Count / 2 * 16) + 8;
                newWidth = ListBox.Size.Width;
            }
            else
            {
                newHeight = ListBox.Items.Count * 16;
                newWidth = ListBox.ColumnWidth + 10;
            }
            ListBox.Size = new Size(newWidth, newHeight);
            ListBox.Location = new Point(border, border);
            this.Size = new Size((int)(border * 3.5 + newWidth), border * 10 + newHeight);
            applyButton.Location = new Point(newWidth - applyButton.Size.Width, border + newHeight + applyButton.Size.Height);
            cancelButton.Location = new Point(newWidth - cancelButton.Size.Width - border - cancelButton.Size.Width, border + newHeight + cancelButton.Size.Height);
        }
    }


    //FLAG ENUM DIALOG UI EDITOR
    public class FlagEnumDialogUIEditor : UITypeEditor
    {
        // The dialog
        private FlagChecklistDialog dialog;

        public FlagEnumDialogUIEditor()
        {
            dialog = new FlagChecklistDialog();
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (context != null && context.Instance != null && provider != null)
            {
                IWindowsFormsEditorService edSvc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if (edSvc != null)
                {

                    Enum e = (Enum)Convert.ChangeType(value, context.PropertyDescriptor.PropertyType);
                    dialog.ListBox.EnumValue = e;
                    dialog.resize();
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        return dialog.ListBox.EnumValue;
                    }
                    else
                    {
                        return e;
                    }

                }
            }
            return null;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}