using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day01Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D01_Puzzle;
        }

        [Benchmark]
        public string D01_P1() => Day01.Puzzle1(input);

        [Benchmark]
        public string D01_P2() => Day01.Puzzle2(input);
    }
}
