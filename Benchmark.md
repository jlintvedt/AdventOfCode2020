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
| D01_P1 | 100000 | 19.62 us | 0.238 us | 0.223 us |
| D01_P2 | 100000 | 28.47 us | 0.351 us | 0.328 us |
