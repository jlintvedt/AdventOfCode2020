using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/9
    /// </summary>
    public class Day09
    {
        public class XmasCypher
        {
            private long[] numbers;
            private readonly int preambleLen;

            public XmasCypher(string rawInput, int preambleLength)
            {
                numbers = Common.Common.ParseStringToLongArray(rawInput, delim: Environment.NewLine);
                preambleLen = preambleLength;
            }

            public long FindFirstWeakness()
            {
                for (int i = preambleLen; i < numbers.Length; i++)
                {
                    if (!IsValid(i))
                    {
                        return numbers[i];
                    }
                }
                throw new Exception($"Could not find weakness");
            }

            private bool IsValid(int pos)
            {
                for (int i = pos-preambleLen; i < pos-1; i++)
                {
                    for (int j = i+1; j < pos; j++)
                    {
                        if (numbers[i]+numbers[j] == numbers[pos])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var xc = new XmasCypher(input, 25);
            return xc.FindFirstWeakness().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
