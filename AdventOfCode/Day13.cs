using System;
using System.Collections.Generic;
using System.Linq;

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
            public List<int> BusIds;

            public ShuttleSearch(string rawInput)
            {
                var parts = rawInput.Split(Environment.NewLine);
                EarliestDeparture = Int32.Parse(parts[0]);
                BusIds = new List<int>();
                foreach (var id in parts[1].Split(','))
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
                    var minutes = (EarliestDeparture / id+1)*(id) - EarliestDeparture;
                    if (minutes < waitMinutes)
                    {
                        bestId = id;
                        waitMinutes = minutes;
                    }
                }

                return bestId * waitMinutes;
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
            return input + "_Puzzle2";
        }
    }
}
