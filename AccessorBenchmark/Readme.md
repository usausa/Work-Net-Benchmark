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
 |              Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
 |-------------------- |-----------:|-----------:|----------:|-------:|----------:|
 |    GenerativeGetter |   1.804 ns |  0.5555 ns | 0.0314 ns |      - |       0 B |
 | DynamicMethodGetter |   3.325 ns |  0.7644 ns | 0.0432 ns |      - |       0 B |
 |    ExpressionGetter |   4.849 ns |  0.5750 ns | 0.0325 ns |      - |       0 B |
 |      DelegateGetter |   5.700 ns |  1.8796 ns | 0.1062 ns |      - |       0 B |
 |    ReflectionGetter |  92.836 ns |  5.1161 ns | 0.2891 ns |      - |       0 B |
 |    GenerativeSetter |   3.946 ns |  1.0345 ns | 0.0584 ns |      - |       0 B |
 | DynamicMethodSetter |   5.162 ns |  0.2599 ns | 0.0147 ns |      - |       0 B |
 |    ExpressionSetter |   7.896 ns |  3.5855 ns | 0.2026 ns |      - |       0 B |
 |      DelegateSetter |   8.918 ns |  0.8807 ns | 0.0498 ns |      - |       0 B |
 |    ReflectionSetter | 169.669 ns | 38.6117 ns | 2.1816 ns | 0.0150 |      64 B |
