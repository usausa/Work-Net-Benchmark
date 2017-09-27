# Get

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
 |                Method |      Mean |     Error |    StdDev |    Gen 0 | Allocated |
 |---------------------- |----------:|----------:|----------:|---------:|----------:|
 |            Dictionary | 204.57 us | 23.617 us | 1.3344 us |        - |       0 B |
 |    DictionaryWithLock | 354.53 us | 14.859 us | 0.8396 us |        - |       0 B |
 |  ConcurrentDictionary | 295.80 us |  9.869 us | 0.5576 us | 152.3438 |  640000 B |
 |               AvlTree |  57.72 us | 15.388 us | 0.8694 us |        - |       0 B |
 | ConcurrentHashArryMap |  41.85 us |  8.564 us | 0.4839 us |        - |       0 B |

# Add

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
 |                     Method |       Mean |      Error |    StdDev |   Gen 0 | Allocated |
 |--------------------------- |-----------:|-----------:|----------:|--------:|----------:|
 |                 Dictionary |   5.541 us |  1.0307 us | 0.0582 us |  3.1891 |   13.1 KB |
 |         DictionaryWithLock |   6.987 us |  0.6192 us | 0.0350 us |  3.1967 |  13.13 KB |
 |       ConcurrentDictionary |  20.470 us |  0.4192 us | 0.0237 us |  6.5002 |  26.69 KB |
 |                    AvlTree |  13.945 us |  1.5991 us | 0.0904 us | 11.7493 |  48.15 KB |
 |     ConcurrentHashArrayMap | 230.266 us | 45.9862 us | 2.5983 us | 61.2793 | 251.22 KB |
 | ConcurrentHashArrayMapBulk |  16.645 us |  6.5233 us | 0.3686 us |  4.6387 |  19.11 KB |
