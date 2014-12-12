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

#if DEBUG
            ConsoleManager.AllocConsole();
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Prompt the user to specify the Dota 2 path if it has not been set
            InitialSetup initial = new InitialSetup(true);
            if (!initial.IsDotaDirSet())
            {
                Application.Exit();
                return;
            }

            // Ensure that the AddOnPath user setting was set
            if (!initial.IsAddOnPathSet())
            {
                Application.Exit();
                return;
            }

            Application.ApplicationExit += Application_ApplicationExit;

            // Extract the Dota 2 pack01_dir VPK file and load all of the data
            AssetLoadingDialog assets = new AssetLoadingDialog();
            assets.ShowDialog(AssetLoadingDialog.InitialLoad);
            if (!String.IsNullOrEmpty(Properties.Settings.Default.AddOnPath))
            {
                assets = new AssetLoadingDialog();
                assets.ShowDialog(AssetLoadingDialog.AddonLoadTasks);
            }
            
            System.Threading.Thread.CurrentThread.CurrentUICulture = 
                System.Globalization.CultureInfo.CreateSpecificCulture(Properties.Settings.Default.Language);

            Application.Run(mainForm = new MainForm());

            Properties.Settings.Default.Save();
#endif
          
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }

        public static MainForm mainForm;

        /// <summary>
        /// Generates all of the Data Classes from the Data Schema. If Valve changes the Dota 2 schema,
        /// edit the schema text files, and run this function to update the Data Classes.
        /// </summary>
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
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "ModifierSchema.txt", unitDir);            

            string actionInputDir = inputDir + "ActionSchemas/";
            string actionOutputDir = outputDir + "ActionTypes/";

            foreach(string file in Directory.GetFiles(actionInputDir))
            {
                if (!file.EndsWith(".txt")) continue; //If it's not a text file, skip it

                DataSchema.DataClassGenerator.GenerateClassForSchema(file, actionOutputDir);
            }

           
        }
    }



}
