using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day14Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D14_Puzzle;
        }

        [Benchmark]
        public string D14_P1() => Day14.Puzzle1(input);

        [Benchmark]
        public string D14_P2() => Day14.Puzzle2(input);
    }
}
