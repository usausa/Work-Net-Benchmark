> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> 条件付き追記・プール式ビルダーの比較は移行先の TXT-02 に集約されています。
>
> - パターン: **TXT-02 文字列構築の stackalloc ファースト化**(Grow の NoInlining 分離は **JIT-04**、[README](../../../dotnet-performance/README.md))
> - 実装: [ValueStringBuilder.cs](../../../dotnet-performance/src/PerformancePatterns/Txt/ValueStringBuilder.cs)
> - 実測: [TXT-02-ValueStringBuilder.md](../../../dotnet-performance/benchmarks/results/TXT-02-ValueStringBuilder.md)
> - 追加検証: **TXT-07 string.Create / TryFormat** — 長さを事前確定できる組み立てでは `string.Create` が最速(15.3 ns / 0.57 倍、割り当ては結果文字列のみ)。[TXT-07-StringCreate.md](../../../dotnet-performance/benchmarks/results/TXT-07-StringCreate.md)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

文字列の条件付き追記における String 連結 / StringBuilder / ArrayPool バッファ / ThreadStatic バッファの比較と、pooled builder の実装細部(Grow 分離・ThreadStatic のローカル退避)の検証。

測定結果は未記録です。
