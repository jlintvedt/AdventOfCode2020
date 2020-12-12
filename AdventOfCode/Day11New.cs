using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/11
    /// </summary>
    public class Day11New
    {
        public class SeatingSystem
        {
            private readonly Dictionary<(int, int), Seat> seats;
            private readonly int height, width;
            private readonly int maxNeighbours;
            private static readonly (int, int)[] directions = new (int, int)[] {
                (0, +1),    // Right
                (+1,-1),    // Down Left
                (+1, 0),    // Down
                (+1,+1)     // Down Right
            };

            public SeatingSystem(string rawInput, bool useSightRules=false)
            {
                seats = new Dictionary<(int, int), Seat>();

                var rows = rawInput.Split(Environment.NewLine);
                height = rows.Length;
                width = rows[0].Length;
                for (int row = 0; row < rows.Length; row++)
                {
                    for (int col = 0; col < rows[0].Length; col++)
                    {
                        if (rows[row][col] == 'L')
                        {
                            seats.Add((row, col), new Seat(row, col));
                        }
                    }
                }

                maxNeighbours = useSightRules ? 5 : 4;
                LinkSeats(bySight: useSightRules);
            }

            public int StabilizeSeating()
            {
                var rounds = 0;
                while (UpdateSeatingStatus()) { 
                    rounds++; }

                return CountOccupiedSeats();
            }

            private bool UpdateSeatingStatus()
            {
                var changed = false;
                foreach (var seat in seats.Values)
                {
                    changed |= seat.UpdateState(maxNeighbours);
                }
                return changed;
            }

            private int CountOccupiedSeats()
            {
                var count = 0;
                foreach (var seat in seats.Values)
                {
                    if (seat.GetCurrentState() == State.occupied)
                    {
                        count++;
                    }
                }
                return count;
            }

            private void LinkSeats(bool bySight = false)
            {
                for (int row = 0; row < height; row++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (!seats.ContainsKey((row,col)))
                        {
                            continue;
                        }
                        if (bySight)
                        {
                            LinkSeatBySight(row, col);
                        } 
                        else
                        {
                            LinkSeatByProximity(row, col);
                        }
                        
                    }
                }
            }

            private void LinkSeatByProximity(int row, int col)
            {
                var seat = seats[(row, col)];
                foreach (var (rowV, colV) in directions)
                {
                    if (seats.ContainsKey((row+rowV, col+colV)))
                    {
                        var other = seats[(row + rowV, col + colV)];
                        seat.AddNeighbour(other);
                        other.AddNeighbour(seat);
                    }
                }
            }

            private void LinkSeatBySight(int row, int col)
            {
                var seat = seats[(row, col)];
                Seat other;
                int r, c, dist;
                foreach (var (rowV, colV) in directions)
                {
                    other = null;
                    dist = 0;
                    do
                    {
                        dist++;
                        r = row + rowV * dist;
                        c = col + colV * dist;
                        if (r < 0 || r >= height || c < 0 || c >= width)
                        {
                            break;
                        }
                    } while (!seats.TryGetValue((r,c), out other));

                    if (other != null)
                    {
                        seat.AddNeighbour(other);
                        other.AddNeighbour(seat);
                    }
                }
            }

            public class Seat
            {
                public int Row, Column;
                private State StateA, StateB;
                private bool modeA = true;
                private List<Seat> neighbours;

                public Seat(int row, int column)
                {
                    Row = row;
                    Column = column;
                    StateA = StateB = State.empty;
                    neighbours = new List<Seat>();
                }

                public void AddNeighbour(Seat seat)
                {
                    neighbours.Add(seat);
                }

                public bool UpdateState(int maxNeigbours)
                {
                    var state = modeA ? StateA : StateB;
                    var newState = state;
                    if (state == State.empty)
                    {
                        if(!HasMinNumOccupiedNeighbours(1, modeA))
                        {
                            newState = State.occupied;
                        }
                    } 
                    else
                    {
                        if(HasMinNumOccupiedNeighbours(maxNeigbours, modeA))
                        {
                            newState = State.empty;
                        }
                    }
                    // Update state
                    if (modeA)
                    {
                        StateB = newState;
                        modeA = false;
                    } 
                    else
                    {
                        StateA = newState;
                        modeA = true;
                    }
                    return state != newState;
                }

                private bool HasMinNumOccupiedNeighbours(int num, bool isModeA)
                {
                    var occupied = 0;
                    foreach (var n in neighbours)
                    {
                        if (n.GetState(isModeA) == State.occupied)
                        {
                            if (++occupied >= num)
                            {
                                return true;
                            }
                        }
                    }
                    return false;
                }

                public State GetState(bool isModeA)
                {
                    return isModeA ? StateA : StateB;
                }

                public State GetCurrentState()
                {
                    return GetState(modeA);
                }

                public override string ToString()
                {
                    return string.Format("Seat [{0},{1}]:{2}", Row, Column, (GetCurrentState().ToString()));
                }
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
            return ss.StabilizeSeating().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ss = new SeatingSystem(input, useSightRules:true);
            return ss.StabilizeSeating().ToString();
        }
    }
}
