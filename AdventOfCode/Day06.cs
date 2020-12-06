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
            private readonly Dictionary<char, int> answers;
            private readonly int peopleInGroup = 0;

            public int NumYes => answers.Count;

            public int NumEveryoneYes { 
                get {
                    var everyoneYes = 0;
                    foreach (var yes in answers.Keys)
                    {
                        if (answers[yes] == peopleInGroup)
                        {
                            everyoneYes++;
                        }
                    }
                    return everyoneYes;
                } 
            }

            public CustomsDeclarationForm(string[] inputForms)
            {
                answers = new Dictionary<char, int>();

                foreach (var individual in inputForms)
                {
                    peopleInGroup++;
                    foreach (var answer in individual)
                    {
                        if (answers.ContainsKey(answer))
                        {
                            answers[answer]++;
                        } 
                        else
                        {
                            answers[answer] = 1;
                        }
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
            var groups = input.Split(string.Format("{0}{0}", Environment.NewLine));
            var yesSum = 0;
            foreach (var group in groups)
            {
                yesSum += (new CustomsDeclarationForm(group.Split(Environment.NewLine))).NumEveryoneYes;
            }
            return yesSum.ToString();
        }
    }
}
