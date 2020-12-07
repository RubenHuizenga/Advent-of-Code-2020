using System;

namespace Advent_of_Code_2020
{
    public class Day1
    {
        private static readonly int[] Input = Array.ConvertAll(System.IO.File.ReadAllLines(@"..\..\..\Input\Day1.txt"), int.Parse);

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        private static void Part1()
        {
            for (var index1 = 0; index1 < Input.Length; index1++)
            {
                var entry1 = Input[index1];
                for (var index2 = index1 + 1; index2 < Input.Length; index2++)
                {
                    var entry2 = Input[index2];
                    if (entry1 + entry2 == 2020) Utils.Print($"{entry1} * {entry2} =", entry1 * entry2, ConsoleColor.Green);
                }
            }
        }

        private static void Part2()
        {
            for (var index1 = 0; index1 < Input.Length; index1++)
            {
                var entry1 = Input[index1];
                for (var index2 = index1 + 1; index2 < Input.Length; index2++)
                {
                    var entry2 = Input[index2];
                    for (var index3 = index2 + 1; index3 < Input.Length; index3++)
                    {
                        var entry3 = Input[index3];
                        if (entry1 + entry2 + entry3 == 2020) Utils.Print($"{entry1} * {entry2} * {entry3} =", 
                            entry1 * entry2 * entry3, ConsoleColor.Green);
                    }
                }
            }
        }
    }
}
