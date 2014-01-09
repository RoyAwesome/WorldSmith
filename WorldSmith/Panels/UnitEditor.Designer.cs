namespace WorldSmith.Panels
{
    partial class UnitEditor
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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Default Units");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Default Heroes");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Custom Units", 1, 1);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Custom Heroes", 1, 1);
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Overriden Units");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Overriden Heroes");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnitEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.unitTreeView = new System.Windows.Forms.TreeView();
            this.unitPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.unitPropertyGrid);
            this.splitContainer1.Size = new System.Drawing.Size(726, 581);
            this.splitContainer1.SplitterDistance = 203;
            this.splitContainer1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.unitTreeView);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(203, 556);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(203, 581);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // unitTreeView
            // 
            this.unitTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitTreeView.ImageIndex = 0;
            this.unitTreeView.ImageList = this.imageList1;
            this.unitTreeView.Location = new System.Drawing.Point(0, 0);
            this.unitTreeView.Name = "unitTreeView";
            treeNode7.ImageIndex = 0;
            treeNode7.Name = "defaultUnits";
            treeNode7.Tag = "\"Folder\"";
            treeNode7.Text = "Default Units";
            treeNode7.ToolTipText = "Valve created Dota2 Units";
            treeNode8.ImageIndex = 0;
            treeNode8.Name = "defaultHeroes";
            treeNode8.Tag = "\"Folder\"";
            treeNode8.Text = "Default Heroes";
            treeNode8.ToolTipText = "Valve created Dota2 Heroes";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "customUnits";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Tag = "\"Folder\"";
            treeNode9.Text = "Custom Units";
            treeNode9.ToolTipText = "Custom Units created by you";
            treeNode10.ImageIndex = 1;
            treeNode10.Name = "customHeroes";
            treeNode10.SelectedImageIndex = 1;
            treeNode10.Tag = "\"Folder\"";
            treeNode10.Text = "Custom Heroes";
            treeNode10.ToolTipText = "Custom Heroes created by you";
            treeNode11.Name = "overrideUnits";
            treeNode11.Text = "Overriden Units";
            treeNode12.Name = "overrideHero";
            treeNode12.Text = "Overriden Heroes";
            this.unitTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            this.unitTreeView.SelectedImageIndex = 0;
            this.unitTreeView.Size = new System.Drawing.Size(203, 556);
            this.unitTreeView.TabIndex = 1;
            this.unitTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.unitTreeView_AfterSelect);
            // 
            // unitPropertyGrid
            // 
            this.unitPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.unitPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.unitPropertyGrid.Name = "unitPropertyGrid";
            this.unitPropertyGrid.Size = new System.Drawing.Size(519, 581);
            this.unitPropertyGrid.TabIndex = 1;
            this.unitPropertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.unitPropertyGrid_PropertyValueChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "DefaultUnits.png");
            this.imageList1.Images.SetKeyName(1, "CustomUnits.png");
            // 
            // UnitEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "UnitEditor";
            this.Size = new System.Drawing.Size(726, 581);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TreeView unitTreeView;
        private System.Windows.Forms.PropertyGrid unitPropertyGrid;
        private System.Windows.Forms.ImageList imageList1;
    }
}
