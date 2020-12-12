using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/12
    /// </summary>
    public class Day12
    {
        public class Ferry
        {
            private readonly List<string> instructions;
            public Direction Orientation;
            public (int x, int y) pos;
            private static readonly Dictionary<char, Action> actionMapping = new Dictionary<char, Action>()
            {
                { 'N', Action.north },
                { 'S', Action.south },
                { 'E', Action.east },
                { 'W', Action.west },
                { 'L', Action.left },
                { 'R', Action.right },
                { 'F', Action.forward },
            };

            public Ferry(string rawInstructions)
            {
                instructions = rawInstructions.Split(Environment.NewLine).ToList();
                Orientation = Direction.east;
                pos = (0, 0);
            }

            public int CalculateDistanceAfterManeuvers()
            {
                foreach (var inst in instructions)
                {
                    var action = actionMapping[inst[0]];
                    var value = Int32.Parse(inst.Substring(1));
                    ExecuteInstruction(action, value);
                }

                return CalculateManhattanDistance();
            }

            public void ExecuteInstruction(Action action, int value)
            {
                switch (action)
                {
                    case Action.north:
                        pos.y -= value;
                        break;
                    case Action.south:
                        pos.y += value;
                        break;
                    case Action.east:
                        pos.x += value;
                        break;
                    case Action.west:
                        pos.x -= value;
                        break;
                    case Action.left:
                        Orientation = (Direction)(((int)Orientation - value/90 + 4) % 4);
                        break;
                    case Action.right:
                        Orientation = (Direction)(((int)Orientation + value/90) % 4);
                        break;
                    case Action.forward:
                        ExecuteInstruction((Action)(int)Orientation, value);
                        break;
                    default:
                        break;
                }
            }

            public int CalculateManhattanDistance()
            {
                return (pos.x > 0 ? pos.x : -pos.x) + (pos.y > 0 ? pos.y : -pos.y);
            }

            public enum Action
            {
                north, east, south, west, left, right, forward
            }

            public enum Direction
            {
                north, east, south, west
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
                var f = new Ferry(input);
                return f.CalculateDistanceAfterManeuvers().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return input + "_Puzzle2";
        }
    }
}
