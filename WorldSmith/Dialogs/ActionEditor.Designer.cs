namespace WorldSmith.Dialogs
{
    partial class ActionEditor
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("OnSpellStart");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("OnChannelSucceeded");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("OnChannelInterrupted");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("OnChannelFinish");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("OnToggleOn");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("OnToggleOff");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("OnAbilityPhaseStart");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("OnOwnerDied");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("OnOwnerSpawned");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("OnUpgrade");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("OnProjectileHitUnit");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("OnProjectileFinish");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Action Name", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10,
            treeNode11,
            treeNode12});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Size = new System.Drawing.Size(991, 549);
            this.splitContainer1.SplitterDistance = 213;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Indent = 10;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "OnSpellStart";
            treeNode1.Text = "OnSpellStart";
            treeNode2.Name = "OnChannelSucceeded";
            treeNode2.Text = "OnChannelSucceeded";
            treeNode3.Name = "OnChannelInterrupted";
            treeNode3.Text = "OnChannelInterrupted";
            treeNode4.Name = "OnChannelFinish";
            treeNode4.Text = "OnChannelFinish";
            treeNode5.Name = "OnToggleOn";
            treeNode5.Text = "OnToggleOn";
            treeNode6.Name = "OnToggleOff";
            treeNode6.Text = "OnToggleOff";
            treeNode7.Name = "OnAbilityPhaseStart";
            treeNode7.Text = "OnAbilityPhaseStart";
            treeNode8.Name = "OnOwnerDied";
            treeNode8.Text = "OnOwnerDied";
            treeNode9.Name = "OnOwnerSpawned";
            treeNode9.Text = "OnOwnerSpawned";
            treeNode10.Name = "OnUpgrade";
            treeNode10.Text = "OnUpgrade";
            treeNode11.Name = "OnProjectileHitUnit";
            treeNode11.Text = "OnProjectileHitUnit";
            treeNode12.Name = "OnProjectileFinish";
            treeNode12.Text = "OnProjectileFinish";
            treeNode13.Name = "actionRoot";
            treeNode13.Text = "Action Name";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(213, 549);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(991, 549);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(991, 574);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(85, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton1.Text = "New Action";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // ActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 574);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionEditor";
            this.Text = "Action Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
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

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;

    }
}