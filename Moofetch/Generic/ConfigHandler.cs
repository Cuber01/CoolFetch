using System.IO;

namespace Moofetch.Generic
{
    public static class ConfigHandler
    {
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
    }
}