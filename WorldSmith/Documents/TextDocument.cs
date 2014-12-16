using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;

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

        /// <summary>
        /// Flase if the document is backed by a filesystem file, True if it's all in memory or a textual represenation of another object.
        /// </summary>
        public bool IsVirtual
        {
            get;
            private set;
        }

        public TextDocument(string File, bool FromVPK)
        {
            Path = File;
            if(FromVPK)
            {
                Source = DocumentSource.VPK;
                ReadOnly = true;
            }
            IsVirtual = false;
            Name = System.IO.Path.GetFileName(File);
        }

        public TextDocument()
        {
            IsVirtual = true;
        }

        protected virtual string GetDocumentText()
        {
            
            if(!IsVirtual)
            {
                //If we are edited, grab the text from the document.  If we aren't edited, read it from the file
                if(IsEdited)
                {
                    //Get the open text editor and grab it's text
                    TextEditor editor = GetEditor<TextEditor>();
                    return editor.GetEditorText();

                }
                else
                {
                    if (Source == DocumentSource.File)
                        return File.ReadAllText(Path);
                    else
                        return DotaData.ReadAllText(Path);
                }                
            }
            else //If we are a virtual text document, that means a subclass is handling this bit.  
            {
                return "";
            }
            
        }

        protected override void DoSave()
        {
           if(!IsVirtual)
           {
               //Only save if we are edited
               if (IsEdited) File.WriteAllText(Path, GetDocumentText());
           }
        }

        public override void Reload()
        {
            IsEdited = false;
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
            if(!EditorAlreadyOpen)
            {
                editor.EditorStyle = TextEditor.TextEditorStyle.KeyValues;
                editor.OpenDocument(this);
                editor.TabText = Name;

                editor.Show(MainForm.PrimaryDockingPanel, DigitalRune.Windows.Docking.DockState.Document);
            }         

            return editor;
        }

        
    }
}
