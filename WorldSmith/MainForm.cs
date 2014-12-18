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

        #region DockableForms
        ConsoleForm ConsoleForm;
        ConsoleStringWriter _consoleWriter;  
        ProjectView ProjectView;
        DotaObjectBrowser ObjectBrowser;
        #endregion

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

        //Open addon button clickevent
        private void addonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Properties.Settings.Default.DotaDir + "\\dota_ugc\\game\\dota_addons\\";
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
            Console.WriteLine("Loading Project: " + path);

            AssetLoadingDialog loader = new AssetLoadingDialog();
            loader.ShowDialog(AssetLoadingDialog.AddonLoadTasks);
            
            InitTabs();

            ProjectView = new ProjectView();
            ProjectView.Show(dockPanel, DockState.DockLeft);

            ObjectBrowser = new DotaObjectBrowser();
            ObjectBrowser.Show(dockPanel, DockState.DockLeft);

            this.Text = "Worldsmith - " + Path.GetFileName(path.Remove(path.Length - 1));

            Console.WriteLine("Successfully Loaded Project: " + path);
        }

        //Close addon button clickevent
        private void fileMenuCloseAddon_Click(object sender, EventArgs e)
        {
            string closingPath = Properties.Settings.Default.LoadedAddonDirectory;
            Console.WriteLine("Unloading project: " + closingPath);

            Properties.Settings.Default.LoadedAddonDirectory = "";
            Properties.Settings.Default.Save();

            ProjectView.Hide();
            ObjectBrowser.Hide();

            foreach(Documents.Document doc in Documents.DocumentRegistry.AllDocuments.ToList())
            {
                doc.CloseAllEditors(true);
            }

            DotaData.UnloadUnits();
            Console.WriteLine("Successfully unloaded project: " + closingPath);
        }

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
        #endregion

        private void blackThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.VisualStylesEnabled = true;
            ToolStripManager.Renderer = new ToolStripOffice2007Renderer(Office2007Theme.Black);
            DockPanelManager.RenderMode = DockPanelRenderMode.Office2007Black;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void blueThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.VisualStylesEnabled = true;
            ToolStripManager.Renderer = new ToolStripOffice2007Renderer(Office2007Theme.Blue);
            DockPanelManager.RenderMode = DockPanelRenderMode.Office2007Blue;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void silverThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.VisualStylesEnabled = true;
            ToolStripManager.Renderer = new ToolStripOffice2007Renderer(Office2007Theme.Silver);
            DockPanelManager.RenderMode = DockPanelRenderMode.Office2007Silver;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void professionalThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.RenderMode = ToolStripManagerRenderMode.Professional;
            ToolStripManager.VisualStylesEnabled = false;
            DockPanelManager.RenderMode = DockPanelRenderMode.Professional;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void visualThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.RenderMode = ToolStripManagerRenderMode.System;
            ToolStripManager.VisualStylesEnabled = true;
            DockPanelManager.RenderMode = DockPanelRenderMode.VisualStyles;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void systemThemeButton_Click(object sender, EventArgs e)
        {
            ToolStripManager.RenderMode = ToolStripManagerRenderMode.System;
            ToolStripManager.VisualStylesEnabled = false;
            DockPanelManager.RenderMode = DockPanelRenderMode.System;
            BackColor = DockPanelManager.BackColor;   // To avoid artifacts when resizing the main window.
            dockPanel.Refresh();
        }

        private void themesToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            professionalThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.Professional;
            systemThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.System;
            visualThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.VisualStyles;
            blackThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.Office2007Black;
            blueThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.Office2007Blue;
            silverThemeButton.Checked = DockPanelManager.RenderMode == DockPanelRenderMode.Office2007Silver;
        }


    }
}
