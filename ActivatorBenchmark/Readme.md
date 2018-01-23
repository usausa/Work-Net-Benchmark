``` ini

BenchmarkDotNet=v0.10.9, OS=Windows 10.0.16299
Processor=Intel Core i7-4771 CPU 3.50GHz (Haswell), ProcessorCount=8
Frequency=3415990 Hz, Resolution=292.7409 ns, Timer=TSC
.NET Core SDK=2.1.4
  [Host]   : .NET Core 2.0.5 (Framework 4.6.26020.03), 64bit RyuJIT
  ShortRun : .NET Core 2.0.5 (Framework 4.6.26020.03), 64bit RyuJIT

Job=ShortRun  LaunchCount=1  TargetCount=3  
WarmupCount=3  

```
 |                        Method |         Mean |       Error |    StdDev |  Gen 0 | Allocated |
 |------------------------------ |-------------:|------------:|----------:|-------:|----------:|
 |                 NewActivator0 |     3.725 ns |   0.5491 ns | 0.0310 ns | 0.0057 |      24 B |
 |      ReflactionCtorActivator0 |   121.955 ns |  17.8064 ns | 1.0061 ns | 0.0055 |      24 B |
 | ReflectionActivatorActivator0 |    48.965 ns |   6.9948 ns | 0.3952 ns | 0.0057 |      24 B |
 |  ExpressionDelegateActivator0 |     4.140 ns |   1.3665 ns | 0.0772 ns | 0.0057 |      24 B |
 |        EmitDelegateActivator0 |     5.250 ns |   3.0814 ns | 0.1741 ns | 0.0057 |      24 B |
 |                EmitActivator0 |     3.734 ns |   1.6805 ns | 0.0950 ns | 0.0057 |      24 B |
 |             ExpressionDirect0 |     3.146 ns |   1.1807 ns | 0.0667 ns | 0.0057 |      24 B |
 |                   EmitDirect0 |     4.131 ns |   2.1635 ns | 0.1222 ns | 0.0057 |      24 B |
 |                 EmitIndirect0 |     3.919 ns |   2.2928 ns | 0.1295 ns | 0.0057 |      24 B |
 |                 NewActivator1 |     4.305 ns |   0.1877 ns | 0.0106 ns | 0.0057 |      24 B |
 |      ReflactionCtorActivator1 |   200.705 ns |  16.1349 ns | 0.9117 ns | 0.0131 |      56 B |
 | ReflectionActivatorActivator1 |   608.902 ns | 163.7097 ns | 9.2499 ns | 0.0906 |     384 B |
 |  ExpressionDelegateActivator1 |     4.858 ns |   0.9647 ns | 0.0545 ns | 0.0057 |      24 B |
 |        EmitDelegateActivator1 |     5.739 ns |   1.6867 ns | 0.0953 ns | 0.0057 |      24 B |
 |                EmitActivator1 |     4.660 ns |   1.5499 ns | 0.0876 ns | 0.0057 |      24 B |
 |             ExpressionDirect1 |     3.511 ns |   1.3458 ns | 0.0760 ns | 0.0057 |      24 B |
 |                   EmitDirect1 |     4.431 ns |   2.7331 ns | 0.1544 ns | 0.0057 |      24 B |
 |                 EmitIndirect1 |     4.600 ns |   0.9476 ns | 0.0535 ns | 0.0057 |      24 B |
 |                 NewActivator8 |    11.137 ns |   1.7284 ns | 0.0977 ns | 0.0114 |      48 B |
 |      ReflactionCtorActivator8 |   582.627 ns | 158.7625 ns | 8.9704 ns | 0.0315 |     136 B |
 | ReflectionActivatorActivator8 | 1,354.474 ns | 128.0155 ns | 7.2331 ns | 0.1411 |     600 B |
 |  ExpressionDelegateActivator8 |    11.784 ns |   3.9081 ns | 0.2208 ns | 0.0114 |      48 B |
 |        EmitDelegateActivator8 |    12.896 ns |   3.4816 ns | 0.1967 ns | 0.0114 |      48 B |
 |                EmitActivator8 |    11.492 ns |   1.6449 ns | 0.0929 ns | 0.0114 |      48 B |
 |             ExpressionDirect8 |     9.896 ns |   2.5044 ns | 0.1415 ns | 0.0114 |      48 B |
 |                   EmitDirect8 |    11.068 ns |   2.9906 ns | 0.1690 ns | 0.0114 |      48 B |
 |                 EmitIndirect8 |    11.491 ns |   3.0751 ns | 0.1737 ns | 0.0114 |      48 B |
