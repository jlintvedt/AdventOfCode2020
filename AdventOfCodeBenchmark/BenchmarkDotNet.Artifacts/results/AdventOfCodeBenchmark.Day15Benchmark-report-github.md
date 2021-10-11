``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
| Method |   N |            Mean |         Error |        StdDev |          Median |
|------- |---- |----------------:|--------------:|--------------:|----------------:|
| D15_P1 | 100 |        16.38 μs |      0.315 μs |      0.801 μs |        15.97 μs |
| D15_P2 | 100 | 2,266,231.32 μs | 31,313.719 μs | 29,290.872 μs | 2,265,254.60 μs |
