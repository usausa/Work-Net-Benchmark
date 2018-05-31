# Core 2.0

 |                 Method |       Mean |      Error |    StdDev |  Gen 0 | Allocated |
 |----------------------- |-----------:|-----------:|----------:|-------:|----------:|
 |               ArrayFor |   3.736 ns |  0.1308 ns | 0.0074 ns |      - |       0 B |
 |       ArrayIndexedList | 116.400 ns |  5.0093 ns | 0.2830 ns |      - |       0 B |
 |      ArrayIndexedArray |  70.260 ns |  3.8062 ns | 0.2151 ns |      - |       0 B |
 | ArrayIndexedEnumerable | 104.647 ns |  1.8861 ns | 0.1066 ns | 0.0075 |      32 B |
 |            ArraySelect | 200.300 ns | 30.1846 ns | 1.7055 ns | 0.0267 |     112 B |
 |                ListFor |  12.688 ns |  0.7321 ns | 0.0414 ns |      - |       0 B |
 |        ListIndexedList | 108.781 ns |  3.0565 ns | 0.1727 ns |      - |       0 B |
 |  ListIndexedEnumerable | 110.881 ns |  5.1381 ns | 0.2903 ns | 0.0094 |      40 B |
 |             ListSelect | 220.744 ns |  7.9707 ns | 0.4504 ns | 0.0284 |     120 B |
