using AdventOfCode;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    /// <summary>
    /// These are the benchmark for different ways to store entries in Day01 solution
    /// | Method |      N |      Mean |    Error |   StdDev |
    /// |------- |------- |----------:|---------:|---------:|
    /// | D01_P1 | 100000 |  15.27 us | 0.139 us | 0.123 us | List<int>
    /// | D01_P2 | 100000 | 683.96 us | 7.010 us | 6.558 us |
    /// | D01_P1 | 100000 |  19.62 us | 0.238 us | 0.223 us | SortedList<int,int>
    /// | D01_P2 | 100000 |  28.47 us | 0.351 us | 0.328 us |
    /// | D01_P1 | 100000 |  14.35 us | 0.148 us | 0.139 us | HashSet<int>
    /// | D01_P2 | 100000 | 266.03 us | 2.355 us | 2.202 us |
    /// 
    /// SortedList is the slowest on part 1, but much faster on part 2.
    /// Assume this random due to the order of my input favouring a sorted key-list, resulting in fewer operations.
    /// 
    /// Validating theory on using a simple List<int>, but using list.Sort() before executing
    /// | D01_P1 | 100000 |  11.54 us | 0.104 us | 0.097 us |
    /// | D01_P2 | 100000 |  26.21 us | 0.247 us | 0.219 us |
    /// Gives comparable P2 to SortedList, but gains some on P1. Making this the fastest solution.
    /// 
    /// Might be mostly lucky due to the my input placing the required entries at index (out of 200 total)
    /// - Puzzle1: [7, 9]
    /// - Puzzle2: [2, 4, 5]
    /// </summary>
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
