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
    public partial class BoolEditor : Form
    {
        public BoolEditor()
        {
            InitializeComponent();
        }

        private bool value = false;

        public bool Value
        {
            get { return value; }
            set
            {
                this.value = value;
                if(value)
                {
                    radioButton2.Checked = true;
                }
                else
                {
                    radioButton1.Checked = false;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                radioButton1.Checked = false;
                value = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton2.Checked = false;
                value = false;
            }
        }
    }
}
