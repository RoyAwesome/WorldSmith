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
    public partial class VariableEditor : Form
    {
        public VariableEditor()
        {      
            InitializeComponent();
            radioButton2.Checked = true;
            radioButton2_CheckedChanged(null, null); //Start the value box checked
        }

        public void SetVariable(IEnumerable<string> vars)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(vars.ToArray());
        }
        
        public void SetDefault(string def)
        {
            if(def.StartsWith("%"))
            {
                radioButton1.Checked = true;
                radioButton1_CheckedChanged(null, null);
                comboBox1.SelectedItem = def.Replace("%", "");
            }
            else
            {
                textBox1.Text = def;
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox1.Clear();
            radioButton2.Checked = false;

            comboBox1.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            radioButton1.Checked = false;

            comboBox1.Enabled = false;
        }

        public string GetValue()
        {
            if(radioButton1.Checked)
            {
                return "%" + comboBox1.SelectedItem as string;
            }
            else
            {
                return textBox1.Text;
            }
        }
    }
}
