using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Documents
{
    class DocumentRegistry
    {
        static Dictionary<object, Document> OpenDocuments = new Dictionary<object, Document>();

        public static IEnumerable<Document> AllDocuments = OpenDocuments.Values;
        public static IEnumerable<Document> ModifiedDocuments = OpenDocuments.Values.Where(x => x.IsEdited);

        public static void OpenDocument(object ParentObject, Document document)
        {
            OpenDocuments[ParentObject] = document;
        }


        public static Document GetDocumentFor(object ParentObject)
        {
            if (OpenDocuments.ContainsKey(ParentObject))
            {
                return OpenDocuments[ParentObject];
            }
            return null;
        }
        

    }
}
