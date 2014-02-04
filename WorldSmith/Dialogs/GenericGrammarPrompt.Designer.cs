namespace WorldSmith.Dialogs
{
    partial class GenericGrammarPrompt
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
            this.objectLinkEdit1 = new WorldSmith.Panels.ObjectLinkEdit();
            this.okayButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // objectLinkEdit1
            // 
            this.objectLinkEdit1.Grammer = null;
            this.objectLinkEdit1.Location = new System.Drawing.Point(12, 12);
            this.objectLinkEdit1.Name = "objectLinkEdit1";
            this.objectLinkEdit1.Object = null;
            this.objectLinkEdit1.Size = new System.Drawing.Size(253, 145);
            this.objectLinkEdit1.TabIndex = 0;
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(190, 163);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(75, 23);
            this.okayButton.TabIndex = 1;
            this.okayButton.Text = "Ok";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(12, 162);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // GenericGrammarPrompt
            // 
            this.AcceptButton = this.okayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(278, 197);
            this.ControlBox = false;
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okayButton);
            this.Controls.Add(this.objectLinkEdit1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GenericGrammarPrompt";
            this.Text = "GenericGrammarPrompt";
            this.ResumeLayout(false);

        }

        #endregion

        private Panels.ObjectLinkEdit objectLinkEdit1;
        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.Button cancelButton;
    }
}