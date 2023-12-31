```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22631.2715/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100
  [Host]             : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  MediumRun-.NET 6.0 : .NET 6.0.25 (6.0.2523.51912), X64 RyuJIT AVX2
  MediumRun-.NET 8.0 : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method        | Job                | Runtime  | Mean      | Error     | StdDev    | Min       | Max       | P90       | Code Size | Allocated |
|-------------- |------------------- |--------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|
| DefinedMember | MediumRun-.NET 6.0 | .NET 6.0 | 10.957 ns | 0.2330 ns | 0.3267 ns | 10.591 ns | 11.920 ns | 11.381 ns |     167 B |         - |
| EachTime      | MediumRun-.NET 6.0 | .NET 6.0 | 23.427 ns | 0.3303 ns | 0.4522 ns | 23.039 ns | 24.993 ns | 24.038 ns |     185 B |         - |
| DefinedMember | MediumRun-.NET 8.0 | .NET 8.0 |  8.545 ns | 0.0572 ns | 0.0801 ns |  8.447 ns |  8.733 ns |  8.662 ns |     181 B |         - |
| EachTime      | MediumRun-.NET 8.0 | .NET 8.0 |  8.144 ns | 0.0990 ns | 0.1451 ns |  8.021 ns |  8.553 ns |  8.367 ns |     181 B |         - |
