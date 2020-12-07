using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2020
{
    public class Day4
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day4.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static void Part1()
        {
            var keys = new List<string>();

            var noOfValidIDs = 0;

            foreach (var line in Input)
            {
                keys.AddRange(line.Split(" ").Select(keyValuePair => keyValuePair.Split(":")[0]));

                if (line != "" && line != Input[^1]) continue;

                if (keys.Contains("byr") &&
                    keys.Contains("iyr") &&
                    keys.Contains("eyr") &&
                    keys.Contains("hgt") &&
                    keys.Contains("hcl") &&
                    keys.Contains("ecl") &&
                    keys.Contains("pid"))
                {
                    noOfValidIDs++;
                }

                keys.Clear();
            }

            Utils.Print("There are", noOfValidIDs, "valid IDs", ConsoleColor.Green);
        }

        public static void Part2()
        {
            var keyValuePairs = new Dictionary<string, string>();

            var noOfValidIDs = 0;

            foreach (var line in Input)
            {
                if (line == "" || line == Input[^1])
                {
                    if (keyValuePairs.ContainsKey("byr") && keyValuePairs.ContainsKey("iyr") &&
                        keyValuePairs.ContainsKey("eyr") && keyValuePairs.ContainsKey("hgt") &&
                        keyValuePairs.ContainsKey("hcl") && keyValuePairs.ContainsKey("ecl") &&
                        keyValuePairs.ContainsKey("pid"))
                    {
                        if ((int.Parse(keyValuePairs["byr"]) <= 2002 && int.Parse(keyValuePairs["byr"]) >= 1920) &&
                            (int.Parse(keyValuePairs["iyr"]) <= 2020 && int.Parse(keyValuePairs["iyr"]) >= 2010) &&
                            (int.Parse(keyValuePairs["eyr"]) <= 2030 && int.Parse(keyValuePairs["eyr"]) >= 2020) &&
                            ((keyValuePairs["hgt"].Contains("in") &&
                              int.Parse(keyValuePairs["hgt"].Split("in")[0]) <= 76 &&
                              int.Parse(keyValuePairs["hgt"].Split("in")[0]) >= 59) ||
                             (keyValuePairs["hgt"].Contains("cm") &&
                              int.Parse(keyValuePairs["hgt"].Split("cm")[0]) <= 193 &&
                              int.Parse(keyValuePairs["hgt"].Split("cm")[0]) >= 150)) &&
                            (keyValuePairs["hcl"][0].Equals('#')) && (Regex.IsMatch(keyValuePairs["hcl"].Replace("#", ""), "[a-fA-F0-9]{6}")) &&
                            (keyValuePairs["ecl"] == "amb" || keyValuePairs["ecl"] == "blu" ||
                             keyValuePairs["ecl"] == "brn" || keyValuePairs["ecl"] == "gry" ||
                             keyValuePairs["ecl"] == "grn" || keyValuePairs["ecl"] == "hzl" ||
                             keyValuePairs["ecl"] == "oth") &&
                            (Regex.IsMatch(keyValuePairs["pid"], "[0-9]{9}"))
                        )
                        {
                            noOfValidIDs++;
                        }
                    }

                    keyValuePairs.Clear();
                }
                else
                {
                    foreach (var keyValuePair in line.Split(" "))
                    {
                        keyValuePairs.Add(keyValuePair.Split(":")[0], keyValuePair.Split(":")[1]);
                    }
                }
            }

            Utils.Print("There are", noOfValidIDs, "valid IDs", ConsoleColor.Green);
        }
    }
}
