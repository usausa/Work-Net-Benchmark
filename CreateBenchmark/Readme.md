``` ini

BenchmarkDotNet=v0.10.13, OS=Windows 10 Redstone 3 [1709, Fall Creators Update] (10.0.16299.192)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical cores and 4 physical cores
Frequency=3415986 Hz, Resolution=292.7412 ns, Timer=TSC
.NET Core SDK=2.1.104
  [Host]   : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT
  ShortRun : .NET Core 2.0.6 (CoreCLR 4.6.26212.01, CoreFX 4.6.26212.01), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
|                      Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|---------------------------- |---------:|----------:|----------:|-------:|----------:|
|                         Raw | 2.172 ns | 7.3490 ns | 0.4152 ns | 0.0057 |      24 B |
|       DirectInstanceFactory | 2.403 ns | 1.2687 ns | 0.0717 ns | 0.0057 |      24 B |
| DirectInstanceFactoryInline | 2.051 ns | 0.3551 ns | 0.0201 ns | 0.0057 |      24 B |
|         DirectStaticFactory | 1.819 ns | 1.4040 ns | 0.0793 ns | 0.0057 |      24 B |
|   DirectStaticFactoryInline | 2.369 ns | 0.4503 ns | 0.0254 ns | 0.0057 |      24 B |
|             InstanceFactory | 3.226 ns | 0.3827 ns | 0.0216 ns | 0.0057 |      24 B |
|       InstanceFactoryInline | 3.033 ns | 3.6535 ns | 0.2064 ns | 0.0057 |      24 B |
|               StaticFactory | 3.787 ns | 1.8283 ns | 0.1033 ns | 0.0057 |      24 B |
|         StaticFactoryInline | 4.089 ns | 2.2739 ns | 0.1285 ns | 0.0057 |      24 B |
|            DelegateFactory1 | 2.619 ns | 0.8092 ns | 0.0457 ns | 0.0057 |      24 B |
|            DelegateFactory2 | 2.820 ns | 1.1073 ns | 0.0626 ns | 0.0057 |      24 B |
|    DelegateFactory1WithCast | 4.819 ns | 0.4230 ns | 0.0239 ns | 0.0057 |      24 B |
|    DelegateFactory2WithCast | 4.126 ns | 0.4573 ns | 0.0258 ns | 0.0057 |      24 B |
