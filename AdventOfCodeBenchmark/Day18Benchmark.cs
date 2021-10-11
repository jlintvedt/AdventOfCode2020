using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day18Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D18_Puzzle;
        }

        [Benchmark]
        public string D18_P1() => Day18.Puzzle1(input);

        [Benchmark]
        public string D18_P2() => Day18.Puzzle2(input);
    }
}
