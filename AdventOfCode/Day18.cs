using System;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/18
    /// </summary>
    public class Day18
    {
        public class OperationOrder
        {
            string[] Equation;
            int index;

            public long SolveLeftToRight(string input)
            {
                Equation = input.Split(' ');
                index = 0;
                var sum = GetNextValue();

                while (index < Equation.Length)
                {
                    sum = PerformNextOperation(sum);
                }

                return sum;
            }

            public long PerformNextOperation(long value)
            {
                var opIsAdd = NextOperationIsAdd();
                var next = GetNextValue();

                if (opIsAdd)
                {
                    value += next;
                }
                else
                {
                    value *= next;
                }

                return value;
            }

            public long GetNextValue()
            {
                var symbol = GetNextBlock();

                if (symbol == "(")
                {
                    var sum = GetNextValue();
                    while (!NextBlockIsEndParanthesis())
                    {
                        sum = PerformNextOperation(sum);
                    }
                    GetNextBlock(); // Need to skip past ')'
                    return sum;
                }

                return int.Parse(symbol);
            }

            public bool NextOperationIsAdd()
            {
                return GetNextBlock() == "+";
            }

            public string GetNextBlock()
            {
                return Equation[index++];
            }

            public bool NextBlockIsEndParanthesis()
            {
                return Equation[index] == ")";
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            input = input.Replace("(", "( ");
            input = input.Replace(")", " )");

            var oo = new OperationOrder();
            var expressions = input.Split(Environment.NewLine);

            long sum = 0;
            foreach (var exp in expressions)
            {
                sum += oo.SolveLeftToRight(exp);
            }

            return sum.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
