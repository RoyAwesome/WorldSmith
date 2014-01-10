using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WorldSmith.DataClasses;

namespace WorldSmith.Dialogs
{
    public partial class InitialSetup : Form
    {
        public InitialSetup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.SelectedPath;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(!ValidateDota2Dir(textBox1.Text))
            {
                MessageBox.Show("This doesn't appear to be your Dota 2 directory", "Invalid Dota Directory", MessageBoxButtons.OK);
                return;
            }

            Properties.Settings.Default.dotadir = textBox1.Text;
            this.Close();
        }

        bool ValidateDota2Dir(string path)
        {
            return File.Exists(path + Path.DirectorySeparatorChar + DotaData.VPKPath);
        }
    }
}
