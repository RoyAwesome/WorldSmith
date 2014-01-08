﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using KVLib;

namespace WorldSmith.DataClasses
{
    static class DotaData
    {
        public static string VPKPath = "dota" + Path.DirectorySeparatorChar + "pak01_dir.vpk";

        #region Unit Data Lists
        public static List<DotaUnit> DefaultUnits = new List<DotaUnit>();

        public static List<DotaUnit> OverriddenUnits = new List<DotaUnit>();

        public static List<DotaUnit> CustomUnits = new List<DotaUnit>();

        public static List<DotaHero> DefaultHeroes = new List<DotaHero>();

        public static List<DotaHero> OverridenHeroes = new List<DotaHero>();

        public static List<DotaHero> CustomHeroes = new List<DotaHero>();

        public static IEnumerable<DotaBaseUnit> AllDefaultUnits = DefaultUnits.Cast<DotaBaseUnit>()
            .Union(DefaultHeroes.Cast<DotaBaseUnit>());

        public static IEnumerable<DotaBaseUnit> AllOverridenUnits = OverriddenUnits.Cast<DotaBaseUnit>()
            .Union(OverridenHeroes.Cast<DotaBaseUnit>());

        public static IEnumerable<DotaBaseUnit> AllCustomUnits = CustomUnits.Cast<DotaBaseUnit>()
            .Union(CustomHeroes.Cast<DotaBaseUnit>());

        public static IEnumerable<DotaBaseUnit> AllUnits = AllDefaultUnits
            .Union(AllOverridenUnits)
            .Union(CustomUnits.Cast<DotaBaseUnit>())
            .Union(CustomUnits.Cast<DotaBaseUnit>());
            
        #endregion

        public static IEnumerable<DotaDataObject> AllClasses = AllUnits.Cast<DotaDataObject>();

        #region HLLib Usage
        public static void LoadFromVPK(string vpkPath)
        {
            if(!Directory.Exists("cache")) Directory.CreateDirectory("cache");

            string path = Properties.Settings.Default.dotadir + Path.DirectorySeparatorChar + VPKPath;
            HLLib.hlInitialize();

            // Get the package type from the filename extension.
            HLLib.HLPackageType PackageType = HLLib.hlGetPackageTypeFromName(path);

            HLLib.HLFileMode OpenMode = HLLib.HLFileMode.HL_MODE_READ |
                HLLib.HLFileMode.HL_MODE_QUICK_FILEMAPPING |
                HLLib.HLFileMode.HL_MODE_VOLATILE;

            uint PackageID;

            ErrorCheck(HLLib.hlCreatePackage(PackageType, out PackageID));            

            ErrorCheck(HLLib.hlBindPackage(PackageID));

            ErrorCheck(HLLib.hlPackageOpenFile(path, (uint)OpenMode));           
            
        }


        private static string ReadTextFromHLLibStream(IntPtr Stream)
        {
            HLLib.HLFileMode mode = HLLib.HLFileMode.HL_MODE_READ;

            ErrorCheck(HLLib.hlStreamOpen(Stream, (uint)mode));

            StringBuilder str = new StringBuilder();

            char ch;
            while (HLLib.hlStreamReadChar(Stream, out ch))
            {
                str.Append(ch);
            }

            HLLib.hlStreamClose(Stream);

            return str.ToString();
        }


        public static void ErrorCheck(bool ret)
        {
            if (!ret)
            {
                MessageBox.Show("Error reading pak01_dir.vpk.\n\n The error reported was: " + HLLib.hlGetString(HLLib.HLOption.HL_ERROR_LONG_FORMATED), "Error opening .pak", MessageBoxButtons.OK);
                Shutdown();
                Application.Exit();
            }
        }

        public static void Shutdown()
        {
            HLLib.hlShutdown();
        }
        #endregion

        #region LoadData
        public static void ReadUnits()
        {
            IntPtr root = HLLib.hlPackageGetRoot();

            IntPtr file = HLLib.hlFolderGetItemByPath(root, "scripts/npc/npc_units.txt", HLLib.HLFindType.HL_FIND_FILES);

            IntPtr stream;
            ErrorCheck(HLLib.hlPackageCreateStream(file, out stream));
         
            string unitsText = ReadTextFromHLLibStream(stream);
            
            KeyValue rootkv = KVLib.KVParser.ParseKeyValueText(unitsText);

            foreach(KeyValue kv in rootkv.Children)
            {
                if (!kv.HasChildren) continue; //Get rid of that pesky "Version" "1" key

                DotaUnit unit = new DotaUnit();
                unit.LoadFromKeyValues(kv);
                DefaultUnits.Add(unit);
            }

        }

        public static void ReadHeroes()
        {
            IntPtr root = HLLib.hlPackageGetRoot();

            IntPtr file = HLLib.hlFolderGetItemByPath(root, "scripts/npc/npc_heroes.txt", HLLib.HLFindType.HL_FIND_FILES);

            IntPtr stream;
            ErrorCheck(HLLib.hlPackageCreateStream(file, out stream));

            string unitsText = ReadTextFromHLLibStream(stream);

            KeyValue rootkv = KVLib.KVParser.ParseKeyValueText(unitsText);

            foreach (KeyValue kv in rootkv.Children)
            {
                if (!kv.HasChildren) continue; //Get rid of that pesky "Version" "1" key

                DotaHero unit = new DotaHero();
                unit.LoadFromKeyValues(kv);
                DefaultHeroes.Add(unit);
            }
        }
        #endregion

        #region SaveData
        public static void SaveUnits()
        {


        }

        #endregion


    }
}
