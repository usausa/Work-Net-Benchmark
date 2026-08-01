> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> 一時バッファの確保戦略は移行先でパターン化・実装され、実測記録も揃っています。
>
> - パターン: **BUF-05 一時バッファの段階戦略** / **STK-06 定数サイズ stackalloc** / **BUF-06 GC.AllocateUninitializedArray**([README](../../../dotnet-performance/README.md))
> - 実装: [TemporaryBuffer.cs](../../../dotnet-performance/src/PerformancePatterns/Buf/TemporaryBuffer.cs)
> - 実測: [BUF-05](../../../dotnet-performance/benchmarks/results/BUF-05-TemporaryBuffer.md) / [STK-06](../../../dotnet-performance/benchmarks/results/STK-06-StackallocSize.md) / [BUF-06](../../../dotnet-performance/benchmarks/results/BUF-06-UninitializedArray.md)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

マネージド / アンマネージド確保、stackalloc・ArrayPool の閾値切替、TemporaryBuffer 抽象化コスト、P/Invoke バッファ渡しの比較。

測定結果は未記録です。
