using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/16
    /// </summary>
    public class Day16
    {
        public class TicketTranslation
        {
            public List<TicketRule> Rules;
            public List<int[]> NearbyTickets;

            public TicketTranslation(string rawRules, string nearbyTickets)
            {
                // Parse rules
                Rules = new List<TicketRule>();
                foreach (var rawRule in rawRules.Split(Environment.NewLine))
                {
                    var parts = rawRule.Split(':');
                    var name = parts[0];
                    parts = parts[1].Split(new char[] { '-', ' ' });
                    var v1 = Int32.Parse(parts[1]);
                    var v2 = Int32.Parse(parts[2]);
                    var v3 = Int32.Parse(parts[4]);
                    var v4 = Int32.Parse(parts[5]);
                    Rules.Add(new TicketRule(name, (v1, v2), (v3, v4)));
                }

                // Parse other tickets
                nearbyTickets = nearbyTickets.Substring(17); // remove header line
                NearbyTickets = new List<int[]>();
                var rawNearby = Common.Common.ParseStringToJaggedIntArray(nearbyTickets, Environment.NewLine, ",");
                foreach (var numbers in rawNearby)
                {
                    NearbyTickets.Add(numbers);
                }
            }

            public int SolveDay1()
            {
                // Find numbers valid in any rule
                var maxValidNumber = Rules.Max(x => x.MaxValidNumber);
                var validNumbers = new bool[maxValidNumber+1];
                for (int i = 0; i < validNumbers.Length; i++)
                {
                    foreach (var rule in Rules)
                    {
                        if (rule.IsValid(i))
                        {
                            validNumbers[i] = true;
                            break;
                        }
                    }
                }

                // Check for invalid tickets
                var errorRate = 0;
                foreach (var ticket in NearbyTickets)
                {
                    foreach (var num in ticket)
                    {
                        if (num > maxValidNumber || !validNumbers[num])
                        {
                            errorRate += num;
                        }
                    }
                }

                return errorRate;
            }

            public class TicketRule
            {
                public string Name;
                private (int min, int max) rangeOne, rangeTwo;

                public TicketRule(string name, (int, int) rangeOne, (int, int) rangeTwo)
                {
                    Name = name;
                    this.rangeOne = rangeOne;
                    this.rangeTwo = rangeTwo;
                }

                public int MaxValidNumber => rangeTwo.max;

                public bool IsValid(int number)
                {
                    if (number < rangeOne.min 
                        || number > rangeTwo.max
                        || (number > rangeOne.max && number < rangeTwo.min))
                    {
                        return false;
                    }
                    return true;
                }

                
            }
        }
        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var sections = input.Split(string.Format("{0}{0}", Environment.NewLine));

            var solver = new TicketTranslation(sections[0], sections[2]);
            return solver.SolveDay1().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
