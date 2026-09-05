using System;

namespace Eddy.Core;

/// <summary>
/// Pure, text-splicing edit primitives built on <see cref="SegmentSource"/>. Every function here takes the
/// original document text plus the source span of one already-parsed segment and returns a new string with
/// exactly that span (and, for Remove/InsertAfter/InsertBefore, the segment's terminator and - where the
/// file's layout calls for it - the newline that follows the terminator) changed. Nothing else in the text
/// is touched, so a caller who only edited one segment gets back a document that is byte-for-byte identical
/// everywhere else. Callers are expected to re-parse the returned text; these functions do not attempt to
/// keep any in-memory model in sync.
/// </summary>
public static class SourceEdit
{
    /// <summary>Replaces exactly [StartOffset, StartOffset+Length) with <paramref name="newSegmentText"/>.
    /// No terminator handling - <paramref name="newSegmentText"/> should not include one, matching
    /// <see cref="SegmentSource.RawText"/>.</summary>
    public static string Replace(string text, SegmentSource source, string newSegmentText)
    {
        ValidateSource(text, source);
        if (newSegmentText == null)
            throw new ArgumentException("newSegmentText must not be null", nameof(newSegmentText));

        return text.Substring(0, source.StartOffset) + newSegmentText + text.Substring(source.EndOffset);
    }

    /// <summary>Removes the segment, its terminator, and - when the character(s) immediately after the
    /// terminator are a newline (\n or \r\n) - that newline too, so the surrounding layout (blank line
    /// conventions included) is preserved. When <paramref name="terminator"/> is itself \n (a file that
    /// uses a newline as its segment terminator) only the segment and that single \n are removed.</summary>
    public static string Remove(string text, SegmentSource source, char terminator)
    {
        ValidateSource(text, source);

        var terminatorIndex = FindTerminator(text, source, terminator);
        var removalEnd = terminatorIndex + 1;
        if (terminator != '\n')
            removalEnd += NewlineLengthAt(text, removalEnd);

        return text.Substring(0, source.StartOffset) + text.Substring(removalEnd);
    }

    /// <summary>Inserts <paramref name="newSegmentText"/> plus <paramref name="terminator"/> immediately
    /// after the given segment's own terminator, followed by a newline when the surrounding text shows the
    /// file puts newlines after terminators. When <paramref name="terminator"/> is itself \n, the inserted
    /// text is simply newSegmentText + '\n' - there is no separate newline convention to detect.</summary>
    public static string InsertAfter(string text, SegmentSource source, char terminator, string newSegmentText)
    {
        ValidateSource(text, source);
        if (newSegmentText == null)
            throw new ArgumentException("newSegmentText must not be null", nameof(newSegmentText));

        var terminatorIndex = FindTerminator(text, source, terminator);
        var afterTerminator = terminatorIndex + 1;
        // The existing newline (if any) after this segment's terminator belongs to the file's layout
        // between this segment and whatever came next - it must stay there, after our inserted segment,
        // not before it. So the insertion point skips past it, and the inserted text carries its own
        // (identical) newline to separate it from the segment now above it.
        var newline = terminator == '\n' ? "" : NewlineAt(text, afterTerminator);
        var insertPos = afterTerminator + newline.Length;
        var insertion = newSegmentText + terminator + newline;

        return text.Substring(0, insertPos) + insertion + text.Substring(insertPos);
    }

    /// <summary>Mirror of <see cref="InsertAfter"/>: inserts newSegmentText plus terminator (plus a
    /// matching newline, detected from what precedes the given segment) immediately before it.</summary>
    public static string InsertBefore(string text, SegmentSource source, char terminator, string newSegmentText)
    {
        ValidateSource(text, source);
        if (newSegmentText == null)
            throw new ArgumentException("newSegmentText must not be null", nameof(newSegmentText));

        var newline = terminator == '\n' ? "" : NewlineBefore(text, source.StartOffset);
        var insertion = newSegmentText + terminator + newline;

        return text.Substring(0, source.StartOffset) + insertion + text.Substring(source.StartOffset);
    }

    private static void ValidateSource(string text, SegmentSource source)
    {
        if (text == null)
            throw new ArgumentException("text must not be null", nameof(text));
        if (source == null)
            throw new ArgumentException("source must not be null", nameof(source));
        if (source.StartOffset < 0 || source.Length < 0 || source.StartOffset + source.Length > text.Length)
            throw new ArgumentException("source is out of range for text", nameof(source));
    }

    /// <summary>Finds the index of the terminator that closes <paramref name="source"/>. Normally this is
    /// exactly at EndOffset (RawText already excludes surrounding whitespace), but this scans forward in
    /// case any whitespace was trimmed between the segment's content and its terminator.</summary>
    private static int FindTerminator(string text, SegmentSource source, char terminator)
    {
        var end = source.EndOffset;
        if (end < text.Length && text[end] == terminator)
            return end;

        var found = text.IndexOf(terminator, end);
        if (found < 0)
            throw new ArgumentException("Could not find the segment's terminator in text", nameof(terminator));
        return found;
    }

    private static int NewlineLengthAt(string text, int pos)
    {
        if (pos + 1 < text.Length && text[pos] == '\r' && text[pos + 1] == '\n')
            return 2;
        if (pos < text.Length && text[pos] == '\n')
            return 1;
        return 0;
    }

    private static string NewlineAt(string text, int pos)
    {
        var length = NewlineLengthAt(text, pos);
        return length == 0 ? "" : text.Substring(pos, length);
    }

    private static string NewlineBefore(string text, int pos)
    {
        if (pos >= 2 && text[pos - 2] == '\r' && text[pos - 1] == '\n')
            return "\r\n";
        if (pos >= 1 && text[pos - 1] == '\n')
            return "\n";
        return "";
    }
}
