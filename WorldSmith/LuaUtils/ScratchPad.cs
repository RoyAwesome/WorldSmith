using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using WorldSmith.Utils;

namespace WorldSmith.LuaUtils
{
    public partial class ScratchPad : DockContent, IConsoleNotify
    {
        private ConsoleStringWriter LuaOutput;

        public ScratchPad()
        {
            InitializeComponent();

            LuaOutput = new ConsoleStringWriter();

            scintilla1.Margins[0].Width = 20;
            LuaOutput.Output = this;

            
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";

            string ret = LuaHelper.DoScratchpadString(scintilla1.Text, LuaOutput);
            if (ret != null) UpdateConsole(ret + Environment.NewLine);
        }
        private void cutButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Cut();
        }
     
        private void copyButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Copy();
        }

        private void pasteButton_Click(object sender, EventArgs e)
        {
            scintilla1.Clipboard.Paste();
        }

        public void UpdateConsole(string text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateConsoleDelegate(UpdateConsole), text);
            }
            else
            {
                textBox1.AppendText(text);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog diag = new SaveFileDialog();
            diag.Filter = "Lua File (.lua)|*.lua";
            if (diag.ShowDialog() == DialogResult.OK)
            {
                string filename = diag.FileName;
                File.WriteAllText(filename, scintilla1.Text);
            }

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
            diag.Filter = "Lua File (.lua)|*.lua";
            if(diag.ShowDialog() == DialogResult.OK)
            {
                string filename = diag.FileName;
                string text = File.ReadAllText(filename);
                scintilla1.Text = text;
            }
        }
    }
}
