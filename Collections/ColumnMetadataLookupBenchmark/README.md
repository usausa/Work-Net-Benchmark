# ColumnMetadataLookupBenchmark

> [!NOTE]
> **📎 一部移行済み — サンプリングハッシュによる名前解決は dotnet-performance へ移行しました。**
>
> 「長さ + 3 文字サンプリング」のハッシュで名前を引く手法は移行先で実装・再測定済みです(全サイズで `Dictionary` の 0.56〜0.84 倍、Span キー比較では `FrozenDictionary` にも勝つ)。DB リーダーの序数解決コストも別途測定済みです。
>
> - パターン: **BIT-02 ドメイン制約を活かした軽量ハッシュ生成** / **COL-04 少数要素ルックアップの戦略選択**([README](../../../dotnet-performance/README.md))
> - 実装: [SampledNameTable.cs](../../../dotnet-performance/src/PerformancePatterns/Col/SampledNameTable.cs)
> - 実測: [COL-04-SampledNameTable.md](../../../dotnet-performance/benchmarks/results/COL-04-SampledNameTable.md)
> - 関連パターン: **DAT-01 DB アクセスの列解決最適化**(序数キャッシュ struct + `in` 渡しで 1 行あたり 0.13 倍)/ [DAT-01-OrdinalResolve.md](../../../dotnet-performance/benchmarks/results/DAT-01-OrdinalResolve.md)
>
> **本プロジェクトに残る固有の検証:** 生成コード(Smart.Data.Accessor)の出し分け判断に必要な、以下の 3 点。移行先では未測定のため本プロジェクトを引き続き参照する。
>
> - **SweepBenchmark**: 1〜32 列のスイープで Direct(`String.Equals` 連鎖)と Switch(サンプリングハッシュ)のどちらが勝つか、リーダー形状をまたいでどれだけ安定するか
> - **CollisionBenchmark**: 退化したキー集合で Switch がどれだけ悪化するか、サンプリング位置を生成時に選び直すことで回復できるか
> - **GuardBenchmark**: 空列名ガードのコスト

Smart.Data.Accessor が生成しうる「列名 → グループインデックス」解決の 2 方式を比較する。`FrozenDictionary` 形式は**どの列数でも最速にならなかったため候補から除外済み**で、残る 2 方式の使い分けを決めるのが目的。

| 方式 | 内容 |
|---|---|
| Direct | `String.Equals(OrdinalIgnoreCase)` の連鎖からグループごとのローカルへ |
| Switch | サンプリングハッシュ(長さ + 3 文字)の switch。ハッシュ定数は生成時に埋め込み |

いずれのベンチマークも、生成される `__{Entity}Ordinals.__From(reader)` の処理(リーダーの列を 1 回走査し、各名前をグループ ID へ対応付け、序数を記録し、全グループが解決した時点で打ち切る)を再現している。

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | Medium |

**測定結果:** 未記録(実行後にここへ追記する)。
