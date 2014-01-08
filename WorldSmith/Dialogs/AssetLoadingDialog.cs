using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;

namespace WorldSmith.Dialogs
{
    public partial class AssetLoadingDialog : Form
    {
        public AssetLoadingDialog()
        {
            InitializeComponent();
        }

        public void Start()
        {
            backgroundWorker1.RunWorkerAsync();
        }

        public new DialogResult ShowDialog()
        {
            Start();
            return base.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int totalsteps = 1;


            backgroundWorker1.ReportProgress(5, "pak01_dir.vpk");
            DotaData.LoadFromVPK(Properties.Settings.Default.dotadir);

            backgroundWorker1.ReportProgress(10, "npc_units.txt");
            DotaData.ReadUnits();

            backgroundWorker1.ReportProgress(15, "npc_heroes.txt");
            DotaData.ReadHeroes();
            
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            loadingLabel.Text = (string)e.UserState;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
