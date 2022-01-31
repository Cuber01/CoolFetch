using System;

namespace CoolFetch
{
    public class Debug
    {
        public static void throwWarning(string message)
        {
            if (!Program.debug) return;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("WARNING: " + message);
            
            Console.ResetColor();
        }
        
        public static void throwInfo(string message)
        {
            if (!Program.debug) return;
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("INFO: " + message);
            
            Console.ResetColor();
        }
        
        public static void criticalError(string message)
        {
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("CRITICAL ERROR: " + message);
            
            Console.ResetColor();
            
            Console.WriteLine("Exiting...");
            Environment.Exit(1);
        }
    }
}