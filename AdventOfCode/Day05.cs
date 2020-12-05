using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/5
    /// </summary>
    public class Day05
    {
        public class BoardingControl
        {
            private List<int> SeatIds;

            public BoardingControl(string[] rawPass)
            {
                SeatIds = new List<int>();
                foreach (var seat in rawPass)
                {
                    SeatIds.Add(new BoardingPass(seat).SeatId);
                }
                SeatIds.Sort();
            }

            public int FindAvailableSeat()
            {
                var min = SeatIds[0];
                var max = SeatIds[SeatIds.Count - 1];
                for (int i = min; i < max; i++)
                {
                    if (SeatIds[i]+2 == SeatIds[i+1])
                    {
                        return SeatIds[i] + 1;
                    }
                }
                throw new Exception("No available seat found");
            }
        }

        public class BoardingPass
        {
            public int Row, Column, SeatId;

            public BoardingPass(string bin)
            {
                // Find row
                int min = 0, max = 127;
                for (int i = 0; i < 6; i++)
                {
                    if (bin[i] == 'F')
                    {
                        max -= (max - min + 1) / 2;
                    } 
                    else
                    {
                        min += (max - min + 1) / 2;
                    }
                }
                Row = bin[6] == 'F' ? min : max;
                
                // Find column
                min = 0; 
                max = 7;
                for (int i = 7; i < 9; i++)
                {
                    if (bin[i] == 'L')
                    {
                        max -= (max - min + 1) / 2;
                    }
                    else
                    {
                        min += (max - min + 1) / 2;
                    }
                }
                Column = bin[9] == 'L' ? min : max;

                // Calculate seatId;
                SeatId = Row * 8 + Column;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var seats = input.Split(Environment.NewLine);
            int maxId = 0;
            foreach (var seat in seats)
            {
                var id = new BoardingPass(seat).SeatId;
                maxId = maxId > id ? maxId : id;
            }
            return maxId.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var bc = new BoardingControl(input.Split(Environment.NewLine));
            return bc.FindAvailableSeat().ToString();
        }
    }
}
