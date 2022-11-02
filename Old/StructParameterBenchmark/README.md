``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK=6.0.402
  [Host]    : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT
  MediumRun : .NET 6.0.10 (6.0.1022.47605), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                   Method |       Mean |     Error |    StdDev |     Median |        Min |        Max |        P90 | Allocated |
|------------------------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|
|       UpdateHolderValue3 |  0.6052 ns | 0.0380 ns | 0.0532 ns |  0.6531 ns |  0.5483 ns |  0.6596 ns |  0.6573 ns |         - |
|  UpdateHolderValue3ByRef |  0.4405 ns | 0.0017 ns | 0.0022 ns |  0.4411 ns |  0.4373 ns |  0.4456 ns |  0.4428 ns |         - |
|       UpdateHolderValue8 |  7.6942 ns | 1.5617 ns | 2.3374 ns |  5.9180 ns |  5.6836 ns | 10.7263 ns | 10.6715 ns |         - |
|  UpdateHolderValue8ByRef |  1.5449 ns | 0.0095 ns | 0.0137 ns |  1.5437 ns |  1.5068 ns |  1.5720 ns |  1.5601 ns |         - |
|              CallDecimal | 12.9450 ns | 0.0286 ns | 0.0410 ns | 12.9483 ns | 12.8775 ns | 13.0168 ns | 12.9901 ns |         - |
|            CallDecimalIn |  6.5071 ns | 0.0311 ns | 0.0466 ns |  6.5091 ns |  6.4374 ns |  6.6057 ns |  6.5725 ns |         - |
|               CallValue3 |  1.4650 ns | 0.0787 ns | 0.1154 ns |  1.5453 ns |  1.3274 ns |  1.6226 ns |  1.5907 ns |         - |
|             CallValue3In |  1.3407 ns | 0.0084 ns | 0.0123 ns |  1.3382 ns |  1.3206 ns |  1.3736 ns |  1.3568 ns |         - |
|    CallReadonlyRefValue3 |  1.3484 ns | 0.0136 ns | 0.0199 ns |  1.3455 ns |  1.3140 ns |  1.3965 ns |  1.3708 ns |         - |
| CallReadonlyRefValue3Ref |  1.4097 ns | 0.0778 ns | 0.1039 ns |  1.3350 ns |  1.2954 ns |  1.5236 ns |  1.5206 ns |         - |
|               CallValue8 |  1.9721 ns | 0.0153 ns | 0.0214 ns |  1.9673 ns |  1.9457 ns |  2.0277 ns |  1.9967 ns |         - |
|             CallValue8In |  1.4002 ns | 0.0744 ns | 0.1043 ns |  1.3417 ns |  1.2869 ns |  1.5146 ns |  1.5084 ns |         - |
|    CallReadonlyRefValue8 |  1.9485 ns | 0.0032 ns | 0.0043 ns |  1.9478 ns |  1.9398 ns |  1.9586 ns |  1.9545 ns |         - |
| CallReadonlyRefValue8Ref |  1.3989 ns | 0.0727 ns | 0.1043 ns |  1.3353 ns |  1.2872 ns |  1.5202 ns |  1.5125 ns |         - |
