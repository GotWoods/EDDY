using Eddy.Edifact.Mapping;

namespace Eddy.Edifact.Tests;

public class RecalculateControlCountsTests
{
    /// <summary>UNB, an explicit UNG group (one message), UNT/UNE/UNZ all wrong.</summary>
    private static string BuildDataWithWrongCounts()
    {
        return
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +   //line 1
            "UNG+APERAK+SENDER:14+RECEIVER:14+230815:1200+GREF+UN+D:96A'\n" + //line 2
            "UNH+1+APERAK:D:96A:UN'\n" +                              //line 3
            "BGM+16+123456+9'\n" +                                    //line 4
            "UNT+99+1'\n" +                                           //line 5 - wrong count (correct 3)
            "UNE+99+GREF'\n" +                                        //line 6 - wrong count (correct 1)
            "UNZ+99+REF1'\n";                                         //line 7 - wrong count (correct 1)
    }

    [Fact]
    public void FixesWrongUntUneAndUnzCountsAndReportsThreeChanges()
    {
        var data = BuildDataWithWrongCounts();
        var originalDoc = EdiFactDocument.Parse(data, new EdifactParseOptions { Lenient = true });
        var message = originalDoc.FunctionalGroups[0].Messages[0];
        var untSource = message.Trailer.Source;
        var uneSource = originalDoc.FunctionalGroups[0].Trailer.Source;
        var unzSource = originalDoc.Interchanges[0].Trailer.Source;

        var result = EdiFactDocument.RecalculateControlCounts(data);

        Assert.Equal(3, result.Changes.Count);

        var unt = Assert.Single(result.Changes, c => c.Trailer == "UNT");
        Assert.Equal("NumberOfSegmentsInMessage", unt.Field);
        Assert.Equal("99", unt.OldValue);
        Assert.Equal("3", unt.NewValue);
        Assert.Equal(untSource.LineNumber, unt.LineNumber);

        var une = Assert.Single(result.Changes, c => c.Trailer == "UNE");
        Assert.Equal("NumberOfMessages", une.Field);
        Assert.Equal("99", une.OldValue);
        Assert.Equal("1", une.NewValue);
        Assert.Equal(uneSource.LineNumber, une.LineNumber);

        var unz = Assert.Single(result.Changes, c => c.Trailer == "UNZ");
        Assert.Equal("InterchangeControlCount", unz.Field);
        Assert.Equal("99", unz.OldValue);
        Assert.Equal("1", unz.NewValue);
        Assert.Equal(unzSource.LineNumber, unz.LineNumber);

        //everything before the UNT trailer (UNB/UNG/UNH/BGM) is untouched, byte for byte
        Assert.Equal(data.Substring(0, untSource.StartOffset), result.Text.Substring(0, untSource.StartOffset));

        var reparsed = EdiFactDocument.Parse(result.Text);
        Assert.True(reparsed.IsValid, reparsed.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal("3", reparsed.FunctionalGroups[0].Messages[0].Trailer.NumberOfSegmentsInMessage);
        Assert.Equal("1", reparsed.FunctionalGroups[0].Trailer.NumberOfMessages);
        Assert.Equal("1", reparsed.Interchanges[0].Trailer.InterchangeControlCount);
    }

    [Fact]
    public void ReturnsOriginalTextUnchangedWhenAllCountsAreCorrect()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "UNH+1+APERAK:D:96A:UN'\n" +
            "BGM+16+123456+9'\n" +
            "UNT+3+1'\n" +
            "UNZ+1+REF1'\n";

        var result = EdiFactDocument.RecalculateControlCounts(data);

        Assert.Empty(result.Changes);
        Assert.Equal(data, result.Text);
    }

    [Fact]
    public void UntAndUnzRecalculationHandlesTheReleaseCharacterInValues()
    {
        //Both reference numbers contain a '+' - the element separator - so the raw text must escape it
        //with the release character ('?'). Recalculation rewrites both trailers (their counts are wrong)
        //and must re-escape the reference values correctly when it does.
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF?+1'\n" +
            "UNH+MSG?+1+APERAK:D:96A:UN'\n" +
            "BGM+16+123456+9'\n" +
            "UNT+99+MSG?+1'\n" +
            "UNZ+99+REF?+1'\n";

        var result = EdiFactDocument.RecalculateControlCounts(data);

        Assert.Equal(2, result.Changes.Count);
        var unt = Assert.Single(result.Changes, c => c.Trailer == "UNT");
        Assert.Equal("NumberOfSegmentsInMessage", unt.Field);
        Assert.Equal("99", unt.OldValue);
        Assert.Equal("3", unt.NewValue);

        var unz = Assert.Single(result.Changes, c => c.Trailer == "UNZ");
        Assert.Equal("InterchangeControlCount", unz.Field);
        Assert.Equal("99", unz.OldValue);
        Assert.Equal("1", unz.NewValue);

        //the release character survives the rewrite
        Assert.Contains("UNT+3+MSG?+1'", result.Text);
        Assert.Contains("UNZ+1+REF?+1'", result.Text);

        var reparsed = EdiFactDocument.Parse(result.Text);
        Assert.True(reparsed.IsValid, reparsed.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal("MSG+1", reparsed.FunctionalGroups[0].Messages[0].Header.MessageReferenceNumber);
        Assert.Equal("MSG+1", reparsed.FunctionalGroups[0].Messages[0].Trailer.MessageReferenceNumber);
        Assert.Equal("REF+1", reparsed.Interchanges[0].Header.InterchangeControlReference);
        Assert.Equal("REF+1", reparsed.Interchanges[0].Trailer.InterchangeControlReference);
    }

    [Fact]
    public void UnknownSegmentRoundTripsThroughSegmentToString()
    {
        var segment = new Unknown_Segment
        {
            SegmentId = "ZZZ",
            Elements = new System.Collections.Generic.List<string> { "1", "2", "" }, //trailing empty trimmed
            Version = "D96A"
        };

        var options = MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote;
        var text = Map.SegmentToString(segment, options);
        Assert.Equal("ZZZ+1+2'", text);

        var withoutTerminator = Map.SegmentToString(segment, options, false);
        Assert.Equal("ZZZ+1+2", withoutTerminator);

        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "UNH+1+APERAK:D:96A:UN'\n" +
            text + "\n" +
            "UNT+3+1'\n" +
            "UNZ+1+REF1'\n";
        var doc = EdiFactDocument.Parse(data, new EdifactParseOptions { Lenient = true });
        var reparsed = Assert.IsType<Unknown_Segment>(doc.FunctionalGroups[0].Messages[0].Segments[0]);
        Assert.Equal("ZZZ", reparsed.SegmentId);
        Assert.Equal(new[] { "1", "2" }, reparsed.Elements);
    }
}
