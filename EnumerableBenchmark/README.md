|                     Method |       Mean |      Error |     StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-----------:|-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|               ForeachListS |  10.997 ns |  0.1602 ns |  0.2246 ns |  11.150 ns |      - |     - |     - |         - |
|     ForeachListEnumerableS |  34.919 ns |  0.1823 ns |  0.2434 ns |  34.996 ns | 0.0085 |     - |     - |      40 B |
|            EnumeratorListS |  10.983 ns |  0.0299 ns |  0.0448 ns |  10.979 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListS |  35.114 ns |  0.1479 ns |  0.2214 ns |  35.067 ns | 0.0085 |     - |     - |      40 B |
|                   ForListS |   2.737 ns |  0.0141 ns |  0.0210 ns |   2.734 ns |      - |     - |     - |         - |
|            ForListGenericS |  15.186 ns |  0.0294 ns |  0.0422 ns |  15.198 ns |      - |     - |     - |         - |
|              ForIListListS |  15.418 ns |  0.2897 ns |  0.4061 ns |  15.630 ns |      - |     - |     - |         - |
|               ForeachListM |  78.624 ns |  0.2661 ns |  0.3816 ns |  78.753 ns |      - |     - |     - |         - |
|     ForeachListEnumerableM | 206.189 ns |  3.5769 ns |  5.0142 ns | 208.796 ns | 0.0083 |     - |     - |      40 B |
|            EnumeratorListM |  80.352 ns |  0.1914 ns |  0.2619 ns |  80.279 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListM | 207.981 ns |  4.0903 ns |  5.7340 ns | 205.386 ns | 0.0083 |     - |     - |      40 B |
|                   ForListM |  16.822 ns |  0.0588 ns |  0.0804 ns |  16.800 ns |      - |     - |     - |         - |
|            ForListGenericM | 121.377 ns |  0.4932 ns |  0.7073 ns | 121.293 ns |      - |     - |     - |         - |
|              ForIListListM | 120.145 ns |  0.1722 ns |  0.2525 ns | 120.120 ns |      - |     - |     - |         - |
|               ForeachListL | 282.027 ns |  1.2134 ns |  1.7010 ns | 281.270 ns |      - |     - |     - |         - |
|     ForeachListEnumerableL | 790.516 ns |  1.8733 ns |  2.6867 ns | 790.454 ns | 0.0076 |     - |     - |      40 B |
|            EnumeratorListL | 281.573 ns |  0.3489 ns |  0.5004 ns | 281.673 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListL | 787.712 ns |  1.9899 ns |  2.8539 ns | 788.048 ns | 0.0076 |     - |     - |      40 B |
|                   ForListL |  70.279 ns |  0.6165 ns |  0.9228 ns |  69.998 ns |      - |     - |     - |         - |
|            ForListGenericL | 458.601 ns |  0.8391 ns |  1.2035 ns | 458.676 ns |      - |     - |     - |         - |
|              ForIListListL | 427.537 ns |  1.1056 ns |  1.5134 ns | 427.085 ns |      - |     - |     - |         - |

|                     Method |       Mean |      Error |     StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-----------:|-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|              ForeachArrayS |   2.392 ns |  0.0212 ns |  0.0305 ns |   2.383 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableS |  23.240 ns |  0.1877 ns |  0.2692 ns |  23.266 ns | 0.0068 |     - |     - |      32 B |
| EnumeratorEnumerableArrayS |  23.230 ns |  0.0710 ns |  0.1018 ns |  23.206 ns | 0.0068 |     - |     - |      32 B |
|                  ForArrayS |   1.901 ns |  0.0073 ns |  0.0107 ns |   1.901 ns |      - |     - |     - |         - |
|             ForIListArrayS |  17.778 ns |  0.2415 ns |  0.3386 ns |  17.865 ns |      - |     - |     - |         - |
|              ForeachArrayM |  13.275 ns |  1.8324 ns |  2.5688 ns |  11.119 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableM | 143.662 ns |  0.5559 ns |  0.7609 ns | 143.405 ns | 0.0067 |     - |     - |      32 B |
| EnumeratorEnumerableArrayM | 136.771 ns |  4.5285 ns |  6.4946 ns | 131.944 ns | 0.0067 |     - |     - |      32 B |
|                  ForArrayM |  13.748 ns |  1.5592 ns |  2.2361 ns |  11.807 ns |      - |     - |     - |         - |
|             ForIListArrayM | 131.361 ns |  2.6435 ns |  3.7058 ns | 134.556 ns |      - |     - |     - |         - |
|              ForeachArrayL |  64.463 ns |  0.0935 ns |  0.1341 ns |  64.470 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableL | 515.768 ns |  1.8853 ns |  2.5807 ns | 515.405 ns | 0.0067 |     - |     - |      32 B |
| EnumeratorEnumerableArrayL | 513.829 ns |  0.8079 ns |  1.1059 ns | 513.617 ns | 0.0067 |     - |     - |      32 B |
|                  ForArrayL |  66.885 ns |  0.1132 ns |  0.1660 ns |  66.878 ns |      - |     - |     - |         - |
|             ForIListArrayL | 502.947 ns | 11.4481 ns | 14.8858 ns | 502.790 ns |      - |     - |     - |         - |

