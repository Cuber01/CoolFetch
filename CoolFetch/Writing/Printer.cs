using System;
using System.Collections.Generic;
using System.Linq;

namespace CoolFetch.Writing
{
    public static class Printer
    {
        
        private const string cow =
@"\|/         (__)       
    `\------(oo)       
     ||     (__)       
     ||w--||     \|/   
\|/                    "; 
        
        private const string bulletPoint = "▶ ";
        private const int boxOffset = 2;

        private const char horizontalLine = '─';
        private const char verticalLine = '│';
        private const char leftUpCorner = '╭';
        private const char rightUpCorner = '╮'; 
        private const char leftDownCorner = '╰';
        private const char rightDownCorner = '╯';
        
        
        public static void printResult(Dictionary<string, string> info)
        {
            int boxWidth = 0;
            int spacesNeeded = 0;
            int lineLength = 0; 
            
            string[] cowLines = cow.Split('\n');

            if(Program.box) 
            {
                boxWidth = calculateBoxWidth(info, cowLines[0].Length, bulletPoint.Length);
                
                // Print ceiling
                printBoxHorizontalLine(boxWidth, leftUpCorner, rightUpCorner);
    
                // Print a |  | in an emopty line
                Console.Write("\n" + verticalLine + String.Concat(Enumerable.Repeat(" ", boxWidth+boxOffset-1)) + verticalLine);
            }
            
            Console.Write("\n");

            for (int i = 0; i < info.Count; i++)
            {
                string fancyKey = info.ElementAt(i).Key;
                string fancyValue = info.ElementAt(i).Value.Trim(new char[] { '\n', '"' });

                if(Program.box) 
                {
                    lineLength = boxOffset + cowLines[i].Length + bulletPoint.Length + fancyKey.Length + fancyValue.Length;
                    spacesNeeded = boxWidth + boxOffset - lineLength - 1;
                    
                    Console.Write(verticalLine + String.Concat(Enumerable.Repeat(" ", boxOffset)));  // Wall of box
                }
                
                Console.Write(Formatting.Bold);  
                Console.Write(cowLines[i]); // Cow
                
                Console.Write(Formatting.Bold);
                Console.Write(bulletPoint); // Bullet point
                
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(fancyKey); // Key
                
                Console.Write(Formatting.ResetEverything);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(fancyValue); // Value
                
                if(Program.box) 
                {
                    Console.Write(Formatting.ResetEverything);
                    Console.Write(String.Concat(Enumerable.Repeat(" ", spacesNeeded)));
                    Console.Write(verticalLine);
                }
                
                Console.Write('\n');
            }
            
            if(Program.box) 
            {
                Console.Write(Formatting.ResetEverything);
            
                // Print a | | in an emopty line
                Console.Write(verticalLine + String.Concat(Enumerable.Repeat(" ", boxWidth+boxOffset-1)) + verticalLine + "\n");
            
                // Print floor
                printBoxHorizontalLine(boxWidth, leftDownCorner, rightDownCorner);
            }
        }
        
        private static void printBoxHorizontalLine(int width, char leftCorner, char rightCorner)
        {
            width += boxOffset;
            
            Console.Write(leftCorner);

            for (int i = 0; i <= width - 2; i++)
            {
                Console.Write(horizontalLine);
            }
            
            Console.Write(rightCorner);
        }
        
        private static int calculateBoxWidth(Dictionary<string, string> info, int asciiArtLength, int bulletPointLength)
        {
            string longestVal = info.Values.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            string longestKey = info.Keys.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            
            return boxOffset + asciiArtLength + bulletPointLength + longestVal.Length + longestKey.Length - boxOffset;
        }

    }
}

        
// private const char horizontalLine = '━';
// private const char verticalLine = '┃';
// private const char leftUpCorner = '┏';
// private const char rightUpCorner = '┓';
// private const char leftDownCorner = '┗';
// private const char rightDownCorner = '┛';

// private const char horizontalLine = '─';
// private const char verticalLine = '│';
// private const char leftUpCorner = '┌';
// private const char rightUpCorner = '┐';
// private const char leftDownCorner = '└';
// private const char rightDownCorner = '┘';