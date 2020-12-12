using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    /// <summary>
    /// |     Method |      N |     Mean |    Error |   StdDev |
    /// |----------- |------- |---------:|---------:|---------:|
    /// |     D11_P1 | 100000 | 13.01 ms | 0.245 ms | 0.240 ms |
    /// | Alt_D11_P1 | 100000 | 22.13 ms | 0.288 ms | 0.269 ms |
    /// |     D11_P2 | 100000 | 30.15 ms | 0.215 ms | 0.201 ms |
    /// | Alt_D11_P2 | 100000 | 25.77 ms | 0.282 ms | 0.263 ms |
    /// </summary>
    public class Day11Benchmark
    {
        string input;

        [Params(10000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = AdventOfCodeTests.Resources.Input.D11_Puzzle;
        }

        [Benchmark]
        public string D11_P1() => Day11.Puzzle1(input);

        [Benchmark]
        public string Alt_D11_P1() => Day11New.Puzzle1(input);

        [Benchmark]
        public string D11_P2() => Day11.Puzzle2(input);

        [Benchmark]
        public string Alt_D11_P2() => Day11New.Puzzle2(input);
    }
}
