using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WorldSmith.DataClasses;
using WorldSmith.Documents;
using WorldSmith.Panels;
using WeifenLuo.WinFormsUI.Docking;

namespace WorldSmith
{
    public partial class TextEditor : DockContent, IEditor
    {


        private bool isReadOnly;
        /// <summary>
        /// Is this document read only?  Set true for VPK files
        /// </summary>
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                ReadOnlyChanged(value);
            }
        }

        public string Filename;

        private bool HideConfirmation = false;


        public TextEditor()
        {
            InitializeComponent();
            Filename = String.Empty;

            scintilla1.TextChanged += Scintilla1_TextChanged;
           

            this.FormClosed += TextEditor_FormClosed;

            scintilla1.Margins[0].Width = 20;
        }

        private void Scintilla1_TextChanged(object sender, EventArgs e)
        {
            ActiveDocument.DocumentEdited(this);
        }
             
        void TextEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Check for changes and ask to save if we are closing.
            if (ActiveDocument.IsEdited)
            {
                if (!HideConfirmation)
                {
                    if (MessageBox.Show("This editor contains unsaved changes! Do you want to save now?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ActiveDocument.Save(this);
                    }
                }


            }

            ActiveDocument.NotifyEditorClosed(this);
        }

        public string TextContent
        {
            get
            {
                return scintilla1.Text;
            }
        }

        public void OpenDocument(VirtualTextDocument document)
        {
            Filename = document.Path;
            IsReadOnly = document.Source == DocumentSource.VPK;
            
            scintilla1.Text = document.Text;
        }

        public void UpdateEditorStyle()
        {
            if (Filename.EndsWith(".lua"))
            {
                scintilla1.ConfigurationManager.Language = "lua";               
            }
            else
            {
                scintilla1.ConfigurationManager.Language = "null";
            }
            scintilla1.ConfigurationManager.Configure();
            scintilla1.Invalidate();
        }

        public string GetEditorText()
        {
            return scintilla1.Text;
        }

        protected void ReadOnlyChanged(bool value)
        {
            if (value)
            {
                saveButton.Enabled = false;
                scintilla1.IsReadOnly = true;
                saveButton.ToolTipText = "Cannot Save, File is read only";
            }
            else
            {
                saveButton.Enabled = true;
                scintilla1.IsReadOnly = false;
                saveButton.ToolTipText = "Save";
            }
        }


        private void cutButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Cut();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ActiveDocument.IsEdited)
            {
                ActiveDocument.Save(this);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Paste();
        }

        public Document ActiveDocument
        {
            get;
            set;

        }

        public void NotifyDocumentModified(IEditor source)
        {
            if (ActiveDocument.IsEdited)
            {
                if (this.TabText.EndsWith("*") == false)
                {
                    this.TabText = this.TabText + "*";
                }
            }
        }

        public void NotifyDocumentSaved(IEditor source)
        {
            //Are we the source?  If not, reload the document in the editor
            if (source != this)
            {
                TextDocument document = ActiveDocument as TextDocument;
                scintilla1.Text = document.Text;
            }
        }


        public void CloseDocument(bool ConfirmChanges)
        {
            HideConfirmation = !ConfirmChanges;
            this.Close();
        }

        private void foldTimer_Tick(object sender, EventArgs e)
        {
            //TODO: Fix this
        }
    }
}
