using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using System.Reflection;

namespace WorldSmith.Panels
{
    public partial class ActionGrammarEditor : UserControl
    {
        BaseAction action;

        public BaseAction Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
                BuildActionPanel();
            }
        }

        public ActionGrammarEditor()
        {
            InitializeComponent();
        }


        private void BuildActionPanel()
        {
            if (action == null) return;
            EditorGrammarAttribute attrib = action.GetType().GetCustomAttribute<EditorGrammarAttribute>();
            if(attrib != null)
            {
                linkLabel1.Links.Clear();
                string grammar = attrib.Grammar;

                //Find each % and get the positions to create links
                int ind = grammar.IndexOf('%', 0);
                int count = 0;
                while(ind != -1)
                {
                    int start = ind;
                    int end = grammar.IndexOf(' ', start);
                    int len = end == -1 ? grammar.Length - start : end - start;

                    linkLabel1.Links.Add(start - count, len - 1); //Shif the region back one because we remove the % signs.

                    ind = grammar.IndexOf('%', start + len);

                    count++;
                    
                }




                linkLabel1.Text = attrib.Grammar.Replace("%", "");

                
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        
    }
}
