``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.16299.334 (1709/FallCreatorsUpdate/Redstone3)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
Frequency=3415990 Hz, Resolution=292.7409 ns, Timer=TSC
.NET Core SDK=2.1.104
  [Host]   : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  ShortRun : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|          Method |       Mean |       Error |    StdDev |  Gen 0 | Allocated |
|---------------- |-----------:|------------:|----------:|-------:|----------:|
|         IntMul9 |   3.795 ns |   1.1284 ns | 0.0638 ns |      - |       0 B |
|        LongMul9 |   5.107 ns |   0.5173 ns | 0.0292 ns |      - |       0 B |
|  BigIntegerMul9 | 182.702 ns |  12.4738 ns | 0.7048 ns |      - |       0 B |
|         IntDiv9 |  28.877 ns |   0.7487 ns | 0.0423 ns |      - |       0 B |
|        LongDiv9 |  68.746 ns |   5.5819 ns | 0.3154 ns |      - |       0 B |
|  BigIntegerDiv9 | 173.845 ns |  17.7195 ns | 1.0012 ns |      - |       0 B |
|       LongMul19 |  10.975 ns |   2.6544 ns | 0.1500 ns |      - |       0 B |
| BigIntegerMul19 | 722.111 ns | 137.7166 ns | 7.7812 ns | 0.1612 |     680 B |
|       LongDiv19 | 183.697 ns |   3.1387 ns | 0.1773 ns |      - |       0 B |
| BigIntegerDiv19 | 787.486 ns | 121.2683 ns | 6.8519 ns | 0.1440 |     608 B |
