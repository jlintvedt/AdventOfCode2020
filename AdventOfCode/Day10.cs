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
            private readonly List<Adapter> Adapters;

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
                var jolt = 0;
                var diffs = new int[4];

                foreach (var adapter in Adapters)
                {
                    diffs[adapter.Jolt - jolt]++;
                    jolt = adapter.Jolt;
                }

                return diffs[1]*diffs[3];
            }

            public long FindPossibleAdapterArrangements()
            {
                MakeAdapterTree();
                return Adapters[0].FindBranchPermutations();
            }

            private void MakeAdapterTree()
            {
                for (int i = 0; i < Adapters.Count; i++)
                {
                    var adapter = Adapters[i];
                    for (int j = i + 1; j < Adapters.Count; j++)
                    {
                        var next = Adapters[j];
                        if (next.Jolt - adapter.Jolt > 3)
                        {
                            break;
                        }
                        adapter.NextAdapters.Add(next);
                    }
                }
            }

            public class Adapter
            {
                public int Jolt;
                public List<Adapter> NextAdapters;
                private long pathPossibilities = 0;

                public Adapter(int jolt)
                {
                    Jolt = jolt;
                    NextAdapters = new List<Adapter>();
                }

                public long FindBranchPermutations()
                {
                    if (pathPossibilities == 0)
                    {
                        if (NextAdapters.Count == 0)
                        {
                            // Special case for leaf
                            pathPossibilities = 1;
                        } 
                        else
                        {
                            // Normal case - Check nexts
                            foreach (var adapter in NextAdapters)
                            {
                                pathPossibilities += adapter.FindBranchPermutations();
                            }
                        }
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