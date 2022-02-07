using System;
using System.Linq;
using Moofetch.Generic;
using Moofetch.Fetch;

namespace Moofetch
{

    public static class Program
    {
        public const string VERSION = "PRE RELEASE";
        public static readonly Random random = new Random();

        public static bool debug = false;
        public static bool box = false;
        private static bool tips = true;


        public static void Main(string[] args)
        {
            if (args.Contains("--debug")) debug = true;
            if (args.Contains("--box")) box = true;
            
            if (args.Contains("--help"))
            {
                Debug.throwInfo("Printing help...");
                Help.run();

                return;
            }
         
            ConfigHandler.init();
            ConfigHandler.updateConfig();
            
            if (args.Contains("--nocowsay"))
            {
                Debug.throwInfo("Disabling cow say...");
                Tips.noCowSay();

                return;
            }
            
            if (args.Contains("--yescowsay"))
            {
                Debug.throwInfo("Enabling cow say...");
                Tips.yesCowSay();

                return;
            }

            if(args.Contains("--cpu"))
            {
                CPU.run();
                
                return;
            }

            if(args.Contains("--gpu"))
            {
                GPU.run();

                return;
            }


            runMain();

        }

        private static void runMain()
        {
            if (ConfigHandler.getValue("COW_SAY") == "NO")
            {
                tips = false;
            }

            if (tips)
            {
                Debug.throwInfo("Printing a tip...");
                Tips.printTip();
            }

            Debug.throwInfo("Running fetch...");
            Fetch.Main.run();
        }
        
        

    }
}