``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-4771 CPU 3.50GHz (Haswell), 1 CPU, 8 logical and 4 physical cores
.NET Core SDK=5.0.100
  [Host]    : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT
  MediumRun : .NET Core 5.0.0 (CoreCLR 5.0.20.51904, CoreFX 5.0.20.51904), X64 RyuJIT

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  

```
|                       Method |         Mean |      Error |     StdDev |          Min |          Max |          P90 | Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|------:|------:|------:|----------:|
|                   ReadArray4 |     1.634 ns |  0.0200 ns |  0.0300 ns |     1.582 ns |     1.697 ns |     1.672 ns |     - |     - |     - |         - |
|             ReadArrayAsSpan4 |     2.232 ns |  0.0329 ns |  0.0492 ns |     2.144 ns |     2.337 ns |     2.295 ns |     - |     - |     - |         - |
|          ReadArrayByPointer4 |     2.384 ns |  0.0379 ns |  0.0567 ns |     2.273 ns |     2.502 ns |     2.449 ns |     - |     - |     - |         - |
|    ReadArrayAsSpanByPointer4 |     2.538 ns |  0.0757 ns |  0.1086 ns |     2.367 ns |     2.724 ns |     2.679 ns |     - |     - |     - |         - |
|             ReadNativeArray4 |     2.488 ns |  0.0488 ns |  0.0700 ns |     2.411 ns |     2.618 ns |     2.599 ns |     - |     - |     - |         - |
|                  ReadArray16 |     6.918 ns |  0.0652 ns |  0.0976 ns |     6.698 ns |     7.103 ns |     7.054 ns |     - |     - |     - |         - |
|            ReadArrayAsSpan16 |     7.277 ns |  0.0626 ns |  0.0918 ns |     7.125 ns |     7.451 ns |     7.373 ns |     - |     - |     - |         - |
|         ReadArrayByPointer16 |     8.696 ns |  0.0725 ns |  0.1040 ns |     8.508 ns |     8.936 ns |     8.814 ns |     - |     - |     - |         - |
|   ReadArrayAsSpanByPointer16 |     7.968 ns |  0.1083 ns |  0.1621 ns |     7.660 ns |     8.286 ns |     8.189 ns |     - |     - |     - |         - |
|            ReadNativeArray16 |     9.717 ns |  0.0752 ns |  0.1079 ns |     9.545 ns |     9.949 ns |     9.858 ns |     - |     - |     - |         - |
|                  ReadArray64 |    29.145 ns |  0.2473 ns |  0.3701 ns |    28.423 ns |    30.084 ns |    29.535 ns |     - |     - |     - |         - |
|            ReadArrayAsSpan64 |    28.133 ns |  0.1938 ns |  0.2841 ns |    27.587 ns |    28.577 ns |    28.495 ns |     - |     - |     - |         - |
|         ReadArrayByPointer64 |    33.339 ns |  0.6449 ns |  0.9453 ns |    31.632 ns |    34.942 ns |    34.377 ns |     - |     - |     - |         - |
|   ReadArrayAsSpanByPointer64 |    34.587 ns |  0.2380 ns |  0.3488 ns |    34.070 ns |    35.391 ns |    34.973 ns |     - |     - |     - |         - |
|            ReadNativeArray64 |    42.130 ns |  0.9269 ns |  1.3294 ns |    40.252 ns |    45.242 ns |    43.809 ns |     - |     - |     - |         - |
|                 ReadArray256 |    83.332 ns |  0.6248 ns |  0.9351 ns |    81.646 ns |    85.387 ns |    84.402 ns |     - |     - |     - |         - |
|           ReadArrayAsSpan256 |    83.546 ns |  0.6044 ns |  0.9046 ns |    81.942 ns |    85.514 ns |    84.466 ns |     - |     - |     - |         - |
|        ReadArrayByPointer256 |   113.724 ns |  0.6267 ns |  0.9187 ns |   111.649 ns |   114.982 ns |   114.639 ns |     - |     - |     - |         - |
|  ReadArrayAsSpanByPointer256 |   113.342 ns |  0.6986 ns |  1.0456 ns |   111.568 ns |   115.738 ns |   114.493 ns |     - |     - |     - |         - |
|           ReadNativeArray256 | 1,335.747 ns | 10.4811 ns | 15.3631 ns | 1,305.652 ns | 1,370.372 ns | 1,352.445 ns |     - |     - |     - |         - |
|                  WriteArray4 |     1.523 ns |  0.0234 ns |  0.0343 ns |     1.461 ns |     1.583 ns |     1.561 ns |     - |     - |     - |         - |
|            WriteArrayAsSpan4 |     2.754 ns |  0.0328 ns |  0.0491 ns |     2.641 ns |     2.852 ns |     2.810 ns |     - |     - |     - |         - |
|         WriteArrayByPointer4 |     2.572 ns |  0.0709 ns |  0.1061 ns |     2.379 ns |     2.702 ns |     2.699 ns |     - |     - |     - |         - |
|   WriteArrayAsSpanByPointer4 |     2.525 ns |  0.0855 ns |  0.1253 ns |     2.315 ns |     2.711 ns |     2.676 ns |     - |     - |     - |         - |
|            WriteNativeArray4 |     2.018 ns |  0.0545 ns |  0.0799 ns |     1.875 ns |     2.199 ns |     2.118 ns |     - |     - |     - |         - |
|                 WriteArray16 |     6.797 ns |  0.0676 ns |  0.1011 ns |     6.583 ns |     6.981 ns |     6.898 ns |     - |     - |     - |         - |
|           WriteArrayAsSpan16 |     9.843 ns |  0.1111 ns |  0.1594 ns |     9.594 ns |    10.293 ns |    10.013 ns |     - |     - |     - |         - |
|        WriteArrayByPointer16 |     7.645 ns |  0.0713 ns |  0.1068 ns |     7.418 ns |     7.789 ns |     7.768 ns |     - |     - |     - |         - |
|  WriteArrayAsSpanByPointer16 |     7.553 ns |  0.1612 ns |  0.2312 ns |     7.133 ns |     7.947 ns |     7.793 ns |     - |     - |     - |         - |
|           WriteNativeArray16 |     9.487 ns |  0.2739 ns |  0.4100 ns |     8.897 ns |    10.041 ns |     9.943 ns |     - |     - |     - |         - |
|                 WriteArray64 |    40.645 ns |  0.2347 ns |  0.3513 ns |    39.698 ns |    41.237 ns |    41.125 ns |     - |     - |     - |         - |
|           WriteArrayAsSpan64 |    42.436 ns |  0.3812 ns |  0.5706 ns |    41.532 ns |    43.554 ns |    43.201 ns |     - |     - |     - |         - |
|        WriteArrayByPointer64 |    29.899 ns |  0.6519 ns |  0.9556 ns |    28.570 ns |    31.722 ns |    31.151 ns |     - |     - |     - |         - |
|  WriteArrayAsSpanByPointer64 |    28.736 ns |  0.3116 ns |  0.4469 ns |    27.692 ns |    29.562 ns |    29.220 ns |     - |     - |     - |         - |
|           WriteNativeArray64 |    40.519 ns |  0.4769 ns |  0.7138 ns |    39.356 ns |    41.797 ns |    41.459 ns |     - |     - |     - |         - |
|                WriteArray256 |   145.515 ns |  1.1136 ns |  1.6667 ns |   142.373 ns |   149.233 ns |   147.018 ns |     - |     - |     - |         - |
|          WriteArrayAsSpan256 |   147.616 ns |  1.1047 ns |  1.6535 ns |   143.904 ns |   150.085 ns |   149.719 ns |     - |     - |     - |         - |
|       WriteArrayByPointer256 |    86.809 ns |  0.7709 ns |  1.1538 ns |    84.816 ns |    89.655 ns |    88.088 ns |     - |     - |     - |         - |
| WriteArrayAsSpanByPointer256 |    86.311 ns |  0.7965 ns |  1.1922 ns |    83.915 ns |    89.021 ns |    87.904 ns |     - |     - |     - |         - |
|          WriteNativeArray256 | 1,232.746 ns | 11.7826 ns | 17.6356 ns | 1,197.556 ns | 1,276.077 ns | 1,251.010 ns |     - |     - |     - |         - |
