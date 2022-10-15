``` ini

BenchmarkDotNet=v0.11.1, OS=Windows 10.0.17763
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=2.1.402
  [Host]    : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT
  MediumRun : .NET Core 2.1.4 (CoreCLR 4.6.26814.03, CoreFX 4.6.26814.02), 64bit RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                        Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------------------------------ |---------:|----------:|----------:|-------:|----------:|
|            DictionaryClassKey | 38.82 us | 0.2088 us | 0.2858 us | 8.6670 |  35.73 KB |
|           DictionaryStructKey | 38.47 us | 0.2066 us | 0.2896 us | 7.9346 |   32.6 KB |
|   DictionaryEquatableClassKey | 39.15 us | 0.2628 us | 0.3852 us | 8.6670 |  35.73 KB |
|  DictionaryEquatableStructKey | 37.84 us | 0.2285 us | 0.3349 us | 7.9346 |   32.6 KB |
|  DictionaryEquatableClassKey2 | 39.68 us | 0.2535 us | 0.3795 us | 8.6670 |  35.73 KB |
| DictionaryEquatableStructKey2 | 38.24 us | 0.2312 us | 0.3389 us | 7.9346 |   32.6 KB |
|             HashArrayClassKey | 38.60 us | 1.0448 us | 1.4984 us | 8.6670 |  35.73 KB |
|            HashArrayStructKey | 37.41 us | 0.2177 us | 0.3259 us | 7.9346 |   32.6 KB |
|    HashArrayEquatableClassKey | 38.51 us | 0.3992 us | 0.5725 us | 8.6670 |  35.73 KB |
|   HashArrayEquatableStructKey | 37.49 us | 0.2385 us | 0.3570 us | 7.9346 |   32.6 KB |
|   HashArrayEquatableClassKey2 | 38.55 us | 0.2356 us | 0.3302 us | 8.6670 |  35.73 KB |
|  HashArrayEquatableStructKey2 | 38.59 us | 0.3932 us | 0.5885 us | 7.9346 |   32.6 KB |
