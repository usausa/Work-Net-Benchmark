namespace DictionaryBenchmark.Library
{
    using System;
    using System.Runtime.CompilerServices;

    public class HashArrayLookupTable<TKey, TValue>
    {
        private readonly int hashCount;

        private readonly KeyValue<TKey, TValue>[][] tables;

        public HashArrayLookupTable(int hashCount)
        {
            this.hashCount = hashCount;
            tables = new KeyValue<TKey, TValue>[hashCount][];
        }

        public void Add(TKey key, TValue value)
        {
            var index = key.GetHashCode() % hashCount;

            var currentSize = tables[index]?.Length ?? 0;
            var newArray = new KeyValue<TKey, TValue>[currentSize + 1];
            if (tables[index] != null)
            {
                Array.Copy(tables[index], 0, newArray, 0, currentSize);
            }
            newArray[currentSize] = new KeyValue<TKey, TValue>(key, value);
            tables[index] = newArray;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value)
        {
            var index = key.GetHashCode() & 0b1111111111;

            var array = tables[index];
            for (var i = 0; i < array.Length; i++)
            {
                if (array[i].Key.Equals(key))
                {
                    value = array[i].Value;
                    return true;
                }
            }

            value = default(TValue);
            return false;
        }
    }
}
