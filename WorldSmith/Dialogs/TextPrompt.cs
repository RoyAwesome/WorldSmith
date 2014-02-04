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
    public partial class TextPrompt : Form
    {
        public TextPrompt()
        {
            InitializeComponent();
        }

        public string PromptText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
