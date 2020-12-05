using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day05Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D05_Puzzle;
        }

        [Benchmark]
        public string D05_P1() => Day05.Puzzle1(input);

        [Benchmark]
        public string D05_P2() => Day05.Puzzle2(input);
    }
}
