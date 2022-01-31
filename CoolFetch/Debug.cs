using System;

namespace CoolFetch
{
    public class Debug
    {
        public static void throwWarning(string message)
        {
            if (!Program.debug) return;
            
            Console.WriteLine("WARNING: " + message);
        }
        
        public static void throwInfo(string message)
        {
            if (!Program.debug) return;
            
            Console.WriteLine("INFO: " + message);
        }

        public static void throwError(string message)
        {
            if (!Program.debug) return;
            
            Console.WriteLine("ERROR: " + message);
        }
        
        public static void throwCriticalError(string message)
        {
            Console.WriteLine("CRITICAL ERROR: " + message);
            
            Console.WriteLine("Exiting...");
            Environment.Exit(1);
        }
    }
}