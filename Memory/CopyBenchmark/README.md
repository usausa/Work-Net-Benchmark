> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> コピー方式の比較は移行先で再測定し、`Unsafe.CopyBlockUnaligned` 置換は不採用と判定済みです。
>
> - 判定: [rejected-patterns.md](../../../dotnet-performance/docs/rejected-patterns.md) の **R-14: Span.CopyTo の Unsafe.CopyBlockUnaligned 置換**
> - 実測: [LAB-CopyBlockUnaligned.md](../../../dotnet-performance/benchmarks/results/LAB-CopyBlockUnaligned.md)(可変長 / 定数長)
> - 関連パターン: [MEM-05](../../../dotnet-performance/README.md)(Slice(offset, length) による明示的スライス)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

Array.Copy / Buffer.BlockCopy / Buffer.MemoryCopy の比較と、配列反転の Span / Unsafe / ポインタ実装比較。

測定結果は未記録です。
