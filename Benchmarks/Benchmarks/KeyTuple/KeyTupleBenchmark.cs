namespace Benchmarks.KeyTuple
{
    using System;

    public class KeyTupleBenchmark
    {
    }

    public class ClassKey
    {
        public readonly Type Type;

        public readonly string Name;

        public ClassKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public struct StructKey
    {
        public readonly Type Type;

        public readonly string Name;

        public StructKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    public readonly struct ReadonlyStructKey
    {
        public readonly Type Type;

        public readonly string Name;

        public ReadonlyStructKey(Type type, string name)
        {
            Type = type;
            Name = name;
        }
    }

    // TODO PropertyVersion ... (other benchmark?)

    public class ClassKeyMap
    {
        // TODO
    }

    // TODO

    // TODO

    // TODO mixed pair
}
