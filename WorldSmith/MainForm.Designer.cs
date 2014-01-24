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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.addonConfig = new System.Windows.Forms.TabPage();
            this.unitTab = new System.Windows.Forms.TabPage();
            this.unitEditor = new WorldSmith.Panels.UnitEditor();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.itemCategory = new WorldSmith.Panels.CategoryEditor();
            this.abilityTab = new System.Windows.Forms.TabPage();
            this.abilityCategory = new WorldSmith.Panels.CategoryEditor();
            this.localeManager1 = new WorldSmith.LocaleManager(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.unitTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            this.abilityTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.optionsMenu});
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.addonConfig);
            this.tabControl.Controls.Add(this.unitTab);
            this.tabControl.Controls.Add(this.itemTab);
            this.tabControl.Controls.Add(this.abilityTab);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // addonConfig
            // 
            resources.ApplyResources(this.addonConfig, "addonConfig");
            this.addonConfig.Name = "addonConfig";
            this.addonConfig.UseVisualStyleBackColor = true;
            // 
            // unitTab
            // 
            this.unitTab.Controls.Add(this.unitEditor);
            resources.ApplyResources(this.unitTab, "unitTab");
            this.unitTab.Name = "unitTab";
            this.unitTab.UseVisualStyleBackColor = true;
            // 
            // unitEditor
            // 
            resources.ApplyResources(this.unitEditor, "unitEditor");
            this.unitEditor.Name = "unitEditor";
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.itemCategory);
            resources.ApplyResources(this.itemTab, "itemTab");
            this.itemTab.Name = "itemTab";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // itemCategory
            // 
            resources.ApplyResources(this.itemCategory, "itemCategory");
            this.itemCategory.Name = "itemCategory";
            // 
            // abilityTab
            // 
            this.abilityTab.Controls.Add(this.abilityCategory);
            resources.ApplyResources(this.abilityTab, "abilityTab");
            this.abilityTab.Name = "abilityTab";
            this.abilityTab.UseVisualStyleBackColor = true;
            // 
            // abilityCategory
            // 
            resources.ApplyResources(this.abilityCategory, "abilityCategory");
            this.abilityCategory.Name = "abilityCategory";
            // 
            // localeManager1
            // 
            this.localeManager1.ParentControl = this;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.unitTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            this.abilityTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        public System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage addonConfig;
        private System.Windows.Forms.TabPage unitTab;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TabPage abilityTab;
        private System.Windows.Forms.ToolStripMenuItem fileMenuNew;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuOpen;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileMenuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuExit;
        private Panels.CategoryEditor itemCategory;
        private Panels.UnitEditor unitEditor;
        private Panels.CategoryEditor abilityCategory;
        private System.Windows.Forms.ToolStripMenuItem optionsMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsSetDotaDirectory;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuLanguage;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swedishToolStripMenuItem;
        private LocaleManager localeManager1;
    }
}

