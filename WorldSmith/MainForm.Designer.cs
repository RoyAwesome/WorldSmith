namespace WorldSmith
{

   //using WorldSmith.Resources.WinFormStrings;
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.addonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.addonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fileMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsSetDotaDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swedishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.objectBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.blueThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.silverThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.professionalThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.visualThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.systemThemeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.dockPanel = new DigitalRune.Windows.Docking.DockPanel();
            this.localeManager1 = new WorldSmith.LocaleManager(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.optionsMenu,
            this.windowToolStripMenuItem,
            this.themesToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuNew,
            this.fileMenuOpen,
            this.fileMenuSave,
            this.toolStripSeparator1,
            this.fileMenuExit});
            this.fileMenu.Name = "fileMenu";
            resources.ApplyResources(this.fileMenu, "fileMenu");
            // 
            // fileMenuNew
            // 
            this.fileMenuNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem1});
            this.fileMenuNew.Name = "fileMenuNew";
            resources.ApplyResources(this.fileMenuNew, "fileMenuNew");
            // 
            // addonToolStripMenuItem1
            // 
            this.addonToolStripMenuItem1.Name = "addonToolStripMenuItem1";
            resources.ApplyResources(this.addonToolStripMenuItem1, "addonToolStripMenuItem1");
            this.addonToolStripMenuItem1.Click += new System.EventHandler(this.addonToolStripMenuItem1_Click);
            // 
            // fileMenuOpen
            // 
            this.fileMenuOpen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem});
            this.fileMenuOpen.Name = "fileMenuOpen";
            resources.ApplyResources(this.fileMenuOpen, "fileMenuOpen");
            // 
            // addonToolStripMenuItem
            // 
            this.addonToolStripMenuItem.Name = "addonToolStripMenuItem";
            resources.ApplyResources(this.addonToolStripMenuItem, "addonToolStripMenuItem");
            this.addonToolStripMenuItem.Click += new System.EventHandler(this.addonToolStripMenuItem_Click);
            // 
            // fileMenuSave
            // 
            this.fileMenuSave.Name = "fileMenuSave";
            resources.ApplyResources(this.fileMenuSave, "fileMenuSave");
            this.fileMenuSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // fileMenuExit
            // 
            this.fileMenuExit.Name = "fileMenuExit";
            resources.ApplyResources(this.fileMenuExit, "fileMenuExit");
            this.fileMenuExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsMenu
            // 
            this.optionsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsSetDotaDirectory,
            this.optionsMenuLanguage});
            this.optionsMenu.Name = "optionsMenu";
            resources.ApplyResources(this.optionsMenu, "optionsMenu");
            // 
            // optionsSetDotaDirectory
            // 
            this.optionsSetDotaDirectory.Name = "optionsSetDotaDirectory";
            resources.ApplyResources(this.optionsSetDotaDirectory, "optionsSetDotaDirectory");
            this.optionsSetDotaDirectory.Click += new System.EventHandler(this.setDotaDirectoryToolStripMenuItem_Click);
            // 
            // optionsMenuLanguage
            // 
            this.optionsMenuLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.swedishToolStripMenuItem});
            this.optionsMenuLanguage.Name = "optionsMenuLanguage";
            resources.ApplyResources(this.optionsMenuLanguage, "optionsMenuLanguage");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // swedishToolStripMenuItem
            // 
            this.swedishToolStripMenuItem.Name = "swedishToolStripMenuItem";
            resources.ApplyResources(this.swedishToolStripMenuItem, "swedishToolStripMenuItem");
            this.swedishToolStripMenuItem.Click += new System.EventHandler(this.swedishToolStripMenuItem_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectExplorerToolStripMenuItem,
            this.objectBrowserToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            resources.ApplyResources(this.windowToolStripMenuItem, "windowToolStripMenuItem");
            // 
            // projectExplorerToolStripMenuItem
            // 
            this.projectExplorerToolStripMenuItem.Name = "projectExplorerToolStripMenuItem";
            resources.ApplyResources(this.projectExplorerToolStripMenuItem, "projectExplorerToolStripMenuItem");
            // 
            // objectBrowserToolStripMenuItem
            // 
            this.objectBrowserToolStripMenuItem.Checked = true;
            this.objectBrowserToolStripMenuItem.CheckOnClick = true;
            this.objectBrowserToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.objectBrowserToolStripMenuItem.Name = "objectBrowserToolStripMenuItem";
            resources.ApplyResources(this.objectBrowserToolStripMenuItem, "objectBrowserToolStripMenuItem");
            // 
            // themesToolStripMenuItem
            // 
            this.themesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackThemeButton,
            this.blueThemeButton,
            this.silverThemeButton,
            this.professionalThemeButton,
            this.visualThemeButton,
            this.systemThemeButton});
            this.themesToolStripMenuItem.Name = "themesToolStripMenuItem";
            resources.ApplyResources(this.themesToolStripMenuItem, "themesToolStripMenuItem");
            // 
            // blackThemeButton
            // 
            this.blackThemeButton.Name = "blackThemeButton";
            resources.ApplyResources(this.blackThemeButton, "blackThemeButton");
            this.blackThemeButton.Click += new System.EventHandler(this.blackThemeButton_Click);
            // 
            // blueThemeButton
            // 
            this.blueThemeButton.Name = "blueThemeButton";
            resources.ApplyResources(this.blueThemeButton, "blueThemeButton");
            this.blueThemeButton.Click += new System.EventHandler(this.blueThemeButton_Click);
            // 
            // silverThemeButton
            // 
            this.silverThemeButton.Name = "silverThemeButton";
            resources.ApplyResources(this.silverThemeButton, "silverThemeButton");
            this.silverThemeButton.Click += new System.EventHandler(this.silverThemeButton_Click);
            // 
            // professionalThemeButton
            // 
            this.professionalThemeButton.Name = "professionalThemeButton";
            resources.ApplyResources(this.professionalThemeButton, "professionalThemeButton");
            this.professionalThemeButton.Click += new System.EventHandler(this.professionalThemeButton_Click);
            // 
            // visualThemeButton
            // 
            this.visualThemeButton.Checked = true;
            this.visualThemeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visualThemeButton.Name = "visualThemeButton";
            resources.ApplyResources(this.visualThemeButton, "visualThemeButton");
            this.visualThemeButton.Click += new System.EventHandler(this.visualThemeButton_Click);
            // 
            // systemThemeButton
            // 
            this.systemThemeButton.Name = "systemThemeButton";
            resources.ApplyResources(this.systemThemeButton, "systemThemeButton");
            this.systemThemeButton.Click += new System.EventHandler(this.systemThemeButton_Click);
            // 
            // dockPanel
            // 
            this.dockPanel.ActiveAutoHideContent = null;
            this.dockPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.dockPanel.DefaultFloatingWindowSize = new System.Drawing.Size(300, 300);
            resources.ApplyResources(this.dockPanel, "dockPanel");
            this.dockPanel.DockBottomPortion = 200D;
            this.dockPanel.DockLeftPortion = 200D;
            this.dockPanel.DockRightPortion = 200D;
            this.dockPanel.DockTopPortion = 200D;
            this.dockPanel.Name = "dockPanel";
            // 
            // localeManager1
            // 
            this.localeManager1.ParentControl = this;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dockPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem fileMenuNew;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExit;
        private System.Windows.Forms.ToolStripMenuItem optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsSetDotaDirectory;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuLanguage;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swedishToolStripMenuItem;
        private LocaleManager localeManager1;
        private DigitalRune.Windows.Docking.DockPanel dockPanel;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem objectBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackThemeButton;
        private System.Windows.Forms.ToolStripMenuItem blueThemeButton;
        private System.Windows.Forms.ToolStripMenuItem silverThemeButton;
        private System.Windows.Forms.ToolStripMenuItem professionalThemeButton;
        private System.Windows.Forms.ToolStripMenuItem visualThemeButton;
        private System.Windows.Forms.ToolStripMenuItem systemThemeButton;
    }
}

