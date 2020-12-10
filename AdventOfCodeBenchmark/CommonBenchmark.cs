using AdventOfCode;
using AdventOfCode.Common;
using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;

namespace AdventOfCodeBenchmark
{
    public class CommonBenchmark
    {
        string intStringNewlineDelim;

        [Params(1000000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            intStringNewlineDelim = string.Format("01{0}11{0}21{0}31{0}41{0}51{0}02{0}12{0}22{0}32{0}42{0}52{0}03{0}13{0}23{0}33{0}43{0}53{0}04{0}14{0}24{0}34{0}44{0}54{0}05{0}15{0}25{0}35{0}45{0}55{0}06{0}16{0}26{0}36{0}46{0}56{0}07{0}17{0}27{0}37{0}47{0}57{0}08{0}18{0}28{0}38{0}48{0}58{0}09{0}19{0}29{0}39{0}49{0}59{0}10{0}20{0}20{0}30{0}40{0}50", Environment.NewLine);
        }

        [Benchmark]
        public long[] ParseStringToLongArrayNew() => Common.ParseStringToLongArray(intStringNewlineDelim, Environment.NewLine);
    }
}
