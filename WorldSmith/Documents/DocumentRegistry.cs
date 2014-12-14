using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Documents
{
    class DocumentRegistry
    {
        static List<Document> OpenDocuments = new List<Document>();

        public static IEnumerable<Document> AllDocuments = OpenDocuments;
        public static IEnumerable<Document> ModifiedDocuments = OpenDocuments.Where(x => x.IsEdited);

        public static void OpenDocument(Document document)
        {
            OpenDocuments.Add(document);
        }



    }
}
