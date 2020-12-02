using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day02Benchmark
    {
        string input;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D02_Puzzle;
        }

        [Benchmark]
        public string D02_P1() => Day02.Puzzle1(input);

        [Benchmark]
        public string D02_P2() => Day02.Puzzle2(input);
    }
}
