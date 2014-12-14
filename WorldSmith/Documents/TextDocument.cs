using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Documents
{
    public class TextDocument : Document
    {
        public string Text
        {
            get
            {
                return GetDocumentText();
            }
        }

        protected string Filename;

        public TextDocument(string File, bool FromVPK)
        {
            Filename = File;
            if(FromVPK)
            {
                Source = DocumentSource.VPK;
            }
        }

        public TextDocument()
        {

        }

        protected virtual string GetDocumentText()
        {
            return "";
        }

        public override void Save()
        {
           
        }

        public override void Reload()
        {
           
        }

        public override bool CanEditorOpen(Type EditorType)
        {
            if (EditorType == typeof(TextEditor)) return true;
            return false;
        }

        public override void OpenDefaultEditor()
        {
            OpenTextEditor();
        }

        public virtual TextEditor OpenTextEditor()
        {
            TextEditor editor = new TextEditor();            
            editor.EditorStyle = TextEditor.TextEditorStyle.KeyValues;
            editor.OpenDocument(this);
            

            editor.Show(MainForm.PrimaryDockingPanel, DigitalRune.Windows.Docking.DockState.Document);

            return editor;
        }

        
    }
}
