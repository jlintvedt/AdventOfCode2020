using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day07Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D07_Puzzle;
        }

        [Benchmark]
        public string D07_P1() => Day07.Puzzle1(input);

        [Benchmark]
        public string D07_P2() => Day07.Puzzle2(input);
    }
}
