```
BenchmarkDotNet v0.15.4, Windows 11 (10.0.26200.7019)
AMD Ryzen AI 9 HX 370 w/ Radeon 890M 2.00GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.100-rc.2.25502.107
  [Host]              : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 10.0 : .NET 10.0.0 (10.0.0-rc.2.25502.107, 10.0.25.50307), X64 RyuJIT x86-64-v4
  MediumRun-.NET 8.0  : .NET 8.0.21 (8.0.21, 8.0.2125.47513), X64 RyuJIT x86-64-v4
  MediumRun-.NET 9.0  : .NET 9.0.10 (9.0.10, 9.0.1025.47515), X64 RyuJIT x86-64-v4

IterationCount=15  LaunchCount=2  WarmupCount=10  
```
| Method                | Job                 | Runtime   | Loop | Mean        | Error     | StdDev    | Median      | Min         | Max         | P90         | Code Size | Allocated |
|---------------------- |-------------------- |---------- |----- |------------:|----------:|----------:|------------:|------------:|------------:|------------:|----------:|----------:|
| **WriteBinaryPrimitive**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **1**    |   **0.4101 ns** | **0.0086 ns** | **0.0120 ns** |   **0.4068 ns** |   **0.3867 ns** |   **0.4355 ns** |   **0.4264 ns** |     **137 B** |         **-** |
| WriteBinaryPrimitive2 | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.2104 ns | 0.0078 ns | 0.0116 ns |   0.2093 ns |   0.1914 ns |   0.2280 ns |   0.2255 ns |      87 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.2721 ns | 0.0079 ns | 0.0119 ns |   0.2687 ns |   0.2515 ns |   0.3009 ns |   0.2867 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.0282 ns | 0.0098 ns | 0.0147 ns |   0.0247 ns |   0.0036 ns |   0.0576 ns |   0.0474 ns |      81 B |         - |
| WriteUnsafe           | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.0213 ns | 0.0083 ns | 0.0125 ns |   0.0169 ns |   0.0031 ns |   0.0489 ns |   0.0377 ns |      42 B |         - |
| WriteUnsafe2          | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.0207 ns | 0.0068 ns | 0.0097 ns |   0.0198 ns |   0.0045 ns |   0.0399 ns |   0.0343 ns |      42 B |         - |
| WritePointer          | MediumRun-.NET 10.0 | .NET 10.0 | 1    |   0.0424 ns | 0.0091 ns | 0.0133 ns |   0.0366 ns |   0.0251 ns |   0.0779 ns |   0.0616 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.4151 ns | 0.0124 ns | 0.0182 ns |   0.4145 ns |   0.3937 ns |   0.4616 ns |   0.4423 ns |     136 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.2050 ns | 0.0091 ns | 0.0136 ns |   0.1996 ns |   0.1861 ns |   0.2332 ns |   0.2241 ns |      87 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.4126 ns | 0.0086 ns | 0.0129 ns |   0.4126 ns |   0.3885 ns |   0.4359 ns |   0.4289 ns |     132 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.0302 ns | 0.0117 ns | 0.0172 ns |   0.0250 ns |   0.0061 ns |   0.0699 ns |   0.0520 ns |      81 B |         - |
| WriteUnsafe           | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.0255 ns | 0.0092 ns | 0.0134 ns |   0.0224 ns |   0.0084 ns |   0.0532 ns |   0.0449 ns |      42 B |         - |
| WriteUnsafe2          | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.0234 ns | 0.0099 ns | 0.0145 ns |   0.0191 ns |   0.0061 ns |   0.0621 ns |   0.0436 ns |      42 B |         - |
| WritePointer          | MediumRun-.NET 8.0  | .NET 8.0  | 1    |   0.0498 ns | 0.0118 ns | 0.0176 ns |   0.0434 ns |   0.0248 ns |   0.0777 ns |   0.0738 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.4412 ns | 0.0116 ns | 0.0174 ns |   0.4401 ns |   0.4188 ns |   0.4771 ns |   0.4670 ns |     139 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.2349 ns | 0.0113 ns | 0.0166 ns |   0.2342 ns |   0.2109 ns |   0.2886 ns |   0.2541 ns |      89 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.3043 ns | 0.0115 ns | 0.0164 ns |   0.3045 ns |   0.2794 ns |   0.3454 ns |   0.3219 ns |     132 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.2309 ns | 0.0104 ns | 0.0156 ns |   0.2314 ns |   0.2068 ns |   0.2593 ns |   0.2524 ns |      83 B |         - |
| WriteUnsafe           | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.2218 ns | 0.0150 ns | 0.0215 ns |   0.2149 ns |   0.1968 ns |   0.2831 ns |   0.2454 ns |      44 B |         - |
| WriteUnsafe2          | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.2201 ns | 0.0111 ns | 0.0167 ns |   0.2119 ns |   0.1995 ns |   0.2582 ns |   0.2422 ns |      44 B |         - |
| WritePointer          | MediumRun-.NET 9.0  | .NET 9.0  | 1    |   0.2355 ns | 0.0091 ns | 0.0137 ns |   0.2336 ns |   0.2179 ns |   0.2665 ns |   0.2514 ns |      79 B |         - |
| **WriteBinaryPrimitive**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **4**    |   **1.6469 ns** | **0.0241 ns** | **0.0361 ns** |   **1.6346 ns** |   **1.5983 ns** |   **1.7095 ns** |   **1.6941 ns** |     **137 B** |         **-** |
| WriteBinaryPrimitive2 | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   0.9941 ns | 0.0145 ns | 0.0213 ns |   0.9885 ns |   0.9646 ns |   1.0397 ns |   1.0273 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   1.4947 ns | 0.0138 ns | 0.0207 ns |   1.4926 ns |   1.4630 ns |   1.5405 ns |   1.5184 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   0.8317 ns | 0.0131 ns | 0.0195 ns |   0.8292 ns |   0.8006 ns |   0.8697 ns |   0.8573 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   0.4292 ns | 0.0154 ns | 0.0221 ns |   0.4262 ns |   0.3877 ns |   0.4720 ns |   0.4569 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   0.4202 ns | 0.0181 ns | 0.0270 ns |   0.4177 ns |   0.3623 ns |   0.4745 ns |   0.4547 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 10.0 | .NET 10.0 | 4    |   0.4917 ns | 0.0110 ns | 0.0161 ns |   0.4884 ns |   0.4675 ns |   0.5243 ns |   0.5126 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   2.2625 ns | 0.0121 ns | 0.0181 ns |   2.2673 ns |   2.2207 ns |   2.2901 ns |   2.2819 ns |     136 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   1.0237 ns | 0.0243 ns | 0.0364 ns |   1.0122 ns |   0.9815 ns |   1.1274 ns |   1.0746 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   2.0318 ns | 0.0148 ns | 0.0217 ns |   2.0296 ns |   1.9946 ns |   2.0832 ns |   2.0580 ns |     132 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   0.7708 ns | 0.0326 ns | 0.0488 ns |   0.7711 ns |   0.7000 ns |   0.8396 ns |   0.8285 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   0.4339 ns | 0.0163 ns | 0.0233 ns |   0.4318 ns |   0.3907 ns |   0.4835 ns |   0.4685 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   0.4436 ns | 0.0156 ns | 0.0233 ns |   0.4439 ns |   0.3988 ns |   0.4985 ns |   0.4654 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 8.0  | .NET 8.0  | 4    |   0.6308 ns | 0.0177 ns | 0.0265 ns |   0.6332 ns |   0.5698 ns |   0.6816 ns |   0.6573 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.6530 ns | 0.0173 ns | 0.0259 ns |   1.6413 ns |   1.6179 ns |   1.6997 ns |   1.6908 ns |     137 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.0228 ns | 0.0176 ns | 0.0263 ns |   1.0190 ns |   0.9819 ns |   1.0777 ns |   1.0634 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   1.5779 ns | 0.0538 ns | 0.0805 ns |   1.5906 ns |   1.4644 ns |   1.6898 ns |   1.6787 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   0.8344 ns | 0.0111 ns | 0.0163 ns |   0.8363 ns |   0.8073 ns |   0.8795 ns |   0.8499 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   0.4206 ns | 0.0173 ns | 0.0259 ns |   0.4209 ns |   0.3647 ns |   0.4555 ns |   0.4531 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   0.4288 ns | 0.0154 ns | 0.0226 ns |   0.4283 ns |   0.3881 ns |   0.4709 ns |   0.4570 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 9.0  | .NET 9.0  | 4    |   0.5115 ns | 0.0129 ns | 0.0193 ns |   0.5067 ns |   0.4819 ns |   0.5497 ns |   0.5404 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **64**   |  **29.2472 ns** | **0.3275 ns** | **0.4902 ns** |  **29.0992 ns** |  **28.5391 ns** |  **30.3203 ns** |  **29.9154 ns** |     **137 B** |         **-** |
| WriteBinaryPrimitive2 | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  23.4033 ns | 0.1195 ns | 0.1789 ns |  23.4211 ns |  23.0918 ns |  23.7487 ns |  23.6257 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  26.4654 ns | 0.1773 ns | 0.2654 ns |  26.4152 ns |  26.0222 ns |  27.2183 ns |  26.8184 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  20.4950 ns | 0.1031 ns | 0.1511 ns |  20.4676 ns |  20.2198 ns |  20.7949 ns |  20.7139 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  11.8409 ns | 0.0712 ns | 0.1021 ns |  11.8400 ns |  11.6673 ns |  12.0395 ns |  11.9658 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  11.8405 ns | 0.0921 ns | 0.1379 ns |  11.8159 ns |  11.6431 ns |  12.1875 ns |  11.9851 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 10.0 | .NET 10.0 | 64   |  12.7257 ns | 0.0779 ns | 0.1166 ns |  12.7218 ns |  12.5834 ns |  13.0767 ns |  12.8294 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  32.6261 ns | 0.2895 ns | 0.4244 ns |  32.5329 ns |  31.9790 ns |  33.5802 ns |  33.1684 ns |     136 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  23.9338 ns | 0.1003 ns | 0.1470 ns |  23.9184 ns |  23.6628 ns |  24.2638 ns |  24.1278 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  28.6242 ns | 0.1532 ns | 0.2294 ns |  28.5764 ns |  28.2314 ns |  29.2250 ns |  28.9087 ns |     132 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  20.4933 ns | 0.1121 ns | 0.1607 ns |  20.5092 ns |  20.2075 ns |  20.8558 ns |  20.6749 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  12.4350 ns | 0.0866 ns | 0.1270 ns |  12.4681 ns |  12.1860 ns |  12.6077 ns |  12.5744 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  12.1731 ns | 0.2434 ns | 0.3643 ns |  12.1829 ns |  11.6751 ns |  12.6557 ns |  12.6014 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 8.0  | .NET 8.0  | 64   |  12.8200 ns | 0.0669 ns | 0.0981 ns |  12.8060 ns |  12.6237 ns |  13.0275 ns |  12.9309 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  29.1130 ns | 0.2782 ns | 0.4165 ns |  28.9642 ns |  28.6282 ns |  30.1517 ns |  29.6778 ns |     137 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  24.8502 ns | 0.1300 ns | 0.1946 ns |  24.8485 ns |  24.5339 ns |  25.2851 ns |  25.1023 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  27.1994 ns | 0.3762 ns | 0.5631 ns |  27.1428 ns |  26.3696 ns |  28.3601 ns |  27.8592 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  20.6094 ns | 0.1153 ns | 0.1725 ns |  20.5941 ns |  20.3630 ns |  21.0400 ns |  20.8217 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.9048 ns | 0.0857 ns | 0.1282 ns |  11.8761 ns |  11.6907 ns |  12.1733 ns |  12.1133 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  11.9297 ns | 0.0972 ns | 0.1424 ns |  11.8899 ns |  11.7493 ns |  12.2646 ns |  12.1316 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 9.0  | .NET 9.0  | 64   |  12.7763 ns | 0.0557 ns | 0.0816 ns |  12.7794 ns |  12.6008 ns |  12.9582 ns |  12.8690 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **MediumRun-.NET 10.0** | **.NET 10.0** | **256**  | **125.1972 ns** | **1.1004 ns** | **1.6470 ns** | **124.9705 ns** | **122.8332 ns** | **129.4448 ns** | **127.2154 ns** |     **137 B** |         **-** |
| WriteBinaryPrimitive2 | MediumRun-.NET 10.0 | .NET 10.0 | 256  | 101.9740 ns | 0.3826 ns | 0.5487 ns | 102.0911 ns | 100.9540 ns | 103.0324 ns | 102.5932 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 10.0 | .NET 10.0 | 256  | 113.2897 ns | 0.5986 ns | 0.8959 ns | 113.3647 ns | 112.0268 ns | 115.1965 ns | 114.3012 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 10.0 | .NET 10.0 | 256  |  93.0295 ns | 0.4181 ns | 0.6258 ns |  92.9260 ns |  92.0320 ns |  94.1528 ns |  93.9468 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 10.0 | .NET 10.0 | 256  |  58.4273 ns | 0.3194 ns | 0.4581 ns |  58.4698 ns |  57.4881 ns |  59.1606 ns |  59.0029 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 10.0 | .NET 10.0 | 256  |  58.5812 ns | 0.4450 ns | 0.6661 ns |  58.5796 ns |  57.3976 ns |  60.3209 ns |  59.2386 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 10.0 | .NET 10.0 | 256  |  59.0864 ns | 0.4166 ns | 0.6236 ns |  58.9397 ns |  58.1922 ns |  60.4333 ns |  60.0055 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 8.0  | .NET 8.0  | 256  | 131.0078 ns | 0.8766 ns | 1.2850 ns | 130.8558 ns | 128.8888 ns | 133.8169 ns | 132.9740 ns |     136 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 8.0  | .NET 8.0  | 256  | 102.1193 ns | 0.3867 ns | 0.5669 ns | 102.1361 ns | 101.3321 ns | 103.2997 ns | 102.8738 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 8.0  | .NET 8.0  | 256  | 117.7929 ns | 0.9078 ns | 1.3307 ns | 117.6250 ns | 116.0883 ns | 120.8127 ns | 119.6005 ns |     132 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 8.0  | .NET 8.0  | 256  |  93.3923 ns | 0.4654 ns | 0.6822 ns |  93.2882 ns |  92.0904 ns |  95.0998 ns |  94.2393 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 8.0  | .NET 8.0  | 256  |  58.5613 ns | 0.3499 ns | 0.5019 ns |  58.6183 ns |  57.5206 ns |  59.4639 ns |  59.1597 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 8.0  | .NET 8.0  | 256  |  58.7032 ns | 0.5691 ns | 0.8518 ns |  58.5826 ns |  57.4803 ns |  60.6046 ns |  59.9492 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 8.0  | .NET 8.0  | 256  |  59.3169 ns | 0.3297 ns | 0.4833 ns |  59.3952 ns |  58.2651 ns |  60.0702 ns |  59.9292 ns |      77 B |         - |
| WriteBinaryPrimitive  | MediumRun-.NET 9.0  | .NET 9.0  | 256  | 125.5416 ns | 0.8969 ns | 1.3425 ns | 125.4575 ns | 123.6084 ns | 129.0756 ns | 127.3693 ns |     137 B |         - |
| WriteBinaryPrimitive2 | MediumRun-.NET 9.0  | .NET 9.0  | 256  | 110.2405 ns | 0.9413 ns | 1.4089 ns | 110.2500 ns | 107.6332 ns | 113.3266 ns | 111.7361 ns |      88 B |         - |
| WriteMemoryMarshal    | MediumRun-.NET 9.0  | .NET 9.0  | 256  | 113.1612 ns | 0.4667 ns | 0.6986 ns | 113.1974 ns | 112.1307 ns | 114.7707 ns | 114.0010 ns |     130 B |         - |
| WriteMemoryMarshal2   | MediumRun-.NET 9.0  | .NET 9.0  | 256  |  93.2164 ns | 0.4126 ns | 0.6176 ns |  93.2084 ns |  92.1728 ns |  94.2003 ns |  94.0665 ns |      82 B |         - |
| WriteUnsafe           | MediumRun-.NET 9.0  | .NET 9.0  | 256  |  58.6730 ns | 0.4950 ns | 0.7255 ns |  58.8239 ns |  57.4449 ns |  59.9241 ns |  59.6300 ns |      50 B |         - |
| WriteUnsafe2          | MediumRun-.NET 9.0  | .NET 9.0  | 256  |  58.5870 ns | 0.3029 ns | 0.4534 ns |  58.5885 ns |  57.7155 ns |  59.4125 ns |  59.2120 ns |      50 B |         - |
| WritePointer          | MediumRun-.NET 9.0  | .NET 9.0  | 256  |  58.9154 ns | 0.3300 ns | 0.4838 ns |  58.9426 ns |  57.7828 ns |  59.8528 ns |  59.4568 ns |      77 B |         - |

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3958/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
```
| Method                | Loop | Mean        | Error     | StdDev    | Min         | Max         | P90         | Code Size | Allocated |
|---------------------- |----- |------------:|----------:|----------:|------------:|------------:|------------:|----------:|----------:|
| **WriteBinaryPrimitive**  | **1**    |   **1.0060 ns** | **0.0424 ns** | **0.0580 ns** |   **0.9336 ns** |   **1.1036 ns** |   **1.0963 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 1    |   0.3945 ns | 0.0238 ns | 0.0244 ns |   0.3766 ns |   0.4612 ns |   0.4259 ns |      87 B |         - |
| WriteMemoryMarshal    | 1    |   0.9896 ns | 0.0370 ns | 0.0346 ns |   0.9473 ns |   1.0704 ns |   1.0241 ns |     132 B |         - |
| WriteMemoryMarshal2   | 1    |   0.2352 ns | 0.0252 ns | 0.0236 ns |   0.2030 ns |   0.2682 ns |   0.2621 ns |      81 B |         - |
| WriteUnsafe           | 1    |   0.2111 ns | 0.0243 ns | 0.0227 ns |   0.1826 ns |   0.2466 ns |   0.2403 ns |      42 B |         - |
| WriteUnsafe2          | 1    |   0.2154 ns | 0.0228 ns | 0.0213 ns |   0.1857 ns |   0.2481 ns |   0.2451 ns |      42 B |         - |
| WritePointer          | 1    |   0.6703 ns | 0.0356 ns | 0.0316 ns |   0.6236 ns |   0.7250 ns |   0.7068 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **4**    |   **3.2514 ns** | **0.0759 ns** | **0.0710 ns** |   **3.1641 ns** |   **3.4202 ns** |   **3.3316 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 4    |   1.5305 ns | 0.0431 ns | 0.0403 ns |   1.4796 ns |   1.6149 ns |   1.5890 ns |      88 B |         - |
| WriteMemoryMarshal    | 4    |   3.1099 ns | 0.0730 ns | 0.0683 ns |   3.0077 ns |   3.2393 ns |   3.1646 ns |     132 B |         - |
| WriteMemoryMarshal2   | 4    |   1.4019 ns | 0.0467 ns | 0.0437 ns |   1.3535 ns |   1.5059 ns |   1.4459 ns |      82 B |         - |
| WriteUnsafe           | 4    |   0.8126 ns | 0.0242 ns | 0.0215 ns |   0.7737 ns |   0.8549 ns |   0.8396 ns |      50 B |         - |
| WriteUnsafe2          | 4    |   0.8041 ns | 0.0338 ns | 0.0317 ns |   0.7468 ns |   0.8591 ns |   0.8494 ns |      42 B |         - |
| WritePointer          | 4    |   1.2631 ns | 0.0376 ns | 0.0333 ns |   1.2255 ns |   1.3308 ns |   1.3125 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **64**   |  **42.7789 ns** | **0.8664 ns** | **1.7502 ns** |  **39.0179 ns** |  **46.7851 ns** |  **44.9371 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 64   |  27.9993 ns | 0.5822 ns | 0.5161 ns |  27.5647 ns |  29.0773 ns |  28.8928 ns |      88 B |         - |
| WriteMemoryMarshal    | 64   |  39.0198 ns | 0.7906 ns | 1.1834 ns |  36.7691 ns |  40.9295 ns |  40.0437 ns |     132 B |         - |
| WriteMemoryMarshal2   | 64   |  28.1374 ns | 0.4709 ns | 0.4405 ns |  27.4579 ns |  28.6759 ns |  28.6458 ns |      82 B |         - |
| WriteUnsafe           | 64   |  14.9488 ns | 0.2374 ns | 0.2104 ns |  14.6396 ns |  15.2955 ns |  15.2502 ns |      50 B |         - |
| WriteUnsafe2          | 64   |  15.2457 ns | 0.3272 ns | 0.3061 ns |  14.7301 ns |  15.8479 ns |  15.6234 ns |      50 B |         - |
| WritePointer          | 64   |  16.1589 ns | 0.3447 ns | 0.3385 ns |  15.6231 ns |  16.9079 ns |  16.5373 ns |      77 B |         - |
| **WriteBinaryPrimitive**  | **256**  | **160.4883 ns** | **2.5222 ns** | **2.3593 ns** | **156.8146 ns** | **164.3575 ns** | **163.3050 ns** |     **136 B** |         **-** |
| WriteBinaryPrimitive2 | 256  | 116.6475 ns | 2.3440 ns | 2.1926 ns | 113.9860 ns | 120.4243 ns | 119.8031 ns |      88 B |         - |
| WriteMemoryMarshal    | 256  | 147.6488 ns | 2.9073 ns | 2.8554 ns | 144.3859 ns | 152.4102 ns | 151.4242 ns |     132 B |         - |
| WriteMemoryMarshal2   | 256  | 116.9340 ns | 2.3539 ns | 2.3118 ns | 114.3158 ns | 120.6539 ns | 120.0774 ns |      82 B |         - |
| WriteUnsafe           | 256  |  61.3442 ns | 1.0409 ns | 0.9736 ns |  60.1629 ns |  63.6522 ns |  62.4169 ns |      50 B |         - |
| WriteUnsafe2          | 256  |  61.5637 ns | 1.2451 ns | 1.6190 ns |  59.9485 ns |  65.6981 ns |  63.4379 ns |      50 B |         - |
| WritePointer          | 256  |  63.7674 ns | 1.2606 ns | 1.5942 ns |  61.6459 ns |  66.9896 ns |  66.1297 ns |      77 B |         - |
