# 考察：同じような処理なのにIndexerとGetRefで優劣が逆転する理由

## 結果の要約

| ベンチマーク | 優秀な手法 | 条件 |
|---|---|---|
| IsMatchColumn | **GetRef** | ColumnCount > 1 |
| IsMatchColumn | **Indexer** | ColumnCount = 1 |
| CalcNameHash | **Indexer** | 全ケース（NameLength ≥ 4） |

---

## IsMatchColumn：GetRefが優秀（ColumnCount > 1）な理由

### 境界チェック除去（Bounds Check Elimination / BCE）の限界

`IsMatchColumnIndexer` は `cached[i]` と `current[i]` という **2つのSpanを同一ループで同時にアクセス** する。

```csharp
for (var i = 0; i < cached.Length; i++)
{
    ref readonly var column1 = ref cached[i];   // 境界チェックあり
    ref readonly var column2 = ref current[i];  // 境界チェックあり
}
```

JITはループ条件 `i < cached.Length` から `cached[i]` の境界チェックは除去できる。しかし `current[i]` については `current.Length` が `cached.Length` と同じであるという保証を（前のif文で確認済みだとしても）静的に証明するのが難しく、**境界チェックが残存しやすい**。

`IsMatchColumnGetRef` は `MemoryMarshal.GetReference` + `Unsafe.Add` を使うことで両方の境界チェックを**完全に排除**する。

```csharp
ref var head1 = ref MemoryMarshal.GetReference(cached);
ref var head2 = ref MemoryMarshal.GetReference(current);
for (var i = 0; i < cached.Length; i++)
{
    ref readonly var column1 = ref Unsafe.Add(ref head1, i);  // 境界チェックなし
    ref readonly var column2 = ref Unsafe.Add(ref head2, i);  // 境界チェックなし
}
```

この恩恵はイテレーション数が増えるほど大きくなるため、ColumnCountが増えるにつれてGetRefの優位性が広がる（コードサイズも 679B → 646B と小さくなっている）。

### ColumnCount=1 でIndexerが勝つ理由

ColumnCount=1 の場合はループが1回しか回らない。JITはループを展開（unroll）し、`cached[0]` の境界チェックも消去できる。一方でGetRef版は `MemoryMarshal.GetReference` で head1/head2 のポインタをセットアップするコストが固定でかかる。この**セットアップコストが、1回分の境界チェック節約より大きい**ため、1要素ではIndexerが速い。

---

## CalcNameHash：Indexerが優秀な理由

### 単一Span + プリミティブ型 = JITのBCEが完璧に機能する

```csharp
for (var i = 0; i < value.Length; i++)
{
    hash = (value[i] ^ hash) * 16777619;  // value[i] の境界チェック
}
```

アクセスするSpanが**1つだけ**で、ループ条件が `i < value.Length` と一致しているため、JITは `value[i]` の境界チェックを**完全に除去**できる。結果としてIndexer版のコードサイズは 64B と非常に小さく、GetRef版の 67B より小さい。

GetRef版では `ref var head = ref MemoryMarshal.GetReference(value)` でベースポインタを取得し、各イテレーションで `Unsafe.Add(ref head, i)` を計算する。しかし `char` は2バイトなので、アドレス計算は `base + i * 2` となる。これはJITの直接Span indexingによる最適化パス（単純な `base + offset` アドレッシング）と比べて、同等以上のコストになりやすい。すでにBCEで境界チェックが消えているIndexer版に対して、GetRefは**節約できるものがない上にポインタセットアップのオーバーヘッドだけが残る**。

---

## まとめ：使い分けの指針

| 条件 | 推奨手法 | 理由 |
|---|---|---|
| **複数のSpanを同時にループアクセス** | `GetRef` + `Unsafe.Add` | JITが複数Spanの境界チェックを除去しにくいため、手動で排除する効果が大きい |
| **単一SpanをForループでアクセス** | Span Indexer | JITのBCEが完璧に機能し、GetRefのセットアップコストが無駄になる |
| **要素数が1（もしくは非常に少ない）** | Span Indexer | GetRefのセットアップコストが支配的になる |

> `MemoryMarshal.GetReference` + `Unsafe.Add` は "境界チェックを自分で除去する" 手法であり、JITがすでに除去できている場合はオーバーヘッドになる。JITのBCEが効かない状況（複数Span・複雑な条件）でのみ有効。