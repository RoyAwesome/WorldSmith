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
    public partial class EnumEditor : Form
    {
        public EnumEditor()
        {
            InitializeComponent();
        }



        public Enum EnumValue
        {
            get
            {
                return listBox1.SelectedItem as Enum;
            }
            set
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(Enum.GetValues(value.GetType()).Cast<Enum>().ToArray());
                listBox1.SelectedItem = value;
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
