using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/14
    /// </summary>
    public class Day14
    {
        public class DockingProgram
        {
            private string[] instructions;
            private readonly BitMask Mask;
            public readonly Dictionary<uint, ulong> Memory;

            public DockingProgram(string rawInput)
            {
                instructions = rawInput.Split(Environment.NewLine);
                Mask = new BitMask();
                Memory = new Dictionary<uint, ulong>();
            }

            public ulong CalculateProgramSum()
            {
                foreach (var inst in instructions)
                {
                    ExecuteRawInstruction(inst);
                }

                return SumEntireMemory();
            }

            private ulong SumEntireMemory()
            {
                ulong totalValue = 0;
                foreach (var value in Memory.Values)
                {
                    totalValue += value;
                }
                return totalValue;
            }

            public void ExecuteRawInstruction(string instruction)
            {
                var parts = instruction.Split(" = ");
                var type = parts[0];
                var value = parts[1];

                if (type == "mask")
                {
                    ExecuteSetMaskInstruction(value);
                }
                else
                {
                    var memAdr = UInt32.Parse(type[4..^1]);
                    var intValue = UInt32.Parse(value);
                    ExecuteWriteToMemory(memAdr, intValue);
                }
            }

            private void ExecuteSetMaskInstruction(string rawMask)
            {
                Mask.SetMask(rawMask);
            }

            private void ExecuteWriteToMemory(uint address, uint value)
            {
                var maskedValue = Mask.Mask(value);
                Memory[address] = maskedValue;
            }

            public class BitMask
            {
                private readonly bool?[] bits;

                public BitMask()
                {
                    bits = new bool?[36];
                }

                public void SetMask(string bitString)
                {
                    if (bitString.Length != 36)
                    {
                        throw new ArgumentException();
                    }

                    for (int i = 0; i < 36; i++)
                    {
                        switch (bitString[i])
                        {
                            case '0': bits[i] = false; break;
                            case '1': bits[i] = true; break;
                            case 'X': bits[i] = null; break;
                            default: throw new ArgumentException();
                        }
                    }
                }

                public ulong Mask (uint input)
                {
                    var binary = Convert.ToString(input, 2);
                    binary = binary.PadLeft(36, '0');
                    ulong value = 0;
                    ulong bitValue = 1;
                    for (int i = 35; i >= 0; i--)
                    {
                        bool isSet = false;
                        if (bits[i] != null)
                        {
                            isSet = (bool)bits[i];
                        }
                        else if (binary[i] == '1')
                        {
                            isSet = true;
                        }

                        if (isSet)
                        {
                            value += bitValue;
                        }
                        bitValue *= 2;
                    }

                    return value;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var dp = new DockingProgram(input);
            return dp.CalculateProgramSum().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
