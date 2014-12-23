using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldSmith.DataClasses;
using WorldSmith.Panels;

namespace WorldSmith.Documents
{
    public class TextDocument : VirtualTextDocument
    {
        public TextDocument(string File, bool FromVPK)
        {
            Path = File;
            if (FromVPK)
            {
                Source = DocumentSource.VPK;
                ReadOnly = true;
            }
            
            Name = System.IO.Path.GetFileName(File);
        }

        protected override string GetDocumentText()
        {
            //If we are edited, grab the text from the document.  If we aren't edited, read it from the file
            if (IsEdited)
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

        protected override void DoSave(IEditor source)
        {
            //Only save if we are edited
            if (IsEdited) File.WriteAllText(Path, GetDocumentText());
        }

        public override void Reload()
        {
            IsEdited = false;
        }

    }
}
