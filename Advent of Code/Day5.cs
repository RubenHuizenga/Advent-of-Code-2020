using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent_of_Code_2020
{
    public class Day5
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day5.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        private static void Part1()
        {
            var occupiedSeats = GetAllSeatIDs();

            Utils.Print("The biggest ID is", occupiedSeats.Max(), ConsoleColor.Green);
        }

        private static void Part2()
        {
            var occupiedSeats = GetAllSeatIDs();

            for (var seatID = occupiedSeats.Min(); seatID <= occupiedSeats.Max(); seatID++)
            {
                if(!occupiedSeats.Contains(seatID)) Utils.Print("Your seat has ID", seatID, ConsoleColor.Green);
            }
        }

        public static List<int> GetAllSeatIDs()
        {
            var allSeatIDs = new List<int>();

            foreach (var line in Input)
            {
                var rowUpper = 127;
                var columnUpper = 7;

                var rowLower = 0;
                var columnLower = 0;

                foreach (var character in line)
                {
                    switch (character)
                    {
                        case 'F':
                            rowUpper = (rowUpper + rowLower) / 2;
                            break;
                        case 'B':
                            rowLower = (rowUpper + rowLower) / 2;
                            break;
                        case 'L':
                            columnUpper = (columnUpper + columnLower) / 2;
                            break;
                        case 'R':
                            columnLower = (columnUpper + columnLower) / 2;
                            break;
                    }
                }

                allSeatIDs.Add(rowUpper * 8 + columnUpper);
            }

            return allSeatIDs;
        }
    }
}
