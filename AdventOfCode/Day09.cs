using System;
using System.Linq;

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
            private readonly long[] numbers;
            private readonly int preambleLen;

            public XmasCypher(string rawInput, int preambleLength)
            {
                numbers = Common.Common.ParseStringToLongArray(rawInput, delim: Environment.NewLine);
                preambleLen = preambleLength;
            }

            public long FindFirstWeakness()
            {
                return numbers[FindWeaknessPosition()];
            }

            public long FindEncryptionWeakness()
            {
                // Find weakness position
                var pos = FindWeaknessPosition();
                var weakness = numbers[pos];

                // Find contigious set summing to weakness
                var range = (0, pos - 1);
                if (!FindContiguousSet(weakness, ref range))
                {
                    range = (pos + 1, numbers.Length - 1);
                    if (!FindContiguousSet(weakness, ref range))
                    {
                        throw new Exception($"Could not find weakness");
                    }
                }

                // Return sum of smallest and largest
                var set = numbers.Skip(range.Item1).Take(range.Item2 - range.Item1 + 1);
                return set.Min() + set.Max();
            }

            private int FindWeaknessPosition()
            {
                for (int i = preambleLen; i < numbers.Length; i++)
                {
                    if (!IsValid(i))
                    {
                        return i;
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

            private bool FindContiguousSet(long sumTarget, ref (int min, int max) range)
            {
                for (int i = range.min; i < range.max-2; i++)
                {
                    var sum = numbers[i];
                    for (int j = i+1; j <= range.max; j++)
                    {
                        sum += numbers[j];
                        if (sum == sumTarget)
                        {
                            range.min = i;
                            range.max = j;
                            return true;
                        }
                        if (sum > sumTarget)
                        {
                            break;
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
            var xc = new XmasCypher(input, 25);
            return xc.FindEncryptionWeakness().ToString();
        }
    }
}
