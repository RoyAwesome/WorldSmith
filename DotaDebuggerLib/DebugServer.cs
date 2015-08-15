using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace DotaDebuggerLib
{
    public class DebugServer
    {
        public delegate void DataRecievedHandler(string data);

       
        static int Port = 10000;

        static Thread ListenThread;
        public static event DataRecievedHandler OnDataRecieved;

        public static bool Started = false;

        public static volatile bool Connected = false;
        public static volatile bool ShouldDisconnect = false;
        public static void StartServer()
        {

            ListenThread = new Thread(Run);
            ListenThread.Start();
            Started = true;
        }

        public static Queue<string> Commands = new Queue<string>();

        public static void Run()
        {
            TcpListener ServerSocket = new TcpListener(IPAddress.Any, Port);

            OnDataRecieved.Invoke("[SERVER] Started");
            ServerSocket.Start();

            Socket conn = ServerSocket.AcceptSocket();
            OnDataRecieved.Invoke("[SERVER] Connected");
            Connected = true;
            
            while (conn.Connected)
            {
                if(ShouldDisconnect)
                {
                    conn.Disconnect(false);
                    break;
                }

                try
                {
                    //Check to see if we have any data in the socket
                    if (conn.Available > 0)
                    {
                        //create a buffer and consume it
                        byte[] Buffer = new byte[conn.Available];
                        conn.Receive(Buffer);

                        //Convert it to a string
                        string data = Encoding.ASCII.GetString(Buffer);

                        if (OnDataRecieved != null)
                        {
                            OnDataRecieved.Invoke(data);
                        }
                    }

                    lock (Commands)
                    {
                        if (Commands.Count > 0)
                        {
                            string command = Commands.Dequeue();
                                                  

                            OnDataRecieved("[SERVER] => " + command);
                            List<byte> cmd = new List<byte>();
                            cmd.AddRange(Encoding.ASCII.GetBytes(command));
                            cmd.Add(0);
                            conn.Send(cmd.ToArray());


                        }
                    }
                }
                catch (Exception e)
                {
                    OnDataRecieved("[SERVER] Error: " + e.ToString());
                    conn.Disconnect(false);
                    break;
                }
                

                Thread.Sleep(100);
            }

            Connected = false;
            OnDataRecieved("[SERVER] Disconnected");
            
        }

        public static void Disconnect()
        {
            ShouldDisconnect = true;
        }

        public static void Logger(string data)
        {
            Console.WriteLine(data);
        }

        public static void SendData(string message)
        {
           

            lock(Commands)
            {
                Commands.Enqueue(message);
            }

        }

    }
}
