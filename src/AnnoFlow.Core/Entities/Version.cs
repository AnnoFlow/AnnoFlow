namespace AnnoFlow.Core.Entities
{
    public class Version : IEquatable<Version>
    {
        public uint Major { get; private set; }

        public uint Minor { get; private set; }

        public uint Patch { get; private set; }

        public string Label { get; private set; } = string.Empty;

        public bool Equals(Version? other)
        {
            return Major == other?.Major
                   && Minor == other?.Minor
                   && Patch == other?.Patch
                   && string.Equals(Label, other.Label, StringComparison.Ordinal);
        }
    }
}