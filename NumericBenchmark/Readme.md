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
|          Method |       Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------- |-----------:|----------:|----------:|-------:|----------:|
|         IntMul9 |   3.385 ns | 0.0290 ns | 0.0406 ns |      - |       0 B |
|        LongMul9 |   5.029 ns | 0.0350 ns | 0.0513 ns |      - |       0 B |
|  BigIntegerMul9 | 178.026 ns | 0.8738 ns | 1.2249 ns |      - |       0 B |
|         IntDiv9 |   5.211 ns | 0.0272 ns | 0.0399 ns |      - |       0 B |
|        LongDiv9 |   7.154 ns | 0.0472 ns | 0.0646 ns |      - |       0 B |
|  BigIntegerDiv9 | 172.462 ns | 0.9724 ns | 1.3946 ns |      - |       0 B |
|       LongMul19 |  10.745 ns | 0.0736 ns | 0.1079 ns |      - |       0 B |
| BigIntegerMul19 | 674.607 ns | 3.4352 ns | 4.7022 ns | 0.1612 |     680 B |
|       LongDiv19 |  17.157 ns | 2.6453 ns | 3.8775 ns |      - |       0 B |
| BigIntegerDiv19 | 747.416 ns | 3.4505 ns | 5.0577 ns | 0.1440 |     608 B |
