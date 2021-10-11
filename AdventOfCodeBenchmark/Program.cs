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
            var resultHandler = new ResultHandler();
            var config = ManualConfig.CreateEmpty()
                .AddColumnProvider(DefaultColumnProviders.Instance)
                .AddLogger(ConsoleLogger.Default)
                .AddExporter(MarkdownExporter.GitHub);

            var summary = BenchmarkRunner.Run<Day17Benchmark>(config);
            resultHandler.UpdateBenchmark(summary, writeToFile: true);

            resultHandler.UpdateResultsInReadme();
        }
    }
}
