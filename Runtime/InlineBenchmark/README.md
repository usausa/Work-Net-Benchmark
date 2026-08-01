> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> SkipLocalsInit と stackalloc の検証は移行先の STK-06 に統合され、サイズ別の実測も記録済みです。
>
> - パターン: **STK-06 定数サイズ stackalloc** / **MEM-03 SkipLocalsInit** / **JIT-01 AggressiveInlining**([README](../../../dotnet-performance/README.md))
> - 実測: [STK-06-StackallocSize.md](../../../dotnet-performance/benchmarks/results/STK-06-StackallocSize.md)(定数 / 可変 × SkipLocalsInit 有無)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

AggressiveInlining と NoInlining の比較、および SkipLocalsInit の有無による stackalloc のゼロ初期化コスト検証(サイズ掃引)。

測定結果は未記録です。
