using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.Documents
{
    static class DocumentRegistry
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
        
        public static void CloseDocument(Document document)
        {
            OpenDocuments.RemoveByValue(document);
        }

        private static void RemoveByValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TValue someValue)
        {
            List<TKey> itemsToRemove = new List<TKey>();

            foreach (var pair in dictionary)
            {
                if (pair.Value.Equals(someValue))
                    itemsToRemove.Add(pair.Key);
            }

            foreach (TKey item in itemsToRemove)
            {
                dictionary.Remove(item);
            }
        }
    }
}
