using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Loggers;
using BenchmarkDotNet.Exporters;
using BenchmarkDotNet.Columns;
using BenchmarkDotNet.Running;

namespace AdventOfCodeBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = ManualConfig.CreateEmpty()
                .AddColumnProvider(DefaultColumnProviders.Instance)
                .AddLogger(ConsoleLogger.Default)
                .AddExporter(MarkdownExporter.GitHub);

            //var summary = BenchmarkRunner.Run<Day03Benchmark>(config);

            var resultHandler = new ResultHandler();
            //resultHandler.UpdateBenchmark(summary, writeToFile: true);
            //resultHandler.UpdateResultsInReadme();
        }
    }
}
