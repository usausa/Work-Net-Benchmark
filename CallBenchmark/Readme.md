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
 |                    Method |     Mean |     Error |    StdDev | Allocated |
 |-------------------------- |---------:|----------:|----------:|----------:|
 |         NonSealedResolver | 1.172 ns | 1.2039 ns | 0.0680 ns |       0 B |
 |            SealedResolver | 1.056 ns | 0.8264 ns | 0.0467 ns |       0 B |
 | NonSealedDelegateResolver | 2.268 ns | 0.7545 ns | 0.0426 ns |       0 B |
 |    SealedDelegateResolver | 2.211 ns | 1.4931 ns | 0.0844 ns |       0 B |
