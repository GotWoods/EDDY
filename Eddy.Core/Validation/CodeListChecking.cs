namespace Eddy.Core.Validation;

/// <summary>Controls whether/how a document parser flags element values that are not in a loaded code
/// list. Shared by <c>x12ParseOptions.CodeListChecking</c> and <c>EdifactParseOptions.CodeListChecking</c>.</summary>
public enum CodeListChecking
{
    /// <summary>Do not check code list membership at all (default). No cost beyond a single comparison
    /// per segment.</summary>
    Off,

    /// <summary>Flag unknown codes as Warning-severity entries; the document (and its ValidationResult)
    /// otherwise stays valid.</summary>
    Warn,

    /// <summary>Flag unknown codes as Error-severity entries.</summary>
    Error,
}
