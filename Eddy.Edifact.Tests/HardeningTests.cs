using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.Tests;

public class HardeningTests
{
    /// <summary>Builds a minimal, well-formed single-message interchange: UNB, UNH, one BGM body
    /// segment (no required fields, so it is always valid on its own), UNT, UNZ.</summary>
    private static string BuildInterchange(string interchangeRef, string messageRef, string version = "D:96A:UN", string messageType = "APERAK")
    {
        return
            $"UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+{interchangeRef}'\n" +
            $"UNH+{messageRef}+{messageType}:{version}'\n" +
            "BGM+16+123456+9'\n" +
            $"UNT+3+{messageRef}'\n" +
            $"UNZ+1+{interchangeRef}'\n";
    }

    [Fact]
    public void UnaWithNonDefaultCharactersIsHonoured()
    {
        //Custom UNA: component separator '|', data element separator '!', decimal mark ',',
        //release character '?', repetition separator '*', segment terminator '~'.
        var data = "UNA|!,?*~" +
                    "UNB!UNOA|1!SENDER|14!RECEIVER|14!230815|1200!REF1~" +
                    "UNH!1!APERAK|D|96A|UN~" +
                    "BGM!16!123456!9~" +
                    "UNT!3!1~" +
                    "UNZ!1!REF1~";

        var doc = EdiFactDocument.Parse(data);

        var advice = doc.ServiceStringAdvice;
        Assert.Equal('|', advice.ComponentDataElementSeparator);
        Assert.Equal('!', advice.DataElementSeparator);
        Assert.Equal(',', advice.DecimalMark);
        Assert.Equal('?', advice.ReleaseCharacter);
        Assert.Equal('*', advice.RepetitionSeparator);
        Assert.Equal('~', advice.SegmentTerminator);

        Assert.Equal("REF1", doc.InterchangeControlHeader.InterchangeControlReference);
        Assert.Single(doc.FunctionalGroups[0].Messages);
    }

    [Fact]
    public void ReleaseCharacterEscapesSeparatorInsideAValue()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "UNH+1+APERAK:D:96A:UN'\n" +
            "NAD+BY+++SMITH?+SONS'\n" +
            "UNT+3+1'\n" +
            "UNZ+1+REF1'\n";

        var doc = EdiFactDocument.Parse(data);
        var nad = Assert.IsType<NAD_NameAndAddress>(doc.FunctionalGroups[0].Messages[0].Segments[0]);
        Assert.Equal("SMITH+SONS", nad.PartyName.PartyName);

        var written = doc.ToString(new MapOptions());
        Assert.Contains("SMITH?+SONS", written);

