namespace ResultMapperCacheBenchmark
{
    using System;

    public sealed class ClassPropertyColumnInfo : IEquatable<ClassPropertyColumnInfo>
    {
        public string Name { get; }

        public Type Type { get; }

        public ClassPropertyColumnInfo(string name, Type type)
        {
            Name = name;
            Type = type;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1008:OpeningParenthesisMustBeSpacedCorrectly", Justification = "Ignore")]
        public override int GetHashCode() => Name.GetHashCode(StringComparison.OrdinalIgnoreCase) ^ Type.GetHashCode();

        public override bool Equals(object obj) => obj is ClassPropertyColumnInfo other && Equals(other);

        public bool Equals(ClassPropertyColumnInfo other) => Name == other.Name && Type == other.Type;

        public static bool operator ==(ClassPropertyColumnInfo x, ClassPropertyColumnInfo y) => x.Equals(y);

        public static bool operator !=(ClassPropertyColumnInfo x, ClassPropertyColumnInfo y) => !x.Equals(y);
    }
}
