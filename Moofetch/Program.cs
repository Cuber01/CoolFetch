using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Moofetch.Generic;

namespace Moofetch
{

    public static class Program
    {
        public const string VERSION = "PRE RELEASE";
        public static readonly Random random = new Random();

        public static bool debug = true;
        public static bool box = false;


        public static void Main(string[] args)
        {
            if (args.Contains("--debug")) debug = true;
            if (args.Contains("--box")) box = true;
            
            if (args.Contains("--help"))
            {
                Debug.throwInfo("Printing help...");
                Help.run();
            }
            else
            {
                ConfigHandler.init();
                Debug.throwInfo("Printing a tip...");
                Tips.printTip();
                Debug.throwInfo("Running fetch...");
                Fetch.run();
            }
            
        }
        
        

    }
}