``` ini

BenchmarkDotNet=v0.12.0, OS=Windows 10.0.18363
Intel Core i5-9500 CPU 3.00GHz, 1 CPU, 6 logical and 6 physical cores
.NET Core SDK=3.1.101
  [Host]    : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT
  MediumRun : .NET Core 3.1.1 (CoreCLR 4.700.19.60701, CoreFX 4.700.19.60801), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                         Method |     Mean |     Error |    StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |---------:|----------:|----------:|---------:|------:|------:|------:|----------:|
|                     EqualsSame | 1.181 ns | 0.0084 ns | 0.0126 ns | 1.176 ns |     - |     - |     - |         - |
|               StringEqualsSame | 1.300 ns | 0.0830 ns | 0.1191 ns | 1.405 ns |     - |     - |     - |         - |
|        StringEqualsSameOrdinal | 1.641 ns | 0.0035 ns | 0.0051 ns | 1.642 ns |     - |     - |     - |         - |
|              EqualsNotSameLast | 3.823 ns | 0.0193 ns | 0.0276 ns | 3.821 ns |     - |     - |     - |         - |
|        StringEqualsNotSameLast | 3.788 ns | 0.0309 ns | 0.0463 ns | 3.771 ns |     - |     - |     - |         - |
| StringEqualsNotSameLastOrdinal | 4.796 ns | 0.0232 ns | 0.0341 ns | 4.794 ns |     - |     - |     - |         - |
|                    EqualsShort | 1.634 ns | 0.1614 ns | 0.2366 ns | 1.421 ns |     - |     - |     - |         - |
|              StringEqualsShort | 1.665 ns | 0.1704 ns | 0.2444 ns | 1.870 ns |     - |     - |     - |         - |
|       StringEqualsShortOrdinal | 3.359 ns | 0.0459 ns | 0.0686 ns | 3.356 ns |     - |     - |     - |         - |
|                     EqualsLong | 1.419 ns | 0.0035 ns | 0.0052 ns | 1.419 ns |     - |     - |     - |         - |
|               StringEqualsLong | 1.880 ns | 0.0045 ns | 0.0066 ns | 1.879 ns |     - |     - |     - |         - |
|        StringEqualsLongOrdinal | 3.343 ns | 0.0372 ns | 0.0545 ns | 3.316 ns |     - |     - |     - |         - |
|                     EqualsNull | 1.952 ns | 0.0045 ns | 0.0067 ns | 1.953 ns |     - |     - |     - |         - |
|               StringEqualsNull | 2.032 ns | 0.0551 ns | 0.0824 ns | 2.029 ns |     - |     - |     - |         - |
|        StringEqualsNullOrdinal | 1.881 ns | 0.0044 ns | 0.0062 ns | 1.882 ns |     - |     - |     - |         - |
