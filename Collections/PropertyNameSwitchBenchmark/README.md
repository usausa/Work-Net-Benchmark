# PropertyNameSwitchBenchmark

> [!NOTE]
> **📎 一部移行済み — サンプリングハッシュによる名前解決は dotnet-performance へ移行しました。**
>
> 「長さ + 3 文字サンプリング」のハッシュ表は移行先で実装・再測定済みです(`Dictionary` / `FrozenDictionary` / 線形探索との比較)。
>
> - パターン: **BIT-02 ドメイン制約を活かした軽量ハッシュ生成** / **COL-04 少数要素ルックアップの戦略選択**([README](../../../dotnet-performance/README.md))
> - 実装: [SampledNameTable.cs](../../../dotnet-performance/src/PerformancePatterns/Col/SampledNameTable.cs)
> - 実測: [COL-04-SampledNameTable.md](../../../dotnet-performance/benchmarks/results/COL-04-SampledNameTable.md)
>
> **本プロジェクトに残る固有の検証:** 対戦相手が **C# コンパイラ自身の switch ロワリング**である点。移行先の比較対象は辞書実装であり、Roslyn が生成するコードとの比較は本プロジェクトにしかない。

BunnyTail.MemberAccessor が生成する `GetValue`/`SetValue(name)` の素の C# 文字列 switch を、サンプリングハッシュ switch へ置き換える価値があるかを判定する。DB 列名のケース(→ ColumnMetadataLookupBenchmark)と違い、相手は `FrozenDictionary` ではなくコンパイラの出力そのもの。

| 方式 | 内容 |
|---|---|
| Compiler | `name switch { "Id" => 0, ... }`。Roslyn は少数なら長さ・文字比較へ、多数なら `ComputeStringHash`(文字列全体の FNV-1a)+ ジャンプテーブル + 序数 `Equals` へロワリングする |
| Hash | `switch (SamplingHash.Calculate(name))`。長さ + 3 文字サンプリングの後、序数 `Equals` で確定 |

プロパティ名は Ordinal(大文字小文字を区別)で照合するため、どちらの方式も `ToUpperInvariant` を必要としない。1 操作 = 名前集合の全要素を 1 巡。

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | Medium |

**測定結果:** 未記録(実行後にここへ追記する)。
