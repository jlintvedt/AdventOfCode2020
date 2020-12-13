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
            public string[] RawIds;
            public List<int> BusIds;

            public ShuttleSearch(string rawInput)
            {
                var parts = rawInput.Split(Environment.NewLine);
                EarliestDeparture = Int32.Parse(parts[0]);
                RawIds = parts[1].Split(',');
                BusIds = new List<int>();
                foreach (var id in RawIds)
                {
                    if (int.TryParse(id, out int intId))
                    {
                        BusIds.Add(intId);
                    }
                }
            }

            public int FindEarliestBus()
            {
                var bestId = 0;
                var waitMinutes = int.MaxValue;

                foreach (var id in BusIds)
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

            public ulong FindPerfectDepartureOrderTimestamp()
            {
                var busInfo = new List<Bus>();
                for (int i = 0; i < RawIds.Length; i++)
                {
                    if (Int32.TryParse(RawIds[i], out int id))
                    {
                        busInfo.Add(new Bus((ulong)id, (ulong)i));
                    }
                }

                var time = busInfo[0].Id;
                ulong step = 1;
                foreach (var bus in busInfo)
                {
                    for (ulong i = time; ; i += step)
                    {
                        if ((i + bus.Offset) % bus.Id == 0)
                        {
                            time = i;
                            step *= bus.Id;
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
