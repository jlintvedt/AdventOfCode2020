using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day04Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D04_Puzzle;
        }

        [Benchmark]
        public string D04_P1() => Day04.Puzzle1(input);

        [Benchmark]
        public string D04_P2() => Day04.Puzzle2(input);
    }
}
