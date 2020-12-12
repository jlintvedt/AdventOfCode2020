using System;
using System.Collections.Generic;
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
            public (int x, int y) pos = (0, 0);
            public (int x, int y) waypoint = (10, -1);
            private readonly bool waypointMode;
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

            public Ferry(string rawInstructions, bool waypointMode = false)
            {
                instructions = rawInstructions.Split(Environment.NewLine).ToList();
                Orientation = Direction.east;
                this.waypointMode = waypointMode;
            }

            public int CalculateDistanceAfterManeuvers()
            {
                foreach (var inst in instructions)
                {
                    ExecuteRawInstruction(inst);
                }

                return CalculateManhattanDistance();
            }

            public static void ParseInstruction(string inst, out Action action, out int value)
            {
                action = actionMapping[inst[0]];
                value = Int32.Parse(inst.Substring(1));
            }

            public void ExecuteRawInstruction(string instruction)
            {
                var action = actionMapping[instruction[0]];
                var value = Int32.Parse(instruction.Substring(1));
                if (waypointMode)
                {
                    ExecuteInstructionWaypointMode(action, value);
                } 
                else
                {
                    ExecuteInstruction(action, value);
                }
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

            public void ExecuteInstructionWaypointMode(Action action, int value)
            {
                switch (action)
                {
                    case Action.north:
                        waypoint.y -= value;
                        break;
                    case Action.south:
                        waypoint.y += value;
                        break;
                    case Action.east:
                        waypoint.x += value;
                        break;
                    case Action.west:
                        waypoint.x -= value;
                        break;
                    case Action.left:
                        RotateWaypoint(-value);
                        break;
                    case Action.right:
                        RotateWaypoint(value);
                        break;
                    case Action.forward:
                        pos.x += waypoint.x * value;
                        pos.y += waypoint.y * value;
                        break;
                    default:
                        break;
                }
            }

            private void RotateWaypoint(int degreesCW)
            {
                degreesCW = degreesCW < 0 ? degreesCW + 360 : degreesCW;
                var numClockwise = degreesCW / 90;
                for (int i = 0; i < numClockwise; i++)
                {
                    var tmp = waypoint.x;
                    waypoint.x = -waypoint.y;
                    waypoint.y = tmp;
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
            var f = new Ferry(input, waypointMode: true);
            return f.CalculateDistanceAfterManeuvers().ToString();
        }
    }
}
