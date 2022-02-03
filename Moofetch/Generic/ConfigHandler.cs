using System.Collections.Generic;
using System.IO;

namespace Moofetch.Generic
{
    public static class ConfigHandler
    {
        private static Dictionary<string, string> config = new Dictionary<string, string>();
        private static string configPath;
        
        private static string[] defaultConfig =
        {
            "COW_SAY=YES"
        };

        public static void init()
        {
            Debug.throwInfo("Checking if config exists...");

            string whoami = CommandRunner.runCommand("whoami");
            
            configPath = "/home/" + whoami.Remove(whoami.Length - 1) + "/.config/moofetch/conf";

            if (!File.Exists(configPath))
            {
                Debug.throwInfo("Creating a new config...");

                Directory.CreateDirectory(configPath.Remove(configPath.Length - 4 /*(Remove the conf on end)*/));
                File.WriteAllLines(configPath, defaultConfig);
            }
        }

        public static void updateConfig()
        {
            Debug.throwInfo("Reading config...");
            config = KeyValueParser.deserialise(FileReader.getFileLines(configPath), '=');
        }
        
        public static string getValue(string key)
        {
            Debug.throwInfo("Getting " + key + " from config...");
            return config[key];
        }
        
        public static void setValue(string key, string value)
        {
            Debug.throwInfo("Setting " + key + " from config...");

            config[key] = value;

            string newConfig = KeyValueParser.serialise(config, '=');
            File.WriteAllLines(configPath, newConfig.Split('\n'));
        }
        
    }
}