``` ini

BenchmarkDotNet=v0.10.14, OS=Windows 10.0.17763
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]    : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  MediumRun : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

Job=MediumRun  LaunchCount=2  TargetCount=15  
WarmupCount=10  

```
|                           Method |     Mean |      Error |     StdDev |   Median |  Gen 0 | Allocated |
|--------------------------------- |---------:|-----------:|-----------:|---------:|-------:|----------:|
|     DictionaryClassEquatableNull | 60.60 ns | 18.6570 ns | 27.9250 ns | 41.01 ns | 0.0076 |      32 B |
|  DictionaryClassEquatableProfile | 47.81 ns |  0.3786 ns |  0.5307 ns | 47.76 ns | 0.0076 |      32 B |
|      DictionaryClassComparerNull | 32.83 ns |  1.0913 ns |  1.6334 ns | 32.89 ns | 0.0076 |      32 B |
|   DictionaryClassComparerProfile | 41.32 ns |  0.5171 ns |  0.7580 ns | 41.09 ns | 0.0076 |      32 B |
|    DictionaryStructEquatableNull | 32.35 ns |  0.3166 ns |  0.4540 ns | 32.18 ns |      - |       0 B |
| DictionaryStructEquatableProfile | 41.00 ns |  0.9654 ns |  1.4450 ns | 41.19 ns |      - |       0 B |
|     DictionaryStructComparerNull | 40.15 ns |  0.4595 ns |  0.6878 ns | 40.27 ns |      - |       0 B |
|  DictionaryStructComparerProfile | 47.51 ns |  0.7028 ns |  1.0079 ns | 47.79 ns |      - |       0 B |
|           HashClassEquatableNull | 20.85 ns |  0.2954 ns |  0.4422 ns | 20.92 ns | 0.0076 |      32 B |
|        HashClassEquatableProfile | 29.49 ns |  0.3616 ns |  0.5413 ns | 29.44 ns | 0.0076 |      32 B |
|            HashClassComparerNull | 17.44 ns |  0.2037 ns |  0.2985 ns | 17.31 ns | 0.0076 |      32 B |
|         HashClassComparerProfile | 26.17 ns |  0.3486 ns |  0.4999 ns | 25.98 ns | 0.0076 |      32 B |
|          HashStructEquatableNull | 19.67 ns |  0.1677 ns |  0.2510 ns | 19.59 ns |      - |       0 B |
|       HashStructEquatableProfile | 25.91 ns |  0.2046 ns |  0.3062 ns | 25.85 ns |      - |       0 B |
|           HashStructComparerNull | 20.11 ns |  0.1316 ns |  0.1970 ns | 20.05 ns |      - |       0 B |
|        HashStructComparerProfile | 26.74 ns |  0.1326 ns |  0.1985 ns | 26.78 ns |      - |       0 B |
