namespace Eddy.Notepad.ViewModels;

/// <summary>A validation or parse problem, shown in the diagnostics pane.</summary>
public sealed class DiagnosticViewModel
{
    public DiagnosticViewModel(DiagnosticSeverity severity, int? lineNumber, string segmentCode, string message)
    {
        Severity = severity;
        LineNumber = lineNumber;
        SegmentCode = segmentCode;
        Message = message;
    }

    public DiagnosticSeverity Severity { get; }

    /// <summary>1-based segment line number in the raw view, or null when the problem has no location.</summary>
    public int? LineNumber { get; }

    /// <summary>Segment identifier the problem belongs to, e.g. "N1", or "" when unknown.</summary>
    public string SegmentCode { get; }

    public string Message { get; }

    /// <summary>The tree node this diagnostic belongs to, when one could be resolved.</summary>
    public DocumentNodeViewModel? Node { get; set; }

    public string Location => LineNumber.HasValue ? $"Line {LineNumber}" : "";
}
