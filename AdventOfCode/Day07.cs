using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/7
    /// </summary>
    public class Day07
    {
        public class BaggageProcessing
        {
            public Dictionary<string, BagType> Bags;

            public BaggageProcessing(string[] rules)
            {
                Bags = new Dictionary<string, BagType>();

                foreach (var rule in rules)
                {
                    var parts = rule.Split(" bags contain ");
                    var bag = GetOrCreateBag(parts[0]);
                    // Parse content
                    if (parts[1] == "no other bags.")
                    {
                        continue;
                    }
                    foreach (var c in parts[1].Split(", "))
                    {
                        // Only handles single digit
                        var num = Int32.Parse(c.Substring(0, 1));
                        // Extract name without ' bags' ending
                        var name = c.Substring(2).Split(" bag")[0];
                        var cBag = GetOrCreateBag(name);
                        // Link parent and child bag
                        bag.Contains.Add(cBag, num);
                        cBag.AppearIn.Add(bag);
                    }
                }
            }

            public int CalculateNumPossibleContainers(string name)
            {
                var visited = new HashSet<string>();
                var bag = Bags[name];

                var numVisited = RecursiveVisitParents(bag, visited) - 1;

                return numVisited;
            }

            public int RecursiveVisitParents(BagType bag, HashSet<string> visited)
            {
                var numVisited = 1;
                foreach (var parent in bag.AppearIn)
                {
                    if (visited.Contains(parent.Name))
                    {
                        continue;
                    }
                    numVisited += RecursiveVisitParents(parent, visited);
                    visited.Add(parent.Name);
                }
                return numVisited;
            }

            private BagType GetOrCreateBag(string name)
            {
                if (Bags.ContainsKey(name))
                {
                    return Bags[name];
                }
                var bag = new BagType(name);
                Bags.Add(name, bag);
                return bag;
            }
        }

        public class BagType
        {
            public string Name;
            public List<BagType> AppearIn;
            public Dictionary<BagType, int> Contains;

            public BagType(string name)
            {
                Name = name;
                AppearIn = new List<BagType>();
                Contains = new Dictionary<BagType, int>();
            }
        }


        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var bp = new BaggageProcessing(input.Split(Environment.NewLine));
            return bp.CalculateNumPossibleContainers("shiny gold").ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
