# Work-Net-Benchmark

BenchmarkDotNet を使用した .NET 性能検証プロジェクト集。

---

## 現在のプロジェクト一覧

### Abstraction/ — 関数呼び出し抽象化

関数・デリゲート・インターフェース等、さまざまな呼び出し抽象化方式のオーバーヘッドを計測する。

---

#### ✅CallAbstractionBenchmark

ファクトリー抽象化方式 (Func / Delegate / Interface / Abstract / 関数ポインタ) の呼び出し性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium |

---

#### ✅CallNopBenchmark

引数なし・戻り値なしの最小呼び出しにおけるオーバーヘッドを比較する (Lambda / Static / Curry / Interface / Abstract)。

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | Medium |

---

#### 🤔⭕DelegateBenchmark

Delegate / Function Pointer / Lambda / 動的メソッド生成 (DynamicMethod, Expression) の生成・呼び出し性能を計測する。

**内包クラス:** `DelegateInvokeBenchmark`, `DelegateCompareBenchmark`, `CallBridgeBenchmark`, `CallbackSortBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `DelegateBenchmark`, `DelegateCompareBenchmark`, `CallBridgeBenchmark`, `CallbackBenchmark` を吸収統合 |

---

#### ✅FactoryEntryBenchmark

`Func<T>` vs `Unsafe.As<T>` によるファクトリー保持方式の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | Medium |

---

#### ✅FunctionPointerBenchmark

`Func<T>` vs 関数ポインタ (MethodHandle / GetFunctionPointer) の呼び出し性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium |

---

#### ✅LambdaLocalBenchmark

Lambda 定義 vs Local 関数定義の呼び出しコストを比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium |

---

#### ✅SealedDispatchBenchmark

sealed / non-sealed クラスの仮想メソッド呼び出し最適化 (devirtualization) 効果を計測する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium |

---

#### ⚠️SwitchBenchmark

制御フロー分岐方式 (if-else / switch / Action delegate / interface dispatch) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium |

---

### Async/ — 非同期・スレッド

非同期処理・スレッド同期の各方式を計測する。

---

#### ⭕CallBenchmark

イベントハンドラー呼び出しおよびスレッド同期方式 (EventHandler / Delegate / Action / `System.Threading.Lock`) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net9.0` `net10.0` |
| Job | Medium ×2 |
| | `System.Threading.Lock` が .NET 9 以降でのみ使用可能なため net8.0 を対象外とする |
| | 再構成前からの変更: ルート直下から `Async/` へ移動 |

---

#### ⭕ValueTaskBenchmark

`Task<T>` vs `ValueTask<T>` の非同期コストを比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

### Collections/ — コレクション

各種コレクション実装の構築・検索・反復コストを計測する。

---

#### ⭕DictionaryMarshalBenchmark

`Dictionary` への書き込み方式 (`TryAdd` vs `CollectionsMarshal.GetValueRef`) を比較する。

**固有設定:** `CategoriesColumn` を追加 (read / write カテゴリで分類) 

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕EntryHolderBenchmark

エントリ配列の割り当て方式 (通常割り当て / ArrayPool / Struct Entry) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕EnumerableImplementBenchmark

Enumerable の実装方式 (Net73 / IEnumerator / Class / Yield) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕FindEntryBenchmark

リスト検索方式 (配列+クラスノード / 配列+構造体 / リンク表) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕FrozenBenchmark

読み取り専用コレクション (Dictionary / ReadOnlyDictionary / ImmutableDictionary / FrozenDictionary) の検索性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕HandlersBenchmark

ハンドラー保持構造 (配列型 vs リンク型) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕ListBenchmark

List の反復・容量確保・Span 化を計測する。

