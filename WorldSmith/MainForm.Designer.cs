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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addonToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDotaDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.swedishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.addonConfig = new System.Windows.Forms.TabPage();
            this.unitTab = new System.Windows.Forms.TabPage();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.abilityTab = new System.Windows.Forms.TabPage();
            this.unitEditor1 = new WorldSmith.Panels.UnitEditor();
            this.itemCategory = new WorldSmith.Panels.CategoryEditor();
            this.abilityCategory = new WorldSmith.Panels.CategoryEditor();
            this.localeManager1 = new WorldSmith.LocaleManager(this.components);
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.unitTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            this.abilityTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            // 
            // addonToolStripMenuItem1
            // 
            this.addonToolStripMenuItem1.Name = "addonToolStripMenuItem1";
            resources.ApplyResources(this.addonToolStripMenuItem1, "addonToolStripMenuItem1");
            this.addonToolStripMenuItem1.Click += new System.EventHandler(this.addonToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            resources.ApplyResources(this.openToolStripMenuItem, "openToolStripMenuItem");
            // 
            // addonToolStripMenuItem
            // 
            this.addonToolStripMenuItem.Name = "addonToolStripMenuItem";
            resources.ApplyResources(this.addonToolStripMenuItem, "addonToolStripMenuItem");
            this.addonToolStripMenuItem.Click += new System.EventHandler(this.addonToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            resources.ApplyResources(this.saveToolStripMenuItem, "saveToolStripMenuItem");
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDotaDirectoryToolStripMenuItem,
            this.languageToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // setDotaDirectoryToolStripMenuItem
            // 
            this.setDotaDirectoryToolStripMenuItem.Name = "setDotaDirectoryToolStripMenuItem";
            resources.ApplyResources(this.setDotaDirectoryToolStripMenuItem, "setDotaDirectoryToolStripMenuItem");
            this.setDotaDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setDotaDirectoryToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.swedishToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.addonConfig);
            this.tabControl1.Controls.Add(this.unitTab);
            this.tabControl1.Controls.Add(this.itemTab);
            this.tabControl1.Controls.Add(this.abilityTab);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // addonConfig
            // 
            resources.ApplyResources(this.addonConfig, "addonConfig");
            this.addonConfig.Name = "addonConfig";
            this.addonConfig.UseVisualStyleBackColor = true;
            // 
            // unitTab
            // 
            this.unitTab.Controls.Add(this.unitEditor1);
            resources.ApplyResources(this.unitTab, "unitTab");
            this.unitTab.Name = "unitTab";
            this.unitTab.UseVisualStyleBackColor = true;
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.itemCategory);
            resources.ApplyResources(this.itemTab, "itemTab");
            this.itemTab.Name = "itemTab";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // abilityTab
            // 
            this.abilityTab.Controls.Add(this.abilityCategory);
            resources.ApplyResources(this.abilityTab, "abilityTab");
            this.abilityTab.Name = "abilityTab";
            this.abilityTab.UseVisualStyleBackColor = true;
            // 
            // unitEditor1
            // 
            resources.ApplyResources(this.unitEditor1, "unitEditor1");
            this.unitEditor1.Name = "unitEditor1";
            // 
            // itemCategory
            // 
            resources.ApplyResources(this.itemCategory, "itemCategory");
            this.itemCategory.Name = "itemCategory";
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
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.unitTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            this.abilityTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage addonConfig;
        private System.Windows.Forms.TabPage unitTab;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TabPage abilityTab;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private Panels.CategoryEditor itemCategory;
        private Panels.UnitEditor unitEditor1;
        private Panels.CategoryEditor abilityCategory;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDotaDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem swedishToolStripMenuItem;
        private LocaleManager localeManager1;
    }
}

