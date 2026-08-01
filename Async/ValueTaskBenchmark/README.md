> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> 同期完了パスの非同期コストは移行先の ASY-01 で再測定され、async 消去まで含めて判定済みです。
>
> - パターン: **ASY-01 async ステートマシンの省略**([README](../../../dotnet-performance/README.md))
> - 実測: [ASY-01-AsyncElision.md](../../../dotnet-performance/benchmarks/results/ASY-01-AsyncElision.md)(Task / ValueTask × await ラッパー / 直接返し)
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

同期完了する非同期処理における Task.FromResult と ValueTask の比較。

測定結果は未記録です。
