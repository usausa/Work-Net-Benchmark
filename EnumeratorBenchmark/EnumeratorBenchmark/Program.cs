namespace EnumeratorBenchmark
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Columns;
    using BenchmarkDotNet.Configs;
    using BenchmarkDotNet.Diagnosers;
    using BenchmarkDotNet.Exporters;
    using BenchmarkDotNet.Jobs;
    using BenchmarkDotNet.Running;

    public static class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }

    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddExporter(MarkdownExporter.Default, MarkdownExporter.GitHub);
            AddColumn(
                StatisticColumn.Mean,
                StatisticColumn.Min,
                StatisticColumn.Max,
                StatisticColumn.P90,
                StatisticColumn.Error,
                StatisticColumn.StdDev);
            AddDiagnoser(MemoryDiagnoser.Default);
            AddJob(Job.MediumRun);
        }
    }

    [Config(typeof(BenchmarkConfig))]
    public class Benchmark
    {
        private readonly StructArray structArray = new(CreateArray());
        private readonly StructArrayWithField structArrayWithField = new(CreateArray());
        private readonly StructArrayWithFieldNoBoundsCheck structArrayWithFieldNoBoundsCheck = new(CreateArray());
        private readonly StructArrayWithFieldLengthCache structArrayWithFieldLengthCache = new(CreateArray());
        private readonly StructArrayWithFieldLengthCacheNoBoundsCheck structArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
        private readonly StructArrayWithFieldLengthUnsignedCache structArrayWithFieldLengthUnsignedCache = new(CreateArray());

        private readonly CustomStructArray customStructArray = new(CreateArray());
        private readonly CustomStructArrayWithField customStructArrayWithField = new(CreateArray());
        private readonly CustomStructArrayWithFieldNoBoundsCheck customStructArrayWithFieldNoBoundsCheck = new(CreateArray());
        private readonly CustomStructArrayWithFieldLengthCache customStructArrayWithFieldLengthCache = new(CreateArray());
        private readonly CustomStructArrayWithFieldLengthCacheNoBoundsCheck customStructArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
        private readonly CustomStructArrayWithFieldLengthUnsignedCache customStructArrayWithFieldLengthUnsignedCache = new(CreateArray());

        private readonly ClassArray classArray = new(CreateArray());
        private readonly ClassArrayWithField classArrayWithField = new(CreateArray());
        private readonly ClassArrayWithFieldNoBoundsCheck classArrayWithFieldNoBoundsCheck = new(CreateArray());
        private readonly ClassArrayWithFieldLengthCache classArrayWithFieldLengthCache = new(CreateArray());
        private readonly ClassArrayWithFieldLengthCacheNoBoundsCheck classArrayWithFieldLengthCacheNoBoundsCheck = new(CreateArray());
        private readonly ClassArrayWithFieldLengthUnsignedCache classArrayWithFieldLengthUnsignedCache = new(CreateArray());

        private static int[] CreateArray() => Enumerable.Range(1, 16).ToArray();

        [Benchmark] public void StructArray() { foreach (var _ in structArray) { } }
        [Benchmark] public void StructArrayWithField() { foreach (var _ in structArrayWithField) { } }
        [Benchmark] public void StructArrayWithFieldNoBoundsCheck() { foreach (var _ in structArrayWithFieldNoBoundsCheck) { } }
        [Benchmark] public void StructArrayWithFieldLengthCache() { foreach (var _ in structArrayWithFieldLengthCache) { } }
        [Benchmark] public void StructArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in structArrayWithFieldLengthCacheNoBoundsCheck) { } }
        [Benchmark] public void StructArrayWithFieldLengthUnsignedCache() { foreach (var _ in structArrayWithFieldLengthUnsignedCache) { } }

        [Benchmark] public void CustomStructArray() { foreach (var _ in customStructArray) { } }
        [Benchmark] public void CustomStructArrayWithField() { foreach (var _ in customStructArrayWithField) { } }
        [Benchmark] public void CustomStructArrayWithFieldNoBoundsCheck() { foreach (var _ in customStructArrayWithFieldNoBoundsCheck) { } }
        [Benchmark] public void CustomStructArrayWithFieldLengthCache() { foreach (var _ in customStructArrayWithFieldLengthCache) { } }
        [Benchmark] public void CustomStructArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in customStructArrayWithFieldLengthCacheNoBoundsCheck) { } }
        [Benchmark] public void CustomStructArrayWithFieldLengthUnsignedCache() { foreach (var _ in customStructArrayWithFieldLengthUnsignedCache) { } }

        [Benchmark] public void ClassArray() { foreach (var _ in classArray) { } }
        [Benchmark] public void ClassArrayWithField() { foreach (var _ in classArrayWithField) { } }
        [Benchmark] public void ClassArrayWithFieldNoBoundsCheck() { foreach (var _ in classArrayWithFieldNoBoundsCheck) { } }
        [Benchmark] public void ClassArrayWithFieldLengthCache() { foreach (var _ in classArrayWithFieldLengthCache) { } }
        [Benchmark] public void ClassArrayWithFieldLengthCacheNoBoundsCheck() { foreach (var _ in classArrayWithFieldLengthCacheNoBoundsCheck) { } }
        [Benchmark] public void ClassArrayWithFieldLengthUnsignedCache() { foreach (var _ in classArrayWithFieldLengthUnsignedCache) { } }
    }

    // TODO pointer / array ?

    //--------------------------------------------------------------------------------
    // StructEnumerator
    //--------------------------------------------------------------------------------

    public sealed class StructArray : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArray(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class StructArrayWithField : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArrayWithField(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class StructArrayWithFieldNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class StructArrayWithFieldLengthCache : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArrayWithFieldLengthCache(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class StructArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class StructArrayWithFieldLengthUnsignedCache : IEnumerable<int>
    {
        private readonly int[] array;

        public StructArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new StructArrayWithFieldLengthUnsignedCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    //--------------------------------------------------------------------------------
    // StructEnumerator custom
    //--------------------------------------------------------------------------------

    public sealed class CustomStructArray : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArray(int[] array) => this.array = array;

        public StructArrayEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class CustomStructArrayWithField : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArrayWithField(int[] array) => this.array = array;

        public StructArrayWithFieldEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class CustomStructArrayWithFieldNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

        public StructArrayWithFieldNoBoundsCheckEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class CustomStructArrayWithFieldLengthCache : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArrayWithFieldLengthCache(int[] array) => this.array = array;

        public StructArrayWithFieldLengthCacheEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class CustomStructArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

        public StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class CustomStructArrayWithFieldLengthUnsignedCache : IEnumerable<int>
    {
        private readonly int[] array;

        public CustomStructArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

        public StructArrayWithFieldLengthUnsignedCacheEnumerator GetEnumerator() => new(array);
        IEnumerator<int> IEnumerable<int>.GetEnumerator() => new StructArrayWithFieldLengthUnsignedCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    //--------------------------------------------------------------------------------
    // ClassEnumerator
    //--------------------------------------------------------------------------------

    public sealed class ClassArray : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArray(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class ClassArrayWithField : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArrayWithField(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class ClassArrayWithFieldNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArrayWithFieldNoBoundsCheck(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class ClassArrayWithFieldLengthCache : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArrayWithFieldLengthCache(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class ClassArrayWithFieldLengthCacheNoBoundsCheck : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArrayWithFieldLengthCacheNoBoundsCheck(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public sealed class ClassArrayWithFieldLengthUnsignedCache : IEnumerable<int>
    {
        private readonly int[] array;

        public ClassArrayWithFieldLengthUnsignedCache(int[] array) => this.array = array;

        public IEnumerator<int> GetEnumerator() => new ClassArrayWithFieldLengthUnsignedCacheEnumerator(array);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    //--------------------------------------------------------------------------------
    // StructEnumerator
    //--------------------------------------------------------------------------------

    public struct StructArrayEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int index;

        public int Current
        {
            get;
            private set;
        }

        object IEnumerator.Current => Current;

        public StructArrayEnumerator(int[] array)
        {
            this.array = array;
            index = 0;
            Current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < array.Length)
            {
                Current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public struct StructArrayWithFieldEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public StructArrayWithFieldEnumerator(int[] array)
        {
            this.array = array;
            index = 0;
            current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < array.Length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public struct StructArrayWithFieldNoBoundsCheckEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public StructArrayWithFieldNoBoundsCheckEnumerator(int[] array)
        {
            this.array = array;
            index = 0;
            current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if ((uint)index < (uint)array.Length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public struct StructArrayWithFieldLengthCacheEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly int length;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public StructArrayWithFieldLengthCacheEnumerator(int[] array)
        {
            this.array = array;
            length = array.Length;
            index = 0;
            current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public struct StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly int length;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public StructArrayWithFieldLengthCacheNoBoundsCheckEnumerator(int[] array)
        {
            this.array = array;
            length = array.Length;
            index = 0;
            current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if ((uint)index < (uint)length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public struct StructArrayWithFieldLengthUnsignedCacheEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly uint length;
        private int current;
        private uint index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public StructArrayWithFieldLengthUnsignedCacheEnumerator(int[] array)
        {
            this.array = array;
            length = (uint)array.Length;
            index = 0;
            current = default;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    //--------------------------------------------------------------------------------
    // ClassEnumerator
    //--------------------------------------------------------------------------------

    public sealed class ClassArrayEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int index;

        public int Current
        {
            get;
            private set;
        }

        object IEnumerator.Current => Current;

        public ClassArrayEnumerator(int[] array)
        {
            this.array = array;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < array.Length)
            {
                Current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public sealed class ClassArrayWithFieldEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public ClassArrayWithFieldEnumerator(int[] array)
        {
            this.array = array;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < array.Length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public sealed class ClassArrayWithFieldNoBoundsCheckEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public ClassArrayWithFieldNoBoundsCheckEnumerator(int[] array)
        {
            this.array = array;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if ((uint)index < (uint)array.Length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public sealed class ClassArrayWithFieldLengthCacheEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly int length;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public ClassArrayWithFieldLengthCacheEnumerator(int[] array)
        {
            this.array = array;
            length = array.Length;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public sealed class ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly int length;
        private int current;
        private int index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public ClassArrayWithFieldLengthCacheNoBoundsCheckEnumerator(int[] array)
        {
            this.array = array;
            length = array.Length;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if ((uint)index < (uint)length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }

    public sealed class ClassArrayWithFieldLengthUnsignedCacheEnumerator : IEnumerator<int>
    {
        private readonly int[] array;
        private readonly uint length;
        private int current;
        private uint index;

        public int Current => current;

        object IEnumerator.Current => Current;

        public ClassArrayWithFieldLengthUnsignedCacheEnumerator(int[] array)
        {
            this.array = array;
            length = (uint)array.Length;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (index < length)
            {
                current = array[index];
                index++;
                return true;
            }

            return false;
        }

        public void Reset() => throw new NotSupportedException();
    }
}
