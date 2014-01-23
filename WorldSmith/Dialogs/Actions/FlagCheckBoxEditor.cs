using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSmith.Dialogs.Actions
{
    public partial class FlagCheckBoxEditor : Form
    {
        public FlagCheckBoxEditor()
        {
            InitializeComponent();
        }

        public Enum EnumValue
        {
            get
            {
                return flagCheckedListBox1.EnumValue;
            }

            set
            {
                flagCheckedListBox1.EnumValue = value;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
