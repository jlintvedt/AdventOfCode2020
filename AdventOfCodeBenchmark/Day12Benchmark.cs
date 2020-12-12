using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day12Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D12_Puzzle;
        }

        [Benchmark]
        public string D12_P1() => Day12.Puzzle1(input);

        [Benchmark]
        public string D12_P2() => Day12.Puzzle2(input);
    }
}
