using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace WorldSmith.Panels
{
    public partial class ConsoleForm : DockContent
    {
        public ConsoleForm()
        {
            InitializeComponent();
        }
        private delegate void UpdateConsole_(String text);
        public void UpdateConsole(String text)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new UpdateConsole_(UpdateConsole), text);
            }
            else
            {
                consoleBox.AppendText(text);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Return)
            {
                string text = textBox1.Text.Trim();
                textBox1.Text = "";

                //Get the lua state and enter this info into it

                Console.WriteLine(">> " + text);

                string r = LuaHelper.DoEditorString(text);
                if(r != null) Console.WriteLine(r);

                e.Handled = true;
            }
        }
    }
}
