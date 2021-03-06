﻿using System;

namespace AdventOfCode
{
    /// <summary>
    /// Template class
    /// https://adventofcode.com/2020/day/3
    /// </summary>
    public class Day03
    {
        public class TobogganSlope
        {
            private readonly bool[,] SlopeTrees;
            private readonly int SlopeWidth, SlopeHeight;

            public TobogganSlope(string inputMap)
            {
                var rows = inputMap.Split(Environment.NewLine);
                SlopeWidth = rows[0].Length;
                SlopeHeight = rows.Length;
                SlopeTrees = new bool[SlopeHeight, SlopeWidth];

                // Parse slope
                for (int y = 0; y < SlopeHeight; y++)
                {
                    for (int x = 0; x < SlopeWidth; x++)
                    {
                        if (rows[y][x] == '#')
                        {
                            SlopeTrees[y, x] = true;
                        }
                    }
                }
                return;
            }

            public long TreesHitOnRide(int xMove, int yMove)
            {
                int x = 0, y = 0;
                long treesHit = 0;

                while (y < SlopeHeight)
                {
                    // Check collision
                    if (SlopeTrees[y,x])
                    {
                        treesHit++;
                    }
                    // Move Toboggan
                    x = (x + xMove) % SlopeWidth;
                    y += yMove;
                }

                return treesHit;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ts = new TobogganSlope(input);
            return ts.TreesHitOnRide(3, 1).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ts = new TobogganSlope(input);

            var treesHit = ts.TreesHitOnRide(1, 1);
            treesHit *= ts.TreesHitOnRide(3, 1);
            treesHit *= ts.TreesHitOnRide(5, 1);
            treesHit *= ts.TreesHitOnRide(7, 1);
            treesHit *= ts.TreesHitOnRide(1, 2);

            return treesHit.ToString();
        }
    }
}
