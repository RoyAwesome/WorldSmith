using KVLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WorldSmith.DataClasses;
using WorldSmith.Dialogs;

namespace WorldSmith
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

     
#if GENERATECLASSES         
            GenerateClasses();
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Properties.Settings.Default.ranonce)
            {
                InitialSetup initial = new InitialSetup(true);
                if (initial.ShowDialog() == DialogResult.OK) {
                    Properties.Settings.Default.ranonce = true;
                    Properties.Settings.Default.Save();
                }
                else {
                    Application.Exit();
                    return;
                }
            }

            AssetLoadingDialog assets = new AssetLoadingDialog();
            assets.ShowDialog(AssetLoadingDialog.InitialLoad);
            if (Properties.Settings.Default.AddonPath != "")
            {
                assets = new AssetLoadingDialog();
                assets.ShowDialog(AssetLoadingDialog.AddonLoadTasks);
            }
            Application.ApplicationExit += Application_ApplicationExit;

            Application.Run(mainForm = new MainForm());

            Properties.Settings.Default.Save();
#endif
          
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }

        public static MainForm mainForm;


        public static void GenerateClasses()
        {
            string outputDir = "../../DataClasses/";            
            string inputDir = "../../DataSchema/";

            string unitDir = outputDir + "ScriptTypes/";
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "BaseUnitSchema.txt", unitDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "HeroSchema.txt", unitDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "UnitSchema.txt", unitDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "AbilitySchema.txt", unitDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "ItemSchema.txt", unitDir);


            string actionInputDir = inputDir + "ActionSchemas/";
            string actionOutputDir = outputDir + "ActionTypes/";

            foreach(string file in Directory.GetFiles(actionInputDir))
            {
                if (!file.EndsWith(".txt")) continue; //If it's no0t a text file, skip it

                DataSchema.DataClassGenerator.GenerateClassForSchema(file, actionOutputDir);
            }

           
        }
    }



}
