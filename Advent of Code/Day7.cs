using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Advent_of_Code_2020
{
    public class Day7
    {
        private static readonly string[] Input = System.IO.File.ReadAllLines(@"..\..\..\Input\Day7.txt");

        public static void Run()
        {
            Utils.Print("Part 1", ConsoleColor.Blue);
            Part1();
            Utils.Print("Part 2", ConsoleColor.Blue);
            Part2();
        }

        public static void Part1()
        {
            var rules = new Dictionary<string, List<string>>();
            var outerColors = new List<string>();

            foreach (var rule in Input)
            {
                var simpleRule = rule.Replace("bags", "").Replace("bag", "").Replace(".", "");
                simpleRule = Regex.Replace(simpleRule, @"[\d]", string.Empty);

                var simpleRuleParts = simpleRule.Split("contain");

                if (simpleRuleParts[1].Contains("no other")) continue;

                foreach (var bag in simpleRuleParts[1].Split(","))
                {
                    var containedBag = bag.Trim();
                    var containerBag = simpleRuleParts[0].Trim();


                    if (rules.ContainsKey(containedBag)) rules[containedBag].Add(containerBag);
                    else rules.Add(containedBag, new List<string> { containerBag });
                }
            }

            outerColors = GetOuterColors(rules, outerColors, "shiny gold");

            Utils.Print("The number of bags that can eventually contain at least one shiny gold bag, is", outerColors.Count, ConsoleColor.Green);
        }

        public static void Part2()
        {
            var rules = new Dictionary<string, List<string[]>>();
            var result = 0;

            foreach (var rule in Input)
            {
                var simpleRule = rule.Replace("bags", "").Replace("bag", "").Replace(".", "");
                
                var simpleRuleParts = simpleRule.Split("contain");

                if (simpleRuleParts[1].Contains("no other")) continue;

                foreach (var bag in simpleRuleParts[1].Split(","))
                {
                    var number = Regex.Match(bag, @"[\d]").Value;

                    var containedBag = Regex.Replace(bag, @"[\d]", string.Empty).Trim();
                    var containerBag = simpleRuleParts[0].Trim();

                    if (rules.ContainsKey(containerBag)) rules[containerBag].Add(new[] { containedBag, number });
                    else rules.Add(containerBag, new List<string[]> { new[] { containedBag, number } });
                }
            }

            result = GetInnerColors(rules, result, new[] { "shiny gold", "1" }, 1);

            Utils.Print("The number of bags that are required in your shiny gold bag, is", result, ConsoleColor.Green);
        }

        public static List<string> GetOuterColors(Dictionary<string, List<string>> rules, List<string> outerColors, string containedBag)
        {
            if (!rules.ContainsKey(containedBag)) return outerColors;
            foreach (var bag in rules[containedBag])
            {
                if (!outerColors.Contains(bag)) outerColors.Add(bag);
                outerColors = GetOuterColors(rules, outerColors, bag);
            }

            return outerColors;
        }

        public static int GetInnerColors(Dictionary<string, List<string[]>> rules, int result, string[] containerBag, int amtContainerBag)
        {
            if (!rules.ContainsKey(containerBag[0])) return result;
            foreach (var bag in rules[containerBag[0]])
            {
                result += int.Parse(bag[1]) * amtContainerBag;
                result = GetInnerColors(rules, result, bag, amtContainerBag * int.Parse(bag[1]));
            }

            return result;
        }
    }
}
