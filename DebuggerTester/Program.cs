using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotaDebuggerLib;

namespace DebuggerTester
{
    class Program
    {
        static bool RequiresUpdate = false;

        static string Input = "";

        static Queue<string> OutputList = new Queue<string>();

        public static Stack<string> Scrollback = new Stack<string>();

        static void Main(string[] args)
        {
            DotaDebuggerLib.DebugServer.StartServer();
            DotaDebuggerLib.DebugServer.OnDataRecieved += RecieveDataFromDebugger;

            int ScrollbackIndex = 0;

            RequiresUpdate = true;
            while(true)
            {
                if (RequiresUpdate)
                {
                    Console.Clear();

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Server: ");
                    Console.ForegroundColor = DebugServer.Started ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(DebugServer.Started ? "Online" : "Offline");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("  Dota Debugger: ");
                    Console.ForegroundColor = DebugServer.Connected ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write(DebugServer.Connected ? "Connected" : "Disconnected");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    Console.SetCursorPosition(0, 1);
                    //Write the text
                    foreach(String s in OutputList)
                    {
                        Console.WriteLine(s);
                    }



                    Console.SetCursorPosition(0, Console.WindowHeight - 1);
                    Console.Write("> " + Input);
                    
                    RequiresUpdate = false;
                }


                if(Console.KeyAvailable)
                {
                    var KeyInfo = Console.ReadKey(true);
                    if (KeyInfo.Key == ConsoleKey.Enter)
                    {
                        if (Input.StartsWith("server."))
                        {
                            if (Input == "server.Start")
                            {
                                DebugServer.StartServer();                                
                            }
                            if(Input == "server.Disconnect")
                            {
                                DebugServer.Disconnect();
                            }
                            if (Input == "server.Clear")
                            {
                                OutputList.Clear();
                            }
                        }
                        else
                        {
                            //Send the command to the server
                            DebugServer.SendData(Input);                           
                        }

                        Scrollback.Push(Input);
                        Input = "";

                    }
                    else if(KeyInfo.Key == ConsoleKey.Backspace)
                    {
                        if(Input.Length > 0) Input = Input.Substring(0, Input.Length - 1);
                    }
                    else if(KeyInfo.Key == ConsoleKey.UpArrow && Scrollback.Count > 0)
                    {                        
                        Input = Scrollback.ElementAt(0);
                        ScrollbackIndex++;
                        if (ScrollbackIndex >= Scrollback.Count) ScrollbackIndex = 0;
                    }
                    else if(char.IsLetterOrDigit(KeyInfo.KeyChar) || char.IsWhiteSpace(KeyInfo.KeyChar) || char.IsPunctuation(KeyInfo.KeyChar))
                    {
                        Input += KeyInfo.KeyChar;
                    }
                    
                    RequiresUpdate = true;
                }
            }
        }

        public static void RecieveDataFromDebugger(string data)
        {
            OutputList.Enqueue(data);
            if (OutputList.Count > 10) OutputList.Dequeue();
            RequiresUpdate = true;
        }
    }
}
