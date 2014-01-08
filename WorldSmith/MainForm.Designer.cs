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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Default Units");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Default Heroes");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Custom Units");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Custom Heroes");
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.addonConfig = new System.Windows.Forms.TabPage();
            this.unitTab = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.unitPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.itemTab = new System.Windows.Forms.TabPage();
            this.abilityTab = new System.Windows.Forms.TabPage();
            this.modifierEditor = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.unitTreeView = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.unitTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(916, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
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
            this.unitTab.Controls.Add(this.splitContainer1);
            this.unitTab.Location = new System.Drawing.Point(4, 22);
            this.unitTab.Name = "unitTab";
            this.unitTab.Padding = new System.Windows.Forms.Padding(3);
            this.unitTab.Size = new System.Drawing.Size(908, 643);
            this.unitTab.TabIndex = 1;
            this.unitTab.Text = "Unit Editor";
            this.unitTab.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.unitPropertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(902, 637);
            this.splitContainer1.SplitterDistance = 191;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.unitTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(191, 612);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(191, 637);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            this.toolStripContainer1.TopToolStripPanel.Click += new System.EventHandler(this.toolStripContainer1_TopToolStripPanel_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // unitPropertyGrid
            // 
            this.unitPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.unitPropertyGrid.Name = "unitPropertyGrid";
            this.unitPropertyGrid.Size = new System.Drawing.Size(707, 637);
            this.unitPropertyGrid.TabIndex = 0;
            // 
            // itemTab
            // 
            this.itemTab.Location = new System.Drawing.Point(4, 22);
            this.itemTab.Name = "itemTab";
            this.itemTab.Size = new System.Drawing.Size(908, 643);
            this.itemTab.TabIndex = 2;
            this.itemTab.Text = "Item Editor";
            this.itemTab.UseVisualStyleBackColor = true;
            // 
            // abilityTab
            // 
            this.abilityTab.Location = new System.Drawing.Point(4, 22);
            this.abilityTab.Name = "abilityTab";
            this.abilityTab.Size = new System.Drawing.Size(908, 643);
            this.abilityTab.TabIndex = 3;
            this.abilityTab.Text = "Ability Editor";
            this.abilityTab.UseVisualStyleBackColor = true;
            // 
            // modifierEditor
            // 
            this.modifierEditor.Location = new System.Drawing.Point(4, 22);
            this.modifierEditor.Name = "modifierEditor";
            this.modifierEditor.Size = new System.Drawing.Size(908, 643);
            this.modifierEditor.TabIndex = 4;
            this.modifierEditor.Text = "Modifier Editor";
            this.modifierEditor.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DefaultUnits.png");
            this.imageList1.Images.SetKeyName(1, "CustomUnits.png");
            // 
            // unitTreeView
            // 
            this.unitTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitTreeView.ImageIndex = 0;
            this.unitTreeView.ImageList = this.imageList1;
            this.unitTreeView.Location = new System.Drawing.Point(0, 0);
            this.unitTreeView.Name = "unitTreeView";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "defaultUnits";
            treeNode1.Tag = "\"Folder\"";
            treeNode1.Text = "Default Units";
            treeNode1.ToolTipText = "Valve created Dota2 Units";
            treeNode2.ImageIndex = 0;
            treeNode2.Name = "defaultHeroes";
            treeNode2.Tag = "\"Folder\"";
            treeNode2.Text = "Default Heroes";
            treeNode2.ToolTipText = "Valve created Dota2 Heroes";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "customUnits";
            treeNode3.Tag = "\"Folder\"";
            treeNode3.Text = "Custom Units";
            treeNode3.ToolTipText = "Custom Units created by you";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "customHeroes";
            treeNode4.Tag = "\"Folder\"";
            treeNode4.Text = "Custom Heroes";
            treeNode4.ToolTipText = "Custom Heroes created by you";
            this.unitTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.unitTreeView.SelectedImageIndex = 0;
            this.unitTreeView.Size = new System.Drawing.Size(191, 612);
            this.unitTreeView.TabIndex = 0;
            this.unitTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.unitTreeView_AfterSelect);
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
            this.Text = "Worldsmith";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.unitTab.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage addonConfig;
        private System.Windows.Forms.TabPage unitTab;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage itemTab;
        private System.Windows.Forms.TabPage abilityTab;
        private System.Windows.Forms.TabPage modifierEditor;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.PropertyGrid unitPropertyGrid;
        private System.Windows.Forms.TreeView unitTreeView;
        private System.Windows.Forms.ImageList imageList1;
    }
}

