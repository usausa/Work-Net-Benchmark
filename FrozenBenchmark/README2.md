```

BenchmarkDotNet v0.13.9+228a464e8be6c580ad9408e98f18813f6407fb5a, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100-rc.1.23463.5
  [Host]    : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
| Method                            | Items | Mean     | Error   | StdDev  | Min      | Max      | P90      | Code Size | Gen0   | Allocated |
|---------------------------------- |------ |---------:|--------:|--------:|---------:|---------:|---------:|----------:|-------:|----------:|
| **FrozenDictionaryTryGetValueByType** | **32**    | **685.2 ns** | **6.32 ns** | **9.46 ns** | **671.9 ns** | **701.1 ns** | **698.0 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 32    | 205.4 ns | 2.51 ns | 3.69 ns | 201.0 ns | 213.3 ns | 212.3 ns |   2,037 B | 0.0491 |     824 B |
| **FrozenDictionaryTryGetValueByType** | **256**   | **673.5 ns** | **4.65 ns** | **6.82 ns** | **661.1 ns** | **689.3 ns** | **682.2 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 256   | 204.6 ns | 2.24 ns | 3.22 ns | 200.5 ns | 213.3 ns | 208.9 ns |   2,037 B | 0.0491 |     824 B |
| **FrozenDictionaryTryGetValueByType** | **1024**  | **669.7 ns** | **6.37 ns** | **8.93 ns** | **657.6 ns** | **699.1 ns** | **680.9 ns** |   **2,120 B** | **0.0486** |     **824 B** |
| HashArrayTryGetValueByType        | 1024  | 204.6 ns | 4.02 ns | 5.64 ns | 200.2 ns | 225.1 ns | 212.7 ns |   2,037 B | 0.0491 |     824 B |
