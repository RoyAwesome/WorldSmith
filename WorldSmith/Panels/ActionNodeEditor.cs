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
using WorldSmith.DataClasses;

namespace WorldSmith.Panels
{
    public partial class ActionNodeEditor : DockContent
    {
        public ActionNodeEditor()
        {
            InitializeComponent();

            ActionNodeCollection ac = new ActionNodeCollection("OnSpellStart");
            ac.Location = new PointF(200, 50);


            graphControl1.AddNode(ac);

        }
    }
}
