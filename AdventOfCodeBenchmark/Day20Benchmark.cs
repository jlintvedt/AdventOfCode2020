using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day20Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D20_Puzzle;
        }

        [Benchmark]
        public string D20_P1() => Day20.Puzzle1(input);

        [Benchmark]
        public string D20_P2() => Day20.Puzzle2(input);
    }
}
