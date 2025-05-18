```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method      | Mean     | Error     | StdDev    | Min      | Max      | P90      | Gen0   | Code Size | Allocated |
|------------ |---------:|----------:|----------:|---------:|---------:|---------:|-------:|----------:|----------:|
| Net73Struct | 2.713 ns | 0.0427 ns | 0.0626 ns | 2.606 ns | 2.877 ns | 2.783 ns |      - |      19 B |         - |
| Struct      | 4.756 ns | 0.1394 ns | 0.2087 ns | 4.422 ns | 5.180 ns | 5.062 ns | 0.0014 |      72 B |      24 B |
| Class       | 4.683 ns | 0.1014 ns | 0.1518 ns | 4.439 ns | 5.034 ns | 4.843 ns | 0.0014 |      72 B |      24 B |
