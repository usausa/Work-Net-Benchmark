``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]    : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  MediumRun : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|          Method |       Mean |     Error |    StdDev |        Min |        Max |        P90 |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|           New32 |   7.330 ns | 0.0629 ns | 0.0881 ns |   7.152 ns |   7.510 ns |   7.439 ns | 0.0210 |     - |     - |      88 B |
|    StackOrNew32 |   4.197 ns | 0.0293 ns | 0.0420 ns |   4.128 ns |   4.306 ns |   4.262 ns |      - |     - |     - |         - |
|   StackOrPool32 |   4.484 ns | 0.0670 ns | 0.0982 ns |   4.339 ns |   4.701 ns |   4.607 ns |      - |     - |     - |         - |
|          New256 |  34.756 ns | 0.3902 ns | 0.5841 ns |  33.845 ns |  36.262 ns |  35.688 ns | 0.1281 |     - |     - |     536 B |
|   StackOrNew256 |  17.854 ns | 0.1535 ns | 0.2201 ns |  17.476 ns |  18.472 ns |  18.103 ns |      - |     - |     - |         - |
|  StackOrPool256 |  18.738 ns | 0.1091 ns | 0.1599 ns |  18.478 ns |  19.076 ns |  18.952 ns |      - |     - |     - |         - |
|         New1024 | 129.516 ns | 1.5966 ns | 2.3402 ns | 124.986 ns | 134.069 ns | 132.369 ns | 0.4952 |     - |     - |    2072 B |
|  StackOrNew1024 |  76.460 ns | 0.3003 ns | 0.4402 ns |  75.817 ns |  77.610 ns |  76.922 ns |      - |     - |     - |         - |
| StackOrPool1024 |  77.091 ns | 0.4124 ns | 0.6172 ns |  75.980 ns |  78.732 ns |  77.844 ns |      - |     - |     - |         - |
|         New2048 | 271.181 ns | 2.6098 ns | 3.8254 ns | 262.661 ns | 279.137 ns | 276.647 ns | 0.9842 |     - |     - |    4120 B |
|  StackOrNew2048 | 274.591 ns | 5.7777 ns | 8.6478 ns | 261.275 ns | 298.146 ns | 286.665 ns | 0.9842 |     - |     - |    4120 B |
| StackOrPool2048 |  31.321 ns | 3.0416 ns | 4.3622 ns |  26.912 ns |  36.978 ns |  36.318 ns |      - |     - |     - |         - |
