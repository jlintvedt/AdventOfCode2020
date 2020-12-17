using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2020/day/17
    /// </summary>
    public class Day17
    {
        public class ConwayCubes
        {
            public HashSet<(int x, int y, int z)> ActiveCubes;
            private HashSet<(int x, int y, int z)> ActiveCubesTmp;
            private readonly Dictionary<(int x, int y, int z), int> Neightbours;
            private static readonly List<(int x, int y, int z)> Offsets = new List<(int, int, int)>()
            {
                (1, 1,  0), (1, 0,  0), (1, -1,  0), (0, -1,  0), (-1, -1,  0), (-1, 0,  0), (-1, 1,  0), (0, 1,  0),
                (1, 1,  1), (1, 0,  1), (1, -1,  1), (0, -1,  1), (-1, -1,  1), (-1, 0,  1), (-1, 1,  1), (0, 1,  1), (0, 0,  1),
                (1, 1, -1), (1, 0, -1), (1, -1, -1), (0, -1, -1), (-1, -1, -1), (-1, 0, -1), (-1, 1, -1), (0, 1, -1), (0, 0, -1)
            };

            public ConwayCubes(string initialGrid)
            {
                ActiveCubes = new HashSet<(int, int, int)>();
                ActiveCubesTmp = new HashSet<(int, int, int)>();
                Neightbours = new Dictionary<(int, int, int), int>();
                // Parse Grid
                var rows = initialGrid.Split(Environment.NewLine);
                for (int x = 0; x < rows.Length; x++)
                {
                    for (int y = 0; y < rows[x].Length; y++)
                    {
                        if (rows[x][y] == '#')
                        {
                            ActiveCubes.Add((x, y, 0));
                        }
                    }
                }
            }

            public int CalculateActiveCubesAfterNumCycles(int numCycles)
            {
                for (int i = 0; i < numCycles; i++)
                {
                    ExecuteCycle();
                }

                return ActiveCubes.Count;
            }

            private void ExecuteCycle()
            {
                Neightbours.Clear();
                foreach (var cube in ActiveCubes)
                {
                    TouchNeighbours(cube);
                }

                // Calculate new active grid
                ActiveCubesTmp.Clear();
                foreach (var (cube, count) in Neightbours)
                {
                    if (count == 2 && ActiveCubes.Contains(cube))
                    {
                        ActiveCubesTmp.Add(cube);
                    } 
                    else if (count == 3)
                    {
                        ActiveCubesTmp.Add(cube);
                    }
                }

                // Swap active sets
                var tmp = ActiveCubes;
                ActiveCubes = ActiveCubesTmp;
                ActiveCubesTmp = tmp;
            }

            private void TouchNeighbours((int x, int y, int z) cube)
            {
                foreach (var offset in Offsets)
                {
                    var pos = (cube.x + offset.x, cube.y + offset.y, cube.z + offset.z);
                    if (Neightbours.ContainsKey(pos))
                    {
                        Neightbours[pos]++;
                    } 
                    else
                    {
                        Neightbours[pos] = 1;
                    }
                }
            }
        }

        public class ConwayCubesFourDimensional
        {
            public HashSet<(int x, int y, int z, int w)> ActiveCubes;
            private HashSet<(int x, int y, int z, int w)> ActiveCubesTmp;
            private readonly Dictionary<(int x, int y, int z, int w), int> Neightbours;
            private static readonly List<(int x, int y, int z, int w)> Offsets = new List<(int, int, int, int)>()
            {
                (1, 1, 0, 0), (1, 0, 0, 0), (1, -1, 0, 0), (0, -1, 0, 0), (-1, -1, 0, 0), (-1, 0, 0, 0), (-1, 1, 0, 0), (0, 1, 0, 0), (0, 0, 1, 0), (1, 1, 1, 0), (1, 0, 1, 0), (1, -1, 1, 0), (0, -1, 1, 0), (-1, -1, 1, 0), (-1, 0, 1, 0), (-1, 1, 1, 0), (0, 1, 1, 0), (0, 0, -1, 0), (1, 1, -1, 0), (1, 0, -1, 0), (1, -1, -1, 0), (0, -1, -1, 0), (-1, -1, -1, 0), (-1, 0, -1, 0), (-1, 1, -1, 0), (0, 1, -1, 0),
                (0, 0, 0, 1), (1, 1, 0, 1), (1, 0, 0, 1), (1, -1, 0, 1), (0, -1, 0, 1), (-1, -1, 0, 1), (-1, 0, 0, 1), (-1, 1, 0, 1), (0, 1, 0, 1), (0, 0, 1, 1), (1, 1, 1, 1), (1, 0, 1, 1), (1, -1, 1, 1), (0, -1, 1, 1), (-1, -1, 1, 1), (-1, 0, 1, 1), (-1, 1, 1, 1), (0, 1, 1, 1), (0, 0, -1, 1), (1, 1, -1, 1), (1, 0, -1, 1), (1, -1, -1, 1), (0, -1, -1, 1), (-1, -1, -1, 1), (-1, 0, -1, 1), (-1, 1, -1, 1),
                (0, 1, -1, 1), (0, 0, 0, -1), (1, 1, 0, -1), (1, 0, 0, -1), (1, -1, 0, -1), (0, -1, 0, -1), (-1, -1, 0, -1), (-1, 0, 0, -1), (-1, 1, 0, -1), (0, 1, 0, -1), (0, 0, 1, -1), (1, 1, 1, -1), (1, 0, 1, -1), (1, -1, 1, -1), (0, -1, 1, -1), (-1, -1, 1, -1), (-1, 0, 1, -1), (-1, 1, 1, -1), (0, 1, 1, -1), (0, 0, -1, -1), (1, 1, -1, -1), (1, 0, -1, -1), (1, -1, -1, -1), (0, -1, -1, -1), (-1, -1, -1, -1), (-1, 0, -1, -1), (-1, 1, -1, -1), (0, 1, -1, -1)
            };

            public ConwayCubesFourDimensional(string initialGrid)
            {
                ActiveCubes = new HashSet<(int, int, int, int)>();
                ActiveCubesTmp = new HashSet<(int, int, int, int)>();
                Neightbours = new Dictionary<(int, int, int, int), int>();
                // Parse Grid
                var rows = initialGrid.Split(Environment.NewLine);
                for (int x = 0; x < rows.Length; x++)
                {
                    for (int y = 0; y < rows[x].Length; y++)
                    {
                        if (rows[x][y] == '#')
                        {
                            ActiveCubes.Add((x, y, 0, 0));
                        }
                    }
                }
            }

            public int CalculateActiveCubesAfterNumCycles(int numCycles)
            {
                for (int i = 0; i < numCycles; i++)
                {
                    ExecuteCycle();
                }

                return ActiveCubes.Count;
            }

            private void ExecuteCycle()
            {
                Neightbours.Clear();
                foreach (var cube in ActiveCubes)
                {
                    TouchNeighbours(cube);
                }

                // Calculate new active grid
                ActiveCubesTmp.Clear();
                foreach (var (cube, count) in Neightbours)
                {
                    if (count == 2 && ActiveCubes.Contains(cube))
                    {
                        ActiveCubesTmp.Add(cube);
                    }
                    else if (count == 3)
                    {
                        ActiveCubesTmp.Add(cube);
                    }
                }

                // Swap active sets
                var tmp = ActiveCubes;
                ActiveCubes = ActiveCubesTmp;
                ActiveCubesTmp = tmp;
            }

            private void TouchNeighbours((int x, int y, int z, int w) cube)
            {
                foreach (var offset in Offsets)
                {
                    var pos = (cube.x + offset.x, cube.y + offset.y, cube.z + offset.z, cube.w + offset.w);
                    if (Neightbours.ContainsKey(pos))
                    {
                        Neightbours[pos]++;
                    }
                    else
                    {
                        Neightbours[pos] = 1;
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var cc = new ConwayCubes(input);
            return cc.CalculateActiveCubesAfterNumCycles(6).ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var cc4d = new ConwayCubesFourDimensional(input);
            return cc4d.CalculateActiveCubesAfterNumCycles(6).ToString();
        }
    }
}
