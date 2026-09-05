using System.Linq;
using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.x12.Models;
using REF_ReferenceIdentification = Eddy.x12.Models.v4010.REF_ReferenceIdentification;

namespace Eddy.x12.Tests;

public class x12DocumentLenientTests
{
    static x12DocumentLenientTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    [Fact]
    public void BadIsaRecordsErrorAndParsesNothingElseWhenLenient()
    {
        var data = "ISA*NOTVALID~\n" + x12TestFixtures.Gs("2100");

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        Assert.False(doc.IsValid);
        Assert.Single(doc.ValidationErrors);
        Assert.Equal(ErrorCodes.InvalidInterchangeHeader, doc.ValidationErrors[0].Errors[0].ErrorCode);
        Assert.Empty(doc.Interchanges);
    }

    [Fact]
    public void BadIsaThrowsWhenStrict()
    {
        var data = "ISA*NOTVALID~\n" + x12TestFixtures.Gs("2100");

        Assert.Throws<InvalidFileFormatException>(() => x12Document.Parse(data));
    }

    [Fact]
    public void MissingGsRecordsErrorAndContinuesWithNullHeaderWhenLenient()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        Assert.Contains(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.MissingFunctionalGroupHeader));
        Assert.Single(doc.Interchanges);
        Assert.Single(doc.Interchanges[0].FunctionalGroups);
        Assert.Null(doc.Interchanges[0].FunctionalGroups[0].Header);
        Assert.Single(doc.Interchanges[0].FunctionalGroups[0].Sections);
    }

    [Fact]
    public void MissingGsThrowsWithOriginalMessageWhenStrict()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Iea(1, "000000001");

        var ex = Assert.Throws<InvalidFileFormatException>(() => x12Document.Parse(data));
        Assert.Equal("A GS record was expected after the ISA record but it was not found", ex.Message);
    }

    [Fact]
    public void UnknownSegmentThrowsInStrictModeNamingCodeVersionAndLine()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   "ZZZ9*1~\n" +
                   x12TestFixtures.Se(3, "0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var ex = Assert.Throws<InvalidFileFormatException>(() => x12Document.Parse(data));
        Assert.Contains("ZZZ9", ex.Message);
        Assert.Contains("4010", ex.Message);
        Assert.Contains("4", ex.Message); // line number: ISA=1, GS=2, ST=3, ZZZ9=4
    }

    [Fact]
    public void UnknownSegmentBecomesUnknownSegmentModelWhenLenient()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   "ZZZ9*1*2~\n" +
                   x12TestFixtures.Se(3, "0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        var section = doc.Sections.Single();
        var unknown = Assert.Single(section.Segments.OfType<Unknown_Segment>());
        Assert.Equal("ZZZ9", unknown.SegmentId);
        Assert.Equal(new[] { "1", "2" }, unknown.Elements);
        Assert.NotNull(unknown.Source);

        var errorResult = doc.ValidationErrors.Single(r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.UnknownSegment));
        Assert.Equal(4, errorResult.LineNumber);
        Assert.Equal("ZZZ9", errorResult.SegmentCode);
        Assert.Equal(unknown.Source, errorResult.Source);
    }

    [Fact]
    public void OrphanSegmentOutsideTransactionSetGoesToNearestContainerWhenLenient()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   "REF*XX*ORPHAN~\n" +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        var group = doc.Interchanges[0].FunctionalGroups[0];
        var orphan = Assert.Single(group.OrphanSegments);
        Assert.IsType<REF_ReferenceIdentification>(orphan);

        var error = doc.ValidationErrors.Single(r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.SegmentOutsideTransactionSet));
        Assert.Equal("REF", error.SegmentCode);
    }

    [Fact]
    public void OrphanSegmentOutsideTransactionSetThrowsWhenStrict()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   "REF*XX*ORPHAN~\n" +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        Assert.Throws<InvalidFileFormatException>(() => x12Document.Parse(data));
    }

    [Fact]
    public void MissingSeGeIeaAtEndOfInputRecordsMissingTrailerWhenLenient()
    {
        // No SE, GE or IEA at all.
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   x12TestFixtures.GoodBody[0];

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        var missing = doc.ValidationErrors
            .SelectMany(r => r.Errors.Select(e => new { r, e }))
            .Where(x => x.e.ErrorCode == ErrorCodes.MissingTrailer)
            .Select(x => x.e.Data[0])
            .ToList();

        Assert.Contains("SE", missing);
        Assert.Contains("GE", missing);
        Assert.Contains("IEA", missing);

        Assert.Null(doc.Sections.Single().TransactionSetTrailer);
        Assert.Null(doc.Interchanges[0].FunctionalGroups[0].Trailer);
        Assert.Null(doc.Interchanges[0].Trailer);
    }

    [Fact]
    public void MissingIeaOnlyIsSilentInStrictMode()
    {
        // Matches the historical parser: an IEA-less file was, and remains, a valid strict parse.
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Ge(1, "2100");

        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Null(doc.Interchanges[0].Trailer);
    }

    [Fact]
    public void UnexpectedTrailerIsRecordedWhenLenient()
    {
        // The group is already closed by its own GE; the second GE has no matching header at all.
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        Assert.Contains(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.UnexpectedTrailer));
    }

    [Fact]
    public void LeadingBomAndWhitespaceAreSkippedWhenLenient()
    {
        var data = "\uFEFF   \r\n" + x12TestFixtures.SingleValidInterchange();

        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Single(doc.Interchanges);
        Assert.Equal(1, doc.Interchanges[0].Header.InterchangeControlNumber);
    }
}
