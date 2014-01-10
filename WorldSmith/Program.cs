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

           // DataSchema.DataClassGenerator.FindPossibleValuesForKey(@"E:\Dota2SDK\root\scripts\npc\items.txt", "ItemDeclarations");

     
#if GENERATECLASSES
            string outputDir = "../../DataClasses/";
            string inputDir = "../../DataSchema/";
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "BaseUnitSchema.txt", outputDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "HeroSchema.txt", outputDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "UnitSchema.txt", outputDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "AbilitySchema.txt", outputDir);
            DataSchema.DataClassGenerator.GenerateClassForSchema(inputDir + "ItemSchema.txt", outputDir);
#else
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Properties.Settings.Default.ranonce)
            {
                Form initial = new InitialSetup();
                if (initial.ShowDialog().Equals(DialogResult.OK)) {
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

            Application.Run(new MainForm());

            Properties.Settings.Default.Save();
#endif
          
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }      
    }
}