**内包クラス:** `ListCapacityBenchmark`, `ListEnumerationBenchmark`, `IndexLoopBenchmark`, `EnumerableBenchmark`, `EnumeratorBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `ListCapacityBenchmark`, `ListEnumerationBenchmark`, `EnumerableBenchmark`, `EnumeratorBenchmark`, `IndexLoopBenchmark` を吸収統合 |

---

#### ⭕LoopListBenchmark

List の反復方式 (for(Count) / while / foreach / Span) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕StructSlotMapBenchmark

ハッシュマップ実装方式 (クラスノード / 構造体スロット / Unsafe 操作) を比較するカスタムデータ構造ベンチマーク。

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | default |
| | バージョン間比較は不要なため net10.0 のみ対象 |

---

### Loop/ — ループ・反復

ループ制御方式および配列要素処理パターンを計測する。

---

#### ⭕ForBenchmark

ループ制御方式 (for 昇順 / for 降順 / while / do-while / foreach) のオーバーヘッドを比較する。

**固有設定:** `[Params(1, 4, 8, 16, 64, 256, 1024)]` で要素数を変化させて計測

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | default |
| | マイクロループのオーバーヘッド計測のため net10.0 のみ対象 |
| | 再構成前からの変更: ルート直下から `Loop/` へ移動 |

---

#### ⭕StructArrayBenchmark

構造体配列 Ref 操作 vs クラス配列操作の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Loop/` へ移動 |

---

#### ⭕ColumnMatchBenchmark

マッチング方式 (ThreadStatic 参照ループ vs Unsafe 操作) の複合計測。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Loop/` へ移動 |

---

### Memory/ — メモリ・バッファ操作

バッファ書き込み・割り当て・コピー・Span アクセスなどのメモリ操作性能を計測する。

---

#### ⭕BoundaryAccessBenchmark

配列アクセスの境界チェック最適化 (配列長参照 / 直接アクセス / 境界チェック有無) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Memory/` へ移動 |

---

#### ⭕BoxingBenchmark

ボックス化のコスト・回避・キャッシュ方式を比較する。

**内包クラス:** `Benchmark`, `BoxCacheBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `BoxCacheBenchmark` (int のキャッシュ) を吸収統合。ルート直下から `Memory/` へ移動 |

---

#### ⭕BufferAllocBenchmark

バッファ割り当て方式 (new / stackalloc / ArrayPool / TemporaryBuffer / Marshal.AllocHGlobal / P/Invoke with Span) を比較する。

**内包クラス:** 4 クラス (`PInvokeBufferBenchmark` は Windows のみ対象) 

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `AllocBenchmark`, `BufferBenchmark`, `TemporaryBenchmark`, `PInvokeBufferBenchmark` を吸収統合 |

---

#### ⭕BufferWriteBenchmark

バッファ書き込み方式 (BinaryPrimitives / MemoryMarshal / Unsafe / ポインタ) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕CopyBenchmark

バッファコピー方式 (Array.Copy / Buffer.BlockCopy / Buffer.MemoryCopy) と配列反転を計測する。

**内包クラス:** `Benchmark`, `ReverseBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `CopyBenchmark`, `ReverseBenchmark` を吸収統合 |

---

#### ⭕SlotMapLookupBenchmark

Span 操作の複合計測 (Indexer / Sliced / Hybrid / GetRef によるアクセス、ハッシュ計算) 。

**内包クラス:** `IsMatchColumnBenchmark`, `CalcNameHashBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net10.0` |
| Job | default |
| | 再構成前からの変更: ルート直下から `Memory/` へ移動 |

---

#### ⭕SpanAccessBenchmark

Span / Unsafe 参照アクセスと境界チェックの網羅的計測。

**内包クラス:** 5 クラス (`RefLoopBenchmark` と `LengthCheckBenchmark` には `[GroupBenchmarksBy]` + `CategoriesColumn` を付与) 

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `ArrayAccessBenchmark`, `FieldArrayAccessBenchmark`, `FuncArrayBenchmark`, `RefLoopBenchmark`, `SpanLoopBenchmark`, `LengthCheckBenchmark` を吸収統合 |

---

#### ⭕UnsafeReferenceBenchmark

Span インデックス vs `MemoryMarshal.GetReference` + `Unsafe.Add` による参照アクセスを比較する。

**内包クラス:** `Benchmark`, `SpanSearchBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Memory/` へ移動 |

---

### Misc/ — その他

単独カテゴリに収まらないベンチマーク。

---

#### ⭕DisposableBenchmark

IDisposable 利用方式 (using 文 / try-finally / クラスベース / 構造体ベース) の性能を比較する。

