|               Method | Size |       Mean |       Error |    StdDev |        Min |        Max |        P90 | Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------- |----- |-----------:|------------:|----------:|-----------:|-----------:|-----------:|------:|------:|------:|----------:|
|             **FindByte** |    **4** |   **4.424 ns** |   **0.3062 ns** | **0.0168 ns** |   **4.412 ns** |   **4.443 ns** |   **4.438 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |    4 |   4.873 ns |   2.1799 ns | 0.1195 ns |   4.803 ns |   5.011 ns |   4.970 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |    4 |   4.743 ns |   0.2942 ns | 0.0161 ns |   4.727 ns |   4.759 ns |   4.756 ns |     - |     - |     - |         - |
|   PointerForFindByte |    4 |   3.395 ns |   0.2001 ns | 0.0110 ns |   3.383 ns |   3.403 ns |   3.402 ns |     - |     - |     - |         - |
| PointerWhileFindByte |    4 |   4.494 ns |   0.9190 ns | 0.0504 ns |   4.436 ns |   4.524 ns |   4.524 ns |     - |     - |     - |         - |
|              FindInt |    4 |   3.992 ns |   3.2859 ns | 0.1801 ns |   3.850 ns |   4.194 ns |   4.141 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |    4 |   4.070 ns |   0.7121 ns | 0.0390 ns |   4.045 ns |   4.115 ns |   4.102 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |    4 |   4.722 ns |   0.8008 ns | 0.0439 ns |   4.683 ns |   4.769 ns |   4.758 ns |     - |     - |     - |         - |
|    PointerForFindInt |    4 |   3.267 ns |   0.5451 ns | 0.0299 ns |   3.242 ns |   3.300 ns |   3.292 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |    4 |   4.157 ns |   0.3518 ns | 0.0193 ns |   4.145 ns |   4.180 ns |   4.173 ns |     - |     - |     - |         - |
|             **FindByte** |    **8** |   **7.118 ns** |   **2.3804 ns** | **0.1305 ns** |   **6.968 ns** |   **7.209 ns** |   **7.202 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |    8 |   7.120 ns |   1.7207 ns | 0.0943 ns |   7.012 ns |   7.188 ns |   7.182 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |    8 |   7.045 ns |   2.6590 ns | 0.1457 ns |   6.936 ns |   7.210 ns |   7.166 ns |     - |     - |     - |         - |
|   PointerForFindByte |    8 |   5.067 ns |   1.4905 ns | 0.0817 ns |   5.014 ns |   5.162 ns |   5.135 ns |     - |     - |     - |         - |
| PointerWhileFindByte |    8 |   6.448 ns |   1.8644 ns | 0.1022 ns |   6.356 ns |   6.558 ns |   6.532 ns |     - |     - |     - |         - |
|              FindInt |    8 |   6.081 ns |   0.7744 ns | 0.0424 ns |   6.043 ns |   6.127 ns |   6.117 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |    8 |   5.701 ns |   1.3897 ns | 0.0762 ns |   5.657 ns |   5.789 ns |   5.763 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |    8 |   7.048 ns |   1.1021 ns | 0.0604 ns |   6.994 ns |   7.114 ns |   7.098 ns |     - |     - |     - |         - |
|    PointerForFindInt |    8 |   5.100 ns |   0.9867 ns | 0.0541 ns |   5.051 ns |   5.158 ns |   5.145 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |    8 |   6.044 ns |   1.0524 ns | 0.0577 ns |   6.002 ns |   6.110 ns |   6.092 ns |     - |     - |     - |         - |
|             **FindByte** |   **16** |  **13.827 ns** |  **26.9959 ns** | **1.4797 ns** |  **12.137 ns** |  **14.888 ns** |  **14.802 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |   16 |  11.706 ns |   1.5929 ns | 0.0873 ns |  11.606 ns |  11.768 ns |  11.763 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |   16 |  12.100 ns |  10.9402 ns | 0.5997 ns |  11.638 ns |  12.777 ns |  12.599 ns |     - |     - |     - |         - |
|   PointerForFindByte |   16 |   8.565 ns |  12.7739 ns | 0.7002 ns |   8.095 ns |   9.370 ns |   9.142 ns |     - |     - |     - |         - |
| PointerWhileFindByte |   16 |  13.080 ns |  45.1829 ns | 2.4766 ns |  10.749 ns |  15.680 ns |  15.106 ns |     - |     - |     - |         - |
|              FindInt |   16 |   8.688 ns |   5.2654 ns | 0.2886 ns |   8.391 ns |   8.968 ns |   8.915 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |   16 |   7.380 ns |   1.9523 ns | 0.1070 ns |   7.297 ns |   7.501 ns |   7.469 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |   16 |  11.540 ns |   2.9716 ns | 0.1629 ns |  11.353 ns |  11.651 ns |  11.644 ns |     - |     - |     - |         - |
|    PointerForFindInt |   16 |   7.696 ns |   1.2148 ns | 0.0666 ns |   7.621 ns |   7.750 ns |   7.743 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |   16 |   9.134 ns |   5.8315 ns | 0.3196 ns |   8.927 ns |   9.502 ns |   9.396 ns |     - |     - |     - |         - |
|             **FindByte** |   **32** |  **28.150 ns** | **106.2592 ns** | **5.8244 ns** |  **21.838 ns** |  **33.316 ns** |  **32.512 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |   32 |  21.371 ns |  18.0949 ns | 0.9918 ns |  20.794 ns |  22.516 ns |  22.173 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |   32 |  17.698 ns |   3.2110 ns | 0.1760 ns |  17.526 ns |  17.878 ns |  17.840 ns |     - |     - |     - |         - |
|   PointerForFindByte |   32 |  21.055 ns |   1.7904 ns | 0.0981 ns |  20.965 ns |  21.160 ns |  21.136 ns |     - |     - |     - |         - |
| PointerWhileFindByte |   32 |  20.612 ns |   3.7292 ns | 0.2044 ns |  20.398 ns |  20.805 ns |  20.771 ns |     - |     - |     - |         - |
|              FindInt |   32 |  22.009 ns |   3.4571 ns | 0.1895 ns |  21.869 ns |  22.225 ns |  22.167 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |   32 |  21.753 ns |   9.2940 ns | 0.5094 ns |  21.440 ns |  22.341 ns |  22.168 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |   32 |  15.352 ns |   3.3426 ns | 0.1832 ns |  15.233 ns |  15.563 ns |  15.502 ns |     - |     - |     - |         - |
|    PointerForFindInt |   32 |  16.067 ns |   3.6907 ns | 0.2023 ns |  15.845 ns |  16.241 ns |  16.216 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |   32 |  21.105 ns |   5.5221 ns | 0.3027 ns |  20.805 ns |  21.410 ns |  21.348 ns |     - |     - |     - |         - |
|             **FindByte** |   **64** |  **45.992 ns** |   **6.4584 ns** | **0.3540 ns** |  **45.618 ns** |  **46.322 ns** |  **46.265 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |   64 |  44.088 ns |   3.4829 ns | 0.1909 ns |  43.914 ns |  44.292 ns |  44.245 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |   64 |  41.141 ns |   6.8584 ns | 0.3759 ns |  40.902 ns |  41.574 ns |  41.449 ns |     - |     - |     - |         - |
|   PointerForFindByte |   64 |  36.306 ns |   5.4773 ns | 0.3002 ns |  36.107 ns |  36.652 ns |  36.553 ns |     - |     - |     - |         - |
| PointerWhileFindByte |   64 |  46.001 ns |  32.1509 ns | 1.7623 ns |  44.036 ns |  47.442 ns |  47.259 ns |     - |     - |     - |         - |
|              FindInt |   64 |  46.962 ns |  20.8972 ns | 1.1454 ns |  45.961 ns |  48.211 ns |  47.912 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |   64 |  45.731 ns |   5.4240 ns | 0.2973 ns |  45.510 ns |  46.069 ns |  45.978 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |   64 |  34.346 ns |   3.7996 ns | 0.2083 ns |  34.182 ns |  34.581 ns |  34.520 ns |     - |     - |     - |         - |
|    PointerForFindInt |   64 |  35.188 ns |   9.1270 ns | 0.5003 ns |  34.688 ns |  35.688 ns |  35.588 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |   64 |  40.458 ns |   8.7590 ns | 0.4801 ns |  39.918 ns |  40.838 ns |  40.794 ns |     - |     - |     - |         - |
|             **FindByte** |  **128** |  **69.366 ns** |  **16.4610 ns** | **0.9023 ns** |  **68.351 ns** |  **70.075 ns** |  **69.995 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |  128 |  67.241 ns |  15.0202 ns | 0.8233 ns |  66.585 ns |  68.165 ns |  67.926 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |  128 |  65.939 ns |  12.3051 ns | 0.6745 ns |  65.180 ns |  66.470 ns |  66.409 ns |     - |     - |     - |         - |
|   PointerForFindByte |  128 |  54.323 ns |   2.4948 ns | 0.1367 ns |  54.174 ns |  54.442 ns |  54.424 ns |     - |     - |     - |         - |
| PointerWhileFindByte |  128 |  67.074 ns |  43.4880 ns | 2.3837 ns |  65.216 ns |  69.762 ns |  69.058 ns |     - |     - |     - |         - |
|              FindInt |  128 |  69.864 ns |   4.5064 ns | 0.2470 ns |  69.605 ns |  70.097 ns |  70.055 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |  128 |  68.918 ns |  27.5147 ns | 1.5082 ns |  67.911 ns |  70.652 ns |  70.160 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |  128 |  58.868 ns |  13.6397 ns | 0.7476 ns |  58.358 ns |  59.726 ns |  59.485 ns |     - |     - |     - |         - |
|    PointerForFindInt |  128 |  53.376 ns |  10.1282 ns | 0.5552 ns |  52.735 ns |  53.699 ns |  53.698 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |  128 |  60.064 ns |  12.6190 ns | 0.6917 ns |  59.273 ns |  60.552 ns |  60.515 ns |     - |     - |     - |         - |
|             **FindByte** |  **256** | **122.170 ns** |  **82.2239 ns** | **4.5070 ns** | **119.203 ns** | **127.357 ns** | **125.876 ns** |     **-** |     **-** |     **-** |         **-** |
|    UnsafeForFindByte |  256 | 115.572 ns |  55.2299 ns | 3.0273 ns | 113.105 ns | 118.950 ns | 118.092 ns |     - |     - |     - |         - |
|  UnsafeWhileFindByte |  256 | 115.193 ns |   6.9655 ns | 0.3818 ns | 114.766 ns | 115.502 ns | 115.464 ns |     - |     - |     - |         - |
|   PointerForFindByte |  256 |  92.022 ns |  35.2741 ns | 1.9335 ns |  90.312 ns |  94.120 ns |  93.623 ns |     - |     - |     - |         - |
| PointerWhileFindByte |  256 | 119.006 ns |  43.7984 ns | 2.4007 ns | 116.308 ns | 120.907 ns | 120.686 ns |     - |     - |     - |         - |
|              FindInt |  256 | 124.292 ns |  33.8416 ns | 1.8550 ns | 122.790 ns | 126.365 ns | 125.836 ns |     - |     - |     - |         - |
|     UnsafeForFindInt |  256 | 123.485 ns |   2.6233 ns | 0.1438 ns | 123.325 ns | 123.605 ns | 123.589 ns |     - |     - |     - |         - |
|   UnsafeWhileFindInt |  256 |  94.229 ns |  54.6366 ns | 2.9948 ns |  92.445 ns |  97.686 ns |  96.660 ns |     - |     - |     - |         - |
|    PointerForFindInt |  256 |  89.330 ns |   3.9031 ns | 0.2139 ns |  89.102 ns |  89.526 ns |  89.493 ns |     - |     - |     - |         - |
|  PointerWhileFindInt |  256 |  97.779 ns |  28.3998 ns | 1.5567 ns |  96.158 ns |  99.262 ns |  98.993 ns |     - |     - |     - |         - |