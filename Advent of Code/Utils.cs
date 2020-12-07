using System;

namespace Advent_of_Code_2020
{
    public static class Utils
    {
        public static void Print(string preText, string coloredText, string postText, ConsoleColor resultColor)
        {
            if(preText != null) Console.Write(preText + " ");

            Console.ForegroundColor = resultColor;
            Console.Write(coloredText);
            Console.ForegroundColor = ConsoleColor.White;
            
            if(postText != null) Console.Write(" " + postText);
            
            Console.WriteLine();
        }

        public static void Print(string preText, string coloredText, ConsoleColor resultColor)
        {
            Print(preText, coloredText, null, resultColor);
        }

        public static void Print(string coloredText, ConsoleColor resultColor)
        {
            Print(null, coloredText, null, resultColor);
        }

        public static void Print(string preText, int coloredText, string postText, ConsoleColor resultColor)
        {
            Print(preText, coloredText.ToString(), postText, resultColor);
        }

        public static void Print(string preText, long coloredText, ConsoleColor resultColor)
        {
            Print(preText, coloredText.ToString(), null, resultColor);
        }

        public static void Print(string preText, int coloredText, ConsoleColor resultColor)
        {
            Print(preText, coloredText.ToString(), null, resultColor);
        }
    }
}
