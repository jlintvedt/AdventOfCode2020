using System;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/5
    /// </summary>
    public class Day05
    {
        public class BoardingPass
        {
            public int row, column, seatId;

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
                row = bin[6] == 'F' ? min : max;
                
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
                column = bin[9] == 'L' ? min : max;

                // Calculate seatId;
                seatId = row * 8 + column;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var seats = input.Split(Environment.NewLine);
            int maxId = 0;
            foreach (var seat in seats)
            {
                var id = new BoardingPass(seat).seatId;
                maxId = maxId > id ? maxId : id;
            }
            return maxId.ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
