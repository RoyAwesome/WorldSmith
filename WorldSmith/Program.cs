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




            //GenerateDataPropertiesFromKeyValues(@"E:\Dota2SDK\root\scripts\npc\npc_units.txt", "npc_dota_units_base", "UnitBase.txt");
          
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
            assets.ShowDialog();
            Application.ApplicationExit += Application_ApplicationExit;

            Application.Run(new MainForm());

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DotaData.Shutdown();
        }


        static void GenerateDataPropertiesFromKeyValues(string file, string baseKey, string outputFile)
        {
            KVLib.KeyValue kv = KVLib.KVParser.ParseKeyValueText(File.ReadAllText(file));
            kv = kv[baseKey];

            StringBuilder sb = new StringBuilder();
            foreach (KVLib.KeyValue k in kv.Children)
            {
                sb.AppendLine("[Category(\"Unit Base\")]");
                sb.AppendLine("[Description(\"No Description Set\")]");

                string type = DetermineType(k);

                sb.Append("[DefaultValue(");
                if(type == "string")
                {
                    sb.Append("\"" + k.GetString() + "\"");
                }
                if(type == "int" || type == "float")
                {
                    sb.Append(k.GetFloat());
                }
                if(type == "bool")
                {
                    sb.Append(k.GetBool().ToString().ToLower());
                }
                if(type == "CANTDETERMINE")
                {
                    sb.Append(k.GetString().ToLower());
                }
                sb.AppendLine(")]");

                sb.AppendLine(string.Format("public {0} {1}", type, k.Key));
                sb.AppendLine("{");
                sb.AppendLine("\tget;");
                sb.AppendLine("\tset;");
                sb.AppendLine("}");
                sb.AppendLine();
                sb.AppendLine();
            }

            File.WriteAllText(outputFile, sb.ToString());
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
    }
}
