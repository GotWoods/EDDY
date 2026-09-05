using System.Linq;
using Eddy.Core;

namespace Eddy.x12.Tests;

public class x12DocumentSourceTests
{
    static x12DocumentSourceTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    [Fact]
    public void EverySegmentHasSourceMatchingTheOriginalText()
    {
        var data = x12TestFixtures.SingleValidInterchange();
        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());

        AssertSource(data, doc.InterchangeControlHeader);
        AssertSource(data, doc.Interchanges[0].FunctionalGroups[0].Header);
        AssertSource(data, doc.Sections[0].TransactionSetHeader);
        AssertSource(data, doc.Sections[0].TransactionSetTrailer);
        AssertSource(data, doc.Interchanges[0].FunctionalGroups[0].Trailer);
        AssertSource(data, doc.Interchanges[0].Trailer);

        foreach (var segment in doc.Sections[0].Segments)
            AssertSource(data, segment);
    }

    [Fact]
    public void SegmentLevelValidationResultsCarrySegmentCodeAndSource()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   "B2**TOOLONGSCAC**9999955559**PP~\n" +
                   x12TestFixtures.Se(3, "0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data);

        Assert.False(doc.IsValid);
        var result = Assert.Single(doc.ValidationErrors);
        Assert.Equal("B2", result.SegmentCode);
        Assert.NotNull(result.Source);
        Assert.Equal(4, result.Source.LineNumber);
        Assert.Equal(4, result.LineNumber);

        var actual = data.Substring(result.Source.StartOffset, result.Source.Length);
        Assert.Equal(result.Source.RawText, actual);
        Assert.StartsWith("B2*", actual);
    }

    [Fact]
    public void StructuralValidationResultsCarrySegmentCodeAndSource()
    {
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.Section("0001") +
                   x12TestFixtures.Ge(1, "9999") + // wrong control number
                   x12TestFixtures.Iea(1, "000000001");

        var doc = x12Document.Parse(data);

        Assert.False(doc.IsValid);
        var result = Assert.Single(doc.ValidationErrors);
        Assert.Equal("GE", result.SegmentCode);
        Assert.NotNull(result.Source);
        Assert.StartsWith("GE*", result.Source.RawText);
    }

    private static void AssertSource(string data, ISourceTracked segment)
    {
        Assert.NotNull(segment);
        var source = segment.Source;
        Assert.NotNull(source);
        Assert.True(source.LineNumber > 0);
        var actual = data.Substring(source.StartOffset, source.Length);
        Assert.Equal(source.RawText, actual);
    }
}
