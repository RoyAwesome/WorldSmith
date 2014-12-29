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
using System.Net;
using System.Threading;
using Ionic.Zip;
using System.Diagnostics;
using System.Reflection;


namespace WorldsmithUpdater
{

    enum UpdaterFunction
    {
        CreateBuild,
        DownloadBuild,
    }

    class CommandOptions
    {
        [VerbOption("createBuild", HelpText = "Creates a build")]
        public BuilderOptions BuilderOptions
        {
            get;
            set;
        }

        [VerbOption("update", HelpText = "Updates a build")]
        public UpdaterOptions UpdaterOptions
        {
            get;
            set;
        }

        [ParserState]
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

        [Option('u', "url", DefaultValue = "http://rhoyne.cloudapp.net:8010/", Required = false)]
        public string URL
        {
            get;
            set;
        }

        [ParserState]
        public IParserState ParserState
        {
            get;
            set;
        }
    }

    class UpdaterOptions : CommonOptions
    {
        [Option('l', "launch-when-complete", DefaultValue = false, Required = false)]
        public bool LaunchWhenComplete
        {
            get;
            set;
        }

        [Option('d', "dont-clean", DefaultValue=false, Required=false, HelpText="Don't clean up the downloaded archive")]
        public bool DontClean
        {
            get;
            set;
        }
    }


    class BuilderOptions : CommonOptions
    {
        [Option('b', "build", HelpText = "File to include in the build", Required = true)]
        public string BuildFile
        {
            get;
            set;
        }

        [Option('n', "notes", HelpText = "Notes for this build", Required = true)]
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


        [Option("manifest", DefaultValue = "UpdateManifest.txt", Required = false)]
        public string Manifest
        {
            get;
            set;
        }




        [Option('p', "patchnotes", DefaultValue = "", Required = false)]
        public string DetailedNotesURL
        {
            get;
            set;
        }

        [Option('v', "version", DefaultValue = "custombuild", Required = false)]
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

            JsonConvert.DefaultSettings = () =>
            {
                var settings = new JsonSerializerSettings();
                settings.Formatting = Formatting.Indented;
                settings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                settings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());

                return settings;
            };


            var options = new CommandOptions();
            
            


            string verbName = "";
            object verbOptions = null;

            if (!CommandLine.Parser.Default.ParseArguments(args, options, (verb, obj) =>
                {
                    verbName = verb;
                    verbOptions = obj;
                }))
            {
                Console.WriteLine("Failed to parse console args");

                HelpText text = new HelpText();
                
                if(options.BuilderOptions != null)
                {
                    Console.WriteLine(text.RenderParsingErrorsText(options.BuilderOptions, 1));
                }

                if (options.UpdaterOptions != null)
                {
                    Console.WriteLine(text.RenderParsingErrorsText(options.UpdaterOptions, 1));
                }

                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }

            if (verbName == "createBuild")
            {
                BuilderOptions op = verbOptions as BuilderOptions;

                CreateBuild(op);
            }
            else if (verbName == "update")
            {
                UpdaterOptions op = verbOptions as UpdaterOptions;

                DownloadLatestVersion(op);
            }

        }

        static volatile bool downloading;

        static void DownloadLatestVersion(UpdaterOptions options)
        {
            Console.WriteLine("Checking for " + options.UpdateChannel + " builds at " + options.URL);

            IEnumerable<Build> builds = null;
            //Get the builds from the server
            try
            {
                builds = UpdaterLib.Updater.GetBuildsForChannel(options.UpdateChannel, options.URL);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error while getting builds: " + e.Message);
                Environment.Exit(1);
            }

            if (builds == null)
            {
                Console.WriteLine("No builds found at " + options.URL);
                Environment.Exit(1);
             }

            //Get the latest build
            Build b = builds.OrderBy(x => x.Date).FirstOrDefault();

            if (b == null)
            {
                Console.WriteLine("There are no builds available for " + options.UpdateChannel);
                Environment.Exit(1);
            }

            Console.WriteLine("Downloading " + b.Version);

            WebClient cl = new WebClient();
            cl.DownloadProgressChanged += cl_DownloadProgressChanged;
            cl.DownloadFileCompleted += cl_DownloadFileCompleted;



            cl.DownloadFileAsync(new Uri(b.DownloadURL + b.FileName), b.FileName);

            downloading = true;

            while (downloading)
            {
                Thread.Sleep(1);
            }

            //Compare the sha with the sha of the build manifest
            Console.WriteLine("Validating Download");

            string hash = "";

            using (FileStream stream = File.OpenRead(b.FileName))
            {
                SHA256Managed sha = new SHA256Managed();
                byte[] h = sha.ComputeHash(stream);
                hash = BitConverter.ToString(h).Replace("-", String.Empty);
            }

            if(hash != b.Sha)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Error: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(b.FileName + "Failed Sha Check.  Run the updater again");

                Environment.Exit(1);

            }


            Console.WriteLine("Sha hashes match");

            //Extract the zip file
            Console.WriteLine("Extracting " + b.FileName);

            using (ZipFile zip = ZipFile.Read(b.FileName))
            {
                zip.ExtractAll(Environment.CurrentDirectory, ExtractExistingFileAction.OverwriteSilently);
            }

            Console.WriteLine("Extracted");


            File.WriteAllText("Version.txt", JsonConvert.SerializeObject(b));
            
            //Clean up the archive unless we don't want to
            if(!options.DontClean)
            {
                File.Delete(b.FileName);
            }
            

            //TODO: Make the executable discoverable to generalize this updater
            if (options.LaunchWhenComplete)
            {
                Console.WriteLine("Launching");
                //Launch worldsmith

                ProcessStartInfo start = new ProcessStartInfo();
                start.Arguments = "";
                start.FileName = "Worldsmith.exe";
                start.UseShellExecute = true;

                Process.Start(start);


            }


        }

        static void cl_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Download Completed");
            downloading = false;
        }

        static void cl_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.WriteLine("Download Progress: " + e.BytesReceived + " / " + e.TotalBytesToReceive + " " + e.ProgressPercentage + "%");
        }


        static void CreateBuild(BuilderOptions options)
        {
            Console.WriteLine("Creating Build for " + options.UpdateChannel.ToString() + " version " + options.Version);

           
            List<Manifest> Manifests;

            //Get the Manifests if the file exists.  If it doesn't, create it
            if (!File.Exists(options.Manifest))
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

            //Create the version file
            UpdaterLib.Version version = new UpdaterLib.Version()
            {
                Name = b.Version,
                Channel = options.UpdateChannel,
                Origin = b.DownloadURL,
                Notes = b.Notes,
                Sha = b.Sha,
            };

            //And insert it into the output
            Console.WriteLine("Inserting version.txt");
            string zip = outputDir + Path.GetFileName(options.BuildFile);
            using(ZipFile z = new ZipFile(zip))
            {
                z.AddEntry("version.txt", JsonConvert.SerializeObject(version));
                string updaterexe = Assembly.GetExecutingAssembly().Location;
                z.AddFile(updaterexe, "");
                z.Save();
            }
            


            Console.WriteLine("Writing Buildfile");
            //Write the builds file
            File.WriteAllText(buildListFilename, JsonConvert.SerializeObject(builds));
            File.WriteAllText(options.OutputPath + "/" + buildListFilename, JsonConvert.SerializeObject(builds));

            //Update the manifest
            man.LastUpdate = b.Date;
            man.LatestVersion = b.Version;

            Console.WriteLine("Writing Manifest");
            //Write the manifests
            File.WriteAllText(options.Manifest, JsonConvert.SerializeObject(Manifests));
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
