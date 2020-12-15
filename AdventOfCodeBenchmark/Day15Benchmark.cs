using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day15Benchmark
    {
        string input;

        [Params(100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D15_Puzzle;
        }

        [Benchmark]
        public string D15_P1() => Day15.Puzzle1(input);

        [Benchmark]
        public string D15_P2() => Day15.Puzzle2(input);
    }
}
