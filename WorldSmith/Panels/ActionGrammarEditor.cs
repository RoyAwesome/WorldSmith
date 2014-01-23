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
using WorldSmith.Dialogs.Actions;

namespace WorldSmith.Panels
{
    public partial class ActionGrammarEditor : UserControl
    {
        BaseAction action;
        public AbilityActionCollection abilityActions;
        public string ActionContext;

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

                    linkLabel1.Links.Add(start - count, len - 1, grammar.Substring(start+1, len - 1)); //Shif the region back one because we remove the % signs.

                    ind = grammar.IndexOf('%', start + len);

                    count++;
                    
                }




                linkLabel1.Text = attrib.Grammar.Replace("%", "");

                
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {           

            string Property = e.Link.LinkData as string;

            PropertyInfo info = action.GetType().GetProperty(Property);

            DialogResult result = DialogResult.Cancel;

            string valueResult = "";

            if(info.PropertyType == typeof(NumberValue))
            {
                VariableEditor editor = new VariableEditor();
                editor.SetVariable(abilityActions.Variables.Select(x => x.Name));
                NumberValue val = info.GetMethod.Invoke(action, new object[] { }) as NumberValue;
                editor.SetDefault(val == null ? "" : val.ToString());
                editor.Text = "Variable Editor - " + Property;

                result = editor.ShowDialog();

                if(editor.ShowDialog() == DialogResult.OK)
                {
                    valueResult = editor.GetValue();
                    info.SetMethod.Invoke(action, new object[] { new NumberValue(valueResult) });

                }
            }
            if(info.PropertyType == typeof(TargetKey))
            {
                TargetKeyEditor editor = new TargetKeyEditor();
                editor.SetPresets(ActionContext);

                result = editor.ShowDialog();

            }


            if(result == DialogResult.OK)
            {
                string display = "(" + valueResult + ")";
                //Get the old display.
                string old = linkLabel1.Text.Substring(e.Link.Start, e.Link.Length);

                //Replace it with the new one
                linkLabel1.Text = linkLabel1.Text.Replace(old, display);

                int diff = e.Link.Length - display.Length; //Get the difference in chars so we can move the other links back

                e.Link.Length = display.Length; //Adjust this link to that it takes up the new area

                //pull back all of the other links so they adjust to the new area, starting with the editing link
                int editedIndex = linkLabel1.Links.IndexOf(e.Link);
                for (int i = editedIndex + 1; i < linkLabel1.Links.Count; i++)
                {
                    LinkLabel.Link l = linkLabel1.Links[i];
                    l.Start -= diff;
                }
            }

            
        }

        
    }
}
