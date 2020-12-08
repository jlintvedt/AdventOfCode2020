using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Schema;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/8
    /// </summary>
    public class Day08
    {
        public class GameConsole
        {
            private List<string> instructions;
            private HashSet<int> visitedInstructions;
            private int pointer = 0;
            private int accumulator = 0;

            public GameConsole(string rawInstructions)
            {
                instructions = rawInstructions.Split(Environment.NewLine).ToList();
                visitedInstructions = new HashSet<int>();
            }

            public int DetectLoop()
            {
                while (!visitedInstructions.Contains(pointer))
                {
                    visitedInstructions.Add(pointer);
                    ExecuteInstruction();
                }
                return accumulator;
            }

            private void ExecuteInstruction()
            {
                var parts = instructions[pointer].Split(' ');
                var op = parts[0];
                var arg = Int32.Parse(parts[1]);

                switch (op)
                {
                    case "acc":
                        accumulator += arg;
                        pointer++;
                        break;
                    case "jmp":
                        pointer += arg;
                        break;
                    case "nop":
                        pointer++;
                        break;
                    default:
                        throw new Exception($"Invalic operation [{op}]");
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var gc = new GameConsole(input);
            return gc.DetectLoop().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
