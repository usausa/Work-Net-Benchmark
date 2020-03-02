namespace ResultMapperCacheBenchmark
{
    using System;

    public sealed class ClassFieldColumnInfo : IEquatable<ClassFieldColumnInfo>
    {
        public readonly string Name;

        public readonly Type Type;

        public ClassFieldColumnInfo(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignore")]
        public override int GetHashCode() => Name.GetHashCode(StringComparison.OrdinalIgnoreCase) ^ Type.GetHashCode();

        public override bool Equals(object obj) => obj is ClassFieldColumnInfo other && Equals(other);

        public bool Equals(ClassFieldColumnInfo other) => Name == other.Name && Type == other.Type;

        public static bool operator ==(ClassFieldColumnInfo x, ClassFieldColumnInfo y) => x.Equals(y);

        public static bool operator !=(ClassFieldColumnInfo x, ClassFieldColumnInfo y) => !x.Equals(y);
    }
}
