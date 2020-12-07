using System;
using System.Linq;

namespace Advent_of_Code_2020
{
    public class Day2
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day2.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static void Part1()
        {
            var correctPasswords = (
                from entry in Input
                select entry.Split(" ") into parts
                let lowerbound = int.Parse(parts[0].Split("-")[0])
                let upperbound = int.Parse(parts[0].Split("-")[1])
                let requiredChar = parts[1].ToCharArray()[0]
                let password = parts[2]
                let requiredCharCounter = password.Count(character => character == requiredChar)
                where requiredCharCounter <= upperbound && requiredCharCounter >= lowerbound
                select lowerbound).Count();

            Utils.Print("There are", correctPasswords, "correct passwords", ConsoleColor.Green);
        }

        private static void Part2()
        {
            var correctPasswords = (
                from entry in Input
                select entry.Split(" ") into parts
                let pos1 = int.Parse(parts[0].Split("-")[0])
                let pos2 = int.Parse(parts[0].Split("-")[1])
                let requiredChar = parts[1].ToCharArray()[0]
                let password = parts[2]
                where password[pos1 - 1] == requiredChar ^ password[pos2 - 1] == requiredChar
                select pos1).Count();

            Utils.Print("There are", correctPasswords, "correct passwords", ConsoleColor.Green);
        }
    }
}
