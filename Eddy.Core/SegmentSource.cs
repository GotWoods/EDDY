namespace Eddy.Core;

/// <summary>
/// Where a parsed segment came from in the original text. Line numbers count non-blank segments
/// from 1 starting at the interchange header, matching <see cref="Validation.ValidationResult.LineNumber"/>.
/// Offsets are character positions into the text handed to the parser.
/// </summary>
public class SegmentSource
{
    public SegmentSource()
    {
    }

    public SegmentSource(int lineNumber, int startOffset, int length, string rawText)
    {
        LineNumber = lineNumber;
        StartOffset = startOffset;
        Length = length;
        RawText = rawText;
    }

    /// <summary>1-based segment number within the document.</summary>
    public int LineNumber { get; set; }

    /// <summary>Character offset of the first character of the segment identifier.</summary>
    public int StartOffset { get; set; }

    /// <summary>Length of the segment text, excluding the terminator.</summary>
    public int Length { get; set; }

    /// <summary>The segment text as it appeared in the file, without its terminator.</summary>
    public string RawText { get; set; }

    public int EndOffset => StartOffset + Length;

    public override string ToString() => $"line {LineNumber} [{StartOffset}..{EndOffset})";
}

/// <summary>Implemented by parsed segments that remember where they came from.</summary>
public interface ISourceTracked
{
    SegmentSource Source { get; set; }
}
