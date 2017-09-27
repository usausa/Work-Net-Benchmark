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
 |      Method |      Mean |     Error |    StdDev | Allocated |
 |------------ |----------:|----------:|----------:|----------:|
 | Dictionary1 | 12.788 us | 1.9913 us | 0.1125 us |       0 B |
 | Dictionary2 | 13.081 us | 1.5813 us | 0.0893 us |       0 B |
 | Dictionary3 | 12.866 us | 2.2955 us | 0.1297 us |       0 B |
 |        Map1 |  4.845 us | 0.5533 us | 0.0313 us |       0 B |
 |        Map2 |  4.804 us | 0.0743 us | 0.0042 us |       0 B |
 |        Map3 |  5.259 us | 0.5025 us | 0.0284 us |       0 B |
 |      Array1 |  1.446 us | 0.0524 us | 0.0030 us |       0 B |
 |      Array2 |  2.457 us | 0.2648 us | 0.0150 us |       0 B |
 |      Array3 |  4.573 us | 0.3159 us | 0.0178 us |       0 B |
