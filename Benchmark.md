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

## Day 04
| Method |      N |     Mean |   Error |  StdDev |
|------- |------- |---------:|--------:|--------:|
| D04_P1 | 100000 | 320.4 us | 2.08 us | 1.84 us |
| D04_P2 | 100000 | 385.2 us | 3.64 us | 3.40 us |

## Day 05
| Method |      N |     Mean |    Error |   StdDev |
|------- |------- |---------:|---------:|---------:|
| D05_P1 | 100000 | 45.06 us | 0.537 us | 0.502 us |
| D05_P2 | 100000 | 64.40 us | 1.242 us | 1.220 us |

## Day 06
| Method |      N |     Mean |   Error |  StdDev |
|------- |------- |---------:|--------:|--------:|
| D06_P1 | 100000 | 622.5 us | 8.15 us | 7.62 us |
| D06_P2 | 100000 | 765.9 us | 6.99 us | 6.54 us |