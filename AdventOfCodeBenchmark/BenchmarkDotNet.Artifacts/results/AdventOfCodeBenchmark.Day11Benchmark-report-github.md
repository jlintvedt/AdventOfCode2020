``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
  [Host]     : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT
  DefaultJob : .NET Core 3.1.3 (CoreCLR 4.700.20.11803, CoreFX 4.700.20.12001), X64 RyuJIT


```
|     Method |     N |     Mean |    Error |   StdDev |
|----------- |------ |---------:|---------:|---------:|
|     D11_P1 | 10000 | 12.74 ms | 0.249 ms | 0.256 ms |
| Alt_D11_P1 | 10000 | 23.39 ms | 0.288 ms | 0.256 ms |
|     D11_P2 | 10000 | 30.28 ms | 0.598 ms | 0.560 ms |
| Alt_D11_P2 | 10000 | 28.61 ms | 0.341 ms | 0.319 ms |
