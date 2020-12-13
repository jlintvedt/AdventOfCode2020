using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/13
    /// </summary>
    public class Day13
    {
        public class ShuttleSearch
        {

            public int EarliestDeparture;
            public List<(long id, long offset)> Busses;

            public ShuttleSearch(string rawInput)
            {
                var parts = rawInput.Split(Environment.NewLine);
                EarliestDeparture = Int32.Parse(parts[0]);
                var rawIds = parts[1].Split(',');
                Busses = new List<(long id, long offset)>();
                
                for (int i = 0; i < rawIds.Length; i++)
                {
                    if (Int32.TryParse(rawIds[i], out int id))
                    {
                        Busses.Add((id, i));
                    }
                }
            }

            public long FindEarliestBus()
            {
                long bestId = 0;
                var waitMinutes = long.MaxValue;

                foreach (var (id, index) in Busses)
                {
                    var minutes = (EarliestDeparture / id + 1) * (id) - EarliestDeparture;
                    if (minutes < waitMinutes)
                    {
                        bestId = id;
                        waitMinutes = minutes;
                    }
                }

                return bestId * waitMinutes;
            }

            public long FindPerfectDepartureOrderTimestamp()
            {
                // Credit: https://www.reddit.com/r/adventofcode/comments/kc4njx/2020_day_13_solutions/gfncyoc/
                var time = Busses[0].id;
                long step = 1;
                foreach (var (id, index) in Busses)
                {
                    for (long i = time; ; i += step)
                    {
                        if ((i + index) % id == 0)
                        {
                            time = i;
                            step *= id;
                            break;
                        }
                    }
                }

                return time;
            }

            public class Bus
            {
                public ulong Id;
                public ulong Offset;

                public Bus(ulong id, ulong offset)
                {
                    Id = id;
                    Offset = offset;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var ss = new ShuttleSearch(input);
            return ss.FindEarliestBus().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var ss = new ShuttleSearch(input);
            return ss.FindPerfectDepartureOrderTimestamp().ToString();
        }
    }
}
