> [!WARNING]
> **⚠️ OBSOLETE — 本プロジェクトの検証内容は dotnet-performance リポジトリへ移行済みです。**
>
> 本プロジェクトは csproj が無効化されており(`_DelegateBenchmark.csproj`)、測定結果にも疑義があります。デリゲート形態の選択指針は移行先で整理済みです。
>
> - パターン: **DSP-02 呼び出し抽象化の選択指針**(delegate / interface / 関数ポインタの使い分け、[README](../../../dotnet-performance/README.md))
> - 判定: [rejected-patterns.md](../../../dotnet-performance/docs/rejected-patterns.md) の **R-11: static メソッド直バインドデリゲートの保持**
>
> 履歴として残置しています。新規の測定・判断は移行先のカタログを参照してください。

## 検証内容(参考)

DynamicMethod 生成デリゲート・関数ポインタ・比較子の渡し方の比較(無効化済み)。

測定結果は未記録です。
