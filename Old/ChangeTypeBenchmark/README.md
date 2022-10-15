|                   Method |        Mean |      Error |    StdDev |      Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------------:|-----------:|----------:|------------:|-------:|------:|------:|----------:|
|             RawIntToLong |   0.0331 ns |  0.0462 ns | 0.0025 ns |   0.0318 ns |      - |     - |     - |         - |
|             RawLongToInt |   0.0083 ns |  0.1975 ns | 0.0108 ns |   0.0021 ns |      - |     - |     - |         - |
|           RawStringToInt |  81.4482 ns |  9.4079 ns | 0.5157 ns |  81.4355 ns |      - |     - |     - |         - |
|           RawIntToString |  23.0172 ns |  2.6339 ns | 0.1444 ns |  23.0129 ns | 0.0095 |     - |     - |      40 B |
|         ConvertIntToLong |  21.7257 ns |  2.4014 ns | 0.1316 ns |  21.7263 ns | 0.0114 |     - |     - |      48 B |
|         ConvertLongToInt |  22.2949 ns |  2.1436 ns | 0.1175 ns |  22.2438 ns | 0.0114 |     - |     - |      48 B |
|       ConvertStringToInt |  88.1233 ns | 15.2093 ns | 0.8337 ns |  88.3713 ns | 0.0056 |     - |     - |      24 B |
|       ConvertIntToString |  44.4779 ns |  4.4908 ns | 0.2462 ns |  44.3825 ns | 0.0152 |     - |     - |      64 B |
|           SmartIntToLong |  32.7150 ns |  8.0470 ns | 0.4411 ns |  32.9197 ns | 0.0114 |     - |     - |      48 B |
|           SmartLongToInt |  36.2786 ns | 16.9497 ns | 0.9291 ns |  35.8452 ns | 0.0114 |     - |     - |      48 B |
|         SmartStringToInt | 126.3812 ns | 34.5953 ns | 1.8963 ns | 126.1871 ns | 0.0057 |     - |     - |      24 B |
|         SmartIntToString |  61.8769 ns |  3.8286 ns | 0.2099 ns |  61.8510 ns | 0.0151 |     - |     - |      64 B |
|   PreparedSmartIntToLong |  14.4633 ns |  0.8658 ns | 0.0475 ns |  14.4553 ns | 0.0114 |     - |     - |      48 B |
|   PreparedSmartLongToInt |  11.8904 ns |  4.4691 ns | 0.2450 ns |  11.9571 ns | 0.0114 |     - |     - |      48 B |
| PreparedSmartStringToInt |  98.2136 ns | 18.3838 ns | 1.0077 ns |  97.8190 ns | 0.0056 |     - |     - |      24 B |
| PreparedSmartIntToString |  32.4446 ns |  3.0049 ns | 0.1647 ns |  32.5033 ns | 0.0152 |     - |     - |      64 B |
