``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.203
  [Host]  : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT
  LongRun : .NET Core 5.0.6 (CoreCLR 5.0.621.22011, CoreFX 5.0.621.22011), X64 RyuJIT

Job=LongRun  IterationCount=100  LaunchCount=3  
WarmupCount=15  

```
|     Method |     Mean |     Error |    StdDev |   Median |      Min |      Max |      P90 |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|-------:|------:|------:|----------:|
| IntToBool1 | 5.082 ns | 0.0108 ns | 0.0549 ns | 5.072 ns | 4.975 ns | 5.249 ns | 5.162 ns | 0.0029 |     - |     - |      48 B |
| IntToBool2 | 3.854 ns | 0.0402 ns | 0.1999 ns | 3.750 ns | 3.677 ns | 4.410 ns | 4.244 ns | 0.0014 |     - |     - |      24 B |
| BoolToInt1 | 5.885 ns | 0.0233 ns | 0.1190 ns | 5.906 ns | 5.639 ns | 6.165 ns | 6.032 ns | 0.0029 |     - |     - |      48 B |
| BoolToInt2 | 3.858 ns | 0.0303 ns | 0.1528 ns | 3.881 ns | 3.661 ns | 4.269 ns | 4.062 ns | 0.0014 |     - |     - |      24 B |
