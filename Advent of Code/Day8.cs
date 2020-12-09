using System;
using System.Linq;

namespace Advent_of_Code_2020
{
    public class Day8
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day8.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static void Part1()
        {
            var values = Enumerable.Repeat(0, Input.Length).ToList();

            var index = 0;
            var accumulator = 0;

            while (true)
            {
                if (++values[index] > 1) break;

                (index, accumulator) = Input[index].Split(" ")[0] switch
                {
                    "acc" => (index + 1, accumulator + int.Parse(Input[index].Split(" ")[1])),
                    "jmp" => (index + int.Parse(Input[index].Split(" ")[1]), accumulator),
                    "nop" => (index + 1, accumulator),
                    _ => (index, accumulator)
                };
            }

            Utils.Print("The value of the accumulator before falling into loop, is", accumulator, ConsoleColor.Green);
        }

        public static void Part2()
        {
            var success = false;

            for (var i = 0; i < Input.Length; i++)
            {
                if (Input[i].Contains("acc")) continue;
               
                var values = Enumerable.Repeat(0, Input.Length).ToList();

                var index = 0;
                var accumulator = 0;

                while (true)
                {
                    if (index >= Input.Length) success = true;
                    if (index >= Input.Length || ++values[index] > 1) break;

                    (index, accumulator) = Input[index].Split(" ")[0] switch
                    {
                        "acc" => (index + 1, accumulator + int.Parse(Input[index].Split(" ")[1])),
                        "jmp" => (index + (index == i ? 1 : int.Parse(Input[index].Split(" ")[1])), accumulator),
                        "nop" => (index + (index == i ? int.Parse(Input[index].Split(" ")[1]) : 1), accumulator),
                        _ => (index, accumulator)
                    };
                }

                if (!success) continue;

                Utils.Print("The value of the accumulator after terminating, is", accumulator, ConsoleColor.Green);
                break;
            }
        }
    }
}
