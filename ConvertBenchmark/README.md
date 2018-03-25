# ConvertBenchmark

## Encoding.GetString()

| Method |     Mean |    Error |    StdDev |  Gen 0 | Allocated |
|------- |---------:|---------:|----------:|-------:|----------:|
|  Ascii | 28.21 ns | 15.16 ns | 0.8565 ns | 0.0114 |      48 B |
|   Utf8 | 41.01 ns | 13.23 ns | 0.7475 ns | 0.0114 |      48 B |
|   Sjis | 84.14 ns | 27.51 ns | 1.5544 ns | 0.0113 |      48 B |

# Int32.Parse()

|                         Method |       Mean |       Error |     StdDev | Allocated |
|------------------------------- |-----------:|------------:|-----------:|----------:|
|       Any_NumberFormat_Current | 212.727 ns | 305.8375 ns | 17.2804 ns |       0 B |
|     Any_NumberFormat_Invariant | 120.000 ns |  71.0414 ns |  4.0140 ns |       0 B |
|          Any_Culture_Invariant | 117.773 ns |  65.5080 ns |  3.7013 ns |       0 B |
|    Number_NumberFormat_Current | 129.044 ns |   9.6189 ns |  0.5435 ns |       0 B |
|  Number_NumberFormat_Invariant | 107.212 ns |  27.9492 ns |  1.5792 ns |       0 B |
|       Number_Culture_Invariant | 103.772 ns |  18.3885 ns |  1.0390 ns |       0 B |
|   Integer_NumberFormat_Current | 121.263 ns |   9.3660 ns |  0.5292 ns |       0 B |
| Integer_NumberFormat_Invariant |  97.912 ns |  18.7980 ns |  1.0621 ns |       0 B |
|      Integer_Culture_Invariant |  98.659 ns | 102.7727 ns |  5.8068 ns |       0 B |
|      None_NumberFormat_Current | 114.012 ns |  10.0818 ns |  0.5696 ns |       0 B |
|    None_NumberFormat_Invariant |  94.781 ns |  38.1496 ns |  2.1555 ns |       0 B |
|         None_Culture_Invariant |  94.553 ns |  56.4761 ns |  3.1910 ns |       0 B |
|                         Custom |   6.902 ns |   0.8404 ns |  0.0475 ns |       0 B |