        //round trip: what we wrote parses back to the same unescaped value
        var reparsed = EdiFactDocument.Parse(written);
        var nad2 = Assert.IsType<NAD_NameAndAddress>(reparsed.FunctionalGroups[0].Messages[0].Segments[0]);
        Assert.Equal("SMITH+SONS", nad2.PartyName.PartyName);
    }

    [Fact]
    public void VersionIsDetectedFromUnhWhenItExists()
    {
        var data = BuildInterchange("REF1", "1", "D:96A:UN");
        var doc = EdiFactDocument.Parse(data);

        var message = doc.FunctionalGroups[0].Messages[0];
        Assert.Equal("D96A", message.Version);
        Assert.Equal("APERAK", message.MessageType);
        Assert.IsType<BGM_BeginningOfMessage>(message.Segments[0]); //parsed with the real D96A model, not Unknown_Segment

        Assert.DoesNotContain(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.EdiFactUnsupportedVersion));
    }

    [Fact]
    public void VersionFallsBackWhenUnhVersionDoesNotExist()
    {
        //D96C does not exist (only D96A/D96B do) - the closest lower available version, D96B, should
        //be used instead. Models/ has D96A, D96B, D97A, D97B, ... D21A - see the final report for the
        //full list.
        var data = BuildInterchange("REF1", "1", "D:96C:UN");
        var doc = EdiFactDocument.Parse(data, new EdifactParseOptions { Lenient = true });

        var message = doc.FunctionalGroups[0].Messages[0];
        Assert.Equal("D96C", message.Version); //the *declared* version is still reported as-is
        //body segments were parsed using the resolved fallback version, not left as Unknown_Segment
        Assert.Equal("Eddy.Edifact.Models.D96B", message.Segments[0].GetType().Namespace);

        var error = Assert.Single(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.EdiFactUnsupportedVersion));
        var data0 = error.Errors.Single(e => e.ErrorCode == ErrorCodes.EdiFactUnsupportedVersion).Data;
        Assert.Equal("D96C", data0[0]);
        Assert.Equal("D96B", data0[1]); //closest lower version
    }

    [Fact]
    public void TwoMessagesInOneInterchangeShareTheImplicitFunctionalGroup()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "UNH+1+APERAK:D:96A:UN'\n" +
            "BGM+16+123456+9'\n" +
            "UNT+3+1'\n" +
            "UNH+2+APERAK:D:96A:UN'\n" +
            "BGM+16+654321+9'\n" +
            "UNT+3+2'\n" +
            "UNZ+2+REF1'\n";

        var doc = EdiFactDocument.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Single(doc.Interchanges);
        Assert.Single(doc.FunctionalGroups); //implicit group holds both messages
        Assert.Equal(2, doc.FunctionalGroups[0].Messages.Count);
        Assert.Equal("1", doc.FunctionalGroups[0].Messages[0].Header.MessageReferenceNumber);
        Assert.Equal("2", doc.FunctionalGroups[0].Messages[1].Header.MessageReferenceNumber);
    }

    [Fact]
    public void TwoInterchangesAreBothParsed()
    {
        var data = BuildInterchange("REF1", "1") + BuildInterchange("REF2", "1");

        var doc = EdiFactDocument.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal(2, doc.Interchanges.Count);
        Assert.Equal("REF1", doc.Interchanges[0].Header.InterchangeControlReference);
        Assert.Equal("REF2", doc.Interchanges[1].Header.InterchangeControlReference);
        //back-compat surface still reflects the first interchange
        Assert.Same(doc.Interchanges[0].Header, doc.InterchangeControlHeader);
    }

    [Fact]
    public void UntCountMismatchIsReportedAtTheRightLine()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" + //line 1
            "UNH+1+APERAK:D:96A:UN'\n" +                             //line 2
            "BGM+16+123456+9'\n" +                                   //line 3
            "UNT+99+1'\n" +                                          //line 4 - wrong count
            "UNZ+1+REF1'\n";                                         //line 5

        var doc = EdiFactDocument.Parse(data);

        var result = Assert.Single(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.EdiFactMessageSegmentCountMismatch));
        Assert.Equal(4, result.LineNumber);
        Assert.Equal("UNT", result.SegmentCode);
        var error = result.Errors.Single(e => e.ErrorCode == ErrorCodes.EdiFactMessageSegmentCountMismatch);
        Assert.Equal("99", error.Data[0]);
        Assert.Equal("3", error.Data[1]);
    }

    [Fact]
    public void UnknownSegmentInStrictModeThrowsNamingSegmentVersionAndLine()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" + //line 1
            "UNH+1+APERAK:D:96A:UN'\n" +                             //line 2
            "ZZZ+1+2+3'\n" +                                         //line 3 - not a real EDIFACT segment
            "UNT+3+1'\n" +
            "UNZ+1+REF1'\n";

        var ex = Assert.Throws<InvalidFileFormatException>(() => EdiFactDocument.Parse(data));
        Assert.Contains("ZZZ", ex.Message);
        Assert.Contains("D96A", ex.Message);
        Assert.Contains("3", ex.Message); //line number
    }

    [Fact]
    public void UnknownSegmentInLenientModeBecomesUnknownSegmentWithErrorAtRightLine()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "UNH+1+APERAK:D:96A:UN'\n" +                             //line 2
            "ZZZ+1+2+3'\n" +                                         //line 3
            "UNT+3+1'\n" +
            "UNZ+1+REF1'\n";

        var doc = EdiFactDocument.Parse(data, new EdifactParseOptions { Lenient = true });

        var message = doc.FunctionalGroups[0].Messages[0];
        var unknown = Assert.IsType<Unknown_Segment>(message.Segments[0]);
        Assert.Equal("ZZZ", unknown.SegmentId);
        Assert.Equal(new List<string> { "1", "2", "3" }, unknown.Elements);

        var result = Assert.Single(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.EdiFactUnknownSegment));
        Assert.Equal(3, result.LineNumber);
    }

    [Fact]
    public void OrphanSegmentOutsideAMessageIsRecorded()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" +
            "BGM+16+123456+9'\n" + //orphan - appears before any UNH
            "UNH+1+APERAK:D:96A:UN'\n" +
            "UNT+2+1'\n" +
            "UNZ+1+REF1'\n";

        var doc = EdiFactDocument.Parse(data, new EdifactParseOptions { Lenient = true });

        var interchange = doc.Interchanges[0];
        var orphan = Assert.Single(interchange.OrphanSegments);
        Assert.IsType<Unknown_Segment>(orphan);
        Assert.Equal("BGM", ((Unknown_Segment)orphan).SegmentId);

        Assert.Contains(doc.ValidationErrors, r => r.Errors.Any(e => e.ErrorCode == ErrorCodes.EdiFactSegmentOutsideMessage));
    }

    [Theory]
    [InlineData("\n")]
    [InlineData("\r\n")]
    public void SourceRawTextMatchesTheOriginalSubstring(string newline)
    {
        var lines = new[]
        {
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'",
            "UNH+1+APERAK:D:96A:UN'",
            "BGM+16+123456+9'",
            "UNT+3+1'",
            "UNZ+1+REF1'"
        };
        var data = string.Join(newline, lines) + newline;

        var doc = EdiFactDocument.Parse(data);

        void CheckSource(EdifactSegment segment)
        {
            Assert.NotNull(segment.Source);
            var src = segment.Source;
            Assert.Equal(src.RawText, data.Substring(src.StartOffset, src.Length));
        }

        CheckSource(doc.InterchangeControlHeader);
        var message = doc.FunctionalGroups[0].Messages[0];
        CheckSource(message.Header);
        CheckSource(message.Segments[0]);
        CheckSource(message.Trailer);
        CheckSource(doc.Interchanges[0].Trailer);

        //line numbers: no UNA present, so UNB is line 1 and each subsequent segment increments by 1
        Assert.Equal(1, doc.InterchangeControlHeader.Source.LineNumber);
        Assert.Equal(2, message.Header.Source.LineNumber);
        Assert.Equal(3, message.Segments[0].Source.LineNumber);
        Assert.Equal(4, message.Trailer.Source.LineNumber);
        Assert.Equal(5, doc.Interchanges[0].Trailer.Source.LineNumber);
    }

    [Fact]
    public void RoundTripParseToStringParsePreservesStructure()
    {
        var data = BuildInterchange("REF1", "1") + BuildInterchange("REF2", "2");
        var original = EdiFactDocument.Parse(data);
        Assert.True(original.IsValid, original.ValidationErrors.FirstOrDefault()?.ToString());

        var written = original.ToString(new MapOptions());
        var roundTripped = EdiFactDocument.Parse(written);

        Assert.True(roundTripped.IsValid, roundTripped.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal(original.Interchanges.Count, roundTripped.Interchanges.Count);

        for (var i = 0; i < original.Interchanges.Count; i++)
        {
            var o = original.Interchanges[i];
            var r = roundTripped.Interchanges[i];
            Assert.Equal(o.Header.InterchangeControlReference, r.Header.InterchangeControlReference);
            Assert.Equal(o.Trailer.InterchangeControlCount, r.Trailer.InterchangeControlCount);
            Assert.Equal(o.FunctionalGroups.Count, r.FunctionalGroups.Count);
            Assert.Equal(o.FunctionalGroups[0].Messages.Count, r.FunctionalGroups[0].Messages.Count);
            Assert.Equal(o.FunctionalGroups[0].Messages[0].Segments.Count, r.FunctionalGroups[0].Messages[0].Segments.Count);
            Assert.Equal(o.FunctionalGroups[0].Messages[0].Version, r.FunctionalGroups[0].Messages[0].Version);
        }
    }
}
