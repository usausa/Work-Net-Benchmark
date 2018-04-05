``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.125)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical cores and 4 physical cores
Frequency=3415989 Hz, Resolution=292.7410 ns, Timer=TSC
.NET Core SDK=2.1.104
  [Host]   : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  ShortRun : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|        Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|-------------- |----------:|----------:|----------:|-------:|----------:|
|        NewRaw |  1.925 ns | 0.4099 ns | 0.0232 ns | 0.0057 |      24 B |
|  NewIndirect1 |  1.987 ns | 0.8365 ns | 0.0473 ns | 0.0057 |      24 B |
|  NewIndirect2 |  2.098 ns | 0.2092 ns | 0.0118 ns | 0.0057 |      24 B |
| NewConstraint | 55.586 ns | 7.0082 ns | 0.3960 ns | 0.0056 |      24 B |
|       Factory |  3.676 ns | 0.4614 ns | 0.0261 ns | 0.0057 |      24 B |
|      Factory2 |  3.980 ns | 1.0201 ns | 0.0576 ns | 0.0057 |      24 B |
