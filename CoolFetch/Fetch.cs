using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CoolFetch.Generic;
using CoolFetch.Writing;

namespace CoolFetch
{
    public static class Fetch
    {
        
        
        private static readonly Dictionary<string, string> info = new Dictionary<string, string>()
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
        
        public static void run()
        {
            Debug.throwInfo("Getting OS...");
            info["OS: "] = KeyValueParser.parseLines(FileReader.getFileLines("/etc/os-release"), '=')["PRETTY_NAME"];
            
            Debug.throwInfo("Getting Kernel Version...");
            info["Kernel: "] = CommandRunner.runCommand("uname -r");
            
            Debug.throwInfo("Getting Uptime...");
            info["Uptime: "] = CommandRunner.runCommand("uptime -p");
            
            Debug.throwInfo("Getting CPU...");
            info["CPU: "] = KeyValueParser.parseLines(FileReader.getFileLines("/proc/cpuinfo"), ':')["model name\t"];
            
            Debug.throwInfo("Getting GPU...");
            info["GPU: "] = getGPU();

            Printer.printResult(info);
        }
        
        private static string getGPU()
        {
            string lspciOutput = CommandRunner.runCommand("lspci | grep -i --color 'vga\\|3d\\|2d'");
            Regex pattern = new Regex(@"\[(.*?)\]");
            Match match = pattern.Match(lspciOutput);

            return match.ToString().Trim(new char[]{'[', ']'});
        }

        
    }
}