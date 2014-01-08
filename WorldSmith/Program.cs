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

            FindPossibleValuesForKey(@"E:\Dota2SDK\root\scripts\npc\npc_heroes.txt", "UnitRelationshipClass");
            
            
            /*
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Properties.Settings.Default.ranonce)
            {
                Form initial = new InitialSetup();
                initial.ShowDialog();
                Properties.Settings.Default.ranonce = true;
                Properties.Settings.Default.Save();
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
             * */

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }

        #region PropertyFinder
        static void GenerateDataPropertiesFromKeyValues(string file, string baseKey, string outputFile)
        {
            KVLib.KeyValue kv = KVLib.KVParser.ParseKeyValueText(File.ReadAllText(file));
            kv = kv[baseKey];

            KVLib.KeyValue doc = new KVLib.KeyValue("Schema");

 
            foreach (KVLib.KeyValue k in kv.Children)
            {
                KVLib.KeyValue property = new KVLib.KeyValue(k.Key);
                property += new KVLib.KeyValue("Category") + "Misc";
                property += new KVLib.KeyValue("Description") + "No Description Set";
                string type = DetermineType(k);
                property += new KVLib.KeyValue("Type") + type;
                property += new KVLib.KeyValue("DefaultValue") + k.GetString();

                doc += property;

                
            }

            File.WriteAllText(outputFile, doc.ToString());
        }

        static void FindPossibleValuesForKey(string file, string key)
        {
            KVLib.KeyValue srcDoc = KVLib.KVParser.ParseKeyValueText(File.ReadAllText(file));

            List<string> foundValues = new List<string>();

           
            foreach(KVLib.KeyValue k in srcDoc.Children)
            {
                KVLib.KeyValue val = k[key];
                if (val == null) continue;
                string sval = val.GetString();
                if (!foundValues.Contains(sval)) foundValues.Add(sval);
            }

            KVLib.KeyValue outDoc = new KVLib.KeyValue("PossibleValues");
            int count = 0;
            foreach (string s in foundValues)
            {
                outDoc += new KVLib.KeyValue(count.ToString()) + s;
                count++;
            }

            File.WriteAllText(key + ".txt", outDoc.ToString());
        }

        static string DetermineType(KVLib.KeyValue k)
        {

            //If they key contains 'Is', 'Can', 'Has', then it's probably a bool
            if(k.Key.IndexOf("Is", StringComparison.OrdinalIgnoreCase) != -1 ||
                k.Key.IndexOf("Can", StringComparison.OrdinalIgnoreCase) != -1 ||
                k.Key.IndexOf("Has", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return "bool";
            }

            //Attributes are always ints
            if(k.Key.IndexOf("Attribute", StringComparison.OrdinalIgnoreCase) != -1)
            {
                return "int";
            }

            //Determine the type of the KV
            List<string> PossibleTypes = new List<string>() {
                    "float",
                    "string",
                    "bool",
                    "int",
                };

            float f;
            if (!k.TryGet(out f)) //Not a float
            {
                PossibleTypes.Remove("float");
            }
            int i;
            if (!k.TryGet(out i))
            {
                PossibleTypes.Remove("int");
            }
            bool b;
            if (!k.TryGet(out b))
            {
                PossibleTypes.Remove("bool");
            }
            if (PossibleTypes.Count > 1) //If we have more than one type, it's probably not a string
            {
                PossibleTypes.Remove("string");
            }

            if(PossibleTypes.Count == 1)
            {
                //Got it, return that one
                return PossibleTypes.First();
            }

            //If the possible types are float or int, default to int
            if(PossibleTypes.Contains("int") && PossibleTypes.Contains("float") 
                && !PossibleTypes.Contains("bool"))
            {
                return "int";
            }

            if(k.GetInt() < 0 || k.GetInt() > 1) //If the number is less than 0 or greater than 1, assume int
            {
                return "int";
            }
            //If the value is '0' or '1', it could be float int or bool.  If the name didn't have 'is', lets default to
           //lets default to int
            

            return "CANTDETERMINE";
        }
        #endregion
    }
}
