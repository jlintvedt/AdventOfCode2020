using System.Text.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Reports;
using System.Linq;

namespace AdventOfCodeBenchmark
{
    public class ResultHandler
    {
        string ResultFilename = "Results.json";
        string ReadmeFilename = "README.md";

        Results results;

        static List<string> symbols = new List<string>() { "ns", "μs", "ms", "s", "ks" };

        public ResultHandler()
        {
            var jsonString = File.ReadAllText(GetPath(ResultFilename));
            results = JsonSerializer.Deserialize<Results>(jsonString);
        }

        public void UpdateBenchmark(Summary summary, bool writeToFile = false)
        {
            if (summary.HasCriticalValidationErrors)
            {
                throw new Exception("Critical Error");
            }

            if (summary.BenchmarksCases.Length != 2)
            {
                throw new InvalidDataException("Only support parsing for exactly 2 bechmark cases");
            }

            var day = summary.BenchmarksCases.First().DisplayInfo.Substring(3, 2);

            var dailyResults = this.results.Days.Where(x => x.Day == day).FirstOrDefault();

            if (dailyResults == null)
            {
                throw new ArgumentException($"Day[{day}] not defined in {ResultFilename}");
            }

            UpdatePuzzleValue(dailyResults, summary.Reports.First());
            UpdatePuzzleValue(dailyResults, summary.Reports.Skip(1).First());

            if (writeToFile)
            {
                WriteResultsToJson();
            }
        }

        public void WriteResultsToJson()
        {
            var options = new JsonSerializerOptions { 
                WriteIndented = true, 
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };
            var jsonstring = JsonSerializer.Serialize(results, options);

            File.WriteAllText(GetPath(ResultFilename), jsonstring);
        }

        public void UpdateResultsInReadme()
        {
            string tableStart = "<!--ResultTableStart-->";
            string tableEnd = "<!--ResultTableEnds-->";

            var markdownTable = ToMarkdownTable.Convert(results);

            var readmeContent = File.ReadAllText(GetPath(ReadmeFilename));
            var startIndex = readmeContent.IndexOf(tableStart) + tableStart.Length;
            var endIndex = readmeContent.IndexOf(tableEnd);

            if (startIndex < 0 || endIndex < 0)
            {
                throw new FileLoadException($"Can't update result table in readme as it's missing {tableStart} and/or {tableEnd}");
            }

            var beforeTable = readmeContent.Substring(0, startIndex) + Environment.NewLine;
            var tableString = string.Join(Environment.NewLine, markdownTable) + Environment.NewLine;
            var afterTable = readmeContent.Substring(endIndex);

            readmeContent = beforeTable + tableString + afterTable;
            File.WriteAllText(GetPath(ReadmeFilename), readmeContent);
        }

        private void UpdatePuzzleValue(Results.DailyResult result, BenchmarkReport report)
        {
            var puzzle = report.BenchmarkCase.Descriptor.WorkloadMethodDisplayInfo.ElementAt(5);

            var elapsed = FormatTimeValue(report.ResultStatistics.Mean);

            switch (puzzle)
            {
                case '1':
                    result.Puzzle1_BenchmarkTime = elapsed;
                    break;
                case '2':
                    result.Puzzle2_BenchmarkTime = elapsed;
                    break;
                default:
                    throw new InvalidDataException($"Unknown test case ending {report.BenchmarkCase.Descriptor.WorkloadMethodDisplayInfo}, only support: 1, 2");
            }
        }

        /// <summary>
        /// Convert elapsed time in nanoseconds to string with proper time denomination.
        /// </summary>
        /// <param name="elapsed">Time in nanoseconds</param>
        /// <returns>Human-readable string for time.</returns>
        private string FormatTimeValue(double elapsed)
        {
            var index = 0;
            while(elapsed > 1000)
            {
                elapsed /= 1000;
                index++;
            }

            return $"{(int)elapsed}{symbols[index]}";
        }

        private string GetPath(string filename)
        {
            return AppDomain.CurrentDomain.BaseDirectory + "..\\..\\..\\..\\" + filename;
        }

        private static class ToMarkdownTable
        {
            static readonly List<int> colWidth = new List<int>() { 30, 7, 24, 21 };

            public static List<string> Convert(Results results)
            {
                var rows = new List<string>
                {
                    GetHeader(results.CoreClockSpeed),
                    GetDivider()
                };

                foreach (var dailyResult in results.Days)
                {
                    if (dailyResult.Puzzle1_TestTime == string.Empty && dailyResult.Puzzle1_BenchmarkTime == string.Empty)
                    {
                        continue;
                    }
                    rows.Add(CreateRow(GetDayLink(dailyResult.Day), "Puzzle1", dailyResult.Puzzle1_TestTime, dailyResult.Puzzle1_BenchmarkTime));
                    
                    if (dailyResult.Puzzle2_TestTime == string.Empty && dailyResult.Puzzle2_BenchmarkTime == string.Empty)
                    {
                        continue;
                    }
                    rows.Add(CreateRow("", "Puzzle2", dailyResult.Puzzle2_TestTime, dailyResult.Puzzle2_BenchmarkTime));
                }

                return rows;
            }

            public static string GetHeader(string clockSpeed)
            {
                return CreateRow("", "", $"Test @{clockSpeed}<sup>1</sup>", "Benchmark<sup>2</sup>");
            }

            public static string GetDivider()
            {
                return string.Format("|{0}|{1}|{2}|{3}|",
                    "".PadLeft(colWidth[0]+2, '-'),
                    "".PadLeft(colWidth[1]+2, '-'),
                    ":".PadLeft(colWidth[2]+2, '-'),
                    ":".PadLeft(colWidth[3]+2, '-')
                );
            }

            public static string CreateRow(string col0, string col1, string col2, string col3)
            {
                return string.Format("| {0} | {1} | {2} | {3} |",
                    col0.PadLeft(colWidth[0]),
                    col1.PadLeft(colWidth[1]),
                    col2.PadLeft(colWidth[2]),
                    col3.PadLeft(colWidth[3])
                );
            }

            public static string GetDayLink(string day)
            {
                return $"[Day{day}](AdventOfCode/Day{day}.cs)";
            }
        }
    }
}
