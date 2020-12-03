# Benchmarks
The implementaions has been benchmarked using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet)

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
```

## Day 01
| Method |      N |     Mean |    Error |   StdDev |
|------- |------- |---------:|---------:|---------:|
| D01_P1 | 100000 | 11.54 us | 0.104 us | 0.097 us |
| D01_P2 | 100000 | 26.21 us | 0.247 us | 0.219 us |

## Day 02
| Method |      N |     Mean |   Error |  StdDev |
|------- |------- |---------:|--------:|--------:|
| D02_P1 | 100000 | 386.9 us | 4.54 us | 4.24 us |
| D02_P2 | 100000 | 233.8 us | 2.61 us | 2.44 us |

## Day 03
| Method |      N |     Mean |    Error |   StdDev |
|------- |------- |---------:|---------:|---------:|
| D03_P1 | 100000 | 26.19 us | 0.427 us | 0.379 us |
| D03_P2 | 100000 | 33.41 us | 0.357 us | 0.334 us |