using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoolFetch
{
    
    public static class Program
    {
        public static bool debug = false;
        
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
            
            Debug.throwInfo("Getting GPU...");
            info["GPU: "] = getGPU();

            printResult();
        }

        private static string getGPU()
        {
            string lspciOutput = CommandRunner.runCommand("lspci | grep -i --color 'vga\\|3d\\|2d'");
            Regex pattern = new Regex(@"\[(.*?)\]");
            Match match = pattern.Match(lspciOutput);

            return match.ToString().Trim(new char[]{'[', ']'});
        }

        private static void printResult()
        {
            string cow =
@"\|/         (__)       
    `\------(oo)       
     ||     (__)       
     ||w--||     \|/   
\|/                    ";
            
            string[] cowLines = cow.Split('\n');

            Console.Write('\n');
            
            for (int i = 0; i < info.Count; i++)
            {
                // Print cow
                Console.Write(cowLines[i]);
                
                // Key
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(info.ElementAt(i).Key);
                
                // Value
                Console.ResetColor();
                Console.Write(info.ElementAt(i).Value.Trim(new char[]{'\n', '"'}) + "\n");
            }
            
        }
        

    }
}