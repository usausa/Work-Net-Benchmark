``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]    : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  MediumRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                   Method |     Mean |     Error |    StdDev |   Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |---------:|----------:|----------:|---------:|-------:|------:|------:|----------:|
|  RunStaticUseStaticCache | 2.591 ns | 0.1649 ns | 0.2365 ns | 2.794 ns |      - |     - |     - |         - |
|        RunStaticUseCache | 2.713 ns | 0.2490 ns | 0.3572 ns | 3.023 ns |      - |     - |     - |         - |
|       RunStaticUseMethod | 7.547 ns | 0.1163 ns | 0.1740 ns | 7.494 ns | 0.0136 |     - |     - |      64 B |
|         RunStaticUseCall | 3.086 ns | 0.0049 ns | 0.0067 ns | 3.087 ns |      - |     - |     - |         - |
|          RunStaticDirect | 3.043 ns | 0.0050 ns | 0.0071 ns | 3.045 ns |      - |     - |     - |         - |
|        RunUseStaticCache | 2.804 ns | 0.0055 ns | 0.0077 ns | 2.803 ns |      - |     - |     - |         - |
|              RunUseCache | 2.802 ns | 0.0088 ns | 0.0131 ns | 2.800 ns |      - |     - |     - |         - |
|             RunUseMethod | 7.453 ns | 0.1315 ns | 0.1969 ns | 7.428 ns | 0.0136 |     - |     - |      64 B |
|               RunUseCall | 3.046 ns | 0.0099 ns | 0.0145 ns | 3.042 ns |      - |     - |     - |         - |
|                RunDirect | 2.814 ns | 0.1491 ns | 0.2138 ns | 2.640 ns |      - |     - |     - |         - |
| RunStaticUseStaticCache1 | 2.574 ns | 0.0045 ns | 0.0064 ns | 2.575 ns |      - |     - |     - |         - |
|       RunStaticUseCache1 | 2.584 ns | 0.0129 ns | 0.0188 ns | 2.579 ns |      - |     - |     - |         - |
|      RunStaticUseMethod1 | 7.642 ns | 0.0811 ns | 0.1214 ns | 7.675 ns | 0.0136 |     - |     - |      64 B |
|        RunStaticUseCall1 | 2.109 ns | 0.0039 ns | 0.0054 ns | 2.110 ns |      - |     - |     - |         - |
|         RunStaticDirect1 | 2.107 ns | 0.0031 ns | 0.0045 ns | 2.109 ns |      - |     - |     - |         - |
|       RunUseStaticCache1 | 2.458 ns | 0.0856 ns | 0.1201 ns | 2.562 ns |      - |     - |     - |         - |
|             RunUseCache1 | 2.573 ns | 0.0049 ns | 0.0070 ns | 2.572 ns |      - |     - |     - |         - |
|            RunUseMethod1 | 7.620 ns | 0.1246 ns | 0.1866 ns | 7.549 ns | 0.0136 |     - |     - |      64 B |
|              RunUseCall1 | 2.109 ns | 0.0032 ns | 0.0045 ns | 2.109 ns |      - |     - |     - |         - |
|               RunDirect1 | 2.353 ns | 0.1624 ns | 0.2380 ns | 2.566 ns |      - |     - |     - |         - |
