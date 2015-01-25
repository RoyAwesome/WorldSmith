using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;
using WorldSmith.Utils;

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
            Stopwatches.Watches["OpenTextEditor"].Start();
            bool EditorAlreadyOpen = ContainsEditor<TextEditor>();
            TextEditor editor = OpenEditor<TextEditor>();
            if (!EditorAlreadyOpen)
            {
                editor.OpenDocument(this);
                editor.UpdateEditorStyle();
                editor.TabText = Name;
                editor.Show(MainForm.PrimaryDockingPanel, DockState.Document);
            }
            Stopwatches.Watches["OpenTextEditor"].Stop();
            Console.WriteLine("Opened editor, taking {0} ms", Stopwatches.Watches["OpenTextEditor"].ElapsedMilliseconds);
            Stopwatches.Watches["OpenTextEditor"].Reset();
            return editor;
        }

        protected virtual string GetDocumentText()
        {
            return "";
        }
    }
}
