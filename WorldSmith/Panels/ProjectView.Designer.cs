namespace WorldSmith.Panels
{
    partial class ProjectView
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node3");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node1", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Project", 4, 4, new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Dota 2 VPK", 3, 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectView));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.folder_context_menu = new System.Windows.Forms.ContextMenu();
            this.context_add = new System.Windows.Forms.MenuItem();
            this.context_add_folder = new System.Windows.Forms.MenuItem();
            this.context_add_lua = new System.Windows.Forms.MenuItem();
            this.context_add_externalresource = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.context_codemap = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.context_history = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.context_cut = new System.Windows.Forms.MenuItem();
            this.context_copy = new System.Windows.Forms.MenuItem();
            this.context_paste = new System.Windows.Forms.MenuItem();
            this.context_delete = new System.Windows.Forms.MenuItem();
            this.context_rename = new System.Windows.Forms.MenuItem();
            this.context_rename_simple = new System.Windows.Forms.MenuItem();
            this.context_rename_smart = new System.Windows.Forms.MenuItem();
            this.menuItem16 = new System.Windows.Forms.MenuItem();
            this.context_openInExplorer = new System.Windows.Forms.MenuItem();
            this.menuItem17 = new System.Windows.Forms.MenuItem();
            this.context_properties = new System.Windows.Forms.MenuItem();
            this.file_context_menu = new System.Windows.Forms.ContextMenu();
            this.file_context_open = new System.Windows.Forms.MenuItem();
            this.file_context_openwith = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.file_context_history = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.file_context_cut = new System.Windows.Forms.MenuItem();
            this.file_context_copy = new System.Windows.Forms.MenuItem();
            this.file_context_delete = new System.Windows.Forms.MenuItem();
            this.file_context_rename = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.file_context_properties = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.images;
            this.treeView1.Indent = 13;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Node3";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Node1";
            treeNode3.Name = "Node2";
            treeNode3.Text = "Node2";
            treeNode4.ImageIndex = 4;
            treeNode4.Name = "project";
            treeNode4.SelectedImageIndex = 4;
            treeNode4.Text = "Project";
            treeNode5.ImageIndex = 3;
            treeNode5.Name = "vpk";
            treeNode5.SelectedImageIndex = 3;
            treeNode5.Text = "Dota 2 VPK";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(284, 579);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.treeView1_afterLabelEdit);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "Generic_Document.png");
            this.images.Images.SetKeyName(1, "UtilityText.ico");
            this.images.Images.SetKeyName(2, "Folder.ico");
            this.images.Images.SetKeyName(3, "dotaicon16x16.png");
            this.images.Images.SetKeyName(4, "WSIcon32.png");
            // 
            // folder_context_menu
            // 
            this.folder_context_menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.context_add,
            this.menuItem14,
            this.context_codemap,
            this.menuItem19,
            this.context_history,
            this.menuItem15,
            this.context_cut,
            this.context_copy,
            this.context_paste,
            this.context_delete,
            this.context_rename,
            this.menuItem16,
            this.context_openInExplorer,
            this.menuItem17,
            this.context_properties});
            this.folder_context_menu.Popup += new System.EventHandler(this.folder_context_menu_Popup);
            // 
            // context_add
            // 
            this.context_add.Index = 0;
            this.context_add.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.context_add_folder,
            this.context_add_lua,
            this.menuItem1,
            this.context_add_externalresource});
            this.context_add.Text = "Add...";
            // 
            // context_add_folder
            // 
            this.context_add_folder.Index = 0;
            this.context_add_folder.Text = "Folder";
            // 
            // context_add_lua
            // 
            this.context_add_lua.Index = 1;
            this.context_add_lua.Text = "Lua Script";
            this.context_add_lua.Click += new System.EventHandler(this.context_add_lua_Click);
            // 
            // context_add_externalresource
            // 
            this.context_add_externalresource.Enabled = false;
            this.context_add_externalresource.Index = 3;
            this.context_add_externalresource.Text = "External Resource...";
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "-";
            // 
            // context_codemap
            // 
            this.context_codemap.Enabled = false;
            this.context_codemap.Index = 2;
            this.context_codemap.Text = "Show on Code Map";
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 3;
            this.menuItem19.Text = "-";
            // 
            // context_history
            // 
            this.context_history.Enabled = false;
            this.context_history.Index = 4;
            this.context_history.Text = "View History";
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 5;
            this.menuItem15.Text = "-";
            // 
            // context_cut
            // 
            this.context_cut.Enabled = false;
            this.context_cut.Index = 6;
            this.context_cut.Text = "Cut";
            this.context_cut.Click += new System.EventHandler(this.context_cut_Click);
            // 
            // context_copy
            // 
            this.context_copy.Enabled = false;
            this.context_copy.Index = 7;
            this.context_copy.Text = "Copy";
            this.context_copy.Click += new System.EventHandler(this.context_copy_Click);
            // 
            // context_paste
            // 
            this.context_paste.Enabled = false;
            this.context_paste.Index = 8;
            this.context_paste.Text = "Paste";
            this.context_paste.Click += new System.EventHandler(this.context_paste_Click);
            // 
            // context_delete
            // 
            this.context_delete.Index = 9;
            this.context_delete.Text = "Delete";
            this.context_delete.Click += new System.EventHandler(this.context_delete_Click);
            // 
            // context_rename
            // 
            this.context_rename.Index = 10;
            this.context_rename.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.context_rename_simple,
            this.context_rename_smart});
            this.context_rename.Text = "Rename";
            // 
            // context_rename_simple
            // 
            this.context_rename_simple.Index = 0;
            this.context_rename_simple.Text = "Simple Rename";
            this.context_rename_simple.Click += new System.EventHandler(this.context_rename_simple_Click);
            // 
            // context_rename_smart
            // 
            this.context_rename_smart.Enabled = false;
            this.context_rename_smart.Index = 1;
            this.context_rename_smart.Text = "Smart Rename";
            // 
            // menuItem16
            // 
            this.menuItem16.Index = 11;
            this.menuItem16.Text = "-";
            // 
            // context_openInExplorer
            // 
            this.context_openInExplorer.Index = 12;
            this.context_openInExplorer.Text = "Open Folder in File Explorer";
            this.context_openInExplorer.Click += new System.EventHandler(this.context_openInExplorer_Click);
            // 
            // menuItem17
            // 
            this.menuItem17.Index = 13;
            this.menuItem17.Text = "-";
            // 
            // context_properties
            // 
            this.context_properties.Enabled = false;
            this.context_properties.Index = 14;
            this.context_properties.Text = "Properties";
            // 
            // file_context_menu
            // 
            this.file_context_menu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.file_context_open,
            this.file_context_openwith,
            this.menuItem5,
            this.file_context_history,
            this.menuItem7,
            this.file_context_cut,
            this.file_context_copy,
            this.file_context_delete,
            this.file_context_rename,
            this.menuItem12,
            this.file_context_properties});
            this.file_context_menu.Popup += new System.EventHandler(this.file_context_menu_Popup);
            // 
            // file_context_open
            // 
            this.file_context_open.Index = 0;
            this.file_context_open.Text = "Open";
            // 
            // file_context_openwith
            // 
            this.file_context_openwith.Enabled = false;
            this.file_context_openwith.Index = 1;
            this.file_context_openwith.Text = "Open With...";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 2;
            this.menuItem5.Text = "-";
            // 
            // file_context_history
            // 
            this.file_context_history.Enabled = false;
            this.file_context_history.Index = 3;
            this.file_context_history.Text = "View History";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 4;
            this.menuItem7.Text = "-";
            // 
            // file_context_cut
            // 
            this.file_context_cut.Enabled = false;
            this.file_context_cut.Index = 5;
            this.file_context_cut.Text = "Cut";
            // 
            // file_context_copy
            // 
            this.file_context_copy.Enabled = false;
            this.file_context_copy.Index = 6;
            this.file_context_copy.Text = "Copy";
            // 
            // file_context_delete
            // 
            this.file_context_delete.Index = 7;
            this.file_context_delete.Text = "Delete";
            // 
            // file_context_rename
            // 
            this.file_context_rename.Index = 8;
            this.file_context_rename.Text = "Rename";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 9;
            this.menuItem12.Text = "-";
            // 
            // file_context_properties
            // 
            this.file_context_properties.Enabled = false;
            this.file_context_properties.Index = 10;
            this.file_context_properties.Text = "Properties";
            // 
            // menuItem1
            // 
            this.menuItem1.Enabled = false;
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Panorama File";
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 579);
            this.Controls.Add(this.treeView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ProjectView";
            this.TabText = "Project View";
            this.Text = "Project View";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList images;
        private System.Windows.Forms.ContextMenu folder_context_menu;
        private System.Windows.Forms.MenuItem context_add;
        private System.Windows.Forms.MenuItem context_add_lua;
        private System.Windows.Forms.MenuItem context_history;
        private System.Windows.Forms.MenuItem context_cut;
        private System.Windows.Forms.MenuItem context_copy;
        private System.Windows.Forms.MenuItem context_paste;
        private System.Windows.Forms.MenuItem context_delete;
        private System.Windows.Forms.MenuItem context_rename;
        private System.Windows.Forms.MenuItem context_rename_simple;
        private System.Windows.Forms.MenuItem context_rename_smart;
        private System.Windows.Forms.MenuItem menuItem14;
        private System.Windows.Forms.MenuItem menuItem15;
        private System.Windows.Forms.MenuItem menuItem16;
        private System.Windows.Forms.MenuItem context_openInExplorer;
        private System.Windows.Forms.MenuItem menuItem17;
        private System.Windows.Forms.MenuItem context_properties;
        private System.Windows.Forms.MenuItem context_codemap;
        private System.Windows.Forms.MenuItem menuItem19;
        private System.Windows.Forms.MenuItem context_add_folder;
        private System.Windows.Forms.MenuItem context_add_externalresource;
        private System.Windows.Forms.ContextMenu file_context_menu;
        private System.Windows.Forms.MenuItem file_context_open;
        private System.Windows.Forms.MenuItem file_context_openwith;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem file_context_history;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem file_context_cut;
        private System.Windows.Forms.MenuItem file_context_copy;
        private System.Windows.Forms.MenuItem file_context_delete;
        private System.Windows.Forms.MenuItem file_context_rename;
        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem file_context_properties;
        private System.Windows.Forms.MenuItem menuItem1;
    }
}