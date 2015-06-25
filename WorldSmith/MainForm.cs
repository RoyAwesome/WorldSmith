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

using WeifenLuo.WinFormsUI.Docking;
using System.Diagnostics;
using WorldSmith.LuaUtils;

namespace WorldSmith
{
    public partial class MainForm : Form
    {
        private readonly ContextMenuStrip _contextMenu;
    
        #region DockableForms
        ConsoleForm ConsoleForm;
        ProjectView ProjectView;
        DotaObjectBrowser ObjectBrowser;
        StartPageForm StartPageForm;
        ScratchPad ScratchPad;
        #endregion

        public static DockPanel PrimaryDockingPanel;

        public MainForm()
        {
            InitializeComponent();
            InitTabs();

            //Initialize the VS2012 ToolStrip for theme support
            this.vS2012ToolStripExtender1 = new DockSample.VS2012ToolStripExtender();

            // Create a dummy context menu
            _contextMenu = new ContextMenuStrip();
            ToolStripMenuItem menuItem1 = new ToolStripMenuItem("Option &1");
            ToolStripMenuItem menuItem2 = new ToolStripMenuItem("Option &2");
            ToolStripMenuItem menuItem3 = new ToolStripMenuItem("Option &3");
            _contextMenu.Items.Add(menuItem1);
            _contextMenu.Items.Add(menuItem2);
            _contextMenu.Items.Add(menuItem3);
 
            PrimaryDockingPanel = dockPanel; //Set a static accessor to our docking panel for all default controls to go to

            //dockPanel.Theme = new VS2012LightTheme();
        }
     
        private void InitTabs()
        {
            ConsoleForm = new ConsoleForm();
            ConsoleForm.Show(dockPanel, DockState.DockBottom);
            Program.ConsoleRedirect.Output = ConsoleForm;

            projectExplorerToolStripMenuItem.Enabled = false;
            objectBrowserToolStripMenuItem.Enabled = false;

            //Create the start page
            ShowStartPage();
        }

        private void addonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowNewAddonWizard();
        }

        private void ShowNewAddonWizard()
        {
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

            string addonPath = Properties.Settings.Default.AddOnPath + Path.DirectorySeparatorChar + wizard.addonNameBox.Text + Path.DirectorySeparatorChar;

            Directory.CreateDirectory(addonPath);
            Directory.CreateDirectory(addonPath + "scripts");
            Directory.CreateDirectory(addonPath + "resource");
            File.WriteAllText(addonPath + "addoninfo.txt", DotaData.KVHeader + doc.ToString());

            LoadProject(addonPath);  
        }

