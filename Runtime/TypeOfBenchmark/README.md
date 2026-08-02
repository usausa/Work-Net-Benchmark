> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> typeof のキャッシュは JIT の定数化により無意味と判定され、不採用手法として記録済みです。
>
> - 判定: [rejected-patterns.md](../../../dotnet-performance/docs/rejected-patterns.md) の **R-01: typeof(X) の static readonly キャッシュ**
> - 関連パターン: **JIT-03 typeof(T) 分岐によるジェネリック特殊化**(こちらは有効、[README](../../../dotnet-performance/README.md))
> - 追加検証: **TYP-01 静的型スロット(TypeMap)** — ジェネリック経路は `Dictionary<Type, T>` の 0.02 倍(約 54 倍)。ただし**実行時 Type 経路は 1.93 倍で素の Dictionary より遅い**ため、型が静的に分かる呼び出しでのみ有効。[TYP-01-TypeMap.md](../../../dotnet-performance/benchmarks/results/TYP-01-TypeMap.md)
> - 追加検証: **TYP-06 型別成果物の静的事前組み立て** — ジェネリック static フィールド読みは 0.09 ns(辞書キャッシュ比 約 53 倍)。[TYP-06-StaticArtifact.md](../../../dotnet-performance/benchmarks/results/TYP-06-StaticArtifact.md)
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
| Method        | Job                 | Runtime   | Mean     | Error     | StdDev    | Min      | Max      | P90      | Code Size | Allocated |
|-------------- |-------------------- |---------- |---------:|----------:|----------:|---------:|---------:|---------:|----------:|----------:|
| DefinedMember | MediumRun-.NET 10.0 | .NET 10.0 | 7.624 ns | 0.1297 ns | 0.1901 ns | 7.468 ns | 8.207 ns | 7.865 ns |     181 B |         - |
| EachTime      | MediumRun-.NET 10.0 | .NET 10.0 | 7.519 ns | 0.0566 ns | 0.0847 ns | 7.387 ns | 7.715 ns | 7.617 ns |     181 B |         - |
| DefinedMember | MediumRun-.NET 8.0  | .NET 8.0  | 7.538 ns | 0.0480 ns | 0.0703 ns | 7.420 ns | 7.670 ns | 7.639 ns |     181 B |         - |
| EachTime      | MediumRun-.NET 8.0  | .NET 8.0  | 7.567 ns | 0.0667 ns | 0.0978 ns | 7.438 ns | 7.743 ns | 7.696 ns |     181 B |         - |
| DefinedMember | MediumRun-.NET 9.0  | .NET 9.0  | 7.578 ns | 0.0861 ns | 0.1289 ns | 7.425 ns | 7.932 ns | 7.741 ns |     181 B |         - |
| EachTime      | MediumRun-.NET 9.0  | .NET 9.0  | 7.592 ns | 0.0609 ns | 0.0911 ns | 7.444 ns | 7.783 ns | 7.707 ns |     181 B |         - |
