``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
| Method |     N |     Mean |   Error |  StdDev |
|------- |------ |---------:|--------:|--------:|
| D18_P1 | 10000 | 478.9 μs | 5.04 μs | 4.46 μs |
| D18_P2 | 10000 | 519.0 μs | 5.18 μs | 4.59 μs |
