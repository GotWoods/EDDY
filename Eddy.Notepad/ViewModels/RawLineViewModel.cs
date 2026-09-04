namespace Eddy.Notepad.ViewModels;

/// <summary>One segment of the raw file text, one per row of the raw view.</summary>
public sealed class RawLineViewModel
{
    public RawLineViewModel(int lineNumber, string text)
    {
        LineNumber = lineNumber;
        Text = text;
    }

    /// <summary>1-based segment number. Matches Eddy's validation LineNumber convention: blank lines are not counted.</summary>
    public int LineNumber { get; }

    /// <summary>The segment text including its terminator, trimmed of surrounding whitespace.</summary>
    public string Text { get; }

    /// <summary>Tree node this line was parsed into, when one exists.</summary>
    public DocumentNodeViewModel? Node { get; set; }

    public bool HasError { get; set; }
}
