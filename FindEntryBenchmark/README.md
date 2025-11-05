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
| Method  | Job                 | Runtime   | Parameter | Mean       | Error    | StdDev    | Median     | Min        | Max        | P90        | Code Size | Allocated |
|-------- |-------------------- |---------- |---------- |-----------:|---------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **1**         |   **459.0 ns** |  **2.29 ns** |   **3.28 ns** |   **458.9 ns** |   **454.1 ns** |   **467.6 ns** |   **463.7 ns** |     **278 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   574.4 ns |  4.48 ns |   6.56 ns |   572.1 ns |   565.2 ns |   588.4 ns |   582.7 ns |     316 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   455.3 ns |  2.49 ns |   3.64 ns |   455.5 ns |   448.7 ns |   462.7 ns |   459.9 ns |     303 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   416.8 ns |  3.18 ns |   4.76 ns |   417.6 ns |   410.7 ns |   433.1 ns |   422.1 ns |     281 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   445.4 ns |  3.05 ns |   4.47 ns |   445.7 ns |   439.4 ns |   456.3 ns |   450.2 ns |     291 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   410.1 ns |  1.88 ns |   2.82 ns |   410.6 ns |   406.3 ns |   415.2 ns |   413.8 ns |     269 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   412.6 ns |  2.28 ns |   3.42 ns |   413.3 ns |   407.3 ns |   419.0 ns |   417.0 ns |     278 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   253.6 ns |  2.06 ns |   3.01 ns |   252.6 ns |   248.9 ns |   260.4 ns |   258.2 ns |     260 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   236.7 ns |  5.34 ns |   7.82 ns |   234.9 ns |   228.5 ns |   259.8 ns |   248.6 ns |     232 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   213.4 ns |  1.64 ns |   2.40 ns |   213.1 ns |   210.4 ns |   218.5 ns |   216.4 ns |     237 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   464.2 ns |  2.33 ns |   3.41 ns |   464.7 ns |   458.5 ns |   471.9 ns |   467.9 ns |     280 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   599.0 ns |  6.66 ns |   9.97 ns |   594.0 ns |   590.2 ns |   624.3 ns |   610.5 ns |     319 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   431.4 ns |  2.76 ns |   4.05 ns |   430.5 ns |   425.0 ns |   439.3 ns |   436.9 ns |     304 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   422.4 ns |  3.30 ns |   4.84 ns |   421.7 ns |   413.8 ns |   431.1 ns |   428.8 ns |     283 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   426.3 ns |  3.50 ns |   5.24 ns |   425.7 ns |   419.0 ns |   437.2 ns |   432.9 ns |     289 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   390.9 ns |  2.88 ns |   4.04 ns |   390.0 ns |   384.7 ns |   399.9 ns |   397.0 ns |     280 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   376.7 ns |  3.09 ns |   4.63 ns |   375.2 ns |   369.3 ns |   385.4 ns |   382.6 ns |     277 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   285.6 ns |  3.92 ns |   5.87 ns |   284.6 ns |   274.8 ns |   296.3 ns |   295.0 ns |     262 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   210.3 ns |  1.09 ns |   1.59 ns |   210.3 ns |   208.0 ns |   213.5 ns |   212.4 ns |     231 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   249.7 ns |  3.26 ns |   4.78 ns |   247.2 ns |   245.0 ns |   261.6 ns |   257.2 ns |     236 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   458.9 ns |  4.37 ns |   6.41 ns |   457.3 ns |   451.7 ns |   480.1 ns |   463.2 ns |     275 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   574.4 ns |  4.65 ns |   6.96 ns |   572.2 ns |   564.9 ns |   591.2 ns |   582.1 ns |     313 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   455.4 ns |  2.86 ns |   4.28 ns |   455.5 ns |   449.8 ns |   464.5 ns |   462.7 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   520.8 ns |  2.51 ns |   3.76 ns |   519.1 ns |   516.4 ns |   530.1 ns |   526.3 ns |     281 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   423.5 ns |  2.96 ns |   4.34 ns |   422.7 ns |   416.8 ns |   434.9 ns |   428.3 ns |     287 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   411.3 ns |  2.46 ns |   3.69 ns |   411.2 ns |   406.9 ns |   419.7 ns |   415.5 ns |     273 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   412.5 ns |  2.12 ns |   3.10 ns |   412.8 ns |   407.8 ns |   418.7 ns |   416.4 ns |     275 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   253.7 ns |  3.12 ns |   4.38 ns |   254.6 ns |   246.9 ns |   263.5 ns |   258.6 ns |     257 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   231.8 ns |  2.34 ns |   3.43 ns |   231.3 ns |   226.6 ns |   240.1 ns |   235.4 ns |     229 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   212.9 ns |  1.19 ns |   1.77 ns |   212.7 ns |   209.5 ns |   217.3 ns |   215.3 ns |     234 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **2**         | **1,025.7 ns** |  **6.90 ns** |  **10.11 ns** | **1,021.5 ns** | **1,012.9 ns** | **1,045.3 ns** | **1,040.1 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   911.7 ns |  7.18 ns |  10.53 ns |   914.2 ns |   891.0 ns |   928.4 ns |   922.6 ns |     231 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   851.7 ns |  5.43 ns |   7.79 ns |   851.7 ns |   839.0 ns |   869.6 ns |   861.1 ns |     210 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   925.5 ns |  7.34 ns |  10.53 ns |   922.3 ns |   909.8 ns |   943.3 ns |   940.8 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   944.9 ns | 16.90 ns |  25.30 ns |   940.0 ns |   905.9 ns | 1,003.0 ns |   978.5 ns |     208 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   791.3 ns | 10.04 ns |  15.03 ns |   791.3 ns |   767.8 ns |   817.1 ns |   810.6 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   897.2 ns | 23.18 ns |  33.98 ns |   884.0 ns |   864.3 ns |   986.2 ns |   944.7 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   704.0 ns |  6.62 ns |   9.92 ns |   704.7 ns |   690.2 ns |   731.3 ns |   714.0 ns |     168 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   600.2 ns |  4.38 ns |   6.42 ns |   599.5 ns |   591.6 ns |   616.8 ns |   610.2 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   785.1 ns | 23.02 ns |  34.45 ns |   793.0 ns |   700.3 ns |   838.9 ns |   823.9 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   979.6 ns |  9.50 ns |  13.62 ns |   976.2 ns |   964.6 ns | 1,017.3 ns |   999.7 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   982.6 ns | 41.56 ns |  60.92 ns |   939.5 ns |   912.7 ns | 1,074.8 ns | 1,064.7 ns |     335 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   957.3 ns |  8.03 ns |  11.26 ns |   955.6 ns |   934.7 ns |   986.8 ns |   971.6 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   960.1 ns | 10.21 ns |  14.96 ns |   956.4 ns |   940.4 ns |   994.6 ns |   980.4 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   839.3 ns |  7.35 ns |  10.54 ns |   838.0 ns |   824.4 ns |   868.0 ns |   851.3 ns |     301 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   861.8 ns |  7.59 ns |  11.13 ns |   862.8 ns |   842.9 ns |   883.3 ns |   876.2 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   891.4 ns |  6.86 ns |  10.27 ns |   892.2 ns |   873.0 ns |   914.7 ns |   903.5 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   674.5 ns |  5.66 ns |   8.12 ns |   671.1 ns |   664.2 ns |   690.5 ns |   686.3 ns |     249 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   844.2 ns |  7.08 ns |  10.37 ns |   842.6 ns |   827.7 ns |   865.6 ns |   855.9 ns |     225 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 2         |   701.8 ns |  7.36 ns |  10.79 ns |   698.9 ns |   685.0 ns |   726.5 ns |   717.4 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,005.9 ns |  9.44 ns |  14.13 ns | 1,003.9 ns |   987.2 ns | 1,043.0 ns | 1,022.9 ns |     259 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   893.5 ns |  9.52 ns |  13.95 ns |   891.6 ns |   868.2 ns |   919.8 ns |   910.2 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   842.1 ns |  6.88 ns |  10.30 ns |   842.5 ns |   823.5 ns |   863.8 ns |   855.1 ns |     285 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   983.4 ns | 36.36 ns |  54.42 ns |   981.2 ns |   918.0 ns | 1,070.9 ns | 1,047.3 ns |     263 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   837.5 ns |  6.65 ns |   9.75 ns |   836.5 ns |   824.5 ns |   855.1 ns |   850.2 ns |     275 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   721.0 ns | 16.71 ns |  25.02 ns |   720.7 ns |   688.5 ns |   777.1 ns |   755.9 ns |     262 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   905.2 ns |  5.61 ns |   8.23 ns |   906.6 ns |   895.5 ns |   924.3 ns |   913.9 ns |     257 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   698.8 ns |  7.04 ns |  10.09 ns |   697.8 ns |   681.9 ns |   718.1 ns |   711.2 ns |     243 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   641.7 ns |  8.33 ns |  12.47 ns |   637.2 ns |   627.0 ns |   674.5 ns |   657.3 ns |     219 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 2         |   651.1 ns |  6.71 ns |   9.84 ns |   645.9 ns |   639.4 ns |   678.8 ns |   662.4 ns |     224 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **4**         | **1,951.5 ns** | **16.60 ns** |  **23.81 ns** | **1,943.1 ns** | **1,916.4 ns** | **2,003.0 ns** | **1,986.5 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,712.5 ns | 13.30 ns |  19.08 ns | 1,703.3 ns | 1,692.8 ns | 1,776.6 ns | 1,732.8 ns |     215 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,713.9 ns | 10.81 ns |  15.84 ns | 1,714.2 ns | 1,690.0 ns | 1,751.7 ns | 1,733.5 ns |     198 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,977.2 ns | 13.88 ns |  20.34 ns | 1,966.8 ns | 1,957.4 ns | 2,022.9 ns | 2,008.8 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,837.9 ns |  9.97 ns |  14.93 ns | 1,838.5 ns | 1,818.7 ns | 1,874.7 ns | 1,856.8 ns |     197 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,580.7 ns |  9.27 ns |  12.99 ns | 1,576.0 ns | 1,562.1 ns | 1,605.2 ns | 1,598.5 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,983.2 ns | 18.32 ns |  27.42 ns | 1,974.6 ns | 1,945.8 ns | 2,056.1 ns | 2,012.5 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,627.9 ns | 13.79 ns |  20.22 ns | 1,626.1 ns | 1,599.1 ns | 1,683.9 ns | 1,651.3 ns |     165 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,475.5 ns | 22.12 ns |  31.72 ns | 1,479.8 ns | 1,425.3 ns | 1,532.8 ns | 1,511.5 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,600.2 ns | 27.82 ns |  41.64 ns | 1,614.3 ns | 1,535.5 ns | 1,664.7 ns | 1,646.6 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,005.8 ns | 19.18 ns |  28.70 ns | 1,994.1 ns | 1,970.2 ns | 2,067.8 ns | 2,047.7 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,935.0 ns | 19.19 ns |  28.14 ns | 1,927.7 ns | 1,901.5 ns | 1,989.7 ns | 1,984.2 ns |     331 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,810.8 ns | 35.19 ns |  51.58 ns | 1,815.5 ns | 1,730.3 ns | 1,886.3 ns | 1,875.1 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,197.2 ns | 17.91 ns |  26.81 ns | 2,188.1 ns | 2,161.3 ns | 2,249.8 ns | 2,237.4 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,933.5 ns | 16.49 ns |  24.16 ns | 1,934.0 ns | 1,875.8 ns | 1,978.8 ns | 1,968.6 ns |     304 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,917.0 ns | 36.88 ns |  55.20 ns | 1,899.0 ns | 1,827.2 ns | 2,034.3 ns | 1,983.6 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,999.6 ns | 19.62 ns |  29.37 ns | 1,987.9 ns | 1,966.3 ns | 2,077.8 ns | 2,042.6 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,627.5 ns | 12.20 ns |  18.26 ns | 1,627.4 ns | 1,605.1 ns | 1,663.3 ns | 1,649.7 ns |     249 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,796.9 ns | 31.12 ns |  46.58 ns | 1,797.8 ns | 1,722.4 ns | 1,881.8 ns | 1,854.5 ns |     225 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 1,595.7 ns | 16.64 ns |  24.91 ns | 1,585.1 ns | 1,568.6 ns | 1,657.6 ns | 1,628.7 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,986.3 ns | 15.27 ns |  22.85 ns | 1,977.8 ns | 1,958.0 ns | 2,037.8 ns | 2,019.0 ns |     257 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,828.6 ns |  7.57 ns |  11.10 ns | 1,826.4 ns | 1,811.4 ns | 1,848.3 ns | 1,845.2 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,793.0 ns | 12.07 ns |  18.07 ns | 1,788.9 ns | 1,764.0 ns | 1,832.3 ns | 1,814.0 ns |     283 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,025.8 ns | 14.37 ns |  21.07 ns | 2,018.5 ns | 2,001.6 ns | 2,075.4 ns | 2,058.2 ns |     263 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,827.6 ns |  6.81 ns |   9.99 ns | 1,828.6 ns | 1,814.4 ns | 1,850.4 ns | 1,839.4 ns |     286 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,619.2 ns |  9.25 ns |  13.27 ns | 1,619.2 ns | 1,599.9 ns | 1,641.6 ns | 1,635.5 ns |     260 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,966.5 ns | 16.05 ns |  23.53 ns | 1,954.7 ns | 1,942.2 ns | 2,019.7 ns | 1,999.5 ns |     257 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,637.8 ns |  9.90 ns |  14.19 ns | 1,634.7 ns | 1,620.0 ns | 1,682.2 ns | 1,655.5 ns |     243 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,460.9 ns | 13.64 ns |  20.42 ns | 1,450.5 ns | 1,436.1 ns | 1,516.1 ns | 1,480.7 ns |     219 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 1,513.9 ns |  8.34 ns |  12.48 ns | 1,511.6 ns | 1,492.1 ns | 1,542.8 ns | 1,533.7 ns |     224 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **8**         | **3,785.2 ns** | **21.83 ns** |  **32.00 ns** | **3,785.9 ns** | **3,728.4 ns** | **3,844.1 ns** | **3,827.7 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,525.7 ns | 21.91 ns |  31.43 ns | 3,518.6 ns | 3,470.6 ns | 3,609.7 ns | 3,557.9 ns |     230 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,606.9 ns | 19.60 ns |  28.11 ns | 3,620.0 ns | 3,566.7 ns | 3,653.8 ns | 3,636.0 ns |     198 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,137.3 ns | 28.43 ns |  42.55 ns | 4,117.2 ns | 4,082.9 ns | 4,232.5 ns | 4,193.0 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,722.9 ns | 20.21 ns |  29.62 ns | 3,723.4 ns | 3,685.3 ns | 3,788.3 ns | 3,762.7 ns |     197 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,207.9 ns | 19.75 ns |  29.56 ns | 3,196.6 ns | 3,168.8 ns | 3,270.5 ns | 3,251.2 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,214.8 ns | 30.46 ns |  44.64 ns | 4,192.2 ns | 4,161.0 ns | 4,352.7 ns | 4,268.0 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,554.4 ns | 17.95 ns |  26.32 ns | 3,551.1 ns | 3,517.1 ns | 3,620.1 ns | 3,579.7 ns |     165 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,071.9 ns | 29.11 ns |  42.66 ns | 3,058.8 ns | 3,010.2 ns | 3,165.2 ns | 3,141.7 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 3,195.0 ns | 24.71 ns |  36.98 ns | 3,190.0 ns | 3,141.9 ns | 3,281.6 ns | 3,240.9 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 4,054.0 ns | 51.33 ns |  75.23 ns | 4,034.9 ns | 3,960.8 ns | 4,218.5 ns | 4,167.6 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 4,112.1 ns | 28.09 ns |  41.17 ns | 4,091.6 ns | 4,062.7 ns | 4,199.9 ns | 4,175.7 ns |     331 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,688.4 ns | 27.75 ns |  41.54 ns | 3,695.9 ns | 3,625.8 ns | 3,790.5 ns | 3,732.1 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 4,576.9 ns | 35.28 ns |  51.71 ns | 4,557.0 ns | 4,502.2 ns | 4,686.1 ns | 4,652.6 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,904.6 ns | 78.04 ns | 114.38 ns | 3,849.0 ns | 3,780.8 ns | 4,162.7 ns | 4,045.8 ns |     304 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,904.9 ns | 75.04 ns | 110.00 ns | 3,880.2 ns | 3,782.6 ns | 4,153.1 ns | 4,057.2 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 4,248.4 ns | 40.31 ns |  60.33 ns | 4,221.1 ns | 4,167.0 ns | 4,379.1 ns | 4,333.9 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,715.4 ns | 36.07 ns |  53.99 ns | 3,712.3 ns | 3,657.3 ns | 3,865.7 ns | 3,774.2 ns |     249 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,751.4 ns | 78.52 ns | 117.53 ns | 3,750.2 ns | 3,554.1 ns | 4,020.5 ns | 3,883.9 ns |     225 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 3,355.1 ns | 34.97 ns |  52.35 ns | 3,367.6 ns | 3,278.0 ns | 3,457.3 ns | 3,420.5 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,819.1 ns | 36.32 ns |  54.37 ns | 3,796.4 ns | 3,759.0 ns | 3,960.9 ns | 3,891.4 ns |     257 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,573.0 ns | 13.08 ns |  18.75 ns | 3,565.9 ns | 3,546.7 ns | 3,610.4 ns | 3,597.8 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,645.8 ns | 15.60 ns |  22.86 ns | 3,637.2 ns | 3,609.3 ns | 3,710.9 ns | 3,672.2 ns |     283 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 4,273.0 ns | 24.04 ns |  34.47 ns | 4,265.4 ns | 4,235.3 ns | 4,352.6 ns | 4,323.3 ns |     263 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,705.2 ns | 13.15 ns |  19.68 ns | 3,714.0 ns | 3,676.0 ns | 3,738.7 ns | 3,724.2 ns |     286 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,399.8 ns | 13.30 ns |  19.07 ns | 3,397.9 ns | 3,374.3 ns | 3,431.7 ns | 3,424.0 ns |     260 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 4,197.7 ns | 26.06 ns |  39.00 ns | 4,181.3 ns | 4,152.6 ns | 4,282.3 ns | 4,253.5 ns |     257 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,636.6 ns | 13.56 ns |  20.30 ns | 3,634.5 ns | 3,601.4 ns | 3,676.3 ns | 3,664.5 ns |     243 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,082.5 ns | 26.59 ns |  39.79 ns | 3,077.6 ns | 3,023.9 ns | 3,195.4 ns | 3,133.0 ns |     219 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 3,157.4 ns | 19.80 ns |  29.02 ns | 3,160.8 ns | 3,114.8 ns | 3,219.5 ns | 3,194.8 ns |     224 B |         - |

