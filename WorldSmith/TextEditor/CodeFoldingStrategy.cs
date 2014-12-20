using System.Collections.Generic;
using DigitalRune.Windows.TextEditor;
using DigitalRune.Windows.TextEditor.Document;
using DigitalRune.Windows.TextEditor.Folding;
using System;

namespace WorldSmith
{
    class CodeFoldingStrategy : IFoldingStrategy
    {
        public List<Fold> GenerateFolds(IDocument document, string fileName, object parseInformation)
        {
            // This is a simple folding strategy.
            // It searches for matching brackets ('{', '}') and creates folds
            // for each region.

            List<Fold> folds = new List<Fold>();
            List<int> startLocs = new List<int>();
            for (int offset = 0; offset < document.TextLength; ++offset)
            {
                char c = document.GetCharAt(offset);
                switch (c) {
                    case '{':
                        startLocs.Add(offset);
                        break;
                    case '}':
                        if (startLocs.Count > 0) //We have had a {
                        {
                            int length = offset - startLocs[startLocs.Count -1] + 1; //+1 so the } is included
                            folds.Add(new Fold(document, startLocs[startLocs.Count - 1], length, "{...}", false));
                            startLocs.Remove(startLocs[startLocs.Count - 1]);
                        }
                        break;
                }
            }
            return folds;
        }
    }
}
