using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/10
    /// </summary>
    public class Day10
    {
        public class AdapterArray
        {
            private List<int> Adapters;

            public AdapterArray(string rawInput)
            {
                Adapters = Common.Common.ParseStringToIntArray(rawInput, Environment.NewLine).ToList();
                Adapters.Sort();
                // Add Device
                Adapters.Add(Adapters[Adapters.Count - 1] + 3);
            }

            public int ChainAdapters()
            {
                var diffOne = 0;
                var diffThree = 0;
                var jolt = 0;

                foreach (var adapter in Adapters)
                {
                    var diff = adapter - jolt;
                    if (diff == 1)
                    {
                        diffOne++;
                    }
                    else if (diff == 2) { }
                    else if (diff == 3)
                    {
                        diffThree++;
                    }
                    else
                    {
                        throw new ArgumentException("Invalid Jolt difference");
                    }
                    jolt = adapter;
                }

                return diffOne * diffThree;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
                var aa = new AdapterArray(input);
                return aa.ChainAdapters().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}