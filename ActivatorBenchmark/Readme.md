``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4771 CPU 3.50GHz (Haswell), ProcessorCount=8
Frequency=3415990 Hz, Resolution=292.7409 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  ShortRun : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
 |       Method |         Mean |       Error |    StdDev |  Gen 0 | Allocated |
 |------------- |-------------:|------------:|----------:|-------:|----------:|
 |         New0 |     2.998 ns |   1.5497 ns | 0.0876 ns | 0.0057 |      24 B |
 |        Ctor0 |   119.588 ns |   6.0952 ns | 0.3444 ns | 0.0055 |      24 B |
 |   Activator0 |    47.687 ns |   4.8034 ns | 0.2714 ns | 0.0057 |      24 B |
 |  Activator0B |    48.001 ns |   1.6007 ns | 0.0904 ns | 0.0057 |      24 B |
 |  Expression0 |     2.716 ns |   1.0074 ns | 0.0569 ns | 0.0057 |      24 B |
 | Expression0B |     2.689 ns |   1.6327 ns | 0.0922 ns | 0.0057 |      24 B |
 |        Emit0 |     4.011 ns |   1.9295 ns | 0.1090 ns | 0.0057 |      24 B |
 |       Emit0B |     3.603 ns |   0.5205 ns | 0.0294 ns | 0.0057 |      24 B |
 |         New1 |     3.596 ns |   1.0339 ns | 0.0584 ns | 0.0057 |      24 B |
 |        Ctor1 |   196.111 ns | 149.5127 ns | 8.4477 ns | 0.0131 |      56 B |
 |   Activator1 |   607.187 ns |  41.3234 ns | 2.3349 ns | 0.0906 |     384 B |
 |  Expression1 |     3.426 ns |   0.5026 ns | 0.0284 ns | 0.0057 |      24 B |
 |        Emit1 |     4.410 ns |   1.9306 ns | 0.1091 ns | 0.0057 |      24 B |
 |         New8 |    10.519 ns |   3.0606 ns | 0.1729 ns | 0.0114 |      48 B |
 |        Ctor8 |   558.530 ns |  65.5567 ns | 3.7041 ns | 0.0315 |     136 B |
 |   Activator8 | 1,326.913 ns | 118.3895 ns | 6.6892 ns | 0.1411 |     600 B |
 |  Expression8 |    10.275 ns |   0.2988 ns | 0.0169 ns | 0.0114 |      48 B |
 |        Emit8 |    10.948 ns |   0.4924 ns | 0.0278 ns | 0.0114 |      48 B |
