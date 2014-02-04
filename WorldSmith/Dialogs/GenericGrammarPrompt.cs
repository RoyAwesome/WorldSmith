using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSmith.Dialogs
{
    public partial class GenericGrammarPrompt : Form
    {
        public string Grammar
        {
            get
            {
                return objectLinkEdit1.Grammer;
            }
            set
            {
                objectLinkEdit1.Grammer = value;
            }
        }

        public object SelectedObject
        {
            get
            {
                return objectLinkEdit1.Object;
            }
            set
            {
                objectLinkEdit1.Object = value;
            }

        }

        public string ActionContext
        {
            get { return objectLinkEdit1.ActionContext; }
            set { objectLinkEdit1.ActionContext = value; }
        }

        public GenericGrammarPrompt()
        {
            InitializeComponent();
        }

        private void okayButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
