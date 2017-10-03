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
 |      Method |         Mean |       Error |    StdDev |  Gen 0 | Allocated |
 |------------ |-------------:|------------:|----------:|-------:|----------:|
 |        New0 |     3.749 ns |   0.4485 ns | 0.0253 ns | 0.0057 |      24 B |
 |       Ctor0 |   120.078 ns |  13.6583 ns | 0.7717 ns | 0.0055 |      24 B |
 |  Activator0 |    48.804 ns |  12.7755 ns | 0.7218 ns | 0.0057 |      24 B |
 | Expression0 |     3.748 ns |   0.5401 ns | 0.0305 ns | 0.0057 |      24 B |
 |       Emit0 |     5.176 ns |   0.8547 ns | 0.0483 ns | 0.0057 |      24 B |
 |        New1 |     4.192 ns |   0.8848 ns | 0.0500 ns | 0.0057 |      24 B |
 |       Ctor1 |   196.427 ns |  83.1515 ns | 4.6982 ns | 0.0131 |      56 B |
 |  Activator1 |   582.216 ns | 105.9011 ns | 5.9836 ns | 0.0906 |     384 B |
 | Expression1 |     4.899 ns |   1.5993 ns | 0.0904 ns | 0.0057 |      24 B |
 |       Emit1 |     5.678 ns |   3.0461 ns | 0.1721 ns | 0.0057 |      24 B |
 |        New8 |    11.895 ns |   5.4369 ns | 0.3072 ns | 0.0114 |      48 B |
 |       Ctor8 |   553.850 ns |  53.1829 ns | 3.0049 ns | 0.0315 |     136 B |
 |  Activator8 | 1,295.650 ns |  60.1914 ns | 3.4009 ns | 0.1411 |     600 B |
 | Expression8 |    11.960 ns |   2.6025 ns | 0.1470 ns | 0.0114 |      48 B |
 |       Emit8 |    12.516 ns |   3.7445 ns | 0.2116 ns | 0.0114 |      48 B |
