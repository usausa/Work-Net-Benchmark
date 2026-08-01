```

BenchmarkDotNet v0.15.8, Windows 11 (10.0.26200.8894/25H2/2025Update/HudsonValley2)
AMD Ryzen 9 5900X 3.70GHz, 1 CPU, 24 logical and 12 physical cores
.NET SDK 10.0.302
  [Host]              : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 10.0 : .NET 10.0.10 (10.0.10, 10.0.1026.32716), X64 RyuJIT x86-64-v3
  MediumRun-.NET 8.0  : .NET 8.0.29 (8.0.29, 8.0.2926.32403), X64 RyuJIT x86-64-v3
  MediumRun-.NET 9.0  : .NET 9.0.18 (9.0.18, 9.0.1826.31522), X64 RyuJIT x86-64-v3

IterationCount=15  LaunchCount=2  WarmupCount=10  

```
| Method  | Job                 | Runtime   | Parameter | Mean       | Error     | StdDev    | Median     | Min        | Max        | P90        | Code Size | Allocated |
|-------- |-------------------- |---------- |---------- |-----------:|----------:|----------:|-----------:|-----------:|-----------:|-----------:|----------:|----------:|
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **1**         |   **833.2 ns** |   **6.69 ns** |  **10.02 ns** |   **830.5 ns** |   **820.0 ns** |   **856.2 ns** |   **846.4 ns** |     **278 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   988.9 ns |   7.31 ns |  10.94 ns |   992.5 ns |   963.8 ns | 1,004.7 ns |   998.9 ns |     316 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   679.6 ns |   5.73 ns |   8.39 ns |   680.4 ns |   662.9 ns |   696.8 ns |   689.2 ns |     303 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   690.5 ns |   6.09 ns |   8.73 ns |   690.2 ns |   675.4 ns |   715.0 ns |   701.7 ns |     281 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   661.9 ns |   3.09 ns |   4.43 ns |   660.1 ns |   656.6 ns |   673.4 ns |   667.9 ns |     291 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   455.4 ns |   2.47 ns |   3.62 ns |   456.5 ns |   448.9 ns |   463.0 ns |   458.7 ns |     269 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   591.1 ns |   4.84 ns |   7.09 ns |   590.0 ns |   581.4 ns |   611.2 ns |   599.1 ns |     278 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   623.7 ns |   3.70 ns |   5.54 ns |   622.6 ns |   616.1 ns |   633.5 ns |   631.6 ns |     258 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   301.1 ns |   5.96 ns |   8.73 ns |   298.1 ns |   288.3 ns |   323.7 ns |   314.7 ns |     232 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 1         |   454.8 ns |   3.61 ns |   5.30 ns |   453.6 ns |   447.2 ns |   469.1 ns |   462.2 ns |     237 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   832.0 ns |  11.69 ns |  17.50 ns |   832.8 ns |   801.4 ns |   862.7 ns |   858.4 ns |     280 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 1         | 1,028.6 ns |   7.50 ns |  10.76 ns | 1,028.4 ns | 1,007.5 ns | 1,055.7 ns | 1,041.0 ns |     319 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   771.6 ns |   9.23 ns |  13.82 ns |   770.9 ns |   747.7 ns |   804.9 ns |   787.1 ns |     304 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   700.5 ns |   5.33 ns |   7.81 ns |   700.9 ns |   688.7 ns |   721.0 ns |   709.3 ns |     283 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   668.6 ns |   6.30 ns |   9.04 ns |   667.4 ns |   658.5 ns |   695.1 ns |   678.6 ns |     289 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   572.0 ns |   8.92 ns |  12.79 ns |   568.7 ns |   552.8 ns |   604.1 ns |   588.9 ns |     280 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   578.7 ns |   4.49 ns |   6.71 ns |   577.5 ns |   568.6 ns |   592.9 ns |   588.4 ns |     277 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   565.3 ns |   6.24 ns |   9.14 ns |   563.2 ns |   554.1 ns |   592.5 ns |   577.4 ns |     257 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   296.9 ns |   2.57 ns |   3.76 ns |   297.8 ns |   287.5 ns |   303.7 ns |   300.8 ns |     231 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 1         |   526.6 ns |  76.65 ns | 114.73 ns |   464.5 ns |   438.5 ns |   807.0 ns |   701.3 ns |     236 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   844.9 ns |  19.34 ns |  28.95 ns |   834.7 ns |   817.7 ns |   937.4 ns |   879.4 ns |     275 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 1         | 1,117.9 ns |  72.09 ns | 107.90 ns | 1,114.5 ns |   980.8 ns | 1,331.9 ns | 1,268.5 ns |     313 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   792.1 ns |  18.88 ns |  27.07 ns |   790.3 ns |   747.4 ns |   856.8 ns |   826.6 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   759.7 ns |  19.76 ns |  29.57 ns |   751.2 ns |   712.0 ns |   823.8 ns |   793.0 ns |     281 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   752.4 ns |  28.10 ns |  40.31 ns |   744.0 ns |   702.8 ns |   854.3 ns |   811.5 ns |     287 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   503.8 ns |   8.85 ns |  12.41 ns |   499.7 ns |   492.1 ns |   539.3 ns |   520.0 ns |     273 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   595.9 ns |  16.78 ns |  25.12 ns |   595.0 ns |   561.9 ns |   661.6 ns |   625.2 ns |     275 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   587.0 ns |  27.95 ns |  39.19 ns |   556.5 ns |   535.0 ns |   646.3 ns |   629.9 ns |     255 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   439.9 ns |   2.78 ns |   4.16 ns |   439.3 ns |   433.0 ns |   447.3 ns |   445.5 ns |     229 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 1         |   342.2 ns |   2.57 ns |   3.61 ns |   342.2 ns |   335.1 ns |   347.6 ns |   346.8 ns |     234 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **2**         | **1,584.1 ns** |  **20.52 ns** |  **30.71 ns** | **1,574.9 ns** | **1,547.3 ns** | **1,665.4 ns** | **1,622.0 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,487.7 ns |  45.25 ns |  66.33 ns | 1,446.3 ns | 1,409.5 ns | 1,587.9 ns | 1,566.0 ns |     231 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,331.5 ns |  17.06 ns |  25.01 ns | 1,325.7 ns | 1,299.2 ns | 1,402.2 ns | 1,362.1 ns |     210 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,434.9 ns |   8.59 ns |  12.85 ns | 1,432.1 ns | 1,417.8 ns | 1,462.9 ns | 1,453.0 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,552.0 ns |  14.53 ns |  20.84 ns | 1,552.8 ns | 1,513.6 ns | 1,591.8 ns | 1,575.8 ns |     208 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,116.3 ns |  11.37 ns |  17.01 ns | 1,117.4 ns | 1,084.3 ns | 1,143.6 ns | 1,138.4 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,354.8 ns |  13.78 ns |  20.63 ns | 1,356.3 ns | 1,315.2 ns | 1,397.8 ns | 1,376.0 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   933.4 ns |  10.92 ns |  16.01 ns |   934.0 ns |   898.4 ns |   960.4 ns |   952.0 ns |     171 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 2         |   802.7 ns |  10.39 ns |  14.91 ns |   800.1 ns |   778.3 ns |   831.7 ns |   826.0 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 2         | 1,100.9 ns |   9.60 ns |  14.07 ns | 1,100.7 ns | 1,079.6 ns | 1,135.6 ns | 1,119.1 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,608.8 ns |  15.26 ns |  21.88 ns | 1,608.7 ns | 1,579.5 ns | 1,661.2 ns | 1,634.7 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,553.7 ns |  15.92 ns |  22.31 ns | 1,555.9 ns | 1,512.9 ns | 1,592.5 ns | 1,583.6 ns |     336 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,756.6 ns | 165.48 ns | 242.56 ns | 1,685.8 ns | 1,512.9 ns | 2,259.0 ns | 2,130.7 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,846.3 ns | 198.75 ns | 285.04 ns | 1,697.9 ns | 1,609.5 ns | 2,417.1 ns | 2,335.7 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,603.6 ns | 109.70 ns | 157.32 ns | 1,632.1 ns | 1,396.0 ns | 1,913.1 ns | 1,800.0 ns |     301 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,768.7 ns | 260.16 ns | 381.34 ns | 1,626.7 ns | 1,392.4 ns | 2,459.7 ns | 2,386.4 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,539.2 ns |  10.06 ns |  14.42 ns | 1,536.0 ns | 1,521.6 ns | 1,576.0 ns | 1,559.3 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,321.6 ns |   7.06 ns |  10.35 ns | 1,320.9 ns | 1,305.0 ns | 1,341.4 ns | 1,335.7 ns |     253 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,219.0 ns |  84.12 ns | 125.91 ns | 1,212.4 ns | 1,081.2 ns | 1,379.1 ns | 1,362.4 ns |     227 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 2         | 1,219.3 ns |  74.54 ns | 106.91 ns | 1,301.6 ns | 1,080.1 ns | 1,335.5 ns | 1,324.1 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,635.0 ns |  24.68 ns |  36.94 ns | 1,638.2 ns | 1,580.8 ns | 1,696.8 ns | 1,680.6 ns |     257 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,434.2 ns |  13.32 ns |  19.93 ns | 1,433.3 ns | 1,408.2 ns | 1,470.8 ns | 1,460.1 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,224.5 ns |  30.94 ns |  46.31 ns | 1,210.2 ns | 1,172.5 ns | 1,309.2 ns | 1,285.4 ns |     285 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,565.5 ns |  21.55 ns |  32.25 ns | 1,566.0 ns | 1,517.0 ns | 1,651.0 ns | 1,608.7 ns |     269 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,136.4 ns |  15.46 ns |  22.66 ns | 1,140.0 ns | 1,093.0 ns | 1,197.7 ns | 1,157.9 ns |     275 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,230.7 ns |   9.61 ns |  14.39 ns | 1,231.7 ns | 1,201.5 ns | 1,263.3 ns | 1,245.8 ns |     260 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,389.2 ns |  28.33 ns |  41.53 ns | 1,410.9 ns | 1,322.3 ns | 1,442.5 ns | 1,431.5 ns |     263 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,103.8 ns |   7.22 ns |  10.80 ns | 1,105.4 ns | 1,087.4 ns | 1,127.1 ns | 1,120.3 ns |     245 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,114.0 ns |  17.76 ns |  26.03 ns | 1,111.2 ns | 1,078.8 ns | 1,169.5 ns | 1,146.6 ns |     221 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 2         | 1,034.5 ns |  46.07 ns |  67.53 ns | 1,080.7 ns |   949.0 ns | 1,119.5 ns | 1,106.0 ns |     226 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **4**         | **3,115.2 ns** |  **27.34 ns** |  **40.07 ns** | **3,105.9 ns** | **3,058.2 ns** | **3,211.9 ns** | **3,169.6 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,747.5 ns | 128.83 ns | 192.83 ns | 2,659.8 ns | 2,563.3 ns | 3,220.8 ns | 3,073.6 ns |     230 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,308.7 ns |  16.23 ns |  22.22 ns | 2,302.7 ns | 2,278.4 ns | 2,373.8 ns | 2,330.5 ns |     198 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 3,232.0 ns |  53.99 ns |  80.81 ns | 3,207.2 ns | 3,133.6 ns | 3,393.7 ns | 3,349.5 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,356.8 ns |  58.58 ns |  87.68 ns | 2,325.9 ns | 2,271.9 ns | 2,599.8 ns | 2,506.5 ns |     197 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,100.4 ns |  17.43 ns |  25.55 ns | 2,104.0 ns | 2,062.4 ns | 2,153.1 ns | 2,135.7 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,844.7 ns |  13.82 ns |  20.25 ns | 2,843.9 ns | 2,799.7 ns | 2,885.6 ns | 2,872.3 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,427.5 ns |  25.03 ns |  37.47 ns | 2,417.4 ns | 2,382.5 ns | 2,516.7 ns | 2,501.5 ns |     168 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 1,986.7 ns |  13.07 ns |  19.16 ns | 1,991.6 ns | 1,961.0 ns | 2,029.1 ns | 2,006.7 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 4         | 2,021.1 ns |  12.73 ns |  18.25 ns | 2,021.7 ns | 1,992.5 ns | 2,058.6 ns | 2,043.1 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,542.8 ns |  35.99 ns |  52.75 ns | 3,546.5 ns | 3,443.7 ns | 3,646.2 ns | 3,609.2 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,660.4 ns |  18.60 ns |  27.26 ns | 2,664.2 ns | 2,606.7 ns | 2,709.3 ns | 2,688.5 ns |     331 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,873.0 ns |  29.92 ns |  42.91 ns | 2,867.5 ns | 2,813.2 ns | 2,996.3 ns | 2,936.6 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,409.6 ns |  48.84 ns |  70.05 ns | 3,401.2 ns | 3,312.5 ns | 3,560.9 ns | 3,520.0 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,387.0 ns |  48.46 ns |  71.03 ns | 3,385.2 ns | 3,262.8 ns | 3,554.9 ns | 3,476.7 ns |     304 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,321.7 ns |  28.94 ns |  43.32 ns | 3,317.0 ns | 3,243.9 ns | 3,430.1 ns | 3,384.2 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,362.5 ns |  41.05 ns |  61.44 ns | 3,356.7 ns | 3,253.8 ns | 3,480.1 ns | 3,436.4 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,740.7 ns |  31.94 ns |  45.81 ns | 2,749.5 ns | 2,628.3 ns | 2,812.4 ns | 2,801.3 ns |     251 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 3,366.0 ns |  37.45 ns |  54.89 ns | 3,355.1 ns | 3,284.7 ns | 3,500.1 ns | 3,429.9 ns |     225 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 4         | 2,680.1 ns |  34.06 ns |  48.84 ns | 2,673.4 ns | 2,606.3 ns | 2,806.7 ns | 2,738.7 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 3,273.9 ns |  43.51 ns |  65.13 ns | 3,262.8 ns | 3,161.6 ns | 3,411.5 ns | 3,345.8 ns |     257 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,560.6 ns |  41.53 ns |  62.16 ns | 2,554.3 ns | 2,467.9 ns | 2,695.6 ns | 2,637.0 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,435.0 ns |  26.21 ns |  38.41 ns | 2,423.3 ns | 2,384.1 ns | 2,531.8 ns | 2,495.4 ns |     283 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 3,252.5 ns |  42.21 ns |  63.18 ns | 3,245.1 ns | 3,174.3 ns | 3,408.8 ns | 3,328.6 ns |     263 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,462.3 ns |  29.55 ns |  44.23 ns | 2,461.3 ns | 2,390.0 ns | 2,545.6 ns | 2,523.4 ns |     286 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,440.8 ns |  19.49 ns |  27.96 ns | 2,437.4 ns | 2,401.3 ns | 2,519.8 ns | 2,473.7 ns |     260 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 3,019.5 ns |  26.77 ns |  39.24 ns | 3,021.1 ns | 2,965.7 ns | 3,129.9 ns | 3,063.5 ns |     257 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,451.4 ns | 254.51 ns | 380.94 ns | 2,273.0 ns | 2,198.5 ns | 3,687.2 ns | 3,115.3 ns |     245 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,442.4 ns |  42.82 ns |  64.09 ns | 2,421.0 ns | 2,371.2 ns | 2,606.6 ns | 2,534.5 ns |     219 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 4         | 2,233.5 ns |  17.44 ns |  25.02 ns | 2,243.6 ns | 2,185.4 ns | 2,266.4 ns | 2,258.6 ns |     224 B |         - |
| **ArrayC1** | **MediumRun-.NET 10.0** | **.NET 10.0** | **8**         | **6,426.4 ns** |  **46.72 ns** |  **69.92 ns** | **6,434.5 ns** | **6,284.4 ns** | **6,573.5 ns** | **6,496.0 ns** |     **171 B** |         **-** |
| ArrayC2 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,672.2 ns |  65.54 ns |  96.07 ns | 4,667.4 ns | 4,531.7 ns | 4,891.2 ns | 4,807.6 ns |     230 B |         - |
| ArrayC3 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,474.5 ns |  31.09 ns |  44.59 ns | 4,488.1 ns | 4,395.7 ns | 4,565.2 ns | 4,515.3 ns |     198 B |         - |
| ArrayS1 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 5,509.1 ns |  33.42 ns |  46.85 ns | 5,500.5 ns | 5,432.6 ns | 5,632.0 ns | 5,562.4 ns |     174 B |         - |
| ArrayS2 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,487.7 ns |  29.51 ns |  44.17 ns | 4,486.5 ns | 4,420.5 ns | 4,589.6 ns | 4,541.6 ns |     197 B |         - |
| ArrayS3 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,263.7 ns |  23.43 ns |  35.08 ns | 4,264.4 ns | 4,200.1 ns | 4,326.6 ns | 4,306.3 ns |     169 B |         - |
| ArrayS4 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 5,907.1 ns |  98.75 ns | 141.62 ns | 5,858.6 ns | 5,739.8 ns | 6,241.3 ns | 6,079.1 ns |     171 B |         - |
| ArrayS5 | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 5,056.4 ns |  49.78 ns |  74.51 ns | 5,053.3 ns | 4,935.5 ns | 5,269.7 ns | 5,145.3 ns |     168 B |         - |
| Link1   | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,606.7 ns |  45.93 ns |  67.32 ns | 4,581.0 ns | 4,510.9 ns | 4,751.6 ns | 4,704.2 ns |     142 B |         - |
| Link2   | MediumRun-.NET 10.0 | .NET 10.0 | 8         | 4,488.0 ns |  23.13 ns |  33.91 ns | 4,491.5 ns | 4,414.7 ns | 4,552.5 ns | 4,524.1 ns |     138 B |         - |
| ArrayC1 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,715.2 ns |  68.36 ns | 102.32 ns | 6,696.9 ns | 6,583.8 ns | 7,019.1 ns | 6,857.6 ns |     270 B |         - |
| ArrayC2 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 5,294.0 ns |  26.14 ns |  38.32 ns | 5,287.1 ns | 5,237.7 ns | 5,383.6 ns | 5,336.3 ns |     331 B |         - |
| ArrayC3 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 5,550.6 ns |  66.59 ns |  99.67 ns | 5,519.7 ns | 5,446.7 ns | 5,792.5 ns | 5,758.2 ns |     299 B |         - |
| ArrayS1 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,851.2 ns |  58.79 ns |  84.32 ns | 6,821.2 ns | 6,732.2 ns | 7,035.0 ns | 6,969.2 ns |     273 B |         - |
| ArrayS2 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,809.6 ns |  59.88 ns |  85.87 ns | 6,802.6 ns | 6,698.1 ns | 7,028.9 ns | 6,931.1 ns |     304 B |         - |
| ArrayS3 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,845.2 ns |  67.76 ns | 101.43 ns | 6,820.4 ns | 6,697.1 ns | 7,115.7 ns | 6,999.2 ns |     270 B |         - |
| ArrayS4 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,807.7 ns |  37.06 ns |  55.48 ns | 6,806.9 ns | 6,715.6 ns | 6,909.3 ns | 6,880.0 ns |     267 B |         - |
| ArrayS5 | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 5,285.3 ns |  61.07 ns |  89.52 ns | 5,271.5 ns | 5,144.9 ns | 5,533.1 ns | 5,424.8 ns |     251 B |         - |
| Link1   | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 6,787.2 ns |  49.99 ns |  73.28 ns | 6,799.8 ns | 6,668.3 ns | 6,936.2 ns | 6,873.9 ns |     225 B |         - |
| Link2   | MediumRun-.NET 8.0  | .NET 8.0  | 8         | 5,274.9 ns |  37.08 ns |  54.35 ns | 5,286.7 ns | 5,197.0 ns | 5,367.7 ns | 5,358.5 ns |     230 B |         - |
| ArrayC1 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 6,434.9 ns |  32.25 ns |  44.15 ns | 6,437.7 ns | 6,372.3 ns | 6,505.6 ns | 6,489.4 ns |     257 B |         - |
| ArrayC2 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 5,058.3 ns |  33.62 ns |  49.28 ns | 5,044.5 ns | 4,987.0 ns | 5,178.5 ns | 5,123.9 ns |     306 B |         - |
| ArrayC3 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 4,687.7 ns |  54.23 ns |  77.77 ns | 4,675.9 ns | 4,579.7 ns | 4,882.7 ns | 4,777.3 ns |     283 B |         - |
| ArrayS1 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 6,020.0 ns |  28.06 ns |  42.00 ns | 6,018.7 ns | 5,957.1 ns | 6,089.5 ns | 6,081.0 ns |     263 B |         - |
| ArrayS2 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 5,122.4 ns |  68.67 ns | 102.79 ns | 5,093.7 ns | 5,011.1 ns | 5,409.1 ns | 5,272.6 ns |     286 B |         - |
| ArrayS3 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 5,084.5 ns |  31.07 ns |  46.51 ns | 5,085.1 ns | 5,018.4 ns | 5,186.6 ns | 5,145.9 ns |     260 B |         - |
| ArrayS4 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 5,952.9 ns |  42.82 ns |  64.09 ns | 5,949.6 ns | 5,861.6 ns | 6,062.4 ns | 6,045.5 ns |     257 B |         - |
| ArrayS5 | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 4,576.5 ns |  58.21 ns |  87.13 ns | 4,574.0 ns | 4,455.7 ns | 4,830.9 ns | 4,697.7 ns |     245 B |         - |
| Link1   | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 5,063.8 ns |  25.02 ns |  35.88 ns | 5,064.6 ns | 5,020.7 ns | 5,151.9 ns | 5,118.8 ns |     219 B |         - |
| Link2   | MediumRun-.NET 9.0  | .NET 9.0  | 8         | 4,864.5 ns |  34.21 ns |  49.07 ns | 4,866.6 ns | 4,786.0 ns | 4,962.4 ns | 4,937.6 ns |     224 B |         - |
