using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            private readonly List<Instruction> instructions;
            private readonly HashSet<int> visitedInstructions;
            private int pointer = 0;
            private int accumulator = 0;

            public GameConsole(string rawInstructions)
            {
                instructions = new List<Instruction>();
                foreach (var raw in rawInstructions.Split(Environment.NewLine))
                {
                    instructions.Add(new Instruction(raw));
                }
                visitedInstructions = new HashSet<int>();
            }

            public bool DetectLoop(out int acc)
            {
                // Clear state
                visitedInstructions.Clear();
                pointer = 0;
                accumulator = 0;

                // Run until loop detected, or program finishes
                while (!visitedInstructions.Contains(pointer))
                {
                    if (pointer >= instructions.Count)
                    {
                        // Program terminated
                        acc = accumulator;
                        return false;
                    }
                    visitedInstructions.Add(pointer);
                    ExecuteInstruction();
                }

                // Loop Detected
                acc = accumulator;
                return true;
            }

            public int TryHealProgram()
            {
                // Try changing jmp->nop
                for (int i = 0; i < instructions.Count; i++)
                {
                    var inst = instructions[i];
                    if (inst.Operation == Operation.jmp)
                    {
                        inst.Operation = Operation.nop;
                        if (!DetectLoop(out int acc))
                        {
                            return acc;
                        }
                        inst.Operation = Operation.jmp;
                    }
                }

                // Try changing nop->jmp
                for (int i = 0; i < instructions.Count; i++)
                {
                    var inst = instructions[i];
                    if (inst.Operation == Operation.nop)
                    {
                        inst.Operation = Operation.jmp;
                        if (!DetectLoop(out int acc))
                        {
                            return acc;
                        }
                        inst.Operation = Operation.nop;
                    }
                }

                throw new Exception("Could not heal broken program!");
            }

            private void ExecuteInstruction()
            {
                var inst = instructions[pointer];

                switch (inst.Operation)
                {
                    case Operation.acc:
                        accumulator += inst.Argument;
                        pointer++;
                        break;
                    case Operation.jmp:
                        pointer += inst.Argument;
                        break;
                    case Operation.nop:
                        pointer++;
                        break;
                    default:
                        break;
                }
            }

            public class Instruction
            {
                public Operation Operation;
                public int Argument;

                public Instruction(string input)
                {
                    var parts = input.Split(" ");
                    switch (parts[0])
                    {
                        case "acc": Operation = Operation.acc; break;
                        case "jmp": Operation = Operation.jmp; break;
                        case "nop": Operation = Operation.nop; break;
                        default: throw new Exception($"Invalic operation [{parts[0]}]");
                    }
                    Argument = Int32.Parse(parts[1]);
                }
            }

            public enum Operation
            {
                acc,
                jmp,
                nop
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var gc = new GameConsole(input);
            gc.DetectLoop(out int accumulator);
            return accumulator.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var gc = new GameConsole(input);
            var accumulator = gc.TryHealProgram();
            return accumulator.ToString();
        }
    }
}