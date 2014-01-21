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
    public partial class NewActionDialog : Form
    {
        public NewActionDialog()
        {
            InitializeComponent();
            Init();
        }


        private void Init()
        {
            actionList.Items.AddRange(DotaActionFactory.ActionNames.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void actionList_SelectedValueChanged(object sender, EventArgs e)
        {
            actionGrammerEditor1.Action = DotaActionFactory.CreateNewAction(actionList.SelectedItem as string);
        }

        public DialogResult ShowDialog(string actionContext, AbilityActionCollection actionCollection)
        {
            actionGrammerEditor1.ActionContext = actionContext;
            actionGrammerEditor1.abilityActions = actionCollection;

            return base.ShowDialog();
        }

    }

    
}
