using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2020
{
    public class Day6
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day6.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static void Part1()
        {
            var answers = new List<char>();
            var result = 0;

            foreach (var line in Input)
            {
                foreach (var character in line.Where(character => !answers.Contains(character)))
                {
                    answers.Add(character);
                }

                if (line != "" && line != Input[^1]) continue;

                result += answers.Count;
                answers.Clear();
            }

            Utils.Print("The number of questions to which anyone answered yes, is", $"{result}", ConsoleColor.Green);
        }

        public static void Part2()
        {
            var result = 0;
            var resultString = "abcdefghijklmnopqrstuvwxyz";
            var resultChanged = false;

            foreach (var line in Input)
            {
                if ((line == "" || line == Input[^1]) && resultChanged)
                {
                    result += resultString.Length;
                    resultString = "abcdefghijklmnopqrstuvwxyz";
                    resultChanged = false;
                }
                else
                {
                    resultString = string.Concat(resultString.Intersect(line));
                    resultChanged = true;
                }
            }

            Utils.Print("The number of questions to which everyone answered yes, is", $"{result}", ConsoleColor.Green);
        }
    }
}
