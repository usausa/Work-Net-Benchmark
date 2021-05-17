``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.203
  [Host]    : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  MediumRun : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|          Method |     Mean |    Error |   StdDev |      Min |      Max |      P90 |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |---------:|---------:|---------:|---------:|---------:|---------:|-------:|------:|------:|----------:|
|    Resolver1Int | 16.94 ns | 0.060 ns | 0.082 ns | 16.80 ns | 17.10 ns | 17.06 ns | 0.0014 |     - |     - |      24 B |
| Resolver1String | 15.76 ns | 0.066 ns | 0.099 ns | 15.43 ns | 15.95 ns | 15.84 ns |      - |     - |     - |         - |
|    Resolver2Int | 15.09 ns | 0.090 ns | 0.135 ns | 14.81 ns | 15.40 ns | 15.19 ns |      - |     - |     - |         - |
| Resolver2String | 15.56 ns | 0.107 ns | 0.159 ns | 15.24 ns | 16.00 ns | 15.75 ns |      - |     - |     - |         - |
