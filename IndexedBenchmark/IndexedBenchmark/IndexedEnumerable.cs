using System;
using System.Collections;
using System.Collections.Generic;

namespace IndexedBenchmark
{
    // Indexed

    public struct Indexed<T>
    {
        public T Item { get; set; }

        public int Index { get; set; }

        public Indexed(T item, int index)
        {
            Item = item;
            Index = index;
        }
    }

    // IList

    public struct IndexedListEnumerable<T> : IEnumerable<Indexed<T>>
    {
        private readonly IList<T> list;

        public IndexedListEnumerable(IList<T> list)
        {
            this.list = list;
        }

        public IndexedListEnumerator<T> GetEnumerator() => new IndexedListEnumerator<T>(list);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
    }

    public struct IndexedListEnumerator<T> : IEnumerator<Indexed<T>>
    {
        public Indexed<T> Current => new Indexed<T>(list[index], index);

        private readonly IList<T> list;

        private int index;

        internal IndexedListEnumerator(IList<T> list)
        {
            this.list = list;
            index = -1;
        }

        public bool MoveNext()
        {
            index++;
            return index < list.Count;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public void Reset() { throw new NotImplementedException(); }
    }

    // Array

    public struct IndexedArrayEnumerable<T> : IEnumerable<Indexed<T>>
    {
        private readonly T[] array;

        public IndexedArrayEnumerable(T[] array)
        {
            this.array = array;
        }

        public IndexedArrayEnumerator<T> GetEnumerator() => new IndexedArrayEnumerator<T>(array);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
    }

    public struct IndexedArrayEnumerator<T> : IEnumerator<Indexed<T>>
    {
        public Indexed<T> Current => new Indexed<T>(array[index], index);

        private readonly T[] array;

        private int index;

        internal IndexedArrayEnumerator(T[] array)
        {
            this.array = array;
            index = -1;
        }

        public bool MoveNext()
        {
            index++;
            return index < array.Length;
        }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    // Common

    public struct IndexedEnumerable<T> : IEnumerable<Indexed<T>>
    {
        private readonly IEnumerable<T> ie;

        public IndexedEnumerable(IEnumerable<T> ie) { this.ie = ie; }

        public IndexedEnumerator<T> GetEnumerator() => new IndexedEnumerator<T>(ie.GetEnumerator());

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        IEnumerator<Indexed<T>> IEnumerable<Indexed<T>>.GetEnumerator() => GetEnumerator();
    }

    public struct IndexedEnumerator<T> : IEnumerator<Indexed<T>>
    {
        public Indexed<T> Current => new Indexed<T>(ie.Current, index);

        private readonly IEnumerator<T> ie;

        private int index;

        internal IndexedEnumerator(IEnumerator<T> ie)
        {
            this.ie = ie;
            index = -1;
        }

        public bool MoveNext()
        {
            index++;
            return ie.MoveNext();
        }

        object IEnumerator.Current => Current;

        public void Dispose() { }

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }

    // Extensions

    public static class EnumerableExtensions
    {
        public static IndexedListEnumerable<T> IndexedList<T>(this IList<T> source)
        {
            return new IndexedListEnumerable<T>(source);
        }

        public static IndexedArrayEnumerable<T> IndexedArray<T>(this T[] source)
        {
            return new IndexedArrayEnumerable<T>(source);
        }

        public static IndexedEnumerable<T> IndexedEnumerable<T>(this IEnumerable<T> source)
        {
            return new IndexedEnumerable<T>(source);
        }
    }
}
