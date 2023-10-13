```

BenchmarkDotNet v0.13.7, Windows 11 (10.0.22621.2428/22H2/2022Update/SunValley2)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.100-rc.1.23463.5
  [Host]   : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2
  .NET 6.0 : .NET 6.0.23 (6.0.2323.48002), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.12 (7.0.1223.47720), X64 RyuJIT AVX2
  .NET 8.0 : .NET 8.0.0 (8.0.23.41904), X64 RyuJIT AVX2


```
|               Method |      Job |  Runtime |      Mean |    Error |   StdDev |       Min |       Max |       P90 | Ratio | RatioSD |
|--------------------- |--------- |--------- |----------:|---------:|---------:|----------:|----------:|----------:|------:|--------:|
|               Format | .NET 6.0 | .NET 6.0 | 111.38 ns | 2.222 ns | 2.966 ns | 108.46 ns | 118.75 ns | 115.18 ns |  1.00 |    0.00 |
| FormatByUtfFormatter | .NET 6.0 | .NET 6.0 |  49.38 ns | 0.882 ns | 0.825 ns |  48.40 ns |  50.89 ns |  50.55 ns |  0.44 |    0.02 |
|         FormatCustom | .NET 6.0 | .NET 6.0 |  23.60 ns | 0.247 ns | 0.207 ns |  23.33 ns |  23.91 ns |  23.89 ns |  0.21 |    0.01 |
|        FormatCustom2 | .NET 6.0 | .NET 6.0 |  28.54 ns | 0.103 ns | 0.092 ns |  28.38 ns |  28.68 ns |  28.64 ns |  0.25 |    0.01 |
|                      |          |          |           |          |          |           |           |           |       |         |
|               Format | .NET 7.0 | .NET 7.0 |  94.37 ns | 1.603 ns | 1.500 ns |  92.72 ns |  96.86 ns |  96.35 ns |  1.00 |    0.00 |
| FormatByUtfFormatter | .NET 7.0 | .NET 7.0 |  44.69 ns | 0.378 ns | 0.316 ns |  44.37 ns |  45.34 ns |  45.15 ns |  0.47 |    0.01 |
|         FormatCustom | .NET 7.0 | .NET 7.0 |  19.40 ns | 0.295 ns | 0.247 ns |  19.14 ns |  19.84 ns |  19.77 ns |  0.21 |    0.00 |
|        FormatCustom2 | .NET 7.0 | .NET 7.0 |  24.82 ns | 0.229 ns | 0.191 ns |  24.49 ns |  25.09 ns |  25.04 ns |  0.26 |    0.01 |
|                      |          |          |           |          |          |           |           |           |       |         |
|               Format | .NET 8.0 | .NET 8.0 |  58.38 ns | 0.610 ns | 0.571 ns |  57.51 ns |  59.57 ns |  59.12 ns |  1.00 |    0.00 |
| FormatByUtfFormatter | .NET 8.0 | .NET 8.0 |  34.68 ns | 0.681 ns | 0.669 ns |  34.07 ns |  36.39 ns |  35.38 ns |  0.59 |    0.01 |
|         FormatCustom | .NET 8.0 | .NET 8.0 |  20.01 ns | 0.233 ns | 0.218 ns |  19.77 ns |  20.38 ns |  20.31 ns |  0.34 |    0.00 |
|        FormatCustom2 | .NET 8.0 | .NET 8.0 |  15.21 ns | 0.159 ns | 0.141 ns |  15.03 ns |  15.42 ns |  15.39 ns |  0.26 |    0.00 |
