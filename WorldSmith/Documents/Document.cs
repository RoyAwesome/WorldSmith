using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Documents
{
  

    public enum DocumentSource
    {
        File,
        VPK,
    }

    /// <summary>
    /// Base class for document types. 
    /// 
    /// These are documents that exist and can be saved (or not, depending if they come from the VPK)
    /// 
    /// </summary>
    public abstract class Document
    {
        public string Name
        {
            get;
            set;
        }

        public bool IsEdited
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public DocumentSource Source
        {
            get;
            set;
        }

        public bool ReadOnly
        {
            get;
            set;
        }


        public abstract void Save();

        public abstract void Reload();

        public abstract bool CanEditorOpen(Type EditorType);

        public abstract void OpenDefaultEditor();

    }
}
