using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Moofetch.Generic;


namespace Moofetch.Fetch
{
    public static class GPU
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
                "Clock: ", ""
            },
            {
                "Width: ", ""
            }
            
        };
        
        public static void run()
        {
            Debug.throwInfo("Gathering GPU info from lshw...");

            string lshw = CommandRunner.runCommand("lshw -C video");

            Debug.throwInfo("Deserialising lshw output...");

            string[] lshwCleaned = lshw.Split('\n').Skip(1).ToArray();

            Dictionary<string, string> lshwDeserialised = KeyValueParser.deserialise(lshwCleaned, ':'); 

            Debug.throwInfo("Assigning GPU info...");

            GPUInfo["Name: "] =             Main.getGPU();
            GPUInfo["Vendor: "] =           lshwDeserialised["       vendor"];
            GPUInfo["Clock: "] =            lshwDeserialised["       clock"];
            GPUInfo["Width: "] =            lshwDeserialised["       width"];

        }
    }
}