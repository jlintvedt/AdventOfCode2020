# Benchmarks
The implementaions has been benchmarked using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet)

```
BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19041.572 (2004/?/20H1)
AMD Ryzen 9 3900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=3.1.201
```

## Day 00
| Method |      N |     Mean |     Error |    StdDev |
|------- |------- |---------:|----------:|----------:|
| D01_P1 | 100000 | 5.378 us | 0.0374 us | 0.0313 us |
| D01_P2 | 100000 | 6.297 us | 0.0530 us | 0.0470 us |
