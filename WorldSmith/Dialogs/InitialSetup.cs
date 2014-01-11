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
        DialogResult result = DialogResult.None;

        public InitialSetup(bool firstTime)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            if (!firstTime)
            {
                this.label1.Text = "";
                this.Text = "Set Dota Directory";
                //resize window and move components to compensate for the lack of label1 text
                this.textBox1.Location = new System.Drawing.Point(this.textBox1.Location.X, this.textBox1.Location.Y - 80);
                this.button1.Location = new System.Drawing.Point(this.button1.Location.X, this.button1.Location.Y - 80);
                this.button2.Location = new System.Drawing.Point(this.button2.Location.X, this.button2.Location.Y - 80);
                this.label2.Location = new System.Drawing.Point(this.label2.Location.X, this.label2.Location.Y - 80);
                this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 80);
            }
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
            if (!ValidateDota2Dir(textBox1.Text))
            {
                MessageBox.Show("This doesn't appear to be your Dota 2 directory.", "Invalid Dota Directory", MessageBoxButtons.OK);
                result = DialogResult.None;
                return;
            }
            else
            {
                result = DialogResult.OK;
                Properties.Settings.Default.dotadir = textBox1.Text;
                this.Close();
            }
        }

        bool ValidateDota2Dir(string path)
        {
            return File.Exists(path + Path.DirectorySeparatorChar + DotaData.VPKPath);
        }

        public new DialogResult ShowDialog()
        {
            this.Focus();
            base.ShowDialog();
            return result;
        }
    }
}
