using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/11
    /// </summary>
    public class Day11
    {
        public class SeatingSystem
        {
            public State[,] seats;
            public State[,] tmpSeats;
            private int height, width;
            private static (int, int)[] adjecent = new (int, int)[] {
                (-1,-1), (-1,0), (-1,+1),
                (0, -1),          (0,+1),
                (+1,-1), (+1,0), (+1,+1)
            };

            public SeatingSystem(string rawInput)
            {
                var rows = rawInput.Split(Environment.NewLine);
                // Add 2 to both dimensions for sorrounding floor
                height = rows.Length+2;
                width = rows[0].Length+2;
                seats = new State[height, width];
                tmpSeats = new State[height,width];
                for (int row = 0; row < height-2; row++)
                {
                    for (int col = 0; col < width-2; col++)
                    {
                        if (rows[row][col] == 'L')
                        {
                            seats[row+1, col+1] = State.empty;
                            tmpSeats[row + 1, col + 1] = State.empty;
                        }
                    }
                }
            }

            public int SteabilizeSeating()
            {
                var rounds = 0;
                do {
                    rounds++;
                } while (UpdateSeatingMap(1));

                return CountOccupiedSeats();
            }

            public int SteabilizeSeatingBySight()
            {
                var rounds = 0;
                do
                {
                    rounds++;
                } while (UpdateSeatingMap(1, maxOccupied:5, sightRules:true));

                return CountOccupiedSeats();
            }

            private bool UpdateSeatingMap(int skipLayers, int maxOccupied = 4, bool sightRules = false)
            {
                var hasChanged = false;
                // Update temporary seat map
                for (int row = skipLayers; row < height-skipLayers; row++)
                {
                    for (int col = skipLayers; col < width-skipLayers; col++)
                    {
                        if (seats[row,col] == State.floor) { continue; }
                        var state = seats[row, col];
                        var occupied = sightRules ? CountNeighboursInSight(row, col) : CountNeighbours(row, col);
                        if (state == State.empty)
                        {
                            tmpSeats[row, col] = occupied == 0 ? State.occupied : State.empty;
                        } 
                        else if (state == State.occupied)
                        {
                            tmpSeats[row, col] = occupied >= maxOccupied ? State.empty : State.occupied;
                        }
                        // Check for change
                        if (!hasChanged && seats[row,col] != tmpSeats[row,col])
                        {
                            hasChanged = true;
                        }
                    }
                }
                // Switch active seat map
                var tmp = seats;
                seats = tmpSeats;
                tmpSeats = tmp;

                return hasChanged;
            }

            private int CountOccupiedSeats()
            {
                var count = 0;
                for (int row = 1; row < height-1; row++)
                {
                    for (int col = 1; col < width-1; col++)
                    {
                        if(seats[row, col] == State.occupied)
                        {
                            count++;
                        }
                    }
                }
                return count;
            }

            private int CountNeighbours(int row, int col)
            {
                var neighbours = 0;
                foreach (var (r, c) in adjecent)
                {
                    if (seats[row+r, col+c] == State.occupied)
                    {
                        neighbours++;
                    }
                }
                return neighbours;
            }

            private int CountNeighboursInSight(int row, int col)
            {
                var neighbours = 0;
                int r = 0, c = 0;
                int dist;
                foreach (var (rowV, colV) in adjecent)
                {
                    var state = State.floor;
                    dist = 0;
                    while (state == State.floor)
                    {
                        dist++;
                        r = row + rowV * dist;
                        c = col + colV * dist;
                        if (r < 0 || r >= height || c < 0 || c >= width)
                        {
                            break;
                        }
                        state = seats[r, c];
                    }

                    if (state == State.occupied)
                    {
                        neighbours++;
                    }
                }
                return neighbours;
            }

            public enum State
            {
                floor,
                empty,
                occupied,
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ss = new SeatingSystem(input);
            return ss.SteabilizeSeating().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ss = new SeatingSystem(input);
            return ss.SteabilizeSeatingBySight().ToString();
        }
    }
}
