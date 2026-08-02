> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> ハンドラ列の不変配列化(マルチキャストデリゲート回避)は移行先で実装・再測定済みです。購読者数 1 / 2 / 4 / 8 のスイープにより、**損益分岐が購読者 2 個**であること(購読 1 個ではマルチキャストが 2.87 倍速い)まで判定されています。
>
> - パターン: **DSP-03 ハンドラ列の不変配列化**([README](../../../dotnet-performance/README.md))
> - 実装: [HandlerList.cs](../../../dotnet-performance/src/PerformancePatterns/Dsp/HandlerList.cs)
> - 実測: [DSP-03-HandlerList.md](../../../dotnet-performance/benchmarks/results/DSP-03-HandlerList.md)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 過去の測定結果(参考)

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
| Method         | Job                 | Runtime   | Mean     | Error     | StdDev    | Median   | Min      | Max      | P90      | Code Size | Allocated |
|--------------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|---------:|----------:|----------:|
| ByArrayHandler | MediumRun-.NET 10.0 | .NET 10.0 | 1.304 ns | 0.0066 ns | 0.0096 ns | 1.303 ns | 1.286 ns | 1.322 ns | 1.318 ns |      80 B |         - |
| ByLinkHandler  | MediumRun-.NET 10.0 | .NET 10.0 | 2.120 ns | 0.0113 ns | 0.0169 ns | 2.118 ns | 2.096 ns | 2.149 ns | 2.147 ns |      74 B |         - |
| ByArrayHandler | MediumRun-.NET 8.0  | .NET 8.0  | 1.369 ns | 0.0097 ns | 0.0145 ns | 1.362 ns | 1.348 ns | 1.394 ns | 1.389 ns |      82 B |         - |
| ByLinkHandler  | MediumRun-.NET 8.0  | .NET 8.0  | 2.184 ns | 0.0108 ns | 0.0162 ns | 2.185 ns | 2.160 ns | 2.218 ns | 2.203 ns |      74 B |         - |
| ByArrayHandler | MediumRun-.NET 9.0  | .NET 9.0  | 1.462 ns | 0.0448 ns | 0.0643 ns | 1.460 ns | 1.303 ns | 1.623 ns | 1.530 ns |      80 B |         - |
| ByLinkHandler  | MediumRun-.NET 9.0  | .NET 9.0  | 2.182 ns | 0.0667 ns | 0.0998 ns | 2.151 ns | 2.089 ns | 2.430 ns | 2.306 ns |      74 B |         - |