**内包クラス:** `Benchmark`, `TryBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `DisposableBenchmark`, `TryBenchmark` を吸収統合 |

---

### Numeric/ — 数値演算

インデックス計算・数値型演算・ソート・比較の性能を計測する。

---

#### ⭕CalcIndexBenchmark

インデックス計算方式 (int vs uint 型のハッシュ値計算 / ビットシフト vs 乗除算) を比較する。

**内包クラス:** `Benchmark`, `BitShiftBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `BitShiftBenchmark` を吸収統合。ルート直下から `Numeric/` へ移動 |

---

#### ⭕NumericBenchmark

数値型の演算性能 (uint / ulong / BigInteger / Decimal) を比較する。

**内包クラス:** `Benchmark`, `DecimalBitsBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `NumericBenchmark`, `DecimalBitsBenchmark` を吸収統合。ルート直下から `Numeric/` へ移動 |

---

#### ⭕SortBenchmark

ソート・比較アルゴリズム (標準 Sort / MergeSort / IComparable / IComparer / delegate) を比較する。

**内包クラス:** `Benchmark`, `CompareSortBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `CompareBenchmark` を吸収統合。ルート直下から `Numeric/` へ移動 |

---

### Runtime/ — ランタイム・型機能

型キャスト・typeof・型変換・パラメータ渡し・メンバーアクセス・コンパイラ最適化を計測する。

---

#### ⭕CastBenchmark

型キャスト方式 (通常キャスト vs `Unsafe.As<T>`) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕CollectionConvertBenchmark

コンテナ型 (Array / List) 間の変換方式を比較する。

**内包クラス:** `ListConverterBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `ContainerConverterBenchmark` を吸収統合 |

---

#### ⭕ConverterBenchmark

型変換コンバーター (デフォルトコンバータ vs ジェネリック delegate / DynamicMethod / Expression) を比較する。

**内包クラス:** `Benchmark`, `ConvertMethodBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `ConverterBenchmark`, `ConvertMethodBenchmark` を吸収統合 |

---

#### ⭕GenericConverterBenchmark

ジェネリック型変換方式 (`Convert.ChangeType` / Delegate / `Unsafe.As`) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Runtime/` へ移動 |

---

#### ⭕InlineBenchmark

コンパイラインライン最適化 (`AggressiveInlining` 有無 / `SkipLocalsInit`) の効果を計測する。

**内包クラス:** `MethodInlineBenchmark`, `LocalsInitBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `DisassemblyBenchmark`, `SkipLocalsInitBenchmark` を吸収統合 |

---

#### ⭕MemberAccessBenchmark

フィールド / プロパティ / ref 直接アクセス / コールバック / アクセサー関数の性能を比較する。

**内包クラス:** `FieldPropertyBenchmark`, `SetStorageBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `MemberAccessBenchmark`, `SetStorageBenchmark` を吸収統合。ルート直下から `Runtime/` へ移動 |

---

#### ⭕ParameterBenchmark

構造体パラメータ渡し方式 (値渡し / ref / in / readonly ref) および構造体サイズ別の影響を計測する。

**内包クラス:** `Benchmark`, `StructSizeBenchmark`, `StructRefBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `StructArgumentBenchmark`, `StructParameterBenchmark` を吸収統合。ルート直下から `Runtime/` へ移動 |

---

#### ⭕ProjectionBenchmark

オブジェクト射影方式 (Map / ClassProjection / StructProjection) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Runtime/` へ移動 |

---

#### ⭕ReadOnlyFieldBenchmark

`readonly` 修飾子の有無が JIT 最適化 (devirtualization) に与える効果を計測する。

**固有設定:** `DisassemblyDiagnoser` の `maxDepth: 4` (標準は 3) — readonly フィールド経由の devirtualization を追加の呼び出し深度まで追跡するため

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Runtime/` へ移動 |

---

#### ⭕TypeConvertBenchmark

TypeConverter のキャッシング (オンデマンド vs Cached 型変換) の性能を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Runtime/` へ移動 |

---

#### ⭕TypeOfBenchmark

`typeof()` 演算子の最適化 (定義済み型情報の再利用 vs 毎回 `typeof()` 呼び出し) を計測する。

**固有設定:** `DisassemblyDiagnoser` の `maxDepth: 4` (標準は 3) — `typeof()` キャッシュがヘルパー間接経由でどう伝播するかを追跡するため

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Runtime/` へ移動 |

