# ConvertBenchmark

## Encoding.GetString()

| Method |     Mean |     Error |    StdDev |  Gen 0 | Allocated |
|------- |---------:|----------:|----------:|-------:|----------:|
|  Ascii | 31.06 ns | 0.2019 ns | 0.2896 ns | 0.0114 |      48 B |
|   Utf8 | 32.46 ns | 0.2424 ns | 0.3553 ns | 0.0114 |      48 B |
|   Sjis | 68.69 ns | 0.5794 ns | 0.8672 ns | 0.0113 |      48 B |

## Int32.Parse()

|                         Method |       Mean |     Error |    StdDev | Allocated |
|------------------------------- |-----------:|----------:|----------:|----------:|
|       Any_NumberFormat_Current | 126.861 ns | 0.8978 ns | 1.2876 ns |       0 B |
|     Any_NumberFormat_Invariant | 115.088 ns | 0.3262 ns | 0.4355 ns |       0 B |
|          Any_NumberFormat_Null | 118.778 ns | 1.1297 ns | 1.6559 ns |       0 B |
|          Any_Culture_Invariant | 110.987 ns | 0.4620 ns | 0.6626 ns |       0 B |
|    Number_NumberFormat_Current | 114.473 ns | 0.4748 ns | 0.6656 ns |       0 B |
|  Number_NumberFormat_Invariant | 103.461 ns | 0.4319 ns | 0.6195 ns |       0 B |
|       Number_Culture_Invariant |  97.739 ns | 0.5764 ns | 0.8267 ns |       0 B |
|                    Number_Null | 106.187 ns | 1.0655 ns | 1.5948 ns |       0 B |
|   Integer_NumberFormat_Current | 101.507 ns | 0.4205 ns | 0.6294 ns |       0 B |
| Integer_NumberFormat_Invariant |  90.334 ns | 0.3993 ns | 0.5727 ns |       0 B |
|      Integer_Culture_Invariant |  85.299 ns | 0.5309 ns | 0.7947 ns |       0 B |
|                   Integer_Null |  93.407 ns | 0.5681 ns | 0.8503 ns |       0 B |
|      None_NumberFormat_Current |  95.776 ns | 0.7554 ns | 1.0834 ns |       0 B |
|    None_NumberFormat_Invariant |  82.447 ns | 0.4122 ns | 0.6170 ns |       0 B |
|         None_Culture_Invariant |  77.509 ns | 0.3780 ns | 0.5540 ns |       0 B |
|                      None_Null |  77.350 ns | 0.3660 ns | 0.5364 ns |       0 B |
|                         Custom |   7.007 ns | 0.0396 ns | 0.0580 ns |       0 B |
