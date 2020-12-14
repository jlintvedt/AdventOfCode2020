using BenchmarkDotNet.Running;

namespace AdventOfCodeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Day14Benchmark>();
            //var summary = BenchmarkRunner.Run<CommonBenchmark>();
        }
    }
}
