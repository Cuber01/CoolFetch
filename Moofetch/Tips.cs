using System;
using System.Collections.Generic;
using Moofetch.Generic;

namespace Moofetch
{
    public static class Tips
    {
        
        public static void printTip()
        {
            Console.Write("\n");
            Console.WriteLine("Cow says: " + tips[Program.random.Next(tips.Count)]);
        }

        public static void noCowSay()
        {
            ConfigHandler.setValue("COW_SAY", "NO");
            Console.WriteLine("Done. You shmuck.");
        }

        public static void yesCowSay()
        {
            ConfigHandler.setValue("COW_SAY", "YES");
            Console.WriteLine("Done. Your sins shall be forgiven, for now.");
        }

        private static readonly List<string> tips = new List<string>()
        {
            "Moo",
            "Have you mooed today?",
            "Don't milk me.",
            "Moo Moo Motherf*cker.",
            "You puny humans will never understand my superiority.",
            "They don't understand, or perhaps the understand too well.",
            "Hello Sir, could you spare a moment to talk about Open Source?",
            "What you're referring to as Linux, is in fact, GMOO/Limoox.",
            "This grass isn't even green!",
            "Which one is your favourite: A, B or C?",
            "My words of advice are always worth listening.",
            "Use --help when you're lost.",
            "Eat healthy foods. Like grass.",
            "Remember young programmers, USSR history books is the only database you need",
            "Hello, I am about to eat your flower and keck your asz.",
            "You can turn this dialog off with --nocowsay. But why would you?",
            "Do you happen to have apt? My colleague works there.",
            "My favorite utility program is cowsay. It lets me express myself.",
            "If you have any problems or suggestions, why don't you contact us at our link from --help?",
            "Impressive, very based.",
        };
    }
}