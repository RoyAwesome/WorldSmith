using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using Newtonsoft.Json;

namespace WorldsmithUpdater
{
    class Program
    {
        public class Manifest
        {
            public string Version
            {
                get;
                set;
            }

            public string DetailURL
            {
                get;
                set;
            }

            public string RootURL
            {
                get;
                set;
            }

            public List<FileData> Files = new List<FileData>();
        
        }

        public class FileData
        {
            public int Action
            {
                get;
                set;
            }
            public string Path
            {
                get;
                set;
            }
            public string Hash
            {
                get;
                set;
            }

            public string DownloadURL
            {
                get;
                set;
            }
        }

        static void RecrsuiveHashFiles(string path, ref Manifest manifest)
        {
            foreach (string f in Directory.GetFiles(path))
            {
                using(FileStream fstream = File.OpenRead(f))
                {
                    SHA256Managed sha = new SHA256Managed();
                    byte[] has = sha.ComputeHash(fstream);
                    string hash = BitConverter.ToString(has).Replace("-", String.Empty);

                    manifest.Files.Add(new FileData()
                        {
                            Path = f,
                            Hash = hash,
                        });  
                
                    
                }
            }
            foreach(string f in Directory.GetDirectories(path))
            {
                RecrsuiveHashFiles(f, ref manifest);
            }
        }

        static void Main(string[] args)
        {
            for(int i = 0; i < args.Length; i+= 2)
            {
                if(args[i] == "-buildManifest")
                {
                    string path = args[i + 1];

                    Manifest manifest = new Manifest();
                    manifest.Version = "TEST VERSION";
                    manifest.DetailURL = "PUTURLHERE";
                    manifest.RootURL = "PUTROOTURLHERE";

                    Directory.CreateDirectory("Output/");


                    RecrsuiveHashFiles(path, ref manifest);

                    string file = JsonConvert.SerializeObject(manifest, Formatting.Indented);

                    File.WriteAllText("Manifest.json", file);
                }

                if(args[i] == "-updateFromURL")
                {

                }

            }



        }
    }
}
