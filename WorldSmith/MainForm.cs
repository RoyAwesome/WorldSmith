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

using DigitalRune.Windows.Docking;

namespace WorldSmith
{
    public partial class MainForm : Form
    {
        private readonly ContextMenuStrip _contextMenu;

        ConsoleForm ConsoleForm;
        ConsoleStringWriter _consoleWriter;

        VPKView VPKView;

        ProjectView ProjectView;

        public static DockPanel PrimaryDockingPanel;

        public MainForm()
        {
            InitializeComponent();
            InitTabs();


            // Create a dummy context menu
            _contextMenu = new ContextMenuStrip();
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Option &1");
            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Option &2");
            ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Option &3");
            _contextMenu.Items.Add(menuItem1);
            _contextMenu.Items.Add(menuItem2);
            _contextMenu.Items.Add(menuItem3);

            //Create the console and lock it
            ConsoleForm = new ConsoleForm();
            ConsoleForm.Show(dockPanel, DockState.DockBottom);
            _consoleWriter = new ConsoleStringWriter(ConsoleForm);
            Console.SetOut(_consoleWriter);

            //Create the project views
            VPKView = new VPKView();
            VPKView.Show(dockPanel, DockState.DockLeft);
            VPKView.HideOnClose = true;

            //TODO: Figure out a way to toggle off the VPK View button when disabled


            DotaObjectBrowser ObjectBrowser = new DotaObjectBrowser();
            ObjectBrowser.Show(dockPanel, DockState.DockLeft);


            PrimaryDockingPanel = dockPanel; //Set a static accessor to our docking panel for all default controls to go to.
        }
     
        private void InitTabs()
        {
            IDockableForm[] documents = dockPanel.DocumentsToArray();
            foreach (IDockableForm document in documents)
            {
                String type = document.GetType().ToString();
                switch (type)
                {
                    case "WorldSmith.Panels.UnitEditor":
                        Console.WriteLine("UNIT EDITOR!!!");
                        //unitEditor.LoadFromData();
                        break;
                    case "WorldSmith.Panels.ItemEditor":
                        Console.WriteLine("ITEM EDITOR!!!");
                        //itemCategory.Init("Items", DotaData.DefaultItems, DotaData.CustomItems, DotaData.OverridenItems);
                        break;
                    case "WorldSmith.Panels.AbilityEditor":
                        Console.WriteLine("ABILITY EDITOR!!!");
                        //abilityCategory.Init("Ability", DotaData.DefaultAbilities, DotaData.CustomAbilities, DotaData.OverridenAbilities);
                        break;
                }
            }

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

            string addonPath = Properties.Settings.Default.AddOnDir + Path.DirectorySeparatorChar + wizard.addonNameBox.Text + Path.DirectorySeparatorChar;

            Directory.CreateDirectory(addonPath);
            Directory.CreateDirectory(addonPath + "scripts");
            Directory.CreateDirectory(addonPath + "resource");
            File.WriteAllText(addonPath + "addoninfo.txt", DotaData.KVHeader + doc.ToString());

            LoadProject(addonPath);         
        }

        private void addonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Properties.Settings.Default.AddOnDir != "" ? Properties.Settings.Default.AddOnDir : Properties.Settings.Default.DotaDir;
            if (dialog.ShowDialog() != DialogResult.OK) return;
            string folder = dialog.SelectedPath + Path.DirectorySeparatorChar;

            if(!File.Exists(folder + "addoninfo.txt"))
            {
                MessageBox.Show("That's not an addon folder!\nSelect a folder with an addoninfo.txt", "Invalid Folder", MessageBoxButtons.OK);
                return;
            }

            LoadProject(folder);            
        }

        public void LoadProject(string path)
        {
            Properties.Settings.Default.LoadedAddonDirectory = path;
            Properties.Settings.Default.Save();

            AssetLoadingDialog loader = new AssetLoadingDialog();
            loader.ShowDialog(AssetLoadingDialog.AddonLoadTasks);

            InitTabs();


            ProjectView = new ProjectView();
            ProjectView.Show(dockPanel, DockState.DockLeft);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.AddOnPath == "") //If we don't have an addon loaded, create a new one
            {
                addonToolStripMenuItem1_Click(null, null);
                if (Properties.Settings.Default.AddOnPath == "") return; //if we still don't have an addon loaded, don't even bother
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
            Properties.Settings.Default.Language = cultureName;
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

        private void textEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextEditor editor = new TextEditor();
            editor.Show();
        }
   
        #region EditorCreation
        private IDockableForm FindDocument(string title)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == title)
                        return form as IDockableForm;

                return null;
            }

            IDockableForm[] documents = dockPanel.DocumentsToArray();
            foreach (IDockableForm document in documents)
                if (document.DockingHandler.TabText == title)
                    return document;
            return null;
        }
        private AbilityEditor  CreateAbilityEditor()
        {
            AbilityEditor document = new AbilityEditor();

            // Set document title
            int count = 1;
            string title = "CategoryEditor " + count;
            while (FindDocument(title) != null)
            {
                count++;
                title = "CategoryEditor" + count;
            }

            document.Text = title;
            document.ToolTipText = "Tool tip of " + title;
            document.TabPageContextMenuStrip = _contextMenu;
            return document;
        }
        private ItemEditor CreateItemEditor()
        {
            ItemEditor document = new ItemEditor();

            // Set document title
            int count = 1;
            string title = "Item Editor " + count;
            while (FindDocument(title) != null)
            {
                count++;
                title = "Item Editor" + count;
            }

            document.Text = title;
            document.ToolTipText = "Tool tip of " + title;
            document.TabPageContextMenuStrip = _contextMenu;
            return document;
        }
        private UnitEditor CreateUnitEditor()
        {
            UnitEditor document = new UnitEditor();

            // Set document title
            int count = 1;
            string title = "Unit Editor " + count;
            while (FindDocument(title) != null)
            {
                count++;
                title = "Unit Editor " + count;
            }

            document.Text = title;
            document.ToolTipText = "Tool tip of " + title;
            document.TabPageContextMenuStrip = _contextMenu;
            return document;
        }
        #endregion

        #region EditorButtons
        private void newUnitEditorButton_Click(object sender, EventArgs e)
        {
            UnitEditor document = CreateUnitEditor();

            // Show document
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                document.MdiParent = this;
                document.Show();
            }
            else
            {
                document.Show(dockPanel);
            }
        }

        private void newAbilityEditorButton_Click(object sender, EventArgs e)
        {
            AbilityEditor document = CreateAbilityEditor();

            // Show document
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                document.MdiParent = this;
                document.Show();
            }
            else
            {
                document.Show(dockPanel);
            }
        }

        private void newItemEditorButton_Click(object sender, EventArgs e)
        {
            ItemEditor document = CreateItemEditor();

            // Show document
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                document.MdiParent = this;
                document.Show();
            }
            else
            {
                document.Show(dockPanel);
            }
        }
        #endregion

        private void vPKViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VPKView view = new VPKView();
           
            view.Show(dockPanel, DockState.DockLeft);
        }

        private void vPKExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(VPKView.IsHidden)
            {
                VPKView.Show(dockPanel);
            }
            else
            {
                VPKView.Hide();
            }
            vpkviewToggleButton.Checked = !VPKView.IsHidden;
        }
    }
}
