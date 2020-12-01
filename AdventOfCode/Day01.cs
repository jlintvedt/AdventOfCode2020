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
            private readonly List<int> entries;

            public ExpenseReport(int[] ent)
            {
                entries = new List<int>();
                foreach (var e in ent)
                {
                    entries.Add(e);
                }
                entries.Sort();
            }

            public int FindProductOfSumTwoNumbers(int sumTotal)
            {
                foreach (var a in entries)
                {
                    var remainder = sumTotal - a;
                    if (entries.Contains(remainder))
                    {
                        return remainder * a;
                    }
                }
                throw new Exception($"Could not find 2 values that summed to {sumTotal}");
            }

            public int FindProductOfSumThreeNumbers(int sumTotal)
            {
                foreach (var a in entries)
                {
                    var r1 = sumTotal - a;
                    foreach (var b in entries)
                    {
                        var r2 = r1 - b;
                        if (entries.Contains(r2))
                        {
                            return a * b * r2;
                        }
                    }
                }
                throw new Exception($"Could not find 3 values that summed to {sumTotal}");
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var entries = Common.Common.ParseStringToIntArray(input, Environment.NewLine);
            var er = new ExpenseReport(entries);
            return er.FindProductOfSumTwoNumbers(2020).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var entries = Common.Common.ParseStringToIntArray(input, Environment.NewLine);
            var er = new ExpenseReport(entries);
            return er.FindProductOfSumThreeNumbers(2020).ToString();
        }
    }
}
