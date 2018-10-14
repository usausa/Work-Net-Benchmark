``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17763
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]    : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  MediumRun : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

Job=MediumRun  LaunchCount=2  TargetCount=15  
WarmupCount=10  

```
|             Method |      Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------------- |----------:|----------:|----------:|-------:|----------:|
|   CachedDictionary |  34.64 ns | 0.6332 ns | 0.9282 ns |      - |       0 B |
|  CachedDictionary2 |  39.59 ns | 0.6243 ns | 0.8953 ns |      - |       0 B |
|  CachedDictionary3 |  37.42 ns | 0.3393 ns | 0.4973 ns |      - |       0 B |
|  CachedDictionaryS |  56.24 ns | 1.6764 ns | 2.4572 ns | 0.0076 |      32 B |
| CachedDictionary2S |  48.90 ns | 0.8578 ns | 1.2574 ns |      - |       0 B |
| CachedDictionary3S |  60.46 ns | 0.7998 ns | 1.1971 ns | 0.0075 |      32 B |
|     CachedArrayMap |  21.74 ns | 0.1888 ns | 0.2825 ns |      - |       0 B |
|    CachedArrayMap2 |  27.16 ns | 0.2153 ns | 0.3156 ns |      - |       0 B |
|    CachedArrayMap3 |  26.19 ns | 0.1219 ns | 0.1748 ns |      - |       0 B |
|    CachedArrayMapS |  40.02 ns | 0.4367 ns | 0.6122 ns | 0.0076 |      32 B |
|   CachedArrayMap2S |  33.81 ns | 0.3470 ns | 0.4977 ns |      - |       0 B |
|   CachedArrayMap3S |  45.63 ns | 0.3456 ns | 0.5173 ns | 0.0076 |      32 B |
|    CachedArrayMapO |  13.71 ns | 0.7557 ns | 1.1311 ns |      - |       0 B |
|   CachedArrayMapO2 |  17.44 ns | 0.8978 ns | 1.2875 ns |      - |       0 B |
|   CachedArrayMapO3 |  18.24 ns | 0.4727 ns | 0.6627 ns |      - |       0 B |
|         Dictionary | 283.23 ns | 2.3372 ns | 3.4259 ns | 0.5951 |    2504 B |
|        Dictionary2 | 294.12 ns | 3.9693 ns | 5.9411 ns | 0.5951 |    2504 B |
|        Dictionary3 | 288.39 ns | 1.8712 ns | 2.7428 ns | 0.5951 |    2504 B |
|        DictionaryS | 276.91 ns | 3.4681 ns | 4.8618 ns | 0.5951 |    2504 B |
|       Dictionary2S | 271.26 ns | 2.7823 ns | 4.1645 ns | 0.5188 |    2184 B |
|       Dictionary3S | 287.81 ns | 2.3321 ns | 3.4906 ns | 0.5951 |    2504 B |
|           ArrayMap | 266.54 ns | 1.9757 ns | 2.9571 ns | 0.5951 |    2504 B |
|          ArrayMap2 | 277.17 ns | 2.4418 ns | 3.6547 ns | 0.5951 |    2504 B |
|          ArrayMap3 | 275.21 ns | 1.7637 ns | 2.6398 ns | 0.5951 |    2504 B |
|          ArrayMapS | 272.34 ns | 3.4759 ns | 4.9850 ns | 0.6180 |    2600 B |
|         ArrayMap2S | 265.26 ns | 1.3172 ns | 1.8891 ns | 0.5188 |    2184 B |
|         ArrayMap3S | 290.35 ns | 1.9182 ns | 2.8711 ns | 0.6180 |    2600 B |
|          ArrayMapO | 257.49 ns | 2.1821 ns | 3.1296 ns | 0.5951 |    2504 B |
|         ArrayMapO2 | 258.95 ns | 1.4783 ns | 2.1669 ns | 0.5951 |    2504 B |
|         ArrayMapO3 | 263.60 ns | 2.8528 ns | 4.1815 ns | 0.5951 |    2504 B |
