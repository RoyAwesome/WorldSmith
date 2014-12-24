using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace WorldSmith.Documents
{
    public abstract class VirtualTextDocument : Document
    {

        public string Text
        {
            get
            {
                return GetDocumentText();
            }
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
            bool EditorAlreadyOpen = ContainsEditor<TextEditor>();
            TextEditor editor = OpenEditor<TextEditor>();
            if (!EditorAlreadyOpen)
            {
                editor.EditorStyle = TextEditor.TextEditorStyle.KeyValues;
                editor.OpenDocument(this);
                editor.TabText = Name;

                editor.Show(MainForm.PrimaryDockingPanel, DockState.Document);
            }

            return editor;
        }

        protected virtual string GetDocumentText()
        {
            return "";
        }
    }
}
