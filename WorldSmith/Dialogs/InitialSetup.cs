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

        public InitialSetup(bool startup)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Set Dota Directory";

            if (!startup)
            {
                this.label1.Text = "";
                //resize window and move components to compensate for the lack of label1 text
                this.txtDotaDir.Location = new System.Drawing.Point(this.txtDotaDir.Location.X,
                                                                    this.txtDotaDir.Location.Y - 40);
                this.btnBrowse.Location = new System.Drawing.Point(this.btnBrowse.Location.X,
                                                                   this.btnBrowse.Location.Y - 40);
                this.btnOK.Location = new System.Drawing.Point(this.btnOK.Location.X, this.btnOK.Location.Y - 40);
                this.label2.Location = new System.Drawing.Point(this.label2.Location.X, this.label2.Location.Y - 40);
                this.Size = new System.Drawing.Size(this.Size.Width, this.Size.Height - 40);
            }
        }

        public bool IsDotaDirSet()
        {
            // Set the Dota 2 directory if it isn't set yet
            if (String.IsNullOrEmpty(Properties.Settings.Default.DotaDir))
            {
                if (this.ShowDialog() != DialogResult.OK)
                {
                    return false;
                }
            }
            else
            {
                // Make sure the dota 2 directory exists
                if (!ValidateDota2Dir(Properties.Settings.Default.DotaDir))
                {
                    MessageBox.Show("Your Dota 2 directory is missing or has been changed.",
                                    "Invalid Dota 2 Directory", MessageBoxButtons.OK);
                    if (this.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsAddOnPathSet()
        {
            if (String.IsNullOrEmpty(Properties.Settings.Default.AddOnPath))
            {
                return false;
            }

            // Make sure an addons directory exists
            if (!Directory.Exists(Properties.Settings.Default.AddOnPath))
            {
                Directory.CreateDirectory(Properties.Settings.Default.AddOnPath);
            }

            return true;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Navigate to your Dota 2 main directory.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtDotaDir.Text = dialog.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateDota2Dir(txtDotaDir.Text))
            {
                MessageBox.Show("This doesn't appear to be your Dota 2 directory.", "Invalid Dota Directory", MessageBoxButtons.OK);
                result = DialogResult.None;
                return;
            }
            else
            {
                result = DialogResult.OK;
                Properties.Settings.Default.DotaDir = txtDotaDir.Text;
                Properties.Settings.Default.AddOnDir = txtDotaDir.Text + Path.DirectorySeparatorChar + "game" + Path.DirectorySeparatorChar + "dota_addons";
                Properties.Settings.Default.AddOnPath = txtDotaDir.Text + Path.DirectorySeparatorChar + "game" + Path.DirectorySeparatorChar + "dota_addons";
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
