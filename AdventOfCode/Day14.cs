using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/14
    /// </summary>
    public class Day14
    {
        public class DockingProgram
        {
            public readonly Dictionary<long, long> Memory;
            private readonly string[] instructions;
            private readonly BitMask Mask;
            private readonly bool useVersion2;

            public DockingProgram(string rawInput, bool useBitMaskVersion2 =false)
            {
                Memory = new Dictionary<long, long>();
                instructions = rawInput.Split(Environment.NewLine);
                Mask = new BitMask();
                useVersion2 = useBitMaskVersion2;
            }

            public long CalculateProgramSum()
            {
                foreach (var inst in instructions)
                {
                    ExecuteRawInstruction(inst);
                }

                return Memory.Values.Sum();
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
                    if (!useVersion2)
                    {
                        ExecuteWriteToMemory(memAdr, intValue);
                    } 
                    else
                    {
                        ExecuteWriteToMemoryVersion2(memAdr, intValue);
                    }
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

            private void ExecuteWriteToMemoryVersion2(uint address, uint value)
            {
                var addresses = Mask.MaskVersion2(address);
                foreach (var addr in addresses)
                {
                    Memory[addr] = value;
                }
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
                        bits[i] = (bitString[i]) switch
                        {
                            '0' => false,
                            '1' => true,
                            'X' => null,
                            _ => throw new ArgumentException(),
                        };
                    }
                }

                public long Mask (uint input)
                {
                    var binary = Convert.ToString(input, 2);
                    binary = binary.PadLeft(36, '0');
                    long value = 0;
                    long bitValue = 1;
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

                public List<long> MaskVersion2(uint input)
                {
                    var binary = Convert.ToString(input, 2);
                    binary = binary.PadLeft(36, '0');
                    List<long> values = new List<long>();
                    long bitValue = 2;
                    
                    // LSB seed
                    if (bits[35] != null)
                    {
                        values.Add(((bool)bits[35] ? 1 : (binary[35] == '1' ? 1 : 0)));
                    } 
                    else
                    {
                        values.Add(0);
                        values.Add(1);
                    }
                    var valuesLength = values.Count;

                    // Step through the remaining bits
                    for (int i = 34; i >= 0; i--)
                    {
                        if (bits[i] != null)
                        {
                            // Non-floating, increase if set
                            if ((bool)bits[i] || binary[i]=='1')
                            {
                                for (int j = 0; j < valuesLength; j++)
                                {
                                    values[j] += bitValue;
                                }
                            }
                        }
                        else
                        {
                            // Floating bit
                            for (int j = 0; j < valuesLength; j++)
                            {
                                values.Add(values[j] + bitValue);
                            }
                            valuesLength *= 2;
                        }

                        bitValue *= 2;
                    }

                    return values;
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
            var dp = new DockingProgram(input, useBitMaskVersion2:true);
            return dp.CalculateProgramSum().ToString();
        }
    }
}
