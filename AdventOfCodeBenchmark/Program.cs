﻿using BenchmarkDotNet.Running;

namespace AdventOfCodeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Day17Benchmark>();
            //var summary = BenchmarkRunner.Run<CommonBenchmark>();
        }
    }
}
