using System.IO;
using System.Runtime.InteropServices;
using System.Linq;
using Moofetch.Writing;
using System.Collections.Generic;
using Moofetch.Generic;
using System;


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

            string lshw = CommandRunner.runCommand("lshw -C video 2> /dev/null"); // Redirect stderr to null

            Debug.throwInfo("Deserialising lshw output...");

            string[] lshwCleaned = lshw.Split('\n').Skip(1).ToArray();

            Dictionary<string, string> lshwDeserialised = KeyValueParser.deserialise(lshwCleaned, ':'); 

            Debug.throwInfo("Assigning GPU info...");

            GPUInfo["Name: "] =             Main.getGPU();
            GPUInfo["Vendor: "] =           lshwDeserialised["       vendor"];
            GPUInfo["Clock: "] =            lshwDeserialised["       clock"];
            GPUInfo["Width: "] =            lshwDeserialised["       width"];

            Printer.printResult(GPUInfo);

        }
    }
}