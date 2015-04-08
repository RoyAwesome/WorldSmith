using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLua;
using NLua.Exceptions;
using System.Reflection;
using WorldSmith.DataClasses;

namespace WorldSmith
{
    static class LuaHelper
    {
        /// <summary>
        /// Lua State for the editor code.  This is the state that exists in the console window
        /// and in the scratch pad.
        /// </summary>
        static Lua EditorState;

        /// <summary>
        /// This is the lua state for any dota 2 related lua code.  This is used for testing if code will work.
        /// </summary>
       // static Lua GameState;

        static Lua ScratchpadState;

        static LuaHelper()
        {
            EditorState = new Lua();
           
            //GameState = new Lua();

            ScratchpadState = new Lua();
        }

        public static void Init()
        {
            var methodinfo = typeof(LuaHelper).GetMethod("Print", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            EditorState.RegisterFunction("print", methodinfo);
           

            methodinfo = typeof(LuaHelper).GetMethod("PrintScratchpad", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
            ScratchpadState.RegisterFunction("print", methodinfo);

            InitEditorState(EditorState);
            InitEditorState(ScratchpadState);
           

            Console.WriteLine("[Lua] Lua Initialized");
        }

        private static void InitEditorState(Lua state)
        {
            state.LoadCLRPackage();

            string resName = "WorldSmith.Scripts.WorldsmithImports.lua";

            Assembly asm = Assembly.GetExecutingAssembly();
            using (System.IO.Stream s = asm.GetManifestResourceStream(resName))
            using (System.IO.StreamReader reader = new System.IO.StreamReader(s))
            {
                string data = reader.ReadToEnd();

                state.DoString(data, resName);               
            }

            state["Units"] = DotaData.AllUnits;          
            state["Heroes"] = DotaData.AllHeroes;          
            state["Abilities"] = DotaData.AllAbilities;           
            state["Items"] = DotaData.DefaultItems;

            //Bind the DataClass enum
            state.DoString("DataClass = {}");
            state["DataClass.Default"] = DotaDataObject.DataObjectInfo.ObjectDataClass.Default;
            state["DataClass.Override"] = DotaDataObject.DataObjectInfo.ObjectDataClass.Override;
            state["DataClass.Custom"] = DotaDataObject.DataObjectInfo.ObjectDataClass.Custom;


        }

        #region Toolbar State
        private static void Print(params object[] message)
        {
            if (message == null) Console.WriteLine();
            else Console.WriteLine(String.Join("\t", message));
        }

        public static string DoEditorToolbarString(string lua)
        {
            try
            {
                var ret = EditorState.DoString(lua);

                if (ret == null) return null;
                return String.Join(",", ret);
            }
            catch (LuaException e)
            {
                return e.ToString();
            }

        }
        #endregion


        private static ConsoleStringWriter StringWriter;
        private static void PrintScratchpad(params object[] message)
        {
            if (message == null) StringWriter.WriteLine();
            else StringWriter.WriteLine(String.Join("\t", message));
        }


        public static string DoScratchpadString(string text, ConsoleStringWriter sw)
        {
            StringWriter = sw;
            try
            {
                var ret = ScratchpadState.DoString(text);

                if (ret == null) return null;
                return String.Join(",", ret);
            }
            catch (LuaException e)
            {
                return e.ToString();
            }
        }

       


    }
}
