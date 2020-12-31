``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET Core SDK=5.0.101
  [Host]   : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT
  ShortRun : .NET Core 5.0.1 (CoreCLR 5.0.120.57516, CoreFX 5.0.120.57516), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|                       Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|------:|------:|------:|----------:|
|                  ByNodeLink1 | 0.4254 ns | 0.0061 ns | 0.0003 ns | 0.4250 ns | 0.4256 ns | 0.4256 ns |     - |     - |     - |         - |
|      ByStructEntryArrayLoop1 | 2.9593 ns | 0.0368 ns | 0.0020 ns | 2.9576 ns | 2.9616 ns | 2.9610 ns |     - |     - |     - |         - |
|      ByStructEntryArrayEach1 | 2.9537 ns | 0.0660 ns | 0.0036 ns | 2.9504 ns | 2.9575 ns | 2.9567 ns |     - |     - |     - |         - |
| ByStructEntryReferenceWhile1 | 3.1513 ns | 0.0651 ns | 0.0036 ns | 3.1479 ns | 3.1550 ns | 3.1542 ns |     - |     - |     - |         - |
|   ByStructEntryReferenceFor1 | 3.1530 ns | 0.0360 ns | 0.0020 ns | 3.1510 ns | 3.1550 ns | 3.1546 ns |     - |     - |     - |         - |
|       ByClassEntryArrayLoop1 | 2.9476 ns | 0.0958 ns | 0.0053 ns | 2.9426 ns | 2.9531 ns | 2.9519 ns |     - |     - |     - |         - |
|       ByClassEntryArrayEach1 | 2.9500 ns | 0.0386 ns | 0.0021 ns | 2.9482 ns | 2.9523 ns | 2.9518 ns |     - |     - |     - |         - |
|  ByClassEntryReferenceWhile1 | 3.3463 ns | 0.1505 ns | 0.0082 ns | 3.3394 ns | 3.3554 ns | 3.3531 ns |     - |     - |     - |         - |
|    ByClassEntryReferenceFor1 | 3.1569 ns | 0.0461 ns | 0.0025 ns | 3.1540 ns | 3.1586 ns | 3.1585 ns |     - |     - |     - |         - |
|                  ByNodeLink2 | 0.6346 ns | 0.0128 ns | 0.0007 ns | 0.6340 ns | 0.6354 ns | 0.6352 ns |     - |     - |     - |         - |
|      ByStructEntryArrayLoop2 | 4.2188 ns | 0.1231 ns | 0.0068 ns | 4.2116 ns | 4.2249 ns | 4.2240 ns |     - |     - |     - |         - |
|      ByStructEntryArrayEach2 | 4.2207 ns | 0.0623 ns | 0.0034 ns | 4.2176 ns | 4.2243 ns | 4.2235 ns |     - |     - |     - |         - |
| ByStructEntryReferenceWhile2 | 4.2037 ns | 0.1041 ns | 0.0057 ns | 4.1997 ns | 4.2103 ns | 4.2085 ns |     - |     - |     - |         - |
|   ByStructEntryReferenceFor2 | 4.2063 ns | 0.0957 ns | 0.0052 ns | 4.2003 ns | 4.2098 ns | 4.2096 ns |     - |     - |     - |         - |
|       ByClassEntryArrayLoop2 | 4.1971 ns | 0.2018 ns | 0.0111 ns | 4.1876 ns | 4.2092 ns | 4.2062 ns |     - |     - |     - |         - |
|       ByClassEntryArrayEach2 | 4.2077 ns | 0.0809 ns | 0.0044 ns | 4.2028 ns | 4.2116 ns | 4.2110 ns |     - |     - |     - |         - |
|  ByClassEntryReferenceWhile2 | 4.4123 ns | 0.3185 ns | 0.0175 ns | 4.3921 ns | 4.4224 ns | 4.4224 ns |     - |     - |     - |         - |
|    ByClassEntryReferenceFor2 | 4.2192 ns | 0.0526 ns | 0.0029 ns | 4.2168 ns | 4.2224 ns | 4.2216 ns |     - |     - |     - |         - |
