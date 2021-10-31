using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode.Common
{
    public static class Common
    {
        // == == == == == Parsing == == == == ==
        public static int[] ParseStringToIntArray(string input, string delim = null)
        {
            if (delim == null)
            {
                // No delim, split on each character
                return input.ToCharArray().Select(i => (int)Char.GetNumericValue(i)).ToArray();
            }
            return input.Split(new[] { delim }, StringSplitOptions.None).Select(i => Convert.ToInt32(i)).ToArray();
        }

        public static long[] ParseStringToLongArray(string input, string delim)
        {
            return input.Split(new[] { delim }, StringSplitOptions.None).Select(long.Parse).ToArray();
        }

        public static int[][] ParseStringToJaggedIntArray(string input, string rowDelim = null, string columnDelim = null)
        {
            var rawRows = input.Split(rowDelim);
            var output = new int[rawRows.Length][];

            for (int i = 0; i < rawRows.Length; i++)
            {
                output[i] = ParseStringToIntArray(rawRows[i], columnDelim);
            }

            return output;
        }

        public static string[][] ParseStringToJaggedStringArray(string input, string rowDelim = null, string columnDelim = null)
        {
            var rawRows = input.Split(rowDelim);
            var output = new string[rawRows.Length][];

            for (int i = 0; i < rawRows.Length; i++)
            {
                output[i] = rawRows[i].Split(new[] { columnDelim }, StringSplitOptions.None);
            }

            return output;
        }

        static Dictionary<char, int[]> HexCharacterToBinary = new Dictionary<char, int[]> {
            { '0', new int[]{0,0,0,0} },
            { '1', new int[]{0,0,0,1} },
            { '2', new int[]{0,0,1,0} },
            { '3', new int[]{0,0,1,1} },
            { '4', new int[]{0,1,0,0} },
            { '5', new int[]{0,1,0,1} },
            { '6', new int[]{0,1,1,0} },
            { '7', new int[]{0,1,1,1} },
            { '8', new int[]{1,0,0,0} },
            { '9', new int[]{1,0,0,1} },
            { 'a', new int[]{1,0,1,0} },
            { 'b', new int[]{1,0,1,1} },
            { 'c', new int[]{1,1,0,0} },
            { 'd', new int[]{1,1,0,1} },
            { 'e', new int[]{1,1,1,0} },
            { 'f', new int[]{1,1,1,1} }
        };

        public static int[] ConvertHexStringToBitArray(string hex)
        {
            var hexes = hex.ToCharArray();
            var bitArray = new int[hex.Length*4];
            int[] bits;

            for (int i = 0; i < hex.Length; i++)
            {
                if(HexCharacterToBinary.TryGetValue(hexes[i], out bits))
                {
                    Array.Copy(bits, 0, bitArray, i * 4, 4);
                }
                else
                {
                    throw new ArgumentException($"Invalid hex [{hex}]");
                }
            }

            return bitArray;
        }

        // == == == == == Conversion == == == == ==
        public static int[] IntToTokenizedArray(int i)
        {
            if (i < 100000 || i >= 1000000)
            {
                throw new ArgumentException($"Number must be in range [100'000 - 999'999], was [{i}]");
            }

            var a = new int[6];

            a[5] = i % 10;
            i -= a[5];
            a[4] = (i % 100) / 10;
            i -= a[4];
            a[3] = (i % 1000) / 100;
            i -= a[3];
            a[2] = (i % 10000) / 1000;
            i -= a[2];
            a[1] = (i % 100000) / 10000;
            i -= a[1];
            a[0] = (i % 1000000) / 100000;

            return a;
        }

        public static int IntArrayToInt(int[] a)
        {
            if (a.Length != 6)
            {
                throw new ArgumentException("Lengh of array must be 6");
            }

            int result = 0;

            result += a[0] * 100000;
            result += a[1] * 10000;
            result += a[2] * 1000;
            result += a[3] * 100;
            result += a[4] * 10;
            result += a[5];

            return result;
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            // Copy from: https://stackoverflow.com/a/10630026
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

        public static string TwoDimIntArrayToString(int[,] array)
        {
            var sb = new StringBuilder();
            foreach (var i in array)
            {
                sb.Append(i.ToString());
            }
            return sb.ToString();
        }

        // == == == == == Validation == == == == ==
        public static bool StringIsIntInRange(string input, int min, int max)
        {
            if (input == null)
            {
                return false;
            }

            try
            {
                int value = Int32.Parse(input);
                if (min > value || value > max)
                {
                    return false;
                }

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        // == == == == == Processing == == == == ==
        public static HashSet<int> SumOfHashsetContent(HashSet<int> setA, HashSet<int> setB)
        {
            var sum = new HashSet<int>();

            foreach (var a in setA)
            {
                foreach (var b in setB)
                {
                    sum.Add(a + b);
                }
            }

            return sum;
        }
    }
}
