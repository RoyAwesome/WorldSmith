using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Security.Cryptography;
using Newtonsoft.Json;
using UpdaterLib;
using CommandLine;
using CommandLine.Text;

namespace WorldsmithUpdater
{

    enum UpdaterFunction
    {
        CreateBuild,
        DownloadBuild,
    }

    class CommandOptions
    {
        [VerbOption("createBuild", HelpText="Creates a build")]
        public BuilderOptions BuilderOptions
        {
            get;
            set;
        }

        [VerbOption("update", HelpText="Updates a build")]
        public UpdaterOptions UpdaterOptions
        {
            get;
            set;
        }

        [ParserState()]
        public IParserState ParserState
        {
            get;
            set;
        }
      
    }

    abstract class CommonOptions
    {
        [Option('c', "channel", DefaultValue = UpdateChannel.Stable, Required = false, HelpText = "Channel to download.  Stable, Beta, or Dev")]
        public UpdateChannel UpdateChannel
        {
            get;
            set;
        }
    }

    class UpdaterOptions : CommonOptions
    {

    }


    class BuilderOptions : CommonOptions
    {
        [Option('b', "build", HelpText = "File to include in the build", Required = true)]
        public string BuildFile
        {
            get;
            set;
        }

        [Option('n', "notes", HelpText="Notes for this build", Required = true)]
        public string UpdateNotes
        {
            get;
            set;
        }

        [Option('o', "ouput", HelpText = "Directory to write the manifests", Required = true)]
        public string OutputPath
        {
            get;
            set;
        }


        [Option("manifest", DefaultValue="UpdateManifest.txt", Required = false)]
        public string Manifest
        {
            get;
            set;
        }

        [Option("url", DefaultValue = "http://rhoyne.cloudapp.net:8010/", Required=false)]
        public string URL
        {
            get;
            set;
        }

     
        [Option('p', "patchnotes", DefaultValue="", Required=false)]
        public string DetailedNotesURL
        {
            get;
            set;
        }

        [Option('v', "version", DefaultValue="custombuild", Required=false)]
        public string Version
        {
            get;
            set;
        }

    }

    class Program
    {
      
        static void Main(string[] args)
        {

            var options = new CommandOptions();
            


            string verbName = "";
            object verbOptions = null;

            if(!CommandLine.Parser.Default.ParseArguments(args, options, (verb, obj) =>
                {
                    verbName = verb;
                    verbOptions = obj;
                }))
            {
                Console.WriteLine("Failed to parse console args");
                HelpText text = new HelpText();
                text.RenderParsingErrorsText(options, 1);

                Console.WriteLine(text);

                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            if(verbName == "createBuild")
            {
                BuilderOptions op = verbOptions as BuilderOptions;

                CreateBuild(op);
            }
            else if(verbName == "update")
            {
                UpdaterOptions op = verbOptions as UpdaterOptions;
            }

        }


        static void CreateBuild(BuilderOptions options)
        {
            Console.WriteLine("Creating Build for " + options.UpdateChannel.ToString() + " version " + options.Version);

            JsonConvert.DefaultSettings = () =>
                {
                    var settings = new JsonSerializerSettings();
                    settings.Formatting = Formatting.Indented;
                    settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

                    return settings;
                };

            List<Manifest> Manifests;

            //Get the Manifests if the file exists.  If it doesn't, create it
            if(!File.Exists(options.Manifest))
            {
                Console.WriteLine("Manifest file does not exist, creating Manifests");
                CreateDefaultManifests(options);
            }


            Manifests = JsonConvert.DeserializeObject<List<Manifest>>(File.ReadAllText(options.Manifest));          


            //Get the update channel we are building for
            Manifest man = Manifests.FirstOrDefault(x => x.Channel == options.UpdateChannel.ToString());

            if (man == null)
            {
                Console.WriteLine("Error: Cannot find the manifest for " + options.Manifest + "!  Aborting.");
                Environment.Exit(0);
            }

            //Get the list of builds
            string buildListFilename = options.UpdateChannel.ToString() + "BuildList.txt";

            List<Build> builds = JsonConvert.DeserializeObject<List<Build>>(File.ReadAllText(buildListFilename));

            Console.WriteLine("Computing Sha Hash of the build");
            //Create the sha hash
            string hash = "";

            using (FileStream stream = File.OpenRead(options.BuildFile))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] h = sha.ComputeHash(stream);
                hash = BitConverter.ToString(h).Replace("-", String.Empty);
            }

            Console.WriteLine("Creating build information");
            //Create the build             
            Build b = new Build()
            {
                FileName = Path.GetFileName(options.BuildFile),
                DownloadURL = options.URL + options.UpdateChannel.ToString() + "/",
                Sha = hash,
                Notes = options.UpdateNotes,
                DetailURL = options.DetailedNotesURL,
                Version = options.Version,
                Date = DateTime.Now,
            };

            builds.Add(b);

            Console.WriteLine("Writing Build");
            //Copy the file to the output directory
            string outputDir = options.OutputPath + "/" + options.UpdateChannel.ToString() + "/";
            Directory.CreateDirectory(options.OutputPath);
            Directory.CreateDirectory(outputDir);

            File.Copy(options.BuildFile, outputDir + Path.GetFileName(options.BuildFile), true);

            Console.WriteLine("Writing Buildfile");
            //Write the builds file
            File.WriteAllText(options.OutputPath + "/" + buildListFilename, JsonConvert.SerializeObject(builds));

            //Update the manifest
            man.LastUpdate = b.Date;
            man.LatestVersion = b.Version;
           
            Console.WriteLine("Writing Manifest");
            //Write the manifests
            File.WriteAllText(options.OutputPath + "/" + options.Manifest, JsonConvert.SerializeObject(Manifests));


        }

        static void CreateDefaultManifests(BuilderOptions options)
        {
            Directory.CreateDirectory(options.OutputPath);

            var Manifests = new List<Manifest>();

            UpdateChannel[] channels = Enum.GetValues(typeof(UpdateChannel)) as UpdateChannel[];

            foreach (UpdateChannel ch in channels)
            {
                string BuildListFilename = ch.ToString() + "BuildList.txt";
                Manifests.Add(new Manifest()
                {
                    Channel = ch.ToString(),
                    LatestVersion = "",
                    LastUpdate = DateTime.Now,
                    BuildListURL = options.URL + BuildListFilename,
                });

                
                File.WriteAllText(BuildListFilename, "[\n]");
            }

            File.WriteAllText(Path.GetFileName(options.Manifest), JsonConvert.SerializeObject(Manifests));
            

           
        }


    }
}
