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
| Method      | Job                 | Runtime   | Size   | Mean         | Error      | StdDev     | Median       | Min          | Max          | P90          | Code Size | Allocated |
|------------ |-------------------- |---------- |------- |-------------:|-----------:|-----------:|-------------:|-------------:|-------------:|-------------:|----------:|----------:|
| **For**         | **MediumRun-.NET 10.0** | **.NET 10.0** | **100**    |     **22.20 ns** |   **0.209 ns** |   **0.312 ns** |     **22.21 ns** |     **21.73 ns** |     **22.80 ns** |     **22.70 ns** |      **78 B** |         **-** |
| While       | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     22.16 ns |   0.248 ns |   0.356 ns |     22.09 ns |     21.65 ns |     23.07 ns |     22.61 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     24.45 ns |   0.152 ns |   0.223 ns |     24.40 ns |     24.12 ns |     25.06 ns |     24.77 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     17.19 ns |   0.188 ns |   0.282 ns |     17.10 ns |     16.86 ns |     17.80 ns |     17.59 ns |      68 B |         - |
| ForSpan2    | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     16.96 ns |   0.152 ns |   0.227 ns |     16.88 ns |     16.65 ns |     17.53 ns |     17.25 ns |      70 B |         - |
| ForeachSpan | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     17.74 ns |   0.574 ns |   0.823 ns |     17.52 ns |     16.77 ns |     19.27 ns |     19.05 ns |      68 B |         - |
| RefLoopSpan | MediumRun-.NET 10.0 | .NET 10.0 | 100    |     18.07 ns |   0.537 ns |   0.752 ns |     17.69 ns |     17.14 ns |     19.68 ns |     19.10 ns |      73 B |         - |
| For         | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     25.54 ns |   0.627 ns |   0.879 ns |     25.19 ns |     24.57 ns |     28.19 ns |     26.33 ns |      82 B |         - |
| While       | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     25.01 ns |   0.184 ns |   0.270 ns |     25.01 ns |     24.48 ns |     25.53 ns |     25.34 ns |      82 B |         - |
| ForEach     | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     25.31 ns |   0.191 ns |   0.280 ns |     25.24 ns |     24.85 ns |     26.02 ns |     25.65 ns |      73 B |         - |
| ForSpan     | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     15.51 ns |   0.180 ns |   0.269 ns |     15.42 ns |     15.17 ns |     16.26 ns |     15.78 ns |      85 B |         - |
| ForSpan2    | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     16.71 ns |   0.158 ns |   0.231 ns |     16.62 ns |     16.42 ns |     17.22 ns |     17.07 ns |      85 B |         - |
| ForeachSpan | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     16.58 ns |   0.129 ns |   0.181 ns |     16.60 ns |     16.29 ns |     17.08 ns |     16.76 ns |      85 B |         - |
| RefLoopSpan | MediumRun-.NET 8.0  | .NET 8.0  | 100    |     16.59 ns |   0.199 ns |   0.298 ns |     16.45 ns |     16.26 ns |     17.42 ns |     16.98 ns |      87 B |         - |
| For         | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     24.67 ns |   0.236 ns |   0.353 ns |     24.61 ns |     24.16 ns |     25.59 ns |     25.14 ns |      78 B |         - |
| While       | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     24.66 ns |   0.171 ns |   0.239 ns |     24.64 ns |     24.16 ns |     25.05 ns |     24.92 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     23.30 ns |   0.107 ns |   0.154 ns |     23.26 ns |     23.05 ns |     23.70 ns |     23.49 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     18.95 ns |   0.176 ns |   0.263 ns |     18.95 ns |     18.52 ns |     19.52 ns |     19.30 ns |      69 B |         - |
| ForSpan2    | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     18.99 ns |   0.157 ns |   0.234 ns |     18.96 ns |     18.70 ns |     19.72 ns |     19.25 ns |      69 B |         - |
| ForeachSpan | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     19.02 ns |   0.126 ns |   0.189 ns |     19.02 ns |     18.70 ns |     19.34 ns |     19.28 ns |      69 B |         - |
| RefLoopSpan | MediumRun-.NET 9.0  | .NET 9.0  | 100    |     16.37 ns |   0.155 ns |   0.232 ns |     16.32 ns |     16.05 ns |     16.81 ns |     16.70 ns |      73 B |         - |
| **For**         | **MediumRun-.NET 10.0** | **.NET 10.0** | **1000**   |    **220.60 ns** |   **1.632 ns** |   **2.233 ns** |    **220.58 ns** |    **217.11 ns** |    **225.21 ns** |    **223.64 ns** |      **78 B** |         **-** |
| While       | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    220.46 ns |   1.866 ns |   2.735 ns |    220.37 ns |    214.54 ns |    227.18 ns |    223.56 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    234.23 ns |   1.977 ns |   2.958 ns |    233.77 ns |    229.83 ns |    241.74 ns |    238.27 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    205.86 ns |   0.950 ns |   1.422 ns |    205.81 ns |    203.92 ns |    208.97 ns |    207.88 ns |      68 B |         - |
| ForSpan2    | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    205.72 ns |   0.684 ns |   0.981 ns |    205.37 ns |    204.16 ns |    207.88 ns |    207.07 ns |      70 B |         - |
| ForeachSpan | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    205.77 ns |   0.793 ns |   1.186 ns |    205.81 ns |    203.74 ns |    208.33 ns |    207.13 ns |      68 B |         - |
| RefLoopSpan | MediumRun-.NET 10.0 | .NET 10.0 | 1000   |    206.44 ns |   0.741 ns |   1.086 ns |    206.53 ns |    204.72 ns |    209.63 ns |    207.77 ns |      73 B |         - |
| For         | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    221.59 ns |   1.726 ns |   2.530 ns |    221.85 ns |    217.52 ns |    226.77 ns |    224.77 ns |      82 B |         - |
| While       | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    221.14 ns |   1.796 ns |   2.632 ns |    220.84 ns |    217.25 ns |    227.89 ns |    223.88 ns |      82 B |         - |
| ForEach     | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    249.68 ns |   3.538 ns |   5.296 ns |    247.58 ns |    244.32 ns |    266.60 ns |    256.50 ns |      73 B |         - |
| ForSpan     | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    204.25 ns |   0.722 ns |   1.058 ns |    204.34 ns |    202.64 ns |    206.74 ns |    205.37 ns |      85 B |         - |
| ForSpan2    | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    204.25 ns |   0.743 ns |   1.066 ns |    204.13 ns |    202.77 ns |    206.55 ns |    205.60 ns |      85 B |         - |
| ForeachSpan | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    204.27 ns |   0.731 ns |   1.094 ns |    203.90 ns |    202.72 ns |    206.60 ns |    205.90 ns |      85 B |         - |
| RefLoopSpan | MediumRun-.NET 8.0  | .NET 8.0  | 1000   |    206.44 ns |   0.790 ns |   1.133 ns |    206.50 ns |    204.63 ns |    209.02 ns |    208.03 ns |      87 B |         - |
| For         | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    219.79 ns |   2.002 ns |   2.935 ns |    219.18 ns |    215.62 ns |    227.64 ns |    223.75 ns |      78 B |         - |
| While       | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    219.13 ns |   1.521 ns |   2.276 ns |    218.71 ns |    216.01 ns |    225.16 ns |    221.41 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    232.04 ns |   1.193 ns |   1.785 ns |    232.48 ns |    229.28 ns |    236.39 ns |    233.74 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    205.62 ns |   0.640 ns |   0.917 ns |    205.74 ns |    204.02 ns |    207.69 ns |    206.61 ns |      69 B |         - |
| ForSpan2    | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    205.86 ns |   0.676 ns |   0.969 ns |    206.09 ns |    204.23 ns |    207.83 ns |    207.00 ns |      69 B |         - |
| ForeachSpan | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    206.05 ns |   0.707 ns |   1.058 ns |    206.18 ns |    204.56 ns |    208.75 ns |    207.43 ns |      69 B |         - |
| RefLoopSpan | MediumRun-.NET 9.0  | .NET 9.0  | 1000   |    205.99 ns |   0.574 ns |   0.805 ns |    205.77 ns |    204.77 ns |    207.85 ns |    207.01 ns |      73 B |         - |
| **For**         | **MediumRun-.NET 10.0** | **.NET 10.0** | **10000**  |  **2,113.00 ns** |  **24.070 ns** |  **36.026 ns** |  **2,104.36 ns** |  **2,063.08 ns** |  **2,194.78 ns** |  **2,161.90 ns** |      **78 B** |         **-** |
| While       | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  2,102.23 ns |  21.041 ns |  30.177 ns |  2,091.43 ns |  2,053.81 ns |  2,170.58 ns |  2,141.11 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  2,395.74 ns |  14.318 ns |  20.988 ns |  2,397.57 ns |  2,358.37 ns |  2,432.46 ns |  2,418.13 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  1,985.87 ns |   9.028 ns |  13.513 ns |  1,981.55 ns |  1,969.43 ns |  2,014.34 ns |  2,005.81 ns |      68 B |         - |
| ForSpan2    | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  1,988.76 ns |  12.128 ns |  18.152 ns |  1,981.96 ns |  1,970.08 ns |  2,044.25 ns |  2,009.76 ns |      70 B |         - |
| ForeachSpan | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  1,990.19 ns |  10.146 ns |  15.186 ns |  1,991.16 ns |  1,968.79 ns |  2,030.76 ns |  2,007.88 ns |      68 B |         - |
| RefLoopSpan | MediumRun-.NET 10.0 | .NET 10.0 | 10000  |  1,987.26 ns |   9.776 ns |  14.021 ns |  1,982.64 ns |  1,970.83 ns |  2,028.80 ns |  2,004.69 ns |      73 B |         - |
| For         | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  2,116.02 ns |  24.996 ns |  35.849 ns |  2,103.36 ns |  2,075.55 ns |  2,186.31 ns |  2,173.14 ns |      82 B |         - |
| While       | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  2,126.02 ns |  40.919 ns |  61.245 ns |  2,126.21 ns |  2,046.65 ns |  2,295.61 ns |  2,203.63 ns |      82 B |         - |
| ForEach     | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  2,472.69 ns |  21.679 ns |  32.449 ns |  2,461.23 ns |  2,429.41 ns |  2,545.34 ns |  2,520.50 ns |      69 B |         - |
| ForSpan     | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  1,982.59 ns |   8.827 ns |  13.212 ns |  1,976.33 ns |  1,967.31 ns |  2,009.49 ns |  2,000.87 ns |      85 B |         - |
| ForSpan2    | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  1,984.35 ns |   9.629 ns |  14.413 ns |  1,976.80 ns |  1,968.82 ns |  2,017.76 ns |  2,004.48 ns |      85 B |         - |
| ForeachSpan | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  1,986.82 ns |   9.742 ns |  14.581 ns |  1,982.59 ns |  1,966.86 ns |  2,018.13 ns |  2,010.08 ns |      85 B |         - |
| RefLoopSpan | MediumRun-.NET 8.0  | .NET 8.0  | 10000  |  1,985.42 ns |   8.845 ns |  12.965 ns |  1,979.89 ns |  1,970.60 ns |  2,012.27 ns |  2,004.48 ns |      87 B |         - |
| For         | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  2,122.79 ns |  25.978 ns |  38.883 ns |  2,114.16 ns |  2,062.90 ns |  2,202.82 ns |  2,176.93 ns |      78 B |         - |
| While       | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  2,109.29 ns |  23.496 ns |  35.168 ns |  2,099.70 ns |  2,065.90 ns |  2,168.92 ns |  2,158.68 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  2,438.67 ns |   9.647 ns |  14.440 ns |  2,441.21 ns |  2,412.47 ns |  2,463.07 ns |  2,457.10 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  1,985.49 ns |   9.962 ns |  13.965 ns |  1,982.65 ns |  1,968.07 ns |  2,026.67 ns |  2,005.09 ns |      69 B |         - |
| ForSpan2    | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  1,984.53 ns |   8.758 ns |  12.837 ns |  1,978.49 ns |  1,969.02 ns |  2,016.83 ns |  2,000.53 ns |      69 B |         - |
| ForeachSpan | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  1,992.05 ns |  10.961 ns |  16.406 ns |  1,988.23 ns |  1,971.70 ns |  2,030.08 ns |  2,011.72 ns |      69 B |         - |
| RefLoopSpan | MediumRun-.NET 9.0  | .NET 9.0  | 10000  |  1,985.58 ns |   7.938 ns |  11.881 ns |  1,981.22 ns |  1,970.74 ns |  2,007.50 ns |  2,001.72 ns |      73 B |         - |
| **For**         | **MediumRun-.NET 10.0** | **.NET 10.0** | **100000** | **20,862.19 ns** | **240.379 ns** | **359.788 ns** | **20,752.39 ns** | **20,408.79 ns** | **21,681.47 ns** | **21,358.58 ns** |      **78 B** |         **-** |
| While       | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 20,745.21 ns | 223.990 ns | 335.257 ns | 20,625.18 ns | 20,363.45 ns | 21,552.42 ns | 21,161.35 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 24,955.68 ns | 108.433 ns | 162.297 ns | 24,965.50 ns | 24,727.61 ns | 25,381.44 ns | 25,116.11 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 19,857.49 ns |  93.394 ns | 136.896 ns | 19,799.14 ns | 19,695.74 ns | 20,062.13 ns | 20,033.54 ns |      68 B |         - |
| ForSpan2    | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 19,891.74 ns | 115.463 ns | 169.245 ns | 19,821.82 ns | 19,681.08 ns | 20,361.00 ns | 20,123.28 ns |      70 B |         - |
| ForeachSpan | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 19,878.65 ns |  87.964 ns | 131.661 ns | 19,853.16 ns | 19,702.70 ns | 20,189.93 ns | 20,030.65 ns |      68 B |         - |
| RefLoopSpan | MediumRun-.NET 10.0 | .NET 10.0 | 100000 | 19,961.51 ns | 125.753 ns | 188.221 ns | 19,943.98 ns | 19,692.22 ns | 20,414.06 ns | 20,221.56 ns |      73 B |         - |
| For         | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 22,088.46 ns | 197.796 ns | 289.927 ns | 21,951.59 ns | 21,777.73 ns | 22,756.75 ns | 22,582.14 ns |      82 B |         - |
| While       | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 22,019.86 ns | 210.404 ns | 308.408 ns | 21,841.45 ns | 21,614.52 ns | 22,752.78 ns | 22,399.29 ns |      82 B |         - |
| ForEach     | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 25,016.96 ns | 171.139 ns | 256.153 ns | 25,028.75 ns | 24,646.30 ns | 25,534.16 ns | 25,345.68 ns |      69 B |         - |
| ForSpan     | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 19,845.01 ns | 109.114 ns | 159.937 ns | 19,776.79 ns | 19,658.37 ns | 20,139.46 ns | 20,078.97 ns |      85 B |         - |
| ForSpan2    | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 19,854.25 ns | 114.056 ns | 170.713 ns | 19,771.22 ns | 19,646.52 ns | 20,228.51 ns | 20,111.90 ns |      85 B |         - |
| ForeachSpan | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 19,886.81 ns | 118.654 ns | 177.596 ns | 19,849.56 ns | 19,689.64 ns | 20,291.73 ns | 20,153.98 ns |      85 B |         - |
| RefLoopSpan | MediumRun-.NET 8.0  | .NET 8.0  | 100000 | 19,850.40 ns |  92.503 ns | 138.454 ns | 19,808.45 ns | 19,690.02 ns | 20,123.16 ns | 20,052.40 ns |      87 B |         - |
| For         | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 20,925.50 ns | 262.167 ns | 384.282 ns | 20,956.56 ns | 20,324.10 ns | 21,694.06 ns | 21,427.11 ns |      78 B |         - |
| While       | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 20,847.78 ns | 182.904 ns | 268.098 ns | 20,753.39 ns | 20,428.77 ns | 21,328.73 ns | 21,242.88 ns |      78 B |         - |
| ForEach     | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 24,890.74 ns |  81.369 ns | 119.269 ns | 24,857.48 ns | 24,728.54 ns | 25,121.77 ns | 25,042.72 ns |      63 B |         - |
| ForSpan     | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 19,886.89 ns | 120.509 ns | 180.372 ns | 19,807.07 ns | 19,671.59 ns | 20,469.06 ns | 20,101.56 ns |      69 B |         - |
| ForSpan2    | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 19,875.82 ns | 117.633 ns | 176.067 ns | 19,801.30 ns | 19,657.38 ns | 20,175.02 ns | 20,123.22 ns |      69 B |         - |
| ForeachSpan | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 19,849.46 ns |  95.434 ns | 139.886 ns | 19,800.25 ns | 19,686.70 ns | 20,169.21 ns | 20,022.78 ns |      69 B |         - |
| RefLoopSpan | MediumRun-.NET 9.0  | .NET 9.0  | 100000 | 19,896.54 ns | 106.963 ns | 160.097 ns | 19,878.02 ns | 19,694.17 ns | 20,277.98 ns | 20,096.81 ns |      73 B |         - |

