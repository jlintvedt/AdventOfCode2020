using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day17Benchmark
    {
        string input;

        [Params(10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D17_Puzzle;
        }

        [Benchmark]
        public string D17_P1() => Day17.Puzzle1(input);

        [Benchmark]
        public string D17_P2() => Day17.Puzzle2(input);
    }
}
