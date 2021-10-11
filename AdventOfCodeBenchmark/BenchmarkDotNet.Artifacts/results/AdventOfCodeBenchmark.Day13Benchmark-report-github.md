``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
| Method |      N |     Mean |     Error |    StdDev |
|------- |------- |---------:|----------:|----------:|
| D13_P1 | 100000 | 2.376 μs | 0.0374 μs | 0.0349 μs |
| D13_P2 | 100000 | 5.458 μs | 0.0520 μs | 0.0486 μs |
