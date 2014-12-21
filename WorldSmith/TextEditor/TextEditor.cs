using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Actions;
using DigitalRune.Windows.TextEditor.Completion;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.Formatting;
using DigitalRune.Windows.TextEditor.Highlighting;
using DigitalRune.Windows.TextEditor.Insight;
using DigitalRune.Windows.TextEditor.Markers;
using DigitalRune.Windows.TextEditor.Selection;
using System.IO;
using WorldSmith.DataClasses;
using WorldSmith.Documents;
using WorldSmith.Panels;
using DigitalRune.Windows.TextEditor.Folding;
using WeifenLuo.WinFormsUI.Docking;

namespace WorldSmith
{
    public partial class TextEditor : DockContent, IEditor
    {
        public enum TextEditorStyle
        {
            KeyValues,
            Lua,
        }

        public TextEditorStyle EditorStyle
        {
            get { return EditorStyle; }
            set
            {
                Console.WriteLine("EDITOR STYLE: " + value.ToString());
                if (value == TextEditorStyle.KeyValues)
                {
                    Console.WriteLine("KEYVALUES TIME BITCHEZ");
                    var test = HighlightingManager.Manager.FindHighlighter("KeyValues");
                    Console.WriteLine(test.Name);
                    textEditorControl1.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("KeyValues");
                    textEditorControl1.EnableFolding = true;
                    textEditorControl1.Document.FoldingManager.FoldingStrategy = new CodeFoldingStrategy();
                }
                else
                    textEditorControl1.Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("Lua");
            }
        }


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

            textEditorControl1.DocumentChanged += textEditorControl1_DocumentChanged;
          
            this.FormClosed += TextEditor_FormClosed;
        }

        void textEditorControl1_DocumentChanged(object sender, DocumentEventArgs e)
        {
            if(e.Length != 0) 
                ActiveDocument.DocumentEdited(this);
        }

        void TextEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Check for changes and ask to save if we are closing.
            if(ActiveDocument.IsEdited)
            {
                if(!HideConfirmation)
                {
                    if (MessageBox.Show("This editor contains unsaved changes! Do you want to save now?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ActiveDocument.Save(this);
                    }
                }
              
              
            }

            ActiveDocument.NotifyEditorClosed(this);
        }

    

        public void OpenDocument(TextDocument document)
        {
            Filename = document.Path;
            IsReadOnly = document.Source == DocumentSource.VPK;
            textEditorControl1.Document.TextContent = document.Text;
        }
     
        public string GetEditorText()
        {
            return textEditorControl1.Text;
        }

        protected void ReadOnlyChanged(bool value)
        {
            if (value)
            {
                saveButton.Enabled = false;
                textEditorControl1.IsReadOnly = true;
                saveButton.ToolTipText = "Cannot Save, File is read only";
            }
            else
            {
                saveButton.Enabled = true;
                textEditorControl1.IsReadOnly = false;
                saveButton.ToolTipText = "Save";
            }
        }


        private void cutButton_Click(object sender, EventArgs e)
        {
            Cut cut = new Cut();
            cut.Execute(textEditorControl1);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(ActiveDocument.IsEdited)
            {
                ActiveDocument.Save(this);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            Copy copy = new Copy();
            copy.Execute(textEditorControl1);
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            Paste paste = new Paste();
            paste.Execute(textEditorControl1);
        }

        public Document ActiveDocument
        {
            get;
            set;

        }

        public void NotifyDocumentModified(IEditor source)
        {
            
        }

        public void NotifyDocumentSaved(IEditor source)
        {
            //Are we the source?  If not, reload the document in the editor
            if (source != this)
            {
                TextDocument document = ActiveDocument as TextDocument;
                textEditorControl1.Text = document.Text;
            }
        }


        public void CloseDocument(bool ConfirmChanges)
        {
            HideConfirmation = !ConfirmChanges;
            this.Close();
        }

        private void foldTimer_Tick(object sender, EventArgs e)
        {
            textEditorControl1.Document.FoldingManager.UpdateFolds();
        }
    }
}
