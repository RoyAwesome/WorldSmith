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
    }
}