|                     Method |       Mean |      Error |     StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-----------:|-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|               ForeachSpanS |   4.235 ns |  0.0365 ns |  0.0546 ns |   4.237 ns |      - |     - |     - |         - |
|       ForeachReadOnlySpanS |   4.126 ns |  0.0365 ns |  0.0536 ns |   4.124 ns |      - |     - |     - |         - |
|     ForeachSpanAsReadonlyS |   3.123 ns |  0.1435 ns |  0.2103 ns |   3.294 ns |      - |     - |     - |         - |
|     ForeachSpanEnumerableS |  24.305 ns |  0.0447 ns |  0.0612 ns |  24.309 ns | 0.0068 |     - |     - |      32 B |
|  EnumeratorEnumerableSpanS |  23.918 ns |  0.3925 ns |  0.5502 ns |  24.287 ns | 0.0068 |     - |     - |      32 B |
|                   ForSpanS |   3.162 ns |  0.0133 ns |  0.0190 ns |   3.158 ns |      - |     - |     - |         - |
|           ForReadOnlySpanS |   2.925 ns |  0.2187 ns |  0.2994 ns |   3.168 ns |      - |     - |     - |         - |
|         ForSpanAsReadOnlyS |   3.433 ns |  0.0105 ns |  0.0154 ns |   3.431 ns |      - |     - |     - |         - |
|               ForeachSpanM |  31.307 ns |  0.1368 ns |  0.2005 ns |  31.260 ns |      - |     - |     - |         - |
|       ForeachReadOnlySpanM |  31.163 ns |  0.0735 ns |  0.1031 ns |  31.158 ns |      - |     - |     - |         - |
|     ForeachSpanAsReadonlyM |  16.686 ns |  0.1159 ns |  0.1662 ns |  16.674 ns |      - |     - |     - |         - |
|     ForeachSpanEnumerableM | 136.804 ns |  4.7428 ns |  6.8020 ns | 136.691 ns | 0.0067 |     - |     - |      32 B |
|  EnumeratorEnumerableSpanM | 136.358 ns |  4.7223 ns |  6.7726 ns | 130.600 ns | 0.0067 |     - |     - |      32 B |
|                   ForSpanM |  13.788 ns |  0.9011 ns |  1.2632 ns |  14.825 ns |      - |     - |     - |         - |
|           ForReadOnlySpanM |  13.059 ns |  0.0464 ns |  0.0665 ns |  13.060 ns |      - |     - |     - |         - |
|         ForSpanAsReadOnlyM |  14.419 ns |  1.7582 ns |  2.5215 ns |  14.421 ns |      - |     - |     - |         - |
|               ForeachSpanL | 125.728 ns |  0.4002 ns |  0.5867 ns | 125.815 ns |      - |     - |     - |         - |
|       ForeachReadOnlySpanL | 125.691 ns |  0.3457 ns |  0.4847 ns | 125.604 ns |      - |     - |     - |         - |
|     ForeachSpanAsReadonlyL |  65.276 ns |  0.1498 ns |  0.2100 ns |  65.261 ns |      - |     - |     - |         - |
|     ForeachSpanEnumerableL | 514.606 ns |  2.4227 ns |  3.5512 ns | 513.968 ns | 0.0067 |     - |     - |      32 B |
|  EnumeratorEnumerableSpanL | 490.803 ns | 15.4469 ns | 22.6419 ns | 471.620 ns | 0.0067 |     - |     - |      32 B |
|                   ForSpanL |  67.502 ns |  0.1708 ns |  0.2450 ns |  67.417 ns |      - |     - |     - |         - |
|           ForReadOnlySpanL |  69.085 ns |  1.0834 ns |  1.6216 ns |  68.970 ns |      - |     - |     - |         - |
|         ForSpanAsReadOnlyL |  63.189 ns |  1.6384 ns |  2.2968 ns |  61.439 ns |      - |     - |     - |         - |
