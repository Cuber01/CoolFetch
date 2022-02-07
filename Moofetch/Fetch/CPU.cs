using System.Runtime.InteropServices;
using System.Collections.Generic;
using Moofetch.Generic;
using Moofetch.Writing;


namespace Moofetch.Fetch
{
    public static class CPU
    {
        private static readonly Dictionary<string, string> CPUInfo = new Dictionary<string, string>()
        {
            
            {
                "Name: ", ""
            },
            {
                "Vendor: ", ""
            },
            {
                "Architecture: ", ""
            },
            {
                "Op-modes: ", ""
            },
            {
                "Cores: ", ""
            },
            {
                "Threads per core: ", ""
            }
            
        };
        
        public static void run()
        {
            Debug.throwInfo("Gathering CPU info from lscpu...");

            Dictionary<string, string> lscpu = KeyValueParser.deserialise(CommandRunner.runCommand("lscpu").Split('\n'), ':'); 

            Debug.throwInfo("Assigning CPU info...");

            CPUInfo["Name: "] =             lscpu["Model name"];
            CPUInfo["Vendor: "] =           lscpu["Vendor ID"];
            CPUInfo["Architecture: "] =     lscpu["Architecture"];
            CPUInfo["Op-modes: "] =         lscpu["CPU op-mode(s)"];
            CPUInfo["Cores: "] =            lscpu["CPU(s)"];
            CPUInfo["Threads per core: "] = lscpu["Thread(s) per core"];

            Printer.printResult(CPUInfo);
        }
    }
}