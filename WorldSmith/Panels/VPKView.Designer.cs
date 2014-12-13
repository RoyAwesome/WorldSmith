namespace WorldSmith.Panels
{
    partial class VPKView
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
            this.fileTreeView1 = new WorldSmith.Controls.FileTreeView();
            this.SuspendLayout();
            // 
            // fileTreeView1
            // 
            this.fileTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTreeView1.Location = new System.Drawing.Point(0, 0);
            this.fileTreeView1.Name = "fileTreeView1";
            this.fileTreeView1.Size = new System.Drawing.Size(245, 627);
            this.fileTreeView1.TabIndex = 0;
            // 
            // VPKView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 627);
            this.Controls.Add(this.fileTreeView1);
            this.Name = "VPKView";
            this.Text = "Dota VPK Viewer";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.FileTreeView fileTreeView1;
    }
}