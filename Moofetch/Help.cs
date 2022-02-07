using System;

namespace Moofetch
{
    public static class Help
    {
        public static void run()
        {
            Console.WriteLine("Usage: moofetch <optional flags>");
            Console.Write("\n");
            Console.WriteLine("Page: https://github.com/Cuber01/Moofetch");
            Console.Write("\n");
            Console.Write(Writing.Formatting.Bold);
            Console.WriteLine("Moofetch Version " + Program.VERSION);
            Console.Write(Writing.Formatting.ResetEverything);
            Console.WriteLine("Moofetch is a small CLI tool written in C#.");
            Console.WriteLine("It's purpose is to get a limited amount of information about your system and hardware in one place.");
            Console.Write("\n");
            Console.WriteLine("Flags:");
            Console.WriteLine("    --help         Display this help message");
            Console.WriteLine("    --cpu          Display cpu information");
            Console.WriteLine("    --gpu          Display gpu information");
            Console.WriteLine("    --debug        Print debug information");
            Console.WriteLine("    --box          Display fetch message in a box");
            Console.WriteLine("    --nocowsay     Turn off Cow says messages. You monster.");
            Console.WriteLine("    --yescowsay    Turn on Cow says messages");
        }
    }
}