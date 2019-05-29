|             Method |       Mean |      Error |    StdDev |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------- |-----------:|-----------:|----------:|-------:|------:|------:|----------:|
|       RawIntToLong |   1.337 ns |  0.1257 ns | 0.0069 ns |      - |     - |     - |         - |
|       RawLongToInt |   1.338 ns |  0.1654 ns | 0.0091 ns |      - |     - |     - |         - |
|     RawStringToInt |  89.984 ns |  1.2736 ns | 0.0698 ns |      - |     - |     - |         - |
|     RawIntToString |  24.488 ns |  0.6636 ns | 0.0364 ns | 0.0095 |     - |     - |      40 B |
|   ConvertIntToLong |  22.488 ns |  1.3484 ns | 0.0739 ns | 0.0114 |     - |     - |      48 B |
|   ConvertLongToInt |  24.254 ns |  0.4077 ns | 0.0223 ns | 0.0114 |     - |     - |      48 B |
| ConvertStringToInt |  88.173 ns |  5.2991 ns | 0.2905 ns | 0.0056 |     - |     - |      24 B |
| ConvertIntToString |  45.385 ns |  0.7104 ns | 0.0389 ns | 0.0152 |     - |     - |      64 B |
|     SmartIntToLong |  34.513 ns |  5.2723 ns | 0.2890 ns | 0.0114 |     - |     - |      48 B |
|     SmartLongToInt |  36.396 ns |  2.7867 ns | 0.1527 ns | 0.0114 |     - |     - |      48 B |
|   SmartStringToInt | 125.643 ns |  4.2618 ns | 0.2336 ns | 0.0057 |     - |     - |      24 B |
|   SmartIntToString |  61.495 ns | 16.9627 ns | 0.9298 ns | 0.0151 |     - |     - |      64 B |