```
BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3958/23H2/2023Update/SunValley3)
AMD Ryzen 9 5900X, 1 CPU, 24 logical and 12 physical cores
.NET SDK 8.0.400
  [Host]    : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  MediumRun : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2

Job=MediumRun  IterationCount=15  LaunchCount=2  
WarmupCount=10  
```
| Method      | Size   | Mean         | Error        | StdDev       | Min          | Max          | P90          | Code Size | Allocated |
|------------ |------- |-------------:|-------------:|-------------:|-------------:|-------------:|-------------:|----------:|----------:|
| **For**         | **100**    |     **49.67 ns** |     **0.991 ns** |     **1.483 ns** |     **47.55 ns** |     **52.79 ns** |     **51.51 ns** |      **82 B** |         **-** |
| While       | 100    |     49.03 ns |     1.097 ns |     1.642 ns |     47.20 ns |     52.57 ns |     51.33 ns |      82 B |         - |
| ForEach     | 100    |     49.77 ns |     0.733 ns |     1.096 ns |     47.87 ns |     52.20 ns |     51.01 ns |      73 B |         - |
| ForSpan     | 100    |     26.26 ns |     0.438 ns |     0.600 ns |     25.50 ns |     28.27 ns |     26.71 ns |      85 B |         - |
| ForSpan2    | 100    |     26.75 ns |     0.448 ns |     0.670 ns |     25.74 ns |     28.41 ns |     27.45 ns |      85 B |         - |
| ForeachSpan | 100    |     26.30 ns |     0.364 ns |     0.521 ns |     25.67 ns |     27.48 ns |     27.18 ns |      85 B |         - |
| RefLoopSpan | 100    |     29.41 ns |     0.599 ns |     0.839 ns |     28.42 ns |     31.42 ns |     30.72 ns |      87 B |         - |
| **For**         | **1000**   |    **451.01 ns** |     **8.980 ns** |    **13.441 ns** |    **437.12 ns** |    **489.42 ns** |    **468.64 ns** |      **82 B** |         **-** |
| While       | 1000   |    453.51 ns |     9.504 ns |    14.226 ns |    434.75 ns |    480.01 ns |    469.98 ns |      82 B |         - |
| ForEach     | 1000   |    454.62 ns |     8.472 ns |    12.150 ns |    438.45 ns |    475.93 ns |    470.65 ns |      73 B |         - |
| ForSpan     | 1000   |    228.34 ns |     4.400 ns |     6.311 ns |    219.59 ns |    245.26 ns |    236.06 ns |      85 B |         - |
| ForSpan2    | 1000   |    231.71 ns |     5.966 ns |     8.930 ns |    221.58 ns |    258.25 ns |    243.54 ns |      85 B |         - |
| ForeachSpan | 1000   |    230.10 ns |     6.125 ns |     9.167 ns |    219.19 ns |    248.83 ns |    244.45 ns |      85 B |         - |
| RefLoopSpan | 1000   |    234.23 ns |     5.835 ns |     8.734 ns |    223.73 ns |    254.77 ns |    243.95 ns |      87 B |         - |
| **For**         | **10000**  |  **4,528.44 ns** |    **71.092 ns** |   **106.407 ns** |  **4,339.56 ns** |  **4,650.19 ns** |  **4,642.56 ns** |      **82 B** |         **-** |
| While       | 10000  |  4,462.96 ns |    93.265 ns |   139.595 ns |  4,324.05 ns |  4,802.64 ns |  4,686.12 ns |      82 B |         - |
| ForEach     | 10000  |  4,506.00 ns |    76.610 ns |   112.294 ns |  4,362.19 ns |  4,734.20 ns |  4,652.29 ns |      69 B |         - |
| ForSpan     | 10000  |  2,248.59 ns |    44.651 ns |    65.449 ns |  2,173.13 ns |  2,378.51 ns |  2,326.18 ns |      85 B |         - |
| ForSpan2    | 10000  |  2,256.74 ns |    44.941 ns |    67.266 ns |  2,176.94 ns |  2,402.71 ns |  2,366.90 ns |      85 B |         - |
| ForeachSpan | 10000  |  2,267.76 ns |    42.518 ns |    63.640 ns |  2,164.21 ns |  2,391.58 ns |  2,355.87 ns |      85 B |         - |
| RefLoopSpan | 10000  |  2,262.75 ns |    46.849 ns |    70.121 ns |  2,181.49 ns |  2,376.93 ns |  2,345.43 ns |      87 B |         - |
| **For**         | **100000** | **45,080.41 ns** | **1,020.245 ns** | **1,527.054 ns** | **43,190.84 ns** | **48,283.03 ns** | **47,190.83 ns** |      **82 B** |         **-** |
| While       | 100000 | 44,510.26 ns |   726.436 ns | 1,041.833 ns | 43,360.97 ns | 47,831.82 ns | 45,841.42 ns |      82 B |         - |
| ForEach     | 100000 | 44,657.99 ns |   647.698 ns |   907.981 ns | 43,525.16 ns | 46,759.20 ns | 45,996.80 ns |      69 B |         - |
| ForSpan     | 100000 | 22,500.29 ns |   479.063 ns |   717.039 ns | 21,597.45 ns | 24,015.63 ns | 23,444.13 ns |      85 B |         - |
| ForSpan2    | 100000 | 22,601.78 ns |   461.015 ns |   690.026 ns | 21,613.17 ns | 24,022.48 ns | 23,483.24 ns |      85 B |         - |
| ForeachSpan | 100000 | 22,585.13 ns |   554.136 ns |   812.245 ns | 21,656.37 ns | 24,607.68 ns | 23,525.73 ns |      85 B |         - |
| RefLoopSpan | 100000 | 22,597.21 ns |   411.783 ns |   616.338 ns | 21,841.35 ns | 23,990.36 ns | 23,413.14 ns |      87 B |         - |
