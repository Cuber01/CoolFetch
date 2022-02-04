using System.Collections.Generic;
using Moofetch.Generic;


namespace Moofetch.Fetch
{
    public class GPU
    {
        private static readonly Dictionary<string, string> GPUInfo = new Dictionary<string, string>()
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
        
        public void getFullGPU()
        {
            Debug.throwInfo("Gathering GPU info from lsGPU...");

            Dictionary<string, string> lsGPU = KeyValueParser.deserialise(CommandRunner.runCommand("lsGPU").Split('\n'), ':'); 

            Debug.throwInfo("Assigning GPU info...");

            GPUInfo["Name: "] =             lsGPU["Model name"];
            GPUInfo["Vendor: "] =           lsGPU["Vendor ID"];
            GPUInfo["Architecture: "] =     lsGPU["Architecture"];
            GPUInfo["Op-modes: "] =         lsGPU["GPU op-mode(s)"];
            GPUInfo["Cores: "] =            lsGPU["GPU(s)"];
            GPUInfo["Threads per core: "] = lscpu["Thread(s) per core"];
        }
    }
}