```
BenchmarkDotNet v0.14.0, Windows 11 (10.0.26100.4061)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 9.0.300
  [Host]     : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.5 (9.0.525.21509), X64 RyuJIT AVX2
```
| Method  | Parameter | Mean       | Error     | StdDev    | Median     | Min        | Max        | P90        | Code Size | Allocated |
|-------- |---------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **ArrayC1** | **1**         |   **899.2 ns** |  **17.09 ns** |  **40.95 ns** |   **895.6 ns** |   **820.5 ns** | **1,021.5 ns** |   **941.0 ns** |     **275 B** |         **-** |
| ArrayC2 | 1         | 1,072.8 ns |  21.32 ns |  43.06 ns | 1,057.0 ns |   982.8 ns | 1,188.3 ns | 1,126.5 ns |     313 B |         - |
| ArrayC3 | 1         |   812.5 ns |  15.67 ns |  19.82 ns |   808.8 ns |   783.3 ns |   852.1 ns |   840.5 ns |     299 B |         - |
| ArrayS1 | 1         |   789.7 ns |  15.76 ns |  28.82 ns |   781.7 ns |   747.0 ns |   871.4 ns |   823.2 ns |     281 B |         - |
| ArrayS2 | 1         |   812.8 ns |  30.63 ns |  90.30 ns |   773.8 ns |   655.5 ns | 1,032.2 ns |   959.5 ns |     287 B |         - |
| ArrayS3 | 1         |   550.7 ns |  14.08 ns |  37.58 ns |   547.5 ns |   459.2 ns |   674.6 ns |   595.1 ns |     273 B |         - |
| ArrayS4 | 1         |   676.1 ns |  13.04 ns |  18.71 ns |   673.0 ns |   615.0 ns |   708.4 ns |   697.1 ns |     275 B |         - |
| ArrayS5 | 1         |   495.3 ns |   9.66 ns |  15.59 ns |   488.5 ns |   476.8 ns |   531.0 ns |   516.2 ns |     257 B |         - |
| Link1   | 1         |   343.4 ns |   6.80 ns |  15.22 ns |   340.8 ns |   297.7 ns |   383.2 ns |   362.0 ns |     229 B |         - |
| Link2   | 1         |   522.9 ns |  13.20 ns |  35.68 ns |   521.3 ns |   440.0 ns |   614.2 ns |   573.9 ns |     234 B |         - |
| **ArrayC1** | **2**         | **1,816.0 ns** |  **35.58 ns** |  **63.25 ns** | **1,794.6 ns** | **1,741.3 ns** | **2,039.8 ns** | **1,900.6 ns** |     **259 B** |         **-** |
| ArrayC2 | 2         | 1,757.2 ns |  34.73 ns |  69.37 ns | 1,731.2 ns | 1,669.9 ns | 1,947.0 ns | 1,853.6 ns |     306 B |         - |
| ArrayC3 | 2         | 1,475.9 ns |  29.29 ns |  72.94 ns | 1,472.5 ns | 1,203.8 ns | 1,646.3 ns | 1,556.7 ns |     285 B |         - |
| ArrayS1 | 2         | 1,772.3 ns |  34.37 ns |  48.19 ns | 1,769.8 ns | 1,673.6 ns | 1,869.2 ns | 1,834.0 ns |     263 B |         - |
| ArrayS2 | 2         | 1,523.8 ns |  30.44 ns |  75.80 ns | 1,514.6 ns | 1,315.3 ns | 1,763.5 ns | 1,607.5 ns |     275 B |         - |
| ArrayS3 | 2         | 1,512.6 ns |  29.23 ns |  70.59 ns | 1,499.0 ns | 1,301.5 ns | 1,730.1 ns | 1,589.5 ns |     260 B |         - |
| ArrayS4 | 2         | 1,546.9 ns |  30.22 ns |  38.22 ns | 1,540.8 ns | 1,496.3 ns | 1,643.3 ns | 1,589.4 ns |     257 B |         - |
| ArrayS5 | 2         | 1,072.9 ns |  21.25 ns |  55.24 ns | 1,064.5 ns |   942.9 ns | 1,233.6 ns | 1,129.5 ns |     245 B |         - |
| Link1   | 2         | 1,038.4 ns |  20.29 ns |  48.21 ns | 1,034.4 ns |   959.3 ns | 1,186.9 ns | 1,105.6 ns |     219 B |         - |
| Link2   | 2         | 1,250.6 ns |  24.26 ns |  61.31 ns | 1,246.0 ns | 1,077.5 ns | 1,441.8 ns | 1,310.6 ns |     224 B |         - |
| **ArrayC1** | **4**         | **3,648.9 ns** |  **71.81 ns** | **107.49 ns** | **3,633.0 ns** | **3,504.9 ns** | **3,887.4 ns** | **3,811.1 ns** |     **257 B** |         **-** |
| ArrayC2 | 4         | 3,107.9 ns |  61.32 ns |  93.64 ns | 3,108.1 ns | 2,975.3 ns | 3,315.9 ns | 3,236.4 ns |     306 B |         - |
| ArrayC3 | 4         | 2,744.3 ns |  54.43 ns |  87.90 ns | 2,734.2 ns | 2,604.0 ns | 2,988.1 ns | 2,854.6 ns |     283 B |         - |
| ArrayS1 | 4         | 3,560.8 ns |  69.81 ns |  93.20 ns | 3,547.2 ns | 3,404.5 ns | 3,798.3 ns | 3,664.3 ns |     263 B |         - |
| ArrayS2 | 4         | 2,755.8 ns |  54.24 ns |  60.28 ns | 2,748.4 ns | 2,683.0 ns | 2,911.4 ns | 2,824.3 ns |     286 B |         - |
| ArrayS3 | 4         | 2,823.4 ns |  56.34 ns | 127.17 ns | 2,794.6 ns | 2,684.3 ns | 3,250.6 ns | 2,964.3 ns |     260 B |         - |
| ArrayS4 | 4         | 3,490.2 ns |  69.61 ns | 177.17 ns | 3,436.0 ns | 3,037.7 ns | 4,020.1 ns | 3,671.5 ns |     257 B |         - |
| ArrayS5 | 4         | 2,756.6 ns |  54.50 ns | 123.03 ns | 2,721.6 ns | 2,423.3 ns | 3,105.0 ns | 2,885.4 ns |     243 B |         - |
| Link1   | 4         | 2,357.7 ns |  46.67 ns | 112.73 ns | 2,341.5 ns | 2,041.1 ns | 2,645.6 ns | 2,469.9 ns |     219 B |         - |
| Link2   | 4         | 2,487.0 ns |  48.97 ns |  95.51 ns | 2,491.7 ns | 2,160.1 ns | 2,635.4 ns | 2,572.7 ns |     224 B |         - |
| **ArrayC1** | **8**         | **7,363.1 ns** | **145.66 ns** | **273.59 ns** | **7,287.4 ns** | **7,028.3 ns** | **8,253.3 ns** | **7,655.4 ns** |     **257 B** |         **-** |
| ArrayC2 | 8         | 5,705.4 ns | 112.15 ns | 250.83 ns | 5,671.6 ns | 4,939.3 ns | 6,499.2 ns | 5,969.6 ns |     306 B |         - |
| ArrayC3 | 8         | 5,169.6 ns | 102.68 ns | 209.76 ns | 5,133.7 ns | 4,681.6 ns | 5,730.9 ns | 5,425.0 ns |     283 B |         - |
| ArrayS1 | 8         | 6,794.2 ns | 130.37 ns | 263.35 ns | 6,767.6 ns | 6,436.1 ns | 7,620.3 ns | 7,137.9 ns |     263 B |         - |
| ArrayS2 | 8         | 5,281.9 ns | 104.52 ns | 206.31 ns | 5,273.9 ns | 4,609.0 ns | 5,782.9 ns | 5,486.3 ns |     286 B |         - |
| ArrayS3 | 8         | 5,309.8 ns | 107.79 ns | 293.26 ns | 5,258.9 ns | 4,546.1 ns | 6,090.3 ns | 5,639.3 ns |     260 B |         - |
| ArrayS4 | 8         | 6,699.4 ns | 123.90 ns | 271.97 ns | 6,624.7 ns | 6,363.8 ns | 7,769.4 ns | 7,080.4 ns |     257 B |         - |
| ArrayS5 | 8         | 5,815.2 ns | 116.25 ns | 271.72 ns | 5,759.0 ns | 5,058.1 ns | 6,664.3 ns | 6,101.4 ns |     243 B |         - |
| Link1   | 8         | 5,191.3 ns | 103.25 ns | 247.38 ns | 5,171.8 ns | 4,539.7 ns | 5,733.5 ns | 5,519.8 ns |     219 B |         - |
| Link2   | 8         | 5,426.9 ns | 107.63 ns | 242.94 ns | 5,358.7 ns | 4,794.9 ns | 6,041.2 ns | 5,745.0 ns |     224 B |         - |
