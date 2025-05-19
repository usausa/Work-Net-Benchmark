```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method      | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Gen0   | Allocated |
|------------ |----------:|----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
| Net73Struct |  2.593 ns | 0.0303 ns | 0.0444 ns |  2.525 ns |  2.698 ns |  2.646 ns |      19 B |      - |         - |
| Struct      |  4.366 ns | 0.0393 ns | 0.0551 ns |  4.261 ns |  4.518 ns |  4.426 ns |      72 B | 0.0014 |      24 B |
| Class       |  4.623 ns | 0.1442 ns | 0.2068 ns |  4.247 ns |  4.916 ns |  4.846 ns |      72 B | 0.0014 |      24 B |
| Yield       | 26.647 ns | 0.1985 ns | 0.2717 ns | 26.264 ns | 27.406 ns | 27.033 ns |     560 B | 0.0033 |      56 B |
