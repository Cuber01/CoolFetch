using System;
using System.Collections.Generic;

namespace CoolFetch
{
    
    /*
     Stuff I want:
     Gpu - Done, run lspci | grep -i --color 'vga\|3d\|2d' and get card in [] brackets



     Maybe more hardware info
     */

    public static class Program
    {
        public static bool debug = true;
        
        private static Dictionary<string, string> info = new Dictionary<string, string>()
        {
            
            {
                "OS: ", "Unknown."
            },
            {
                "Kernel: ", "Unknown."
            },
            {
                "Uptime: ", "Unknown."
            },
            {
                "CPU: ", "Unknown."
            },
            {
                "GPU: ", "Unknown."
            }
            
        };

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--debug") debug = true;

            Debug.throwInfo("Getting OS...");
            info["OS: "] = KeyValueParser.parseLines(FileReader.getFileLines("/etc/os-release"), '=')["PRETTY_NAME"];
            
            Debug.throwInfo("Getting Kernel Version...");
            info["Kernel: "] = CommandRunner.runCommand("uname -r");
            
            Debug.throwInfo("Getting Uptime...");
            info["Uptime: "] = CommandRunner.runCommand("uptime -p");
            
            Debug.throwInfo("Getting CPU...");
            info["CPU: "] = KeyValueParser.parseLines(FileReader.getFileLines("/proc/cpuinfo"), ':')["model name\t"];

            //Console.WriteLine(CommandRunner.runCommand("uname -r"));
        }
        

    }
}