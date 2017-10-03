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
 |        New0 |     3.726 ns |   1.0916 ns |  0.0617 ns | 0.0057 |      24 B |
 |       Ctor0 |   123.428 ns |  27.4934 ns |  1.5534 ns | 0.0055 |      24 B |
 |  Activator0 |    51.117 ns |   3.0457 ns |  0.1721 ns | 0.0057 |      24 B |
 | Expression0 |     4.176 ns |   2.8455 ns |  0.1608 ns | 0.0057 |      24 B |
 |       Emit0 |     5.168 ns |   1.4268 ns |  0.0806 ns | 0.0057 |      24 B |
 |      Emit0B |     3.486 ns |   0.9390 ns |  0.0531 ns | 0.0057 |      24 B |
 |        New1 |     4.097 ns |   0.6560 ns |  0.0371 ns | 0.0057 |      24 B |
 |       Ctor1 |   195.081 ns |  39.2088 ns |  2.2154 ns | 0.0131 |      56 B |
 |  Activator1 |   631.405 ns | 170.7909 ns |  9.6500 ns | 0.0906 |     384 B |
 | Expression1 |     4.752 ns |   2.9336 ns |  0.1658 ns | 0.0057 |      24 B |
 |       Emit1 |     5.574 ns |   0.6575 ns |  0.0372 ns | 0.0057 |      24 B |
 |      Emit1B |     4.432 ns |   0.7305 ns |  0.0413 ns | 0.0057 |      24 B |
 |        New8 |    11.788 ns |   0.7112 ns |  0.0402 ns | 0.0114 |      48 B |
 |       Ctor8 |   569.921 ns | 109.3018 ns |  6.1758 ns | 0.0315 |     136 B |
 |  Activator8 | 1,377.825 ns | 508.8724 ns | 28.7522 ns | 0.1411 |     600 B |
 | Expression8 |    12.234 ns |   6.2929 ns |  0.3556 ns | 0.0114 |      48 B |
 |       Emit8 |    12.958 ns |   2.9151 ns |  0.1647 ns | 0.0114 |      48 B |
 |      Emit8B |    12.088 ns |   3.2583 ns |  0.1841 ns | 0.0114 |      48 B |
