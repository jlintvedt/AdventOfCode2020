using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day03Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D03_Puzzle;
        }

        [Benchmark]
        public string D03_P1() => Day03.Puzzle1(input);

        [Benchmark]
        public string D03_P2() => Day03.Puzzle2(input);
    }
}
