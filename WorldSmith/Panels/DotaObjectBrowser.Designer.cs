namespace WorldSmith.Panels
{
    partial class DotaObjectBrowser
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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Heroes");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Node4");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] {
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Units", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15});
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Abilities");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Items");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DotaObjectBrowser));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.assetTreeView = new System.Windows.Forms.TreeView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openAsTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.overrideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.heroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abilityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.assetTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(245, 568);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(245, 593);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // assetTreeView
            // 
            this.assetTreeView.ContextMenuStrip = this.contextMenuStrip;
            this.assetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTreeView.ImageIndex = 0;
            this.assetTreeView.ImageList = this.imageList;
            this.assetTreeView.Indent = 13;
            this.assetTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetTreeView.Name = "assetTreeView";
            treeNode10.Name = "heroes";
            treeNode10.Text = "Heroes";
            treeNode11.Name = "Node3";
            treeNode11.Text = "Node3";
            treeNode12.Name = "Node4";
            treeNode12.Text = "Node4";
            treeNode13.Name = "Node0";
            treeNode13.Text = "Node0";
            treeNode14.Name = "Node1";
            treeNode14.Text = "Node1";
            treeNode15.Name = "Node2";
            treeNode15.Text = "Node2";
            treeNode16.Name = "units";
            treeNode16.Text = "Units";
            treeNode17.Name = "abilities";
            treeNode17.Text = "Abilities";
            treeNode18.Name = "items";
            treeNode18.Text = "Items";
            this.assetTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode16,
            treeNode17,
            treeNode18});
            this.assetTreeView.SelectedImageIndex = 0;
            this.assetTreeView.Size = new System.Drawing.Size(245, 568);
            this.assetTreeView.TabIndex = 0;
            this.assetTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.assetTreeView_AfterSelect);
            this.assetTreeView.DoubleClick += new System.EventHandler(this.assetTreeView_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openAsTextToolStripMenuItem,
            this.toolStripSeparator1,
            this.overrideToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(143, 98);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // openAsTextToolStripMenuItem
            // 
            this.openAsTextToolStripMenuItem.Name = "openAsTextToolStripMenuItem";
            this.openAsTextToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.openAsTextToolStripMenuItem.Text = "Open as Text";
            this.openAsTextToolStripMenuItem.Click += new System.EventHandler(this.openAsTextToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // overrideToolStripMenuItem
            // 
            this.overrideToolStripMenuItem.Enabled = false;
            this.overrideToolStripMenuItem.Name = "overrideToolStripMenuItem";
            this.overrideToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.overrideToolStripMenuItem.Text = "Override";
            this.overrideToolStripMenuItem.Click += new System.EventHandler(this.overrideToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Folder.png");
            this.imageList.Images.SetKeyName(1, "dotaicon16x16.png");
            this.imageList.Images.SetKeyName(2, "WSIcon32.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(97, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heroToolStripMenuItem,
            this.unitToolStripMenuItem,
            this.abilityToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(54, 22);
            this.toolStripDropDownButton1.Text = "Create";
            // 
            // heroToolStripMenuItem
            // 
            this.heroToolStripMenuItem.Enabled = false;
            this.heroToolStripMenuItem.Name = "heroToolStripMenuItem";
            this.heroToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.heroToolStripMenuItem.Text = "Hero";
            this.heroToolStripMenuItem.ToolTipText = "This is not currently supported by Dota 2.";
            this.heroToolStripMenuItem.Click += new System.EventHandler(this.heroToolStripMenuItem_Click);
            // 
            // unitToolStripMenuItem
            // 
            this.unitToolStripMenuItem.Name = "unitToolStripMenuItem";
            this.unitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.unitToolStripMenuItem.Text = "Unit";
            this.unitToolStripMenuItem.ToolTipText = "Create a new unit.";
            this.unitToolStripMenuItem.Click += new System.EventHandler(this.unitToolStripMenuItem_Click);
            // 
            // abilityToolStripMenuItem
            // 
            this.abilityToolStripMenuItem.Name = "abilityToolStripMenuItem";
            this.abilityToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abilityToolStripMenuItem.Text = "Ability";
            this.abilityToolStripMenuItem.ToolTipText = "Create a new ability.";
            this.abilityToolStripMenuItem.Click += new System.EventHandler(this.abilityToolStripMenuItem_Click);
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.itemToolStripMenuItem.Text = "Item";
            this.itemToolStripMenuItem.ToolTipText = "Create a new item.";
            this.itemToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
            // 
            // DotaObjectBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 593);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DotaObjectBrowser";
            this.TabText = "DotaObjectBrowser";
            this.Text = "DotaObjectBrowser";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TreeView assetTreeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openAsTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem overrideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem heroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abilityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
    }
}