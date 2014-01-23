namespace WorldSmith.Dialogs.Actions
{
    partial class TargetKeyEditor
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkChance = new WorldSmith.Panels.ObjectLinkEdit();
            this.linkTargetFilter = new WorldSmith.Panels.ObjectLinkEdit();
            this.linkLineOrCircle = new WorldSmith.Panels.ObjectLinkEdit();
            this.linkHeader = new WorldSmith.Panels.ObjectLinkEdit();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(13, 13);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Preset";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(75, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(287, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(13, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Custom";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkChance);
            this.panel1.Controls.Add(this.linkTargetFilter);
            this.panel1.Controls.Add(this.linkLineOrCircle);
            this.panel1.Controls.Add(this.linkHeader);
            this.panel1.Location = new System.Drawing.Point(12, 82);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 191);
            this.panel1.TabIndex = 3;
            // 
            // linkChance
            // 
            this.linkChance.Grammer = "No Grammer Set";
            this.linkChance.Location = new System.Drawing.Point(3, 156);
            this.linkChance.Name = "linkChance";
            this.linkChance.Object = null;
            this.linkChance.Size = new System.Drawing.Size(344, 32);
            this.linkChance.TabIndex = 3;
            // 
            // linkTargetFilter
            // 
            this.linkTargetFilter.Grammer = "No Grammer Set";
            this.linkTargetFilter.Location = new System.Drawing.Point(3, 73);
            this.linkTargetFilter.Name = "linkTargetFilter";
            this.linkTargetFilter.Object = null;
            this.linkTargetFilter.Size = new System.Drawing.Size(344, 77);
            this.linkTargetFilter.TabIndex = 2;
            // 
            // linkLineOrCircle
            // 
            this.linkLineOrCircle.Grammer = "No Grammer Set";
            this.linkLineOrCircle.Location = new System.Drawing.Point(3, 37);
            this.linkLineOrCircle.Name = "linkLineOrCircle";
            this.linkLineOrCircle.Object = null;
            this.linkLineOrCircle.Size = new System.Drawing.Size(344, 30);
            this.linkLineOrCircle.TabIndex = 1;
            // 
            // linkHeader
            // 
            this.linkHeader.Grammer = "No Grammer Set";
            this.linkHeader.Location = new System.Drawing.Point(3, 3);
            this.linkHeader.Name = "linkHeader";
            this.linkHeader.Object = null;
            this.linkHeader.Size = new System.Drawing.Size(344, 28);
            this.linkHeader.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 279);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Okay";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(15, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TargetKeyEditor
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(374, 314);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.radioButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TargetKeyEditor";
            this.Text = "TargetKeyEditor";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Panels.ObjectLinkEdit linkHeader;
        private Panels.ObjectLinkEdit linkChance;
        private Panels.ObjectLinkEdit linkTargetFilter;
        private Panels.ObjectLinkEdit linkLineOrCircle;
    }
}