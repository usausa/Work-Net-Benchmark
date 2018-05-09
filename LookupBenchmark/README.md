``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17134
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
Frequency=3415985 Hz, Resolution=292.7413 ns, Timer=TSC
.NET Core SDK=2.1.200
  [Host]   : .NET Core 2.0.7 (CoreCLR 4.6.26328.01, CoreFX 4.6.26403.03), 64bit RyuJIT
  ShortRun : .NET Core 2.0.7 (CoreCLR 4.6.26328.01, CoreFX 4.6.26403.03), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|     Method |     Mean |    Error |    StdDev |  Gen 0 | Allocated |
|----------- |---------:|---------:|----------:|-------:|----------:|
|    Current | 316.1 ns | 40.22 ns | 2.2725 ns |      - |       0 B |
| ThreadSafe | 317.5 ns | 76.70 ns | 4.3334 ns |      - |       0 B |
|         If | 394.3 ns | 37.01 ns | 2.0912 ns | 0.0873 |     368 B |
|        If2 | 363.5 ns | 10.26 ns | 0.5800 ns | 0.0854 |     360 B |
