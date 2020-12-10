using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day10Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D10_Puzzle;
        }

        [Benchmark]
        public string D10_P1() => Day10.Puzzle1(input);

        [Benchmark]
        public string D10_P2() => Day10.Puzzle2(input);
    }
}
