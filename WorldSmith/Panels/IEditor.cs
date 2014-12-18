using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Panels
{
    public interface IEditor
    {
        Documents.Document ActiveDocument
        {
            get;
            set;
        }

        void NotifyDocumentModified(IEditor source);

        void NotifyDocumentSaved(IEditor source);

        void CloseDocument(bool ConfirmChanges);
    }
}
