using System;

namespace CoolFetch
{
    public static class Help
    {
        public static void run()
        {
            Console.WriteLine("Usage: moofetch <optional flags>");
            Console.Write("\n");
            Console.WriteLine("Moofetch is a small CLI tool written in C#.");
            Console.WriteLine("It's purpose is to get a limited amount of information about your system and hardware in one place.");
            Console.Write("\n");
            Console.WriteLine("Flags:");
            Console.WriteLine("    --help       Display this help message");
            Console.WriteLine("    --debug      Print debug information");
            Console.WriteLine("    --box        Display fetch message in a box");
        }
    }
}