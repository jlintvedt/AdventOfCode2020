using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/6
    /// </summary>
    public class Day06
    {
        public class CustomsDeclarationForm
        {
            private readonly HashSet<char> answers;

            public int NumYes => answers.Count;

            public CustomsDeclarationForm(string[] inputForms)
            {
                answers = new HashSet<char>();

                foreach (var individual in inputForms)
                {
                    foreach (var answer in individual)
                    {
                        answers.Add(answer);
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var groups = input.Split(string.Format("{0}{0}", Environment.NewLine));
            var yesSum = 0;
            foreach (var group in groups)
            {
                yesSum += (new CustomsDeclarationForm(group.Split(Environment.NewLine))).NumYes;
            }
            return yesSum.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
