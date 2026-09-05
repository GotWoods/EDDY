namespace Eddy.Core.Validation;

/// <summary>Process-wide knobs for validation rules that need one, so segment Validate() methods (which
/// take no options) can still be tuned. Currently just the code list rule's severity.</summary>
public static class ValidationSettings
{
    /// <summary>Severity <see cref="BasicValidator{T}.KnownCode"/> uses when a value is not in a loaded
    /// code list. Defaults to Warning: an unrecognised code is usually a partner-specific extension, not
    /// malformed input.</summary>
    public static ErrorSeverity CodeListSeverity { get; set; } = ErrorSeverity.Warning;
}
