using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day16Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D16_Puzzle;
        }

        [Benchmark]
        public string D16_P1() => Day16.Puzzle1(input);

        // [Benchmark]
        // public string D16_P2() => Day16.Puzzle2(input);
    }
}
