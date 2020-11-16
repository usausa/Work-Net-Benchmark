|                     Method |       Mean |      Error |     StdDev |     Median |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|--------------------------- |-----------:|-----------:|-----------:|-----------:|-------:|------:|------:|----------:|
|               ForeachListS |  13.281 ns |  0.1973 ns |  0.2893 ns |  13.366 ns |      - |     - |     - |         - |
|     ForeachListEnumerableS |  42.808 ns |  0.2413 ns |  0.3537 ns |  42.723 ns | 0.0095 |     - |     - |      40 B |
|            EnumeratorListS |  13.218 ns |  0.2658 ns |  0.3812 ns |  13.068 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListS |  42.461 ns |  0.2832 ns |  0.3970 ns |  42.377 ns | 0.0095 |     - |     - |      40 B |
|                   ForListS |   2.755 ns |  0.0331 ns |  0.0475 ns |   2.742 ns |      - |     - |     - |         - |
|              ForIListListS |  19.023 ns |  0.1489 ns |  0.1988 ns |  19.034 ns |      - |     - |     - |         - |
|               ForeachListM |  83.425 ns |  0.4153 ns |  0.5956 ns |  83.460 ns |      - |     - |     - |         - |
|     ForeachListEnumerableM | 242.804 ns |  7.9338 ns | 11.3784 ns | 243.186 ns | 0.0095 |     - |     - |      40 B |
|            EnumeratorListM |  83.415 ns |  0.3599 ns |  0.5162 ns |  83.328 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListM | 231.789 ns |  1.0933 ns |  1.5680 ns | 231.579 ns | 0.0095 |     - |     - |      40 B |
|                   ForListM |  20.920 ns |  0.3550 ns |  0.5091 ns |  21.168 ns |      - |     - |     - |         - |
|              ForIListListM | 137.952 ns |  0.5444 ns |  0.7452 ns | 137.959 ns |      - |     - |     - |         - |
|               ForeachListL | 297.076 ns |  1.2203 ns |  1.7887 ns | 296.645 ns |      - |     - |     - |         - |
|     ForeachListEnumerableL | 892.700 ns | 12.3766 ns | 18.1414 ns | 891.093 ns | 0.0095 |     - |     - |      40 B |
|            EnumeratorListL | 296.434 ns |  1.5565 ns |  2.2322 ns | 296.134 ns |      - |     - |     - |         - |
|  EnumeratorEnumerableListL | 878.972 ns | 17.4301 ns | 25.5489 ns | 894.338 ns | 0.0095 |     - |     - |      40 B |
|                   ForListL |  86.558 ns |  0.5144 ns |  0.7212 ns |  86.392 ns |      - |     - |     - |         - |
|              ForIListListL | 527.476 ns |  2.7229 ns |  3.9051 ns | 526.379 ns |      - |     - |     - |         - |
|              ForeachArrayS |   2.328 ns |  0.0182 ns |  0.0255 ns |   2.322 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableS |  29.674 ns |  0.2210 ns |  0.3097 ns |  29.580 ns | 0.0076 |     - |     - |      32 B |
| EnumeratorEnumerableArrayS |  29.912 ns |  0.5029 ns |  0.7371 ns |  29.570 ns | 0.0076 |     - |     - |      32 B |
|                  ForArrayS |   2.131 ns |  0.0156 ns |  0.0219 ns |   2.131 ns |      - |     - |     - |         - |
|             ForIListArrayS |  21.369 ns |  0.1419 ns |  0.2080 ns |  21.329 ns |      - |     - |     - |         - |
|              ForeachArrayM |  17.291 ns |  0.0891 ns |  0.1250 ns |  17.320 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableM | 159.308 ns |  0.8077 ns |  1.1322 ns | 159.091 ns | 0.0076 |     - |     - |      32 B |
| EnumeratorEnumerableArrayM | 160.347 ns |  0.6740 ns |  0.9880 ns | 160.225 ns | 0.0076 |     - |     - |      32 B |
|                  ForArrayM |  13.393 ns |  0.0998 ns |  0.1399 ns |  13.340 ns |      - |     - |     - |         - |
|             ForIListArrayM | 154.754 ns |  0.5231 ns |  0.7160 ns | 154.577 ns |      - |     - |     - |         - |
|              ForeachArrayL |  60.645 ns |  0.8094 ns |  1.1346 ns |  59.961 ns |      - |     - |     - |         - |
|    ForeachArrayEnumerableL | 608.240 ns |  3.6059 ns |  5.0550 ns | 607.037 ns | 0.0076 |     - |     - |      32 B |
| EnumeratorEnumerableArrayL | 593.253 ns | 13.1710 ns | 18.8895 ns | 605.253 ns | 0.0076 |     - |     - |      32 B |
|                  ForArrayL |  82.144 ns |  0.3612 ns |  0.5295 ns |  82.146 ns |      - |     - |     - |         - |
|             ForIListArrayL | 580.465 ns | 13.7862 ns | 19.3264 ns | 591.529 ns |      - |     - |     - |         - |
