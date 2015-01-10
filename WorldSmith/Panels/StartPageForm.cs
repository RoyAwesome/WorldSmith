using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace WorldSmith.Panels
{
    public partial class StartPageForm : DockContent
    {
        #region LabelSettings
        private static Font lblFont = new Font(new FontFamily("Microsoft Sans Serif"), 9);
        #endregion
        #region SharedFunctions
        public delegate void ShowNewAddonWizzardDelegate();
        public delegate void LoadAddonDelegate();
        public delegate void LoadProjectDelegate(string path);
        private ShowNewAddonWizzardDelegate ShowNewAddonWizzard;
        private LoadAddonDelegate LoadAddon;
        private LoadProjectDelegate LoadProject;
        #endregion

        public StartPageForm(ShowNewAddonWizzardDelegate snawd, LoadAddonDelegate la, LoadProjectDelegate lp)
        {
            InitializeComponent();
            ListRecentAddons();
            this.ShowNewAddonWizzard = snawd;
            this.LoadAddon = la;
            this.LoadProject = lp;
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
                lblAddon.Tag = addon;
                lblAddon.Click += loadRecentAddon_Click;
            }
        }

        private void loadRecentAddon_Click(object sender, EventArgs e)
        {
            if(LoadProject == null)
            {
                Console.WriteLine("Error: LoadProject is not set");
            }
            Label clicked = (Label)sender;
            string project = Properties.Settings.Default.DotaDir + Path.DirectorySeparatorChar + Properties.Settings.Default.BaseAddonDir + (string)clicked.Tag + "\\"; 
            LoadProject(project);
        }

        private void lblNewAddon_Click(object sender, EventArgs e)
        {
            //Call the mainforms function for displaying the NewAddonWizzard
            if(ShowNewAddonWizzard == null)
            {
                Console.WriteLine("Error: ShowNewAddonWizzard is not set");
                return;    
            }
            ShowNewAddonWizzard();
        }

        private void lblLoadAddon_Click(object sender, EventArgs e)
        {
            //Call the mainforms function for loading an addon
            if(LoadAddon == null)
            {
                Console.WriteLine("Error: LoadAddon is not set");
                return;    
            }
            LoadAddon();
        }
    }
}
