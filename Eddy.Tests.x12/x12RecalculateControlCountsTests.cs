using System.Linq;
using Eddy.Core;
using Eddy.x12.Models;

namespace Eddy.x12.Tests;

public class x12RecalculateControlCountsTests
{
    static x12RecalculateControlCountsTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    /// <summary>A single interchange whose SE/GE/IEA counts are all wrong (999) but whose control
    /// numbers all match their headers, so recalculation should touch exactly one field per trailer.</summary>
    private static string BuildDataWithWrongCounts()
    {
        var body = string.Concat(x12TestFixtures.GoodBody.Select(l => l.Replace("~", "~\n")));
        return x12TestFixtures.Isa("000000001") +
               x12TestFixtures.Gs("2100") +
               x12TestFixtures.St("0001") +
               body +
               x12TestFixtures.Se(999, "0001") +
               x12TestFixtures.Ge(999, "2100") +
               x12TestFixtures.Iea(999, "000000001");
    }

    [Fact]
    public void FixesWrongSeGeAndIeaCountsAndReportsThreeChanges()
    {
        var data = BuildDataWithWrongCounts();
        var originalDoc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });
        var seSource = originalDoc.Sections[0].TransactionSetTrailer.Source;
        var geSource = originalDoc.Interchanges[0].FunctionalGroups[0].Trailer.Source;
        var ieaSource = originalDoc.Interchanges[0].Trailer.Source;

        var result = x12Document.RecalculateControlCounts(data);

        Assert.Equal(3, result.Changes.Count);

        var se = Assert.Single(result.Changes, c => c.Trailer == "SE");
        Assert.Equal("NumberOfIncludedSegments", se.Field);
        Assert.Equal("999", se.OldValue);
        Assert.Equal((x12TestFixtures.GoodBody.Length + 2).ToString(), se.NewValue);
        Assert.Equal(seSource.LineNumber, se.LineNumber);

        var ge = Assert.Single(result.Changes, c => c.Trailer == "GE");
        Assert.Equal("NumberOfTransactionSetsIncluded", ge.Field);
        Assert.Equal("999", ge.OldValue);
        Assert.Equal("1", ge.NewValue);
        Assert.Equal(geSource.LineNumber, ge.LineNumber);

        var iea = Assert.Single(result.Changes, c => c.Trailer == "IEA");
        Assert.Equal("NumberOfIncludedFunctionalGroups", iea.Field);
        Assert.Equal("999", iea.OldValue);
        Assert.Equal("1", iea.NewValue);
        Assert.Equal(ieaSource.LineNumber, iea.LineNumber);

        //everything before the SE trailer (ISA/GS/ST/body) is untouched, byte for byte
        Assert.Equal(data.Substring(0, seSource.StartOffset), result.Text.Substring(0, seSource.StartOffset));

        //the corrected text re-parses with no validation errors at all
        var reparsed = x12Document.Parse(result.Text);
        Assert.True(reparsed.IsValid, reparsed.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal(x12TestFixtures.GoodBody.Length + 2, reparsed.Sections[0].TransactionSetTrailer.NumberOfIncludedSegments);
        Assert.Equal(1, reparsed.Interchanges[0].FunctionalGroups[0].Trailer.NumberOfTransactionSetsIncluded);
        Assert.Equal(1, reparsed.Interchanges[0].Trailer.NumberOfIncludedFunctionalGroups);
    }

    [Fact]
    public void ReturnsOriginalTextUnchangedWhenAllCountsAreCorrect()
    {
        var data = x12TestFixtures.SingleValidInterchange();

        var result = x12Document.RecalculateControlCounts(data);

        Assert.Empty(result.Changes);
        Assert.Equal(data, result.Text);
    }

    [Fact]
    public void FixesWrongControlNumbersToo()
    {
        var body = string.Concat(x12TestFixtures.GoodBody.Select(l => l.Replace("~", "~\n")));
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   body +
                   x12TestFixtures.Se(x12TestFixtures.GoodBody.Length + 2, "9999") + //wrong control number
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");

        var result = x12Document.RecalculateControlCounts(data);

        var change = Assert.Single(result.Changes);
        Assert.Equal("SE", change.Trailer);
        Assert.Equal("TransactionSetControlNumber", change.Field);
        Assert.Equal("9999", change.OldValue);
        Assert.Equal("0001", change.NewValue);

        var reparsed = x12Document.Parse(result.Text);
        Assert.True(reparsed.IsValid, reparsed.ValidationErrors.FirstOrDefault()?.ToString());
    }

    [Fact]
    public void WorksWhenTerminatorIsABareNewline()
    {
        var body = string.Concat(x12TestFixtures.GoodBody.Select(l => l.Replace("~", "\n")));
        var data = x12TestFixtures.Isa("000000001", "\n") +
                   x12TestFixtures.Gs("2100", "\n") +
                   x12TestFixtures.St("0001", "\n") +
                   body +
                   x12TestFixtures.Se(999, "0001", "\n") +
                   x12TestFixtures.Ge(1, "2100", "\n") +
                   x12TestFixtures.Iea(1, "000000001", "\n");

        var result = x12Document.RecalculateControlCounts(data);

        var change = Assert.Single(result.Changes);
        Assert.Equal("SE", change.Trailer);
        Assert.Equal("NumberOfIncludedSegments", change.Field);

        var reparsed = x12Document.Parse(result.Text, new x12ParseOptions { Lenient = true });
        Assert.True(reparsed.IsValid, reparsed.ValidationErrors.FirstOrDefault()?.ToString());
    }
}
