```

BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]    : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  MediumRun : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method           | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|----------------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|-------:|----------:|
| Mapping          | 4.673 ns | 0.0948 ns | 0.1298 ns | 4.500 ns | 5.049 ns | 4.798 ns |     110 B | 0.0029 |      48 B |
| MappingInterface | 4.849 ns | 0.1355 ns | 0.2028 ns | 4.646 ns | 5.352 ns | 5.104 ns |     217 B | 0.0029 |      48 B |
| ProjectClass     | 4.130 ns | 0.1445 ns | 0.2163 ns | 3.856 ns | 4.647 ns | 4.468 ns |     197 B | 0.0014 |      24 B |
| ProjectStruct    | 4.565 ns | 0.1399 ns | 0.2094 ns | 4.230 ns | 4.976 ns | 4.892 ns |     189 B | 0.0014 |      24 B |
