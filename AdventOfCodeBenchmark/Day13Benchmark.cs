using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day13Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D13_Puzzle;
        }

        [Benchmark]
        public string D13_P1() => Day13.Puzzle1(input);

        [Benchmark]
        public string D13_P2() => Day13.Puzzle2(input);
    }
}
