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
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("OnSpellStart");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("OnChannelSucceeded");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("OnChannelInterrupted");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("OnChannelFinish");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("OnToggleOn");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("OnToggleOff");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("OnAbilityPhaseStart");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("OnOwnerDied");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("OnOwnerSpawned");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("OnUpgrade");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("OnProjectileHitUnit");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("OnProjectileFinish");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Actions", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("Variables");
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("Modifiers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionEditor));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.objectLinkEdit1 = new WorldSmith.Panels.ObjectLinkEdit();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.newVariableButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.newModifierButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
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
            treeNode16.Name = "OnSpellStart";
            treeNode16.Tag = "Folder";
            treeNode16.Text = "OnSpellStart";
            treeNode17.Name = "OnChannelSucceeded";
            treeNode17.Tag = "Folder";
            treeNode17.Text = "OnChannelSucceeded";
            treeNode18.Name = "OnChannelInterrupted";
            treeNode18.Tag = "Folder";
            treeNode18.Text = "OnChannelInterrupted";
            treeNode19.Name = "OnChannelFinish";
            treeNode19.Tag = "Folder";
            treeNode19.Text = "OnChannelFinish";
            treeNode20.Name = "OnToggleOn";
            treeNode20.Tag = "Folder";
            treeNode20.Text = "OnToggleOn";
            treeNode21.Name = "OnToggleOff";
            treeNode21.Tag = "Folder";
            treeNode21.Text = "OnToggleOff";
            treeNode22.Name = "OnAbilityPhaseStart";
            treeNode22.Tag = "Folder";
            treeNode22.Text = "OnAbilityPhaseStart";
            treeNode23.Name = "OnOwnerDied";
            treeNode23.Tag = "Folder";
            treeNode23.Text = "OnOwnerDied";
            treeNode24.Name = "OnOwnerSpawned";
            treeNode24.Tag = "Folder";
            treeNode24.Text = "OnOwnerSpawned";
            treeNode25.Name = "OnUpgrade";
            treeNode25.Tag = "Folder";
            treeNode25.Text = "OnUpgrade";
            treeNode26.Name = "OnProjectileHitUnit";
            treeNode26.Tag = "Folder";
            treeNode26.Text = "OnProjectileHitUnit";
            treeNode27.Name = "OnProjectileFinish";
            treeNode27.Tag = "Folder";
            treeNode27.Text = "OnProjectileFinish";
            treeNode28.Name = "actionRoot";
            treeNode28.Tag = "Folder";
            treeNode28.Text = "Actions";
            treeNode29.Name = "Variables";
            treeNode29.Tag = "Folder";
            treeNode29.Text = "Variables";
            treeNode30.Name = "modifiers";
            treeNode30.Tag = "Folder";
            treeNode30.Text = "Modifiers";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode28,
            treeNode29,
            treeNode30});
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.ShowRootLines = false;
            this.treeView1.Size = new System.Drawing.Size(213, 549);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.objectLinkEdit1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.propertyGrid1);
            this.splitContainer2.Size = new System.Drawing.Size(774, 549);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.TabIndex = 0;
            // 
            // objectLinkEdit1
            // 
            this.objectLinkEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectLinkEdit1.Grammer = "No Object Selected";
            this.objectLinkEdit1.Location = new System.Drawing.Point(0, 0);
            this.objectLinkEdit1.Name = "objectLinkEdit1";
            this.objectLinkEdit1.Object = null;
            this.objectLinkEdit1.Size = new System.Drawing.Size(774, 228);
            this.objectLinkEdit1.TabIndex = 0;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(774, 317);
            this.propertyGrid1.TabIndex = 0;
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
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.newVariableButton,
            this.toolStripSeparator2,
            this.newModifierButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(291, 25);
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
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // newVariableButton
            // 
            this.newVariableButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newVariableButton.Image = ((System.Drawing.Image)(resources.GetObject("newVariableButton.Image")));
            this.newVariableButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newVariableButton.Name = "newVariableButton";
            this.newVariableButton.Size = new System.Drawing.Size(80, 22);
            this.newVariableButton.Text = "New Variable";
            this.newVariableButton.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // newModifierButton
            // 
            this.newModifierButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newModifierButton.Image = ((System.Drawing.Image)(resources.GetObject("newModifierButton.Image")));
            this.newModifierButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newModifierButton.Name = "newModifierButton";
            this.newModifierButton.Size = new System.Drawing.Size(83, 22);
            this.newModifierButton.Text = "New Modifier";
            this.newModifierButton.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // ActionEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 574);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ActionEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Action Editor";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton newVariableButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton newModifierButton;
        private Panels.ObjectLinkEdit objectLinkEdit1;

    }
}