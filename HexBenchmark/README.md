``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.900)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=7.0.101
  [Host]    : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2
  MediumRun : .NET 7.0.1 (7.0.122.56804), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                        Method | Categories |     Mean |    Error |   StdDev |      Min |      Max |      P90 |   Gen0 | Code Size |   Gen1 | Allocated |
|------------------------------ |----------- |---------:|---------:|---------:|---------:|---------:|---------:|-------:|----------:|-------:|----------:|
|       DecodeByPointerToIndex1 |    Decode1 | 374.5 ns |  1.67 ns |  2.34 ns | 370.4 ns | 380.9 ns | 377.6 ns | 0.0167 |     304 B |      - |     280 B |
|     DecodeByPointerToPointer1 |    Decode1 | 328.3 ns | 31.33 ns | 46.90 ns | 275.3 ns | 383.2 ns | 376.6 ns | 0.0167 |     342 B |      - |     280 B |
|     DecodeByReferenceToIndex1 |    Decode1 | 276.6 ns |  3.29 ns |  4.82 ns | 270.8 ns | 289.6 ns | 283.4 ns | 0.0167 |     285 B |      - |     280 B |
| DecodeByReferenceToReference1 |    Decode1 | 319.7 ns | 28.77 ns | 39.38 ns | 278.8 ns | 360.9 ns | 360.0 ns | 0.0167 |     290 B |      - |     280 B |
|                               |            |          |          |          |          |          |          |        |           |        |           |
|       DecodeByPointerToIndex2 |    Decode2 | 316.6 ns |  4.14 ns |  6.19 ns | 308.9 ns | 330.4 ns | 325.6 ns |      - |     382 B |      - |         - |
|     DecodeByPointerToPointer2 |    Decode2 | 350.5 ns | 34.61 ns | 49.63 ns | 298.4 ns | 402.3 ns | 401.2 ns |      - |     407 B |      - |         - |
|     DecodeByReferenceToIndex2 |    Decode2 | 298.0 ns |  3.71 ns |  5.55 ns | 289.5 ns | 311.3 ns | 304.8 ns |      - |     363 B |      - |         - |
| DecodeByReferenceToReference2 |    Decode2 | 301.9 ns |  3.32 ns |  4.87 ns | 295.0 ns | 315.9 ns | 309.4 ns |      - |     338 B |      - |         - |
|                               |            |          |          |          |          |          |          |        |           |        |           |
|       EncodeByIndexToPointer1 |    Encode1 | 231.5 ns |  2.35 ns |  3.29 ns | 227.1 ns | 241.1 ns | 235.8 ns | 0.1252 |     435 B | 0.0005 |    2096 B |
|     EncodeByIndexToReference1 |    Encode1 | 228.4 ns |  2.29 ns |  3.36 ns | 219.7 ns | 234.6 ns | 232.0 ns | 0.1252 |     416 B | 0.0007 |    2096 B |
|       EncodeByPointerToIndex1 |    Encode1 | 304.4 ns |  4.33 ns |  6.34 ns | 294.2 ns | 321.8 ns | 311.0 ns | 0.1249 |     443 B | 0.0005 |    2096 B |
|     EncodeByPointerToPointer1 |    Encode1 | 247.6 ns |  2.52 ns |  3.62 ns | 241.6 ns | 257.2 ns | 252.5 ns | 0.1249 |     443 B | 0.0005 |    2096 B |
|     EncodeByReferenceToIndex1 |    Encode1 | 261.8 ns |  2.09 ns |  3.00 ns | 255.8 ns | 268.4 ns | 265.9 ns | 0.1249 |     430 B | 0.0005 |    2096 B |
| EncodeByReferenceToReference1 |    Encode1 | 237.4 ns |  2.39 ns |  3.35 ns | 232.4 ns | 244.6 ns | 241.4 ns | 0.1252 |     415 B | 0.0007 |    2096 B |
|                               |            |          |          |          |          |          |          |        |           |        |           |
|       EncodeByIndexToPointer2 |    Encode2 | 176.6 ns |  1.03 ns |  1.48 ns | 174.8 ns | 180.2 ns | 178.9 ns |      - |     299 B |      - |         - |
|     EncodeByIndexToReference2 |    Encode2 | 176.0 ns |  0.75 ns |  1.08 ns | 174.1 ns | 177.6 ns | 177.3 ns |      - |     254 B |      - |         - |
|       EncodeByPointerToIndex2 |    Encode2 | 210.0 ns |  1.26 ns |  1.81 ns | 207.6 ns | 214.3 ns | 212.7 ns |      - |     313 B |      - |         - |
|     EncodeByPointerToPointer2 |    Encode2 | 184.7 ns |  0.65 ns |  0.91 ns | 183.5 ns | 187.4 ns | 185.9 ns |      - |     313 B |      - |         - |
|     EncodeByReferenceToIndex2 |    Encode2 | 246.5 ns |  1.95 ns |  2.92 ns | 242.1 ns | 252.8 ns | 250.0 ns |      - |     294 B |      - |         - |
| EncodeByReferenceToReference2 |    Encode2 | 184.8 ns |  1.04 ns |  1.49 ns | 182.6 ns | 187.9 ns | 187.2 ns |      - |     256 B |      - |         - |
