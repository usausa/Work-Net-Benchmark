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
|                 Method |     Mean |     Error |    StdDev |   Median |  Gen 0 | Allocated |
|----------------------- |---------:|----------:|----------:|---------:|-------:|----------:|
|          FactoryStatic | 3.025 ns | 0.0665 ns | 0.0933 ns | 3.018 ns | 0.0057 |      24 B |
|    FactoryStaticInline | 4.139 ns | 0.0361 ns | 0.0540 ns | 4.133 ns | 0.0057 |      24 B |
|        FactoryInstance | 3.153 ns | 0.0381 ns | 0.0559 ns | 3.142 ns | 0.0057 |      24 B |
|  FactoryInstanceInline | 4.173 ns | 0.0449 ns | 0.0658 ns | 4.158 ns | 0.0057 |      24 B |
|         FactoryVirtual | 4.526 ns | 0.0484 ns | 0.0710 ns | 4.544 ns | 0.0057 |      24 B |
|   FactoryVirtualInline | 4.674 ns | 0.0374 ns | 0.0524 ns | 4.668 ns | 0.0057 |      24 B |
|          FactorySealed | 4.559 ns | 0.0470 ns | 0.0689 ns | 4.559 ns | 0.0057 |      24 B |
|    FactorySealedInline | 4.480 ns | 0.0431 ns | 0.0632 ns | 4.478 ns | 0.0057 |      24 B |
|         DelegateStatic | 5.043 ns | 0.0567 ns | 0.0813 ns | 5.028 ns | 0.0057 |      24 B |
|   DelegateStaticInline | 5.262 ns | 0.0424 ns | 0.0622 ns | 5.251 ns | 0.0057 |      24 B |
|       DelegateInstance | 4.276 ns | 0.0374 ns | 0.0525 ns | 4.277 ns | 0.0057 |      24 B |
| DelegateInstanceInline | 4.186 ns | 0.0405 ns | 0.0593 ns | 4.191 ns | 0.0057 |      24 B |
|        DelegateVirtual | 4.192 ns | 0.0340 ns | 0.0498 ns | 4.191 ns | 0.0057 |      24 B |
|  DelegateVirtualInline | 4.438 ns | 0.0349 ns | 0.0523 ns | 4.438 ns | 0.0057 |      24 B |
|         DelegateSealed | 4.293 ns | 0.0555 ns | 0.0796 ns | 4.290 ns | 0.0057 |      24 B |
|   DelegateSealedInline | 4.205 ns | 0.0546 ns | 0.0800 ns | 4.172 ns | 0.0057 |      24 B |
