``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17134.112 (1803/April2018Update/Redstone4)
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
Frequency=3415991 Hz, Resolution=292.7408 ns, Timer=TSC
.NET Core SDK=2.1.401
  [Host]    : .NET Core 2.1.2 (CoreCLR 4.6.26628.05, CoreFX 4.6.26629.01), 64bit RyuJIT
  MediumRun : .NET Core 2.1.2 (CoreCLR 4.6.26628.05, CoreFX 4.6.26629.01), 64bit RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                 Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|----------------------- |---------:|----------:|----------:|-------:|----------:|
|          FactoryStatic | 2.661 ns | 0.0470 ns | 0.0674 ns | 0.0057 |      24 B |
|    FactoryStaticInline | 3.904 ns | 0.0622 ns | 0.0930 ns | 0.0057 |      24 B |
|        FactoryInstance | 2.832 ns | 0.0327 ns | 0.0468 ns | 0.0057 |      24 B |
|  FactoryInstanceInline | 3.814 ns | 0.0508 ns | 0.0760 ns | 0.0057 |      24 B |
|         FactoryVirtual | 4.205 ns | 0.0564 ns | 0.0844 ns | 0.0057 |      24 B |
|   FactoryVirtualInline | 4.437 ns | 0.0734 ns | 0.1098 ns | 0.0057 |      24 B |
|          FactorySealed | 4.290 ns | 0.0549 ns | 0.0769 ns | 0.0057 |      24 B |
|    FactorySealedInline | 4.181 ns | 0.0434 ns | 0.0650 ns | 0.0057 |      24 B |
|         DelegateDirect | 3.866 ns | 0.0417 ns | 0.0624 ns | 0.0057 |      24 B |
|         DelegateStatic | 4.926 ns | 0.0439 ns | 0.0630 ns | 0.0057 |      24 B |
|   DelegateStaticInline | 4.842 ns | 0.0534 ns | 0.0783 ns | 0.0057 |      24 B |
|       DelegateInstance | 3.808 ns | 0.0394 ns | 0.0577 ns | 0.0057 |      24 B |
| DelegateInstanceInline | 3.903 ns | 0.0417 ns | 0.0625 ns | 0.0057 |      24 B |
|        DelegateVirtual | 4.177 ns | 0.0448 ns | 0.0657 ns | 0.0057 |      24 B |
|  DelegateVirtualInline | 3.896 ns | 0.0327 ns | 0.0479 ns | 0.0057 |      24 B |
|         DelegateSealed | 3.891 ns | 0.0498 ns | 0.0745 ns | 0.0057 |      24 B |
|   DelegateSealedInline | 3.814 ns | 0.0652 ns | 0.0956 ns | 0.0057 |      24 B |
