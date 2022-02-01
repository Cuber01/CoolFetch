using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoolFetch
{

    public static class Program
    {
        public const string VERSION = "PRE RELEASE";
        public static Random random = new Random();

        public static bool debug = false;
        public static bool box = false;


        public static void Main(string[] args)
        {
            if (args.Contains("--debug")) debug = true;
            if (args.Contains("--box")) box = true;
            
            if (args.Contains("--help"))
            {
                Help.run();
            }
            else
            {
                Fetch.run();
            }
            
        }
        
        

    }
}