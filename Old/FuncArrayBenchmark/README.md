``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1165 (21H1/May2021Update)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=5.0.400
  [Host]    : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  MediumRun : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                               Method |      Mean |     Error |    StdDev |       Min |       Max |       P90 | Allocated |
|------------------------------------- |----------:|----------:|----------:|----------:|----------:|----------:|----------:|
|                         ArrayCaller4 |  8.244 ns | 0.2056 ns | 0.3077 ns |  7.876 ns |  8.683 ns |  8.586 ns |         - |
|                   ArrayCachedCaller4 |  7.211 ns | 0.0092 ns | 0.0123 ns |  7.186 ns |  7.236 ns |  7.227 ns |         - |
|               ArrayIndividualCaller4 |  6.878 ns | 0.2657 ns | 0.3637 ns |  6.342 ns |  7.392 ns |  7.332 ns |         - |
|         ArrayCachedIndividualCaller4 |  6.120 ns | 0.0068 ns | 0.0099 ns |  6.098 ns |  6.139 ns |  6.130 ns |         - |
|  ReverseArrayCachedIndividualCaller4 |  6.115 ns | 0.0057 ns | 0.0077 ns |  6.100 ns |  6.131 ns |  6.123 ns |         - |
|                    IndividualCaller4 |  6.107 ns | 0.0123 ns | 0.0173 ns |  6.089 ns |  6.160 ns |  6.130 ns |         - |
|                         ArrayCaller8 | 15.828 ns | 0.3626 ns | 0.5427 ns | 14.687 ns | 16.504 ns | 16.202 ns |         - |
|                   ArrayCachedCaller8 | 13.205 ns | 0.0326 ns | 0.0446 ns | 13.149 ns | 13.291 ns | 13.261 ns |         - |
|               ArrayIndividualCaller8 | 19.192 ns | 0.1678 ns | 0.2460 ns | 18.409 ns | 19.382 ns | 19.335 ns |         - |
|         ArrayCachedIndividualCaller8 | 11.701 ns | 0.2036 ns | 0.2920 ns | 11.409 ns | 12.376 ns | 12.137 ns |         - |
|  ReverseArrayCachedIndividualCaller8 | 11.444 ns | 0.0137 ns | 0.0201 ns | 11.411 ns | 11.502 ns | 11.472 ns |         - |
|                    IndividualCaller8 | 11.212 ns | 0.0082 ns | 0.0114 ns | 11.192 ns | 11.240 ns | 11.227 ns |         - |
|                        ArrayCaller16 | 31.426 ns | 0.6156 ns | 0.9214 ns | 28.365 ns | 32.135 ns | 32.093 ns |         - |
|                  ArrayCachedCaller16 | 25.070 ns | 0.0221 ns | 0.0303 ns | 25.004 ns | 25.130 ns | 25.114 ns |         - |
|              ArrayIndividualCaller16 | 22.351 ns | 0.0382 ns | 0.0560 ns | 22.296 ns | 22.552 ns | 22.423 ns |         - |
|        ArrayCachedIndividualCaller16 | 22.059 ns | 0.0155 ns | 0.0212 ns | 22.024 ns | 22.107 ns | 22.087 ns |         - |
| ReverseArrayCachedIndividualCaller16 | 21.620 ns | 0.0195 ns | 0.0266 ns | 21.572 ns | 21.673 ns | 21.651 ns |         - |
|                   IndividualCaller16 | 21.648 ns | 0.0191 ns | 0.0274 ns | 21.603 ns | 21.730 ns | 21.682 ns |         - |
