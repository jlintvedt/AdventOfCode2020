namespace AdventOfCodeBenchmark
{
    public class Results
    {
        public string CoreClockSpeed { get; set; }

        public DailyResult[] Days { get; set; }

        public class DailyResult
        {
            public string Day { get; set; }

            public string Puzzle1_TestTime { get; set; }

            public string Puzzle2_TestTime { get; set; }

            public string Puzzle1_BenchmarkTime { get; set; }

            public string Puzzle2_BenchmarkTime { get; set; }
        }
    }
}
