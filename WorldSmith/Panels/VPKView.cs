using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DigitalRune.Windows.Docking;

namespace WorldSmith.Panels
{


    public partial class VPKView : DockableForm
    {
        public VPKView()
        {
            InitializeComponent();
            fileTreeView1.Populate(WorldSmith.Controls.FileViewSource.Vpk);
        }
    }
}
