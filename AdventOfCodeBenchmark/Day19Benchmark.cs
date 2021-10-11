using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day19Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D19_Puzzle;
        }

        [Benchmark]
        public string D19_P1() => Day19.Puzzle1(input);

        [Benchmark]
        public string D19_P2() => Day19.Puzzle2(input);
    }
}
