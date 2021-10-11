# AdventOfCode2020

### Running benchmarks
Update reference [BenchmarkRunner.Run<Day**17**Benchmark>(config)](AdventOfCodeBenchmark/Program.cs).

Run without debugger: `ctrl+f5` in VS Code. This stores the benchmark in [results](AdventOfCodeBenchmark\BenchmarkDotNet.Artifacts\results) folder and the [Results](Results.json) file, also updates the table below.

## Runtimes
<!--ResultTableStart-->
|                                |         | Test @3.8GHz<sup>1</sup> | Benchmark<sup>2</sup> |
|--------------------------------|---------|-------------------------:|----------------------:|
| [Day01](AdventOfCode/Day01.cs) | Puzzle1 |                     <1ms |                  11μs |
|                                | Puzzle2 |                     <1ms |                  27μs |
| [Day02](AdventOfCode/Day02.cs) | Puzzle1 |                     <1ms |                 372μs |
|                                | Puzzle2 |                     <1ms |                 239μs |
| [Day03](AdventOfCode/Day03.cs) | Puzzle1 |                     <1ms |                  24μs |
|                                | Puzzle2 |                     <1ms |                  32μs |
| [Day04](AdventOfCode/Day04.cs) | Puzzle1 |                     <1ms |                 307μs |
|                                | Puzzle2 |                     <1ms |                 372μs |
| [Day05](AdventOfCode/Day05.cs) | Puzzle1 |                     <1ms |                  39μs |
|                                | Puzzle2 |                     <1ms |                  61μs |
| [Day06](AdventOfCode/Day06.cs) | Puzzle1 |                      1ms |                 581μs |
|                                | Puzzle2 |                      1ms |                 707μs |
| [Day07](AdventOfCode/Day07.cs) | Puzzle1 |                      1ms |                 737μs |
|                                | Puzzle2 |                      1ms |                 748μs |
| [Day08](AdventOfCode/Day08.cs) | Puzzle1 |                      1ms |                 107μs |
|                                | Puzzle2 |                      1ms |                 918μs |
| [Day09](AdventOfCode/Day09.cs) | Puzzle1 |                     <1ms |                  73μs |
|                                | Puzzle2 |                     <1ms |                  78μs |
| [Day10](AdventOfCode/Day10.cs) | Puzzle1 |                     <1ms |                   7μs |
|                                | Puzzle2 |                     <1ms |                  10μs |
| [Day11](AdventOfCode/Day11.cs) | Puzzle1 |                     72ms |                  12ms |
|                                | Puzzle2 |                    125ms |                  30ms |
| [Day12](AdventOfCode/Day12.cs) | Puzzle1 |                     <1ms |                  59μs |
|                                | Puzzle2 |                     <1ms |                  58μs |
| [Day13](AdventOfCode/Day13.cs) | Puzzle1 |                     <1ms |                   2μs |
|                                | Puzzle2 |                     <1ms |                   5μs |
| [Day14](AdventOfCode/Day14.cs) | Puzzle1 |                      1ms |                 269μs |
|                                | Puzzle2 |                      9ms |                   6ms |
| [Day15](AdventOfCode/Day15.cs) | Puzzle1 |                     <1ms |                  16μs |
|                                | Puzzle2 |                     2.5s |                    2s |
| [Day16](AdventOfCode/Day16.cs) | Puzzle1 |                      1ms |                 289μs |
|                                | Puzzle2 |                      WIP |                       |
| [Day17](AdventOfCode/Day17.cs) | Puzzle1 |                      9ms |                   1ms |
|                                | Puzzle2 |                     64ms |                  27ms |
<!--ResultTableEnd-->

1) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Visual Studio Test Explorer
2) Desktop AMD Ryzen 9 3900X @3.8/4.6GHz. Using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet).