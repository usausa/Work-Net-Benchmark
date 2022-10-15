``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19042.928 (20H2/October2020Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.203
  [Host]   : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  ShortRun : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT

Job=ShortRun  IterationCount=3  LaunchCount=1  
WarmupCount=3  

```
|        Method |      Mean |    Error |    StdDev |       Min |       Max |       P90 |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|-------------- |----------:|---------:|----------:|----------:|----------:|----------:|-------:|------:|------:|----------:|
|       Default |  3.583 ns | 1.260 ns | 0.0691 ns |  3.511 ns |  3.649 ns |  3.637 ns | 0.0019 |     - |     - |      32 B |
|     Capacity1 |  8.152 ns | 4.963 ns | 0.2721 ns |  7.898 ns |  8.439 ns |  8.375 ns | 0.0038 |     - |     - |      64 B |
|     Capacity2 |  8.103 ns | 2.238 ns | 0.1227 ns |  8.001 ns |  8.239 ns |  8.205 ns | 0.0043 |     - |     - |      72 B |
|   DefaultAdd1 | 13.879 ns | 2.203 ns | 0.1207 ns | 13.776 ns | 14.012 ns | 13.980 ns | 0.0052 |     - |     - |      88 B |
| Capacity1Add1 |  8.440 ns | 3.608 ns | 0.1978 ns |  8.316 ns |  8.668 ns |  8.601 ns | 0.0038 |     - |     - |      64 B |
| Capacity2Add1 |  8.779 ns | 2.040 ns | 0.1118 ns |  8.650 ns |  8.849 ns |  8.846 ns | 0.0043 |     - |     - |      72 B |
|   DefaultAdd2 | 22.633 ns | 6.152 ns | 0.3372 ns | 22.358 ns | 23.009 ns | 22.914 ns | 0.0062 |     - |     - |     104 B |
| Capacity1Add2 | 22.538 ns | 1.380 ns | 0.0756 ns | 22.491 ns | 22.625 ns | 22.600 ns | 0.0062 |     - |     - |     104 B |
| Capacity2Add2 |  8.942 ns | 3.568 ns | 0.1955 ns |  8.797 ns |  9.164 ns |  9.104 ns | 0.0043 |     - |     - |      72 B |
|   DefaultAdd3 | 14.306 ns | 1.386 ns | 0.0760 ns | 14.225 ns | 14.375 ns | 14.364 ns | 0.0052 |     - |     - |      88 B |
| Capacity1Add3 | 38.053 ns | 9.234 ns | 0.5061 ns | 37.472 ns | 38.399 ns | 38.377 ns | 0.0095 |     - |     - |     160 B |
| Capacity2Add3 | 23.922 ns | 4.914 ns | 0.2694 ns | 23.715 ns | 24.227 ns | 24.146 ns | 0.0076 |     - |     - |     128 B |
