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
    public partial class StartPageForm : DockableForm
    {
        #region LabelSettings
        private static Font lblFont = new Font(new FontFamily("Microsoft Sans Serif"), 9);
        #endregion

        public StartPageForm()
        {
            InitializeComponent();
            ListRecentAddons();
        }

        public void ListRecentAddons()
        {
            recentAddonsFlowPanel.Controls.Clear();
            string[] recentAddons = Properties.Settings.Default.RecentAddons;
            if (recentAddons == null) { return; }

            foreach(string addon in recentAddons)
            {
                Label lblAddon = new Label();
                lblAddon.AutoSize = true;
                lblAddon.Text = addon;
                lblAddon.Font = lblFont;
                lblAddon.ForeColor = Color.CornflowerBlue;
                lblAddon.Parent = recentAddonsFlowPanel;
                lblAddon.Cursor = Cursors.Hand; 
            }
        }
    }
}
