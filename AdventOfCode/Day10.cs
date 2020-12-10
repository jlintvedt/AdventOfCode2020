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
            private List<Adapter> Adapters;

            public AdapterArray(string rawInput)
            {
                Adapters = new List<Adapter>();
                var jolts = Common.Common.ParseStringToIntArray(rawInput, Environment.NewLine).ToList();
                jolts.Sort();
                // Add outlet
                Adapters.Add(new Adapter(0));
                // Add adapters
                foreach (var jolt in jolts)
                {
                    Adapters.Add(new Adapter(jolt));
                }
                // Add Device
                Adapters.Add(new Adapter(jolts[jolts.Count - 1] + 3));
            }

            public int ChainAllAdapters()
            {
                var diffOne = 0;
                var diffThree = 0;
                var jolt = 0;

                foreach (var adapter in Adapters.Skip(1))
                {
                    var diff = adapter.Jolt - jolt;
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
                    jolt = adapter.Jolt;
                }

                return diffOne * diffThree;
            }

            public long FindPossibleAdapterArrangements()
            {
                // Make adapter tree
                for (int i = 0; i < Adapters.Count; i++)
                {
                    var adapter = Adapters[i];
                    for (int j = i+1; j < Adapters.Count; j++)
                    {
                        var next = Adapters[j];
                        if (next.Jolt - adapter.Jolt > 3)
                        {
                            break;
                        }
                        adapter.nextAdapters.Add(next);
                    }
                }

                return Adapters[0].FindBreanchPermutations();
            }

            public class Adapter
            {
                public int Jolt;
                public List<Adapter> nextAdapters;
                private long pathPossibilities = 0;

                public Adapter(int jolt)
                {
                    Jolt = jolt;
                    nextAdapters = new List<Adapter>();
                }

                public long FindBreanchPermutations()
                {
                    if (pathPossibilities > 0)
                    {
                        return pathPossibilities;
                    }
                    // Special case for leaf
                    if (nextAdapters.Count == 0)
                    {
                        pathPossibilities = 1;
                        return pathPossibilities;
                    }
                    // Normal case - Check nexts
                    foreach (var adapter in nextAdapters)
                    {
                        pathPossibilities += adapter.FindBreanchPermutations();
                    }
                    return pathPossibilities;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
                var aa = new AdapterArray(input);
                return aa.ChainAllAdapters().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var aa = new AdapterArray(input);
            return aa.FindPossibleAdapterArrangements().ToString();
        }
    }
}