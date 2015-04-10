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
        public static ConsoleStringWriter ConsoleRedirect;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

#if GENERATECLASSES         
            GenerateClasses();
#else
            ConsoleRedirect = new ConsoleStringWriter();
            Console.SetOut(ConsoleRedirect);

            //Set up the crash handler          
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;


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
            System.Threading.Thread.CurrentThread.CurrentUICulture =
           System.Globalization.CultureInfo.CreateSpecificCulture(Properties.Settings.Default.Language);

       
            // Extract the Dota 2 pack01_dir VPK file and load all of the data
            AssetLoadingDialog assets = new AssetLoadingDialog();
            assets.ShowDialog(AssetLoadingDialog.InitialLoad);



            //Construct the main form and load the default project (if any).
            MainForm mainForm = new MainForm();
            if (IsLoaddedAddonDirectoryValid())
            {
                mainForm.LoadProject(Properties.Settings.Default.LoadedAddonDirectory);
            }

            CheckForUpdate.Check(true);

            Application.Run(mainForm);

            Properties.Settings.Default.Save();
#endif

        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if(e.IsTerminating)
            {
                Exception ex = e.ExceptionObject as Exception;
                WriteCrash(ex.ToString());
            }
        }      
        public static void WriteCrash(string message)
        {
            Directory.CreateDirectory("Crashes");

            string header = "Please report this crash to https://github.com/RoyAwesome/worldsmith/issues \n";
            header += "Please include your project and the build that crashed (located in the Version.txt file)\n\n";

            File.WriteAllText("Crashes/Crash_" + DateTime.Now.ToString("dd-mm-yy_h-mm-ss") +".txt", header + message);

            MessageBox.Show("Worldsmith has crashed.  A crash report has been written to the Crashes/ directory.\nWorldsmith will now close", "Worldsmith Error", MessageBoxButtons.OK);
            Application.Exit();
            
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }

        static bool IsLoaddedAddonDirectoryValid()
        {
            return !String.IsNullOrEmpty(Properties.Settings.Default.LoadedAddonDirectory) && Directory.Exists(Properties.Settings.Default.LoadedAddonDirectory);
        }

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
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "AbilityEventSchema.txt", unitDir);

            string actionInputDir = inputDir + "ActionSchemas/";
            string actionOutputDir = outputDir + "ActionTypes/";

            foreach (string file in Directory.GetFiles(actionInputDir))
            {
                if (!file.EndsWith(".txt")) continue; //If it's not a text file, skip it

                DataSchema.DataClassGenerator.GenerateClassForSchema(file, actionOutputDir);
            }


        }
    }



}
