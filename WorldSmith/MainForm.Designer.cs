namespace WorldSmith
{
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.addonConfig = new System.Windows.Forms.TabPage();
            this.unitTab = new System.Windows.Forms.TabPage();
            this.unitEditor1 = new WorldSmith.Panels.UnitEditor();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.itemCategory = new WorldSmith.Panels.CategoryEditor();
            this.abilityTab = new System.Windows.Forms.TabPage();
            this.abilityCategory = new WorldSmith.Panels.CategoryEditor();
            this.modifierEditor = new System.Windows.Forms.TabPage();
            this.categoryEditor1 = new WorldSmith.Panels.CategoryEditor();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDotaDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.unitTab.SuspendLayout();
            this.itemTab.SuspendLayout();
            this.abilityTab.SuspendLayout();
            this.modifierEditor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem1});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // addonToolStripMenuItem1
            // 
            this.addonToolStripMenuItem1.Name = "addonToolStripMenuItem1";
            this.addonToolStripMenuItem1.Size = new System.Drawing.Size(110, 22);
            this.addonToolStripMenuItem1.Text = "Addon";
            this.addonToolStripMenuItem1.Click += new System.EventHandler(this.addonToolStripMenuItem1_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addonToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // addonToolStripMenuItem
            // 
            this.addonToolStripMenuItem.Name = "addonToolStripMenuItem";
            this.addonToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.addonToolStripMenuItem.Text = "Addon";
            this.addonToolStripMenuItem.Click += new System.EventHandler(this.addonToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(135, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.addonConfig);
            this.tabControl1.Controls.Add(this.unitTab);
            this.tabControl1.Controls.Add(this.itemTab);
            this.tabControl1.Controls.Add(this.abilityTab);
            this.tabControl1.Controls.Add(this.modifierEditor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 669);
            this.tabControl1.TabIndex = 1;
            // 
            // addonConfig
            // 
            this.addonConfig.Location = new System.Drawing.Point(4, 22);
            this.addonConfig.Name = "addonConfig";
            this.addonConfig.Padding = new System.Windows.Forms.Padding(3);
            this.addonConfig.Size = new System.Drawing.Size(908, 643);
            this.addonConfig.TabIndex = 0;
            this.addonConfig.Text = "Addon Config";
            this.addonConfig.UseVisualStyleBackColor = true;
            // 
            // unitTab
            // 
            this.unitTab.Controls.Add(this.unitEditor1);
            this.unitTab.Location = new System.Drawing.Point(4, 22);
            this.unitTab.Name = "unitTab";
            this.unitTab.Padding = new System.Windows.Forms.Padding(3);
            this.unitTab.Size = new System.Drawing.Size(908, 643);
            this.unitTab.TabIndex = 1;
            this.unitTab.Text = "Unit Editor";
            this.unitTab.UseVisualStyleBackColor = true;
            // 
            // unitEditor1
            // 
            this.unitEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitEditor1.Location = new System.Drawing.Point(3, 3);
            this.unitEditor1.Name = "unitEditor1";
            this.unitEditor1.Size = new System.Drawing.Size(902, 637);
            this.unitEditor1.TabIndex = 0;
            // 
            // itemTab
            // 
            this.itemTab.Controls.Add(this.itemCategory);
            this.itemTab.Location = new System.Drawing.Point(4, 22);
            this.itemTab.Name = "itemTab";
            this.itemTab.Size = new System.Drawing.Size(908, 643);
            this.itemTab.TabIndex = 2;
            this.itemTab.Text = "Item Editor";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // itemCategory
            // 
            this.itemCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemCategory.Location = new System.Drawing.Point(0, 0);
            this.itemCategory.Name = "itemCategory";
            this.itemCategory.Size = new System.Drawing.Size(908, 643);
            this.itemCategory.TabIndex = 0;
            // 
            // abilityTab
            // 
            this.abilityTab.Controls.Add(this.abilityCategory);
            this.abilityTab.Location = new System.Drawing.Point(4, 22);
            this.abilityTab.Name = "abilityTab";
            this.abilityTab.Size = new System.Drawing.Size(908, 643);
            this.abilityTab.TabIndex = 3;
            this.abilityTab.Text = "Ability Editor";
            this.abilityTab.UseVisualStyleBackColor = true;
            // 
            // abilityCategory
            // 
            this.abilityCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abilityCategory.Location = new System.Drawing.Point(0, 0);
            this.abilityCategory.Name = "abilityCategory";
            this.abilityCategory.Size = new System.Drawing.Size(908, 643);
            this.abilityCategory.TabIndex = 0;
            // 
            // modifierEditor
            // 
            this.modifierEditor.Controls.Add(this.categoryEditor1);
            this.modifierEditor.Location = new System.Drawing.Point(4, 22);
            this.modifierEditor.Name = "modifierEditor";
            this.modifierEditor.Size = new System.Drawing.Size(908, 643);
            this.modifierEditor.TabIndex = 4;
            this.modifierEditor.Text = "Modifier Editor";
            this.modifierEditor.UseVisualStyleBackColor = true;
            // 
            // categoryEditor1
            // 
            this.categoryEditor1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryEditor1.Location = new System.Drawing.Point(0, 0);
            this.categoryEditor1.Name = "categoryEditor1";
            this.categoryEditor1.Size = new System.Drawing.Size(908, 643);
            this.categoryEditor1.TabIndex = 0;
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDotaDirectoryToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // setDotaDirectoryToolStripMenuItem
            // 
            this.setDotaDirectoryToolStripMenuItem.Name = "setDotaDirectoryToolStripMenuItem";
            this.setDotaDirectoryToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.setDotaDirectoryToolStripMenuItem.Text = "Set Dota Directory";
            this.setDotaDirectoryToolStripMenuItem.Click += new System.EventHandler(this.setDotaDirectoryToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 693);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Worldsmith";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.unitTab.ResumeLayout(false);
            this.itemTab.ResumeLayout(false);
            this.abilityTab.ResumeLayout(false);
            this.modifierEditor.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage addonConfig;
        private System.Windows.Forms.TabPage unitTab;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TabPage abilityTab;
        private System.Windows.Forms.TabPage modifierEditor;
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
        private Panels.CategoryEditor categoryEditor1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDotaDirectoryToolStripMenuItem;
    }
}

