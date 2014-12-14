namespace WorldSmith.Panels
{
    partial class AbilityEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Default Abilities");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Custom Abilities", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Overridden Abilities", 1, 1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AbilityEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.abilityTreeView = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addItemButton = new System.Windows.Forms.ToolStripButton();
            this.abilityPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.categoryEditorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryEditorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.toolStripContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.abilityPropertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(557, 471);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.abilityTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(185, 446);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(185, 471);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // abilityTreeView
            // 
            this.abilityTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abilityTreeView.ImageIndex = 0;
            this.abilityTreeView.ImageList = this.imageList1;
            this.abilityTreeView.Location = new System.Drawing.Point(0, 0);
            this.abilityTreeView.Name = "abilityTreeView";
            treeNode1.ImageIndex = 0;
            treeNode1.Name = "defaultAbilities";
            treeNode1.Text = "Default Abilities";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "customAbilities";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Text = "Custom Abilities";
            treeNode2.ToolTipText = "Abilities created by you";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "overriddenAbilities";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Text = "Overridden Abilities";
            this.abilityTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.abilityTreeView.SelectedImageIndex = 0;
            this.abilityTreeView.Size = new System.Drawing.Size(185, 446);
            this.abilityTreeView.TabIndex = 0;
            this.abilityTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.abilityTreeView_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DefaultUnits.png");
            this.imageList1.Images.SetKeyName(1, "CustomUnits.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addItemButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(35, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // addItemButton
            // 
            this.addItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addItemButton.Image = ((System.Drawing.Image)(resources.GetObject("addItemButton.Image")));
            this.addItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addItemButton.Name = "addItemButton";
            this.addItemButton.Size = new System.Drawing.Size(23, 22);
            this.addItemButton.Text = "toolStripButton1";
            this.addItemButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // abilityPropertyGrid
            // 
            this.abilityPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.abilityPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.abilityPropertyGrid.Name = "abilityPropertyGrid";
            this.abilityPropertyGrid.Size = new System.Drawing.Size(368, 471);
            this.abilityPropertyGrid.TabIndex = 0;
            this.abilityPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.itemPropertyGrid_PropertyValueChanged);
            // 
            // categoryEditorBindingSource
            // 
            this.categoryEditorBindingSource.DataSource = typeof(WorldSmith.Panels.AbilityEditor);
            // 
            // AbilityEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 471);
            this.Controls.Add(this.splitContainer1);
            this.DockAreas = ((DigitalRune.Windows.Docking.DockAreas)((((((DigitalRune.Windows.Docking.DockAreas.Float | DigitalRune.Windows.Docking.DockAreas.Left) 
            | DigitalRune.Windows.Docking.DockAreas.Right) 
            | DigitalRune.Windows.Docking.DockAreas.Top) 
            | DigitalRune.Windows.Docking.DockAreas.Bottom) 
            | DigitalRune.Windows.Docking.DockAreas.Document)));
            this.Name = "AbilityEditor";
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
            ((System.ComponentModel.ISupportInitialize)(this.categoryEditorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        public System.Windows.Forms.TreeView abilityTreeView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.PropertyGrid abilityPropertyGrid;
        private System.Windows.Forms.BindingSource categoryEditorBindingSource;
        private System.Windows.Forms.ToolStripButton addItemButton;
        private System.Windows.Forms.ImageList imageList1;
    }
}