        //Open addon button clickevent
        private void addonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadAddon();
        }

        public void LoadAddon()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Properties.Settings.Default.DotaDir + Path.DirectorySeparatorChar + Properties.Settings.Default.BaseAddonDir;
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
            if (this.Text != "Worldsmith")
            {
                UnloadProject(); //This prevents some duplicated stuff
            }
            if(!Directory.Exists(path))
            {
                Console.WriteLine("Error: Directory does not exists. \"" + path + "\"");
                return;
            }
            Properties.Settings.Default.LoadedAddonDirectory = path;
            Properties.Settings.Default.Save();
            Console.WriteLine("Loading Project: " + path);

            AssetLoadingDialog loader = new AssetLoadingDialog();
            loader.ShowDialog(AssetLoadingDialog.AddonLoadTasks);

            ProjectView = new ProjectView();
            ProjectView.Show(dockPanel, DockState.DockLeft);

            ObjectBrowser = new DotaObjectBrowser();
            ObjectBrowser.Show(dockPanel, DockState.DockLeft);

            string addonName = Path.GetFileName(path.Remove(path.Length - 1));
            this.Text = "Worldsmith - " + addonName;

            projectExplorerToolStripMenuItem.Enabled = true;
            objectBrowserToolStripMenuItem.Enabled = true;

            AddToRecentAddonsList(addonName);
            UpdateStartPage(); 

            Console.WriteLine("Successfully Loaded Project: " + path);
        }

        //Close addon button clickevent
        private void fileMenuCloseAddon_Click(object sender, EventArgs e)
        {
            UnloadProject();
        }

        private void UnloadProject()
        {
            string closingPath = Properties.Settings.Default.LoadedAddonDirectory;
            Console.WriteLine("Unloading project: " + closingPath);

            Properties.Settings.Default.LoadedAddonDirectory = "";
            Properties.Settings.Default.Save();

            CloseFormsAndEditors();
            DotaData.UnloadUnits();
            ShowStartPage();

            this.Text = "Worldsmith";

            projectExplorerToolStripMenuItem.Enabled = false;
            objectBrowserToolStripMenuItem.Enabled = false;

            Console.WriteLine("Successfully unloaded project: " + closingPath);
        }

        #region UnloadAddon
        private void CloseFormsAndEditors()
        {
            if ( ProjectView != null && !ProjectView.IsDisposed) 
            { 
                ProjectView.Hide(); 
            }
            if ( ObjectBrowser != null && !ObjectBrowser.IsDisposed) 
            { 
                ObjectBrowser.Hide(); 
            }
            foreach(Documents.Document doc in Documents.DocumentRegistry.AllDocuments.ToList())
            {
                doc.CloseAllEditors(true);
            }
        }
        #endregion


        #region StartPage

        private void UpdateStartPage()
        {
            if (StartPageForm == null || StartPageForm.IsDisposed) { return; }
            StartPageForm.ListRecentAddons();
        }

        private void ShowStartPage()
        {
            if (StartPageForm == null || StartPageForm.IsDisposed) { StartPageForm = new StartPageForm(ShowNewAddonWizard,LoadAddon, LoadProject); }
            if (StartPageForm.Visible) { return; }
            StartPageForm.Show(dockPanel, DockState.Document);
        }

        private void HideStartPage()
        {
            if (StartPageForm == null || !StartPageForm.Visible) { return; }
            StartPageForm.Hide(); 
        }
        private void AddToRecentAddonsList(string name)
        {
            string[] recentAddons = Properties.Settings.Default.RecentAddons;

            if(recentAddons == null)
            {
                //first time, set it up
                recentAddons = new string[5];
                recentAddons[0] = name;
                for(int i=1;i<5;i++)
                {
                    recentAddons[i] = "";
                }
            }
            else
            {
                if(recentAddons.Contains(name))
                {
                    //make sure we dont store the same addon twice
                    for(int i=0;i<5;i++)
                    {
                        if(recentAddons[i] == name)
                        {
                            for(int j=i;j<5;j++)
                            {
                                recentAddons[j] = j == 4 ? "" : recentAddons[j + 1];
                            }
                            break;
                        }
                    }
                }
                string[] oldAddons = new string[5];
                recentAddons.CopyTo(oldAddons, 0);
                recentAddons[0] = name;
                for(int i=1; i<5; i++)
                {
                    recentAddons[i] = oldAddons[i - 1];
                }
            }
            Properties.Settings.Default.RecentAddons = recentAddons;
            Properties.Settings.Default.Save();
        }
        #endregion


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.LoadedAddonDirectory == "") //If we don't have an addon loaded, create a new one
            {
                addonToolStripMenuItem1_Click(null, null);
                if (Properties.Settings.Default.LoadedAddonDirectory == "") return; //if we still don't have an addon loaded, don't even bother
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
        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    if (form.Text == text)
                        return form as IDockContent;

                return null;
            }
            else
            {
                foreach (IDockContent content in dockPanel.Documents)
                    if (content.DockHandler.TabText == text)
                        return content;

                return null;
            }
        }
        #endregion

        #region Theme
        private void EnableVS2012Renderer(bool enable)
        {
            vS2012ToolStripExtender1.SetEnableVS2012Style(this.menuStrip1, enable);
        }
        private void SetSchema(object sender, System.EventArgs e)
        {
            //We need to close all the forms or else it goes boom
            foreach (IDockContent document in dockPanel.DocumentsToArray())
            {
                document.DockHandler.Close();
            }

            //Lets nuke all the default stuff too while we are at it
            if (ConsoleForm != null) { ConsoleForm.DockPanel = null; }
            if (ProjectView != null) { ProjectView.DockPanel = null; }
            if (ObjectBrowser != null) { ObjectBrowser.DockPanel = null; }

            if (sender == theme2005Button)
            {
                dockPanel.Theme = vS2005Theme1;
                EnableVS2012Renderer(false);
            }
            else if (sender == theme2003Button)
            {
                dockPanel.Theme = vS2003Theme1;
                EnableVS2012Renderer(false);
            }
            else if (sender == theme2012LightButton)
            {
                dockPanel.Theme = vS2012LightTheme1;
                EnableVS2012Renderer(true);
            }

            theme2005Button.Checked = (sender == theme2005Button);
            theme2003Button.Checked = (sender == theme2003Button);
            theme2012LightButton.Checked = (sender == theme2012LightButton);

            if (ConsoleForm != null) { ConsoleForm.Show(dockPanel, DockState.DockBottom); }
            if (ProjectView != null) { ProjectView.Show(dockPanel, DockState.DockLeft); }
            if (ObjectBrowser != null) { ObjectBrowser.Show(dockPanel, DockState.DockLeft); }

            StartPageForm = new StartPageForm(ShowNewAddonWizard, LoadAddon, LoadProject);
            StartPageForm.Show(dockPanel, DockState.Document);
            UpdateStartPage();

        }
        #endregion

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/royawesome/Worldsmith/issues");
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/royawesome/Worldsmith");
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdate.Check();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void luaScratchpadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ScratchPad == null) ScratchPad = new ScratchPad();
            ScratchPad.Show(dockPanel, DockState.Document);
        }
             
    }
}
