using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/1
    /// </summary>
    public class Day01
    {
        public class ExpenseReport
        {
            private List<int> entries;

            public ExpenseReport(int[] ent)
            {
                entries = new List<int>();
                foreach (var e in ent)
                {
                    entries.Add(e);
                }
            }

            public int FindProductOfSum(int sumTotal)
            {
                foreach (var ent in entries)
                {
                    var rest = sumTotal - ent;
                    if (entries.Contains(rest))
                    {
                        return rest * ent;
                    }
                }
                throw new Exception($"Could not find 2 values that summed to {sumTotal}");
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var entries = Common.Common.ParseStringToIntArray(input, Environment.NewLine);
            var er = new ExpenseReport(entries);

            return er.FindProductOfSum(2020).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
