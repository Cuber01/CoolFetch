using System;
using System.Collections.Generic;

namespace CoolFetch
{
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
            }
        };

        public static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "--debug") debug = true;
            
            //Console.WriteLine(KeyValueParser.parseLines(FileReader.getFileLines("/etc/os-release")));
            Console.WriteLine(CommandRunner.runCommand("/usr/bin/echo","echo gamer"));
        }
        

    }
}