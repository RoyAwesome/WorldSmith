using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using WorldSmith.DataClasses;
using WorldSmith.Documents;
using WorldSmith.Panels;
using WeifenLuo.WinFormsUI.Docking;
using ScintillaNET;

namespace WorldSmith
{
    public partial class TextEditor : DockContent, IEditor
    {


        private bool isReadOnly;
        /// <summary>
        /// Is this document read only?  Set true for VPK files
        /// </summary>
        public bool IsReadOnly
        {
            get { return isReadOnly; }
            set
            {
                isReadOnly = value;
                ReadOnlyChanged(value);
            }
        }

        public string Filename;

        private bool HideConfirmation = false;


        public TextEditor()
        {
            InitializeComponent();
            Filename = String.Empty;

            scintilla1.TextChanged += Scintilla1_TextChanged;
            scintilla1.StyleNeeded += Scintilla1_StyleNeeded;
           

            this.FormClosed += TextEditor_FormClosed;

            scintilla1.Margins[0].Width = 20;

            scintilla1.StyleResetDefault();
            scintilla1.Styles[Style.Default].Font = "Consolas";
            scintilla1.Styles[Style.Default].Size = 10;
            scintilla1.StyleClearAll();

            scintilla1.Styles[(int)LUA_STYLES.STYLE_DEFAULT].ForeColor = Color.Black;
            scintilla1.Styles[(int)LUA_STYLES.STYLE_KEYWORD].ForeColor = Color.Blue;
            scintilla1.Styles[(int)LUA_STYLES.STYLE_IDENTIFIER].ForeColor = Color.Teal;
            scintilla1.Styles[(int)LUA_STYLES.STYLE_NUMBER].ForeColor = Color.Purple;
            scintilla1.Styles[(int)LUA_STYLES.STYLE_STRING].ForeColor = Color.Red;
            scintilla1.Styles[(int)LUA_STYLES.STYLE_COMMENT].ForeColor = Color.FromArgb(0, 128, 0);

        }
        private enum LUA_STATES
        {
            STATE_UNKNOWN,
            STATE_IDENTIFIER,
            STATE_NUMBER,
            STATE_STRING,
            STATE_COMMENT
        };
        private enum LUA_STYLES
        {
            STYLE_DEFAULT,
            STYLE_KEYWORD, //not used yet
            STYLE_IDENTIFIER,
            STYLE_NUMBER,
            STYLE_STRING,
            STYLE_COMMENT
        }
        private readonly List<String> LUA_KEYWORDS = new List<string>()
        {
            "and", "break", "do", "else", "elseif", "end", "false", "for", "function", "if", "in",
            "local", "nil", "not", "or", "repeat", "return", "then", "true", "until", "while"
        };
        private void Scintilla1_StyleNeeded(object sender, StyleNeededEventArgs e)
        {
            var startPos = scintilla1.GetEndStyled();
            var endPos = e.Position;

            var length = 0;
            var state = LUA_STATES.STATE_UNKNOWN;
            while (startPos < endPos)
            {
                var c = (char)scintilla1.GetCharAt(startPos);
                REPROCESS:
                switch (state)
                {
                    case LUA_STATES.STATE_UNKNOWN:
                        if (c == '"')
                        {
                            scintilla1.SetStyling(1, (int)LUA_STYLES.STYLE_STRING);
                            state = LUA_STATES.STATE_STRING;
                        }
                        else if (Char.IsDigit(c))
                        {
                            state = LUA_STATES.STATE_NUMBER;
                            goto REPROCESS;
                        }
                        else if (Char.IsLetter(c))
                        {
                            state = LUA_STATES.STATE_IDENTIFIER;
                            goto REPROCESS;
                        }
                        else if (c == '-')
                        {
                            if (startPos + 1 <= endPos)
                            {
                                if (scintilla1.GetCharAt(startPos + 1) == '-')
                                {
                                    state = LUA_STATES.STATE_COMMENT;
                                }
                            }
                        }
                        else
                        {

                            scintilla1.SetStyling(1, (int)LUA_STYLES.STYLE_DEFAULT); //0 is default apparently
                        }
                        break;
                    case LUA_STATES.STATE_STRING:
                        if (c == '"')
                        {
                            length++;
                            scintilla1.SetStyling(length, (int)LUA_STYLES.STYLE_STRING); //4 is String apparently
                            length = 0;
                            state = LUA_STATES.STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }
                        break;
                    case LUA_STATES.STATE_NUMBER:
                        if (Char.IsDigit(c) || (c >= 'a' && c <= 'f') || (c >= 'A' && c <= 'F') || c == 'x')
                        {
                            length++;
                        }
                        else
                        {
                            scintilla1.SetStyling(length, (int)LUA_STYLES.STYLE_NUMBER); //2 is Number apparently
                            length = 0;
                            state = LUA_STATES.STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;
                    case LUA_STATES.STATE_COMMENT:
                        if (c == '\n')
                        {
                            length++;
                            scintilla1.SetStyling(length, (int)LUA_STYLES.STYLE_COMMENT);
                            length = 0;
                            state = LUA_STATES.STATE_UNKNOWN;
                        }
                        else
                        {
                            length++;
                        }

                        break;
                    case LUA_STATES.STATE_IDENTIFIER:
                        if (Char.IsLetterOrDigit(c))
                        {
                            length++;
                        }
                        else
                        {
                            var style = (int)LUA_STYLES.STYLE_IDENTIFIER;
                            var identifier = scintilla1.GetTextRange(startPos - length, length);
                            if (LUA_KEYWORDS.Contains(identifier))
                               style =  (int)LUA_STYLES.STYLE_KEYWORD;

                            scintilla1.SetStyling(length, style);
                            length = 0;
                            state = LUA_STATES.STATE_UNKNOWN;
                            goto REPROCESS;
                        }
                        break;
                }
                startPos++;
            }
            
        }

        private void Scintilla1_TextChanged(object sender, EventArgs e)
        {
            ActiveDocument.DocumentEdited(this);
        }
             
        void TextEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            //TODO: Check for changes and ask to save if we are closing.
            if (ActiveDocument.IsEdited)
            {
                if (!HideConfirmation)
                {
                    if (MessageBox.Show("This editor contains unsaved changes! Do you want to save now?", "Are you sure?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ActiveDocument.Save(this);
                    }
                }


            }

            ActiveDocument.NotifyEditorClosed(this);
        }

        public string TextContent
        {
            get
            {
                return scintilla1.Text;
            }
        }

        public void OpenDocument(VirtualTextDocument document)
        {
            Filename = document.Path;
            IsReadOnly = document.Source == DocumentSource.VPK;
            
            scintilla1.Text = document.Text;
        }

        public void UpdateEditorStyle()
        {
            Console.WriteLine("UpdateEditorStyle");
            if (Filename.EndsWith(".lua"))
            {
                scintilla1.LexerLanguage = "lua";
                scintilla1.Styles[ScintillaNET.Style.Lua.Comment].ForeColor = Color.FromArgb(0, 128, 0);
                scintilla1.Lexer = ScintillaNET.Lexer.Lua;
            }
            else
            {
                scintilla1.LexerLanguage = "null";
                scintilla1.Lexer = ScintillaNET.Lexer.Null;
            }
           
            scintilla1.Invalidate();
        }

        public string GetEditorText()
        {
            return scintilla1.Text;
        }

        protected void ReadOnlyChanged(bool value)
        {
            if (value)
            {
                saveButton.Enabled = false;
                scintilla1.ReadOnly = true;
                saveButton.ToolTipText = "Cannot Save, File is read only";
            }
            else
            {
                saveButton.Enabled = true;
                scintilla1.ReadOnly = false;
                saveButton.ToolTipText = "Save";
            }
        }


        private void cutButton_Click(object sender, EventArgs e)
        {
            scintilla1.Cut();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ActiveDocument.IsEdited)
            {
                ActiveDocument.Save(this);
            }
        }

        private void copyButton_Click(object sender, EventArgs e)
        {
            scintilla1.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            scintilla1.Paste();
        }

        public Documents.Document ActiveDocument
        {
            get;
            set;

        }

        public void NotifyDocumentModified(IEditor source)
        {
            if (ActiveDocument.IsEdited)
            {
                if (this.TabText.EndsWith("*") == false)
                {
                    this.TabText = this.TabText + "*";
                }
            }
        }

        public void NotifyDocumentSaved(IEditor source)
        {
            //Are we the source?  If not, reload the document in the editor
            if (source != this)
            {
                TextDocument document = ActiveDocument as TextDocument;
                scintilla1.Text = document.Text;
            }
        }


        public void CloseDocument(bool ConfirmChanges)
        {
            HideConfirmation = !ConfirmChanges;
            this.Close();
        }

        private void foldTimer_Tick(object sender, EventArgs e)
        {
            //TODO: Fix this
        }
    }
}
