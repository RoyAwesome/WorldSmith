using DigitalRune.Windows.Docking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorldSmith.Panels
{
    public partial class ProjectView : DockableForm
    {
        public ProjectView()
        {
            InitializeComponent();
            fileTreeView1.Populate(WorldSmith.Controls.FileViewSource.Project);
        }
    }
}
