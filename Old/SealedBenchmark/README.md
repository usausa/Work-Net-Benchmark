``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.675)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]    : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2
  MediumRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT AVX2

Job=MediumRun  Jit=RyuJit  Platform=X64  
Runtime=.NET 6.0  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                              Method |      Mean |     Error |    StdDev |    Median |       Min |       Max |       P90 | Code Size |   Gen0 | Allocated |
|------------------------------------ |----------:|----------:|----------:|----------:|----------:|----------:|----------:|----------:|-------:|----------:|
|              InvokeNonSealedDerived | 1.2067 ns | 0.0734 ns | 0.1052 ns | 1.2053 ns | 1.0916 ns | 1.3324 ns | 1.3188 ns |      44 B |      - |         - |
|                 InvokeSealedDerived | 0.2225 ns | 0.0017 ns | 0.0024 ns | 0.2220 ns | 0.2189 ns | 0.2286 ns | 0.2255 ns |      51 B |      - |         - |
|            InvokeNonSealedImplement | 0.2225 ns | 0.0009 ns | 0.0012 ns | 0.2228 ns | 0.2202 ns | 0.2241 ns | 0.2239 ns |      51 B |      - |         - |
|               InvokeSealedImplement | 0.2222 ns | 0.0013 ns | 0.0018 ns | 0.2220 ns | 0.2197 ns | 0.2270 ns | 0.2241 ns |      51 B |      - |         - |
|        InvokeNonSealedDerivedAsBase | 1.0927 ns | 0.0058 ns | 0.0082 ns | 1.0912 ns | 1.0810 ns | 1.1150 ns | 1.1026 ns |      44 B |      - |         - |
|           InvokeSealedDerivedAsBase | 0.2234 ns | 0.0026 ns | 0.0038 ns | 0.2232 ns | 0.2187 ns | 0.2359 ns | 0.2285 ns |      51 B |      - |         - |
|                 InvokeNonSealedBase | 1.0911 ns | 0.0045 ns | 0.0066 ns | 1.0907 ns | 1.0803 ns | 1.1073 ns | 1.0983 ns |      44 B |      - |         - |
|                    InvokeSealedBase | 1.2010 ns | 0.0797 ns | 0.1117 ns | 1.2925 ns | 1.0782 ns | 1.3220 ns | 1.3111 ns |      44 B |      - |         - |
| InvokeNonSealedImplementAsInterface | 1.3131 ns | 0.0096 ns | 0.0135 ns | 1.3095 ns | 1.2994 ns | 1.3487 ns | 1.3382 ns |      48 B |      - |         - |
|    InvokeSealedImplementAsInterface | 0.2218 ns | 0.0020 ns | 0.0030 ns | 0.2209 ns | 0.2187 ns | 0.2298 ns | 0.2263 ns |      51 B |      - |         - |
|            InvokeNonSealedInterface | 1.4779 ns | 0.1182 ns | 0.1695 ns | 1.5262 ns | 1.3023 ns | 1.7345 ns | 1.7100 ns |      48 B |      - |         - |
|               InvokeSealedInterface | 1.4311 ns | 0.0751 ns | 0.1077 ns | 1.5156 ns | 1.3008 ns | 1.5469 ns | 1.5345 ns |      48 B |      - |         - |
|        InvokeNonSealedDerivedAsFunc | 1.3290 ns | 0.0055 ns | 0.0076 ns | 1.3292 ns | 1.3157 ns | 1.3481 ns | 1.3373 ns |     117 B | 0.0000 |         - |
|           InvokeSealedDerivedAsFunc | 1.4430 ns | 0.0759 ns | 0.1088 ns | 1.5272 ns | 1.3157 ns | 1.5565 ns | 1.5496 ns |     117 B | 0.0000 |         - |
|      InvokeNonSealedImplementAsFunc | 1.4248 ns | 0.0714 ns | 0.1047 ns | 1.3620 ns | 1.3029 ns | 1.5551 ns | 1.5362 ns |     108 B | 0.0000 |         - |
|         InvokeSealedImplementAsFunc | 1.4309 ns | 0.0760 ns | 0.1114 ns | 1.3659 ns | 1.3088 ns | 1.5811 ns | 1.5495 ns |     108 B | 0.0000 |         - |
