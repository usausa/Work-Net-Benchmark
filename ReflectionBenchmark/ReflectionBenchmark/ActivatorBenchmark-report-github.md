``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4771 CPU 3.50GHz (Haswell), ProcessorCount=8
Frequency=3415988 Hz, Resolution=292.7411 ns, Timer=TSC
.NET Core SDK=2.0.0
  [Host]   : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT
  ShortRun : .NET Core 2.0.0 (Framework 4.6.00001.0), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
 |                   Method |         Mean |       Error |     StdDev |  Gen 0 | Allocated |
 |------------------------- |-------------:|------------:|-----------:|-------:|----------:|
 |                     New0 |     2.574 ns |   0.9300 ns |  0.0525 ns | 0.0057 |      24 B |
 |               Activator0 |    51.754 ns |  48.0242 ns |  2.7135 ns | 0.0057 |      24 B |
 |         ConstructorInfo0 |   129.414 ns |  44.1825 ns |  2.4964 ns | 0.0055 |      24 B |
 | ConstructorInfo0WithNull |   128.861 ns | 127.8744 ns |  7.2251 ns | 0.0055 |      24 B |
 |                     New1 |     2.686 ns |   3.6185 ns |  0.2045 ns | 0.0057 |      24 B |
 |               Activator1 |   623.317 ns |  82.8072 ns |  4.6788 ns | 0.0906 |     384 B |
 |         ConstructorInfo1 |   203.654 ns |  25.9591 ns |  1.4667 ns | 0.0131 |      56 B |
 |                     New2 |     2.892 ns |   0.9279 ns |  0.0524 ns | 0.0057 |      24 B |
 |               Activator2 |   729.097 ns |  64.0268 ns |  3.6176 ns | 0.0963 |     408 B |
 |         ConstructorInfo2 |   257.514 ns |  36.7678 ns |  2.0774 ns | 0.0148 |      64 B |
 |                     New8 |     4.077 ns |   1.2421 ns |  0.0702 ns | 0.0114 |      48 B |
 |               Activator8 | 1,371.329 ns | 312.4073 ns | 17.6516 ns | 0.1411 |     600 B |
 |         ConstructorInfo8 |   591.986 ns | 224.0029 ns | 12.6566 ns | 0.0315 |     136 B |