---

### Text/ — 文字列・フォーマット

文字列構築・フォーマット・パース・ハッシュ・エンコードを計測する。

---

#### ⭕CharConvertBenchmark

char 配列操作方式 (Unsafe 操作 vs Ref 操作) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Text/` へ移動 |

---

#### ⭕FormatBenchmark

DateTime / 数値の書式化方式 (ToString / Utf8Formatter / カスタム実装) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕HexBenchmark

Hex エンコード / デコード方式 (Index / Pointer / Reference) を比較する。

**固有設定:** `CategoriesColumn` を追加 (`Default`, `Encode1`, `Encode2`, `Decode1`, `Decode2` カテゴリで分類) 

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `HexBenchmark` を吸収統合 |

---

#### ⭕IndexOfAnyBenchmark

文字列検索の最適化 (`IndexOfAny` vs `SearchValues` キャッシュ) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕ParseBenchmark

文字列パース方式 (`TryParse` vs `Parse` / 例外処理コスト) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Text/` へ移動 |

---

#### ⭕StringAppendBenchmark

文字列追記方式 (+ 演算子 / StringBuilder / PoolBuffer / ThreadStaticBuffer) を比較する。

**内包クラス:** `Benchmark`, `PooledBuilderBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `StringAppendBenchmark`, `OldStringBuilderBenchmark` を吸収統合 |

---

#### ⭕StringBuilderBenchmark

文字列構築方式 (StringBuilder / `DefaultInterpolatedStringHandler` / ValueStringBuilder / Pooled) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |

---

#### ⭕StringHashBenchmark

文字列ハッシュ方式 (XxHash3 vs XxHash3b / fixed char ポインタ) を比較する。

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: ルート直下から `Text/` へ移動 |

---

#### ⭕TextConvertBenchmark

テキスト変換 (エンコード・数値パース) の方式を比較する。

**内包クラス:** `EncodingBenchmark`, `ParseNumberBenchmark`

| 項目 | 設定 |
|---|---|
| TFM | `net8.0` `net9.0` `net10.0` |
| Job | Medium |
| | 再構成前からの変更: Old/ の `ConvertBenchmark` を吸収統合 |

---

## Old/ プロジェクト一覧 (未対応) 

Old/ フォルダのプロジェクトは以下の理由により最新構成へのマージを保留している。

### 凡例

| 記号 | 区分 | 説明 |
|---|---|---|
| 🔴 | 外部依存 | 社内ライブラリ (Smart.*) や専用 NuGet パッケージが必要で、標準 .NET のみでは再現不可 |
| 🟡 | 重複 | 新規作成済みプロジェクトが同等の計測をすでにカバー済み |
| 🟢 | 追加可能 | ベンチマーク数が少なく、既存プロジェクトへの追加として後回し |

---

### 🔴 外部依存 (12 件) 

| プロジェクト | 依存先 | 代替カバー |
|---|---|---|
| AccessorBenchmark | `Smart.Reflection` の `DynamicDelegateFactory` | `MemberAccessBenchmark` |
| BuildServiceProviderBenchmark | `Microsoft.Extensions.DependencyInjection` | — |
| CallBenchmark50 | `InlineIL` (実験的 NuGet)  | `InlineBenchmark` |
| ChangeTypeBenchmark | `Smart.Converter` の `ObjectConverter` | `ConverterBenchmark` |
| CreateBenchmark | `Smart.Reflection` の `DelegateFactory` | `FactoryEntryBenchmark`, `DelegateBenchmark` |
| DefaultLookupBenchmark | `Smart.Collections.Concurrent` の `ThreadsafeTypeHashArrayMap` | `FindEntryBenchmark` |
| DictionaryKeyBenchmark | `Smart.Collections.Concurrent` の `HashArrayMap` | `FindEntryBenchmark` |
| EquatableBenchmark | `Smart.Collections.Concurrent` の `HashArrayMap` | `FindEntryBenchmark` |
| LookupBenchmark | `Smart.Collections.Concurrent` の `ThreadSafeHashArrayMap` | `FindEntryBenchmark` |
| RoslynScriptBenchmark | `Microsoft.CodeAnalysis.CSharp.Scripting` | — |
| SmallKeyBenchmark | `Smart.Collections.Generic` / `Smart.Collections.Concurrent` | — |
| SmallLookupBenchmark | `Smart.Collections.Concurrent` の `ThreadSafeHashArrayMap`, `MetadataHashArray` | — |

---

### 🟡 既存と重複 (10 件) 

| プロジェクト | 重複している既存プロジェクト |
|---|---|
| AbstractCallBenchmark | `CallAbstractionBenchmark` |
| ActivatorBenchmark | `FactoryEntryBenchmark`, `DelegateBenchmark` |
| CallBenchmark | `SealedDispatchBenchmark`, `DelegateBenchmark`, `CallAbstractionBenchmark` |
| CallTypeBenchmark | `SealedDispatchBenchmark` |
| CallVirtBenchmark | `SealedDispatchBenchmark` |
| DispatchBenchmark | `SwitchBenchmark`, `DelegateBenchmark` |
| DynamicMethodBenchmark | `DelegateBenchmark`, `ConverterBenchmark` |
| FunctionBenchmark | `DelegateBenchmark` |
| ResolveBenchmark | `SealedDispatchBenchmark`, `CallAbstractionBenchmark` |
| StaticInstanceBenchmark | `CallAbstractionBenchmark`, `SealedDispatchBenchmark`, `DelegateBenchmark` |

---

### 🟢 追加対応可 (9 件) 

| プロジェクト | 内容 | 想定する吸収先 |
|---|---|---|
| BinarySearchBenchmark | `Array.BinarySearch` vs `Span.BinarySearch` (2 メソッド)  | `SortBenchmark` |
| BoxCacheBenchmark2 | int ↔ bool 変換時のボックス化キャッシュ (4 メソッド)  | `BoxingBenchmark` |
| GenericStructFactoryBenchmark | ジェネリック構造体ファクトリ vs Func 委譲 (6 メソッド)  | `FactoryEntryBenchmark` |
| KeyBenchmark | struct / class × field / property の辞書ルックアップ (8 メソッド)  | `FindEntryBenchmark` / `HashBenchmark` |
| LookupKeyBenchmark | タプルキー vs `record struct` キーの Dictionary ルックアップ (2 メソッド)  | `FindEntryBenchmark` / `HashBenchmark` |
| LookupNodeBenchmark | リンクリスト / 構造体配列 / クラス配列の探索パターン (18 メソッド)  | `LoopListBenchmark` / `ForBenchmark` |
| LoopStructBenchmark | リンクリスト / 構造体配列 / Span のノード検索 (9 メソッド)  | `ForBenchmark` / `StructArrayBenchmark` |
| ResultMapperCacheBenchmark | class / struct × field / property マッパーキャッシュ (4 メソッド)  | `ProjectionBenchmark` / `MemberAccessBenchmark` |
| TypedInterfaceBenchmark | `Func<object>` 辞書 vs `Func<T>` 型付きジェネリックリゾルバー (4 メソッド)  | `GenericConverterBenchmark` |

---

## 標準 BenchmarkConfig

特記なき場合、全プロジェクトで以下の共通設定を使用する。

```csharp
public class BenchmarkConfig : ManualConfig
{
    public BenchmarkConfig()
    {
        AddExporter(MarkdownExporter.GitHub);
        AddColumn(
            StatisticColumn.Mean,
            StatisticColumn.Min,
            StatisticColumn.Max,
            StatisticColumn.P90,
            StatisticColumn.Error,
            StatisticColumn.StdDev);
        AddDiagnoser(
            MemoryDiagnoser.Default,
            new DisassemblyDiagnoser(new DisassemblyDiagnoserConfig(
                maxDepth: 3,
                printSource: true,
                printInstructionAddresses: true,
                exportDiff: true)));
    }
}
```

マルチフレームワーク対象プロジェクトは、各ランタイムに `[MediumRunJob]` を付与する。

```csharp
[Config(typeof(BenchmarkConfig))]
[MediumRunJob(RuntimeMoniker.Net80)]
[MediumRunJob(RuntimeMoniker.Net90)]
[MediumRunJob(RuntimeMoniker.Net10_0)]
public class Benchmark { ... }
```

