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
 |      Method |         Mean |       Error |     StdDev |  Gen 0 | Allocated |
 |------------ |-------------:|------------:|-----------:|-------:|----------:|
 |        New0 |     3.664 ns |   1.1452 ns |  0.0647 ns | 0.0057 |      24 B |
 |       Ctor0 |   121.413 ns |  33.7294 ns |  1.9058 ns | 0.0055 |      24 B |
 |  Activator0 |    48.498 ns |   2.4505 ns |  0.1385 ns | 0.0057 |      24 B |
 | Expression0 |     4.070 ns |   0.5490 ns |  0.0310 ns | 0.0057 |      24 B |
 |       Emit0 |     5.083 ns |   0.3290 ns |  0.0186 ns | 0.0057 |      24 B |
 |      Emit0B |     3.462 ns |   0.4375 ns |  0.0247 ns | 0.0057 |      24 B |
 |        New1 |     4.435 ns |   2.0007 ns |  0.1130 ns | 0.0057 |      24 B |
 |       Ctor1 |   196.273 ns |  12.4088 ns |  0.7011 ns | 0.0131 |      56 B |
 |  Activator1 |   584.046 ns |  33.1312 ns |  1.8720 ns | 0.0906 |     384 B |
 | Expression1 |     4.746 ns |   2.0228 ns |  0.1143 ns | 0.0057 |      24 B |
 |       Emit1 |     5.553 ns |   0.3683 ns |  0.0208 ns | 0.0057 |      24 B |
 |      Emit1B |     4.295 ns |   0.5800 ns |  0.0328 ns | 0.0057 |      24 B |
 |        New8 |    11.396 ns |   1.2541 ns |  0.0709 ns | 0.0114 |      48 B |
 |       Ctor8 |   579.677 ns | 214.0743 ns | 12.0956 ns | 0.0315 |     136 B |
 |  Activator8 | 1,309.569 ns |  78.9144 ns |  4.4588 ns | 0.1411 |     600 B |
 | Expression8 |    12.132 ns |   2.4808 ns |  0.1402 ns | 0.0114 |      48 B |
 |       Emit8 |    13.211 ns |   3.5234 ns |  0.1991 ns | 0.0114 |      48 B |
 |      Emit8B |    11.513 ns |   2.1960 ns |  0.1241 ns | 0.0114 |      48 B |
