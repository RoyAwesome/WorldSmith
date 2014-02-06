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

namespace WorldSmith.Dialogs.Actions
{
    public partial class ActionListEditor : Form
    {
        public ActionListEditor()
        {
            InitializeComponent();
        }

        public IEnumerable<BaseActionVariable> Variables;
        public string ActionContext;

        private ActionCollection actions;

        public ActionCollection Actions
        {
            get { return actions; }
            set
            {
                actions = value;
                ResetActionList();
            }
        }


        private void ResetActionList()
        {
            listBox1.Items.Clear();

            foreach(BaseAction action in Actions)
            {
                listBox1.Items.Add(action.ClassName);
            }

        }



        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewActionDialog dialog = new NewActionDialog();

            

            if(dialog.ShowDialog(ActionContext, Variables) == DialogResult.OK)
            {
                BaseAction action = dialog.SelectedAction;
                actions.Add(action);

                ResetActionList();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BaseAction action = Actions.FirstOrDefault(x => x.ClassName == listBox1.SelectedItem as string);

            propertyGrid1.SelectedObject = action;
            objectLinkEdit1.Object = action;
        }
    }
}
