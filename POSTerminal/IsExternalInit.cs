namespace System.Runtime.CompilerServices {
    using ComponentModel;
    /// <summary>
    /// Reserved to be used by the compiler for tracking metadata.
    /// This class allows the use of some C# 9 and .NET 5 features (records, init) in older .NET versions
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit {
    }
}