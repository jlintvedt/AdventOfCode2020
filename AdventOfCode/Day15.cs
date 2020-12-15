using System;
using System.Collections.Generic;
using System.Globalization;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/15
    /// </summary>
    public class Day15
    {
        public class MemoryGame
        {
            private Number[] Numbers;
            private int turnNumber;
            private Number lastSpoken;

            public MemoryGame(string input)
            {
                Numbers = new Number[2020];

                turnNumber = 1;
                var inputNum = Common.Common.ParseStringToIntArray(input, ",");
                for (int i = 0; i < inputNum.Length; i++)
                {
                    lastSpoken = GetOrCreateNumber(inputNum[i], turnNumber++);
                }
            }

            public int FindSpokenNumberOnTurn(int targetTurn)
            {
                while (turnNumber <= targetTurn)
                {
                    ExecuteTurn();
                }
                return lastSpoken.Value;
            }

            private void ExecuteTurn()
            {
                var next = lastSpoken.GetMentionDifference();
                lastSpoken = GetOrCreateNumber(next, turnNumber);
                turnNumber++;
            }

            private Number GetOrCreateNumber(int num, int turn)
            {
                Number outNum;
                if (Numbers[num] != null)
                {
                    outNum = Numbers[num];
                    outNum.SetMention(turn);
                    return outNum;
                }
                outNum = new Number(num, turn);
                Numbers[num] = outNum;
                return outNum;
            }

            public class Number
            {
                public int Value;
                private int prev1, prev2;

                public Number(int value, int mentionTurn)
                {
                    Value = value;
                    prev1 = mentionTurn;
                    prev2 = 0;
                }

                public void SetMention(int turn)
                {
                    prev2 = prev1;
                    prev1 = turn;
                }

                public int GetMentionDifference()
                {
                    return prev2 == 0 ? 0 : prev1 - prev2;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var mg = new MemoryGame(input);
            return mg.FindSpokenNumberOnTurn(2020).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
