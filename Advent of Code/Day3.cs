using System;

namespace Advent_of_Code_2020
{
    public class Day3
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day3.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1(true, 3, 1);
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static int Part1(bool print, int right, int down)
        {
            var noOfTrees = 0;

            var rows = Input;

            var column = 0;

            for (var index = down; index < rows.Length; index += down)
            {
                var nextRow = rows[index];
                column += right;
                if (nextRow[column % nextRow.Length] == '#') noOfTrees++;
            }

            if (print) Utils.Print("You will encounter", $"{noOfTrees}", "trees", ConsoleColor.Green);

            return noOfTrees;
        }

        public static void Part2()
        {
            long a = Part1(false, 1, 1);
            long b = Part1(false, 3, 1);
            long c = Part1(false, 5, 1);
            long d = Part1(false, 7, 1);
            long e = Part1(false, 1, 2);
            var result = a * b * c * d * e;

            Utils.Print($"The number of trees on each slope multiplied together give", $"{result}", ConsoleColor.Green);
        }
    }
}
