using System;
using System.Collections.Generic;
using Eddy.Core;

namespace Eddy.Tests;

/// <summary>
/// SourceEdit is pure text splicing keyed off a SegmentSource - it does not care what EDI dialect produced
/// that span. These tests build small hand-rolled "files" (three segments, one of the three newline
/// conventions the real parsers support) and compute the SegmentSource for the middle segment by hand, the
/// same way a real parser would have recorded it.
/// </summary>
public class SourceEditTests
{
    public static IEnumerable<object[]> Styles => new[]
    {
        new object[] { "~\n", '~' }, // terminator '~', with a stylistic newline after it
        new object[] { "~", '~' },   // terminator '~', no newline at all
        new object[] { "\n", '\n' }  // terminator IS the newline
    };

    private static string BuildFile(string newline)
    {
        return $"AAA*1{newline}BBB*2{newline}CCC*3{newline}";
    }

    private static SegmentSource SourceFor(string text, string content, int lineNumber = 2)
    {
        var start = text.IndexOf(content, StringComparison.Ordinal);
        Assert.True(start >= 0, $"'{content}' not found in '{text}'");
        return new SegmentSource(lineNumber, start, content.Length, content);
    }

    [Theory]
    [MemberData(nameof(Styles))]
    public void ReplaceSwapsOnlyTheMiddleSegment(string newline, char _)
    {
        var data = BuildFile(newline);
        var source = SourceFor(data, "BBB*2");

        var result = SourceEdit.Replace(data, source, "BBB*99*XX");

        var expected = $"AAA*1{newline}BBB*99*XX{newline}CCC*3{newline}";
        Assert.Equal(expected, result);
        //prefix/suffix around the replaced span are byte-for-byte identical
        Assert.StartsWith($"AAA*1{newline}", result);
        Assert.EndsWith($"{newline}CCC*3{newline}", result);
    }

    [Fact]
    public void ReplaceDoesNotTouchTheTerminator()
    {
        var data = BuildFile("~\n");
        var source = SourceFor(data, "BBB*2");

        var result = SourceEdit.Replace(data, source, "BBB*99");

        Assert.Equal("AAA*1~\nBBB*99~\nCCC*3~\n", result);
    }

    [Theory]
    [MemberData(nameof(Styles))]
    public void RemovePreservesTheSurroundingLayoutConvention(string newline, char terminator)
    {
        var data = BuildFile(newline);
        var source = SourceFor(data, "BBB*2");

        var result = SourceEdit.Remove(data, source, terminator);

        Assert.Equal($"AAA*1{newline}CCC*3{newline}", result);
    }

    [Fact]
    public void RemoveFirstSegmentLeavesRemainderIntact()
    {
        var data = BuildFile("~\n");
        var source = SourceFor(data, "AAA*1", lineNumber: 1);

        var result = SourceEdit.Remove(data, source, '~');

        Assert.Equal("BBB*2~\nCCC*3~\n", result);
    }

    [Theory]
    [MemberData(nameof(Styles))]
    public void InsertAfterMatchesTheFilesNewlineConvention(string newline, char terminator)
    {
        var data = BuildFile(newline);
        var source = SourceFor(data, "BBB*2");

        var result = SourceEdit.InsertAfter(data, source, terminator, "DDD*4");

        Assert.Equal($"AAA*1{newline}BBB*2{newline}DDD*4{newline}CCC*3{newline}", result);
    }

    [Theory]
    [MemberData(nameof(Styles))]
    public void InsertBeforeMatchesTheFilesNewlineConvention(string newline, char terminator)
    {
        var data = BuildFile(newline);
        var source = SourceFor(data, "BBB*2");

        var result = SourceEdit.InsertBefore(data, source, terminator, "DDD*4");

        Assert.Equal($"AAA*1{newline}DDD*4{newline}BBB*2{newline}CCC*3{newline}", result);
    }

    [Fact]
    public void InsertAfterTheLastSegmentAppendsCleanly()
    {
        var data = BuildFile("~\n");
        var source = SourceFor(data, "CCC*3", lineNumber: 3);

        var result = SourceEdit.InsertAfter(data, source, '~', "DDD*4");

        Assert.Equal("AAA*1~\nBBB*2~\nCCC*3~\nDDD*4~\n", result);
    }

    [Fact]
    public void ReplaceThrowsOnNullText()
    {
        var source = new SegmentSource(1, 0, 3, "AAA");
        Assert.Throws<ArgumentException>(() => SourceEdit.Replace(null, source, "BBB"));
    }

    [Fact]
    public void ReplaceThrowsOnNullSource()
    {
        Assert.Throws<ArgumentException>(() => SourceEdit.Replace("AAA*1~", null, "BBB"));
    }

    [Fact]
    public void ReplaceThrowsWhenSourceIsOutOfRange()
    {
        var data = "AAA*1~";
        var source = new SegmentSource(1, 0, 999, "AAA*1");
        Assert.Throws<ArgumentException>(() => SourceEdit.Replace(data, source, "BBB"));
    }

    [Fact]
    public void ReplaceThrowsOnNegativeStartOffset()
    {
        var data = "AAA*1~";
        var source = new SegmentSource(1, -1, 3, "AAA");
        Assert.Throws<ArgumentException>(() => SourceEdit.Replace(data, source, "BBB"));
    }

    [Fact]
    public void RemoveThrowsWhenTerminatorIsMissing()
    {
        var data = "AAA*1"; //no terminator anywhere after the segment
        var source = new SegmentSource(1, 0, 5, "AAA*1");
        Assert.Throws<ArgumentException>(() => SourceEdit.Remove(data, source, '~'));
    }
}
