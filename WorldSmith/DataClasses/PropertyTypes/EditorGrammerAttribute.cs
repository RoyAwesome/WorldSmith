using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    class EditorGrammarAttribute : Attribute
    {
        public string Grammar
        {
            get;
            set;
        }
        public EditorGrammarAttribute(string grammar)
        {
            Grammar = grammar;
        }

    }
}
