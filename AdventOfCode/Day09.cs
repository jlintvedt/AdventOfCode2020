using System;

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

            public long FindEncryptionWeakness()
            {
                // Find weakness position
                int pos;
                for (pos = preambleLen; pos < numbers.Length; pos++)
                {
                    if (!IsValid(pos))
                    {
                        break;
                    }
                }

                // Find contigious set summing to weakness
                var range = (0, pos - 1);
                if (!FindContiguousSet(numbers[pos], ref range))
                {
                    range = (pos + 1, numbers.Length);
                    if (!FindContiguousSet(numbers[pos], ref range))
                    {
                        throw new Exception($"Could not find weakness");
                    }
                }

                var smallest = Int64.MaxValue;
                var largest = Int64.MinValue;

                for (int i = range.Item1; i < range.Item2; i++)
                {
                    smallest = numbers[i] < smallest ? numbers[i] : smallest;
                    largest = numbers[i] > largest ? numbers[i] : largest;
                }

                return smallest + largest;
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

            private bool FindContiguousSet(long sumTarget, ref (int,int) range)
            {
                var min = range.Item1;
                var max = range.Item2;

                for (int i = min; i < max-2; i++)
                {
                    var sum = numbers[i];
                    for (int j = i+1; j <= max; j++)
                    {
                        sum += numbers[j];
                        if (sum == sumTarget)
                        {
                            range.Item1 = i;
                            range.Item2 = j;
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
