> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> スコープガード・Dispose 排他の比較は移行先の CON-02 で再測定・判定済みです。
>
> - パターン: **CON-02 Interlocked によるワンショットガード**([README](../../../dotnet-performance/README.md))
> - 実測: [CON-02-DisposeGuard.md](../../../dotnet-performance/benchmarks/results/CON-02-DisposeGuard.md)(素の bool / lock / Interlocked)
> - 関連パターン: **STK-01 ref struct**(struct スコープガードのボックス化回避)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

IDisposable 利用方式(using 文 / try-finally / クラスベース / 構造体ベース)の性能比較と、解除可能スコープパターンの検証。

測定結果は未記録です。
