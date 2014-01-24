using KVLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs;
using WorldSmith.Panels;

namespace WorldSmith
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitTabs();
        }

        private void InitTabs()
        {
            abilityCategory.Init("Ability", DotaData.DefaultAbilities, DotaData.CustomAbilities);

            unitEditor.LoadFromData();
        }

        private void addonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Create the new Addon Wizard
            NewAddonWizard wizard = new NewAddonWizard();
            if (wizard.ShowDialog() != DialogResult.OK) return; //They didnt want to make a new addon.  Whatever...


            KeyValue doc = new KeyValue("AddonInfo");
            doc += new KeyValue("addonSteamAppID") + 816;
            doc += new KeyValue("addontitle") + wizard.addonTitleBox.Text;
            doc += new KeyValue("addonversion") + wizard.addonVersionBox.Text;
            doc += new KeyValue("addontagline") + wizard.addonTagLineBox.Text;
            doc += new KeyValue("addonauthor") + wizard.addonTagLineBox.Text;
            doc += new KeyValue("addonSteamGroupName") + wizard.addonSteamGroupName.Text;
            doc += new KeyValue("addonauthorSteamID") + wizard.addonSteamGroupName.Text;
            doc += new KeyValue("addonContent_Campaign") + 0;
            doc += new KeyValue("addonURL0") + wizard.addonURLBox.Text;
            doc += new KeyValue("addonDescription") + wizard.addonDescriptionBox.Text;

            string addonPath = Properties.Settings.Default.dotadir + Path.DirectorySeparatorChar
                + "dota" + Path.DirectorySeparatorChar + "addons" + Path.DirectorySeparatorChar
                + wizard.addonNameBox.Text + Path.DirectorySeparatorChar;

            Directory.CreateDirectory(addonPath);
            Directory.CreateDirectory(addonPath + "scripts");
            Directory.CreateDirectory(addonPath + "maps");
            Directory.CreateDirectory(addonPath + "materials");
            Properties.Settings.Default.AddonPath = addonPath;
            Properties.Settings.Default.Save();
            
            File.WriteAllText(addonPath + "addoninfo.txt", DotaData.KVHeader + doc.ToString());
        }

        private void addonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Properties.Settings.Default.dotadir + Path.DirectorySeparatorChar + "dota" + Path.DirectorySeparatorChar + "addons";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            string folder = dialog.SelectedPath + Path.DirectorySeparatorChar;

            if(!File.Exists(folder + "addoninfo.txt"))
            {
                MessageBox.Show("That's not an addon folder!\nSelect a folder with an addoninfo.txt", "Invalid Folder", MessageBoxButtons.OK);
                return;
            }


            Properties.Settings.Default.AddonPath = folder;
            Properties.Settings.Default.Save();

            AssetLoadingDialog loader = new AssetLoadingDialog();
            loader.ShowDialog(AssetLoadingDialog.AddonLoadTasks);

            
            InitTabs();

            
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.AddonPath == "") //If we don't have an addon loaded, create a new one
            {
                addonToolStripMenuItem1_Click(null, null);
                if (Properties.Settings.Default.AddonPath == "") return; //if we still don't have an addon loaded, don't even bother
            }

            AssetLoadingDialog dialog = new AssetLoadingDialog();
            dialog.ShowDialog(AssetLoadingDialog.AddonSaveTasks);
        }

        private void setDotaDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form initial = new InitialSetup(false);
            initial.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void oPENDIALOGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlagChecklistDialog dialog = new FlagChecklistDialog();
            dialog.ShowDialog();
        }

        #region Localization functions
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uncheckLanguage();
            englishToolStripMenuItem.Checked = true;
            localize("en-US");
        }

        private void swedishToolStripMenuItem_Click(object sender, EventArgs e)
        {

            uncheckLanguage();
            swedishToolStripMenuItem.Checked = true;
            localize("sv");
            
        }

        private void localize(String cultureName)
        {
            Properties.Settings.Default.language = cultureName;
            Properties.Settings.Default.Save();
            localeManager1.updateCulture(cultureName);
        }

        private void uncheckLanguage()
        {

            foreach (ToolStripMenuItem ts in optionsMenuLanguage.DropDownItems)
            {
                ts.Checked = false;
            }
        }
        #endregion

    }
}
