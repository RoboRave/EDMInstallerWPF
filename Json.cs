using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows;

namespace EDMInstallerWPF
{
    public class Json
    {
        public static Json instance = new Json();
        private string RunLocation = System.Environment.CurrentDirectory;
    
        public static Config config = new Config();
        public static EDMI es = new EDMI();

        public static void genDefaults()
        {
            config.name = "MinecraftForge";
            config.value = "false";
            es.name = "EDM";
            es.value = "false";
            Console.WriteLine("Generated defaults");
        }

        public void run()
        {
            File.WriteAllText(RunLocation + "/config.json", JsonConvert.SerializeObject(config));
            File.WriteAllText(RunLocation + "/config.json", JsonConvert.SerializeObject(es));
            // serialize JSON directly to a file
            using (StreamWriter file = File.CreateText(RunLocation + "/config.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, config);
                serializer.Serialize(file, es);
            }
        }
    }
}