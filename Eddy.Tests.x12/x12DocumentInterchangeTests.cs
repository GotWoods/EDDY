using System.Linq;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12.Tests;

public class x12DocumentInterchangeTests
{
    static x12DocumentInterchangeTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    [Fact]
    public void SingleInterchangeParsesCleanly()
    {
        var data = x12TestFixtures.SingleValidInterchange();
        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Single(doc.Interchanges);
        Assert.Single(doc.Interchanges[0].FunctionalGroups);
        Assert.Single(doc.Interchanges[0].FunctionalGroups[0].Sections);
        Assert.Single(doc.Sections);
        Assert.Same(doc.Interchanges[0].Header, doc.InterchangeControlHeader);
        Assert.Same(doc.Interchanges[0].FunctionalGroups[0].Header, doc.GsHeader);
    }

    [Fact]
    public void MultipleGroupsWithinOneInterchange()
    {
        var data =
            x12TestFixtures.Isa("000000001") +
            x12TestFixtures.Gs("2100") +
            x12TestFixtures.Section("0001") +
            x12TestFixtures.Ge(1, "2100") +
            x12TestFixtures.Gs("2200") +
            x12TestFixtures.Section("0002") +
            x12TestFixtures.Ge(1, "2200") +
            x12TestFixtures.Iea(2, "000000001");

        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Single(doc.Interchanges);
        Assert.Equal(2, doc.Interchanges[0].FunctionalGroups.Count);
        Assert.Equal("2100", doc.Interchanges[0].FunctionalGroups[0].Header.GroupControlNumber);
        Assert.Equal("2200", doc.Interchanges[0].FunctionalGroups[1].Header.GroupControlNumber);
        Assert.Equal(2, doc.Sections.Count);
    }

    [Fact]
    public void MultipleInterchangesBackToBack()
    {
        var data =
            x12TestFixtures.SingleValidInterchange("000000001", "2100", "0001") +
            x12TestFixtures.SingleValidInterchange("000000002", "3100", "0001");

        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.Equal(2, doc.Interchanges.Count);
        Assert.Equal(1, doc.Interchanges[0].Header.InterchangeControlNumber);
        Assert.Equal(2, doc.Interchanges[1].Header.InterchangeControlNumber);
        Assert.Equal(2, doc.Sections.Count);

        // Legacy properties mirror the FIRST interchange/group.
        Assert.Same(doc.Interchanges[0].Header, doc.InterchangeControlHeader);
        Assert.Same(doc.Interchanges[0].FunctionalGroups[0].Header, doc.GsHeader);
    }

    [Fact]
    public void WrongGroupControlNumberIsCaughtPerGroupNotJustTheFirst()
    {
        // The second group's GE references the wrong control number; validation must compare against
        // *that* group's header, not always the first group's (a bug in the pre-Interchanges parser).
        var data =
            x12TestFixtures.Isa("000000001") +
            x12TestFixtures.Gs("2100") +
            x12TestFixtures.Section("0001") +
            x12TestFixtures.Ge(1, "2100") +
            x12TestFixtures.Gs("2200") +
            x12TestFixtures.Section("0002") +
            x12TestFixtures.Ge(1, "9999") + // wrong: should be 2200
            x12TestFixtures.Iea(2, "000000001");

        var doc = x12Document.Parse(data);

        Assert.False(doc.IsValid);
        Assert.Single(doc.ValidationErrors);
        Assert.Equal(Eddy.Core.Validation.ErrorCodes.FunctionalGroupControlNumberMismatch, doc.ValidationErrors[0].Errors[0].ErrorCode);
    }

    [Fact]
    public void InterchangeGroupCountAndControlNumberAreValidated()
    {
        var data =
            x12TestFixtures.Isa("000000001") +
            x12TestFixtures.Gs("2100") +
            x12TestFixtures.Section("0001") +
            x12TestFixtures.Ge(1, "2100") +
            x12TestFixtures.Iea(9, "000000009"); // wrong count and control number

        var doc = x12Document.Parse(data);

        Assert.False(doc.IsValid);
        var errorCodes = doc.ValidationErrors.SelectMany(e => e.Errors).Select(e => e.ErrorCode).ToList();
        Assert.Contains(Eddy.Core.Validation.ErrorCodes.InterchangeGroupCountMismatch, errorCodes);
        Assert.Contains(Eddy.Core.Validation.ErrorCodes.InterchangeControlNumberMismatch, errorCodes);
    }

    [Fact]
    public void IeaAndGeNeverLandInSectionSegments()
    {
        var data = x12TestFixtures.SingleValidInterchange();
        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        var section = doc.Sections.Single();
        Assert.Equal(x12TestFixtures.GoodBody.Length, section.Segments.Count);
        Assert.DoesNotContain(section.Segments, s => s is GenericInterchangeControlTrailer);
        Assert.DoesNotContain(section.Segments, s => s is GenericFunctionalGroupTrailer);
        Assert.NotNull(doc.Interchanges[0].Trailer);
        Assert.NotNull(doc.Interchanges[0].FunctionalGroups[0].Trailer);
    }

    [Fact]
    public void TildeTerminatorFollowedByNewlineAfterIsaIsHandled()
    {
        // Regression test: x12Document.Parse used to check lines[1].StartsWith("GS") without trimming,
        // so a "~" terminator immediately followed by a newline (the normal, expected shape) made it
        // think the GS record was missing.
        var data = x12TestFixtures.Isa("000000001", "~\n") +
                   x12TestFixtures.Gs("2100", "~\n") +
                   x12TestFixtures.Section("0001", "~\n") +
                   x12TestFixtures.Ge(1, "2100", "~\n") +
                   x12TestFixtures.Iea(1, "000000001", "~\n");

        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());
        Assert.NotNull(doc.GsHeader);
    }

    [Fact]
    public void CrlfInputProducesCorrectOffsetsAndRawText()
    {
        var data = x12TestFixtures.SingleValidInterchange(newline: "~\r\n");
        var doc = x12Document.Parse(data);

        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());

        Assert.NotNull(doc.InterchangeControlHeader.Source);
        AssertSourceMatches(data, doc.InterchangeControlHeader.Source);

        foreach (var segment in doc.Sections.Single().Segments)
            AssertSourceMatches(data, ((Eddy.Core.ISourceTracked)segment).Source);
    }

    [Fact]
    public void RoundTripOfTwoInterchangesReparsesToSameStructure()
    {
        var data =
            x12TestFixtures.SingleValidInterchange("000000001", "2100", "0001") +
            x12TestFixtures.SingleValidInterchange("000000002", "3100", "0001");

        var first = x12Document.Parse(data);
        Assert.True(first.IsValid, first.ValidationErrors.FirstOrDefault()?.ToString());

        var options = MapOptionsForTesting.x12DefaultEndsWithTilde;
        var regenerated = first.ToString(options);

        var second = x12Document.Parse(regenerated);
        Assert.True(second.IsValid, second.ValidationErrors.FirstOrDefault()?.ToString());

        Assert.Equal(first.Interchanges.Count, second.Interchanges.Count);
        for (var i = 0; i < first.Interchanges.Count; i++)
        {
            Assert.Equal(first.Interchanges[i].Header.InterchangeControlNumber, second.Interchanges[i].Header.InterchangeControlNumber);
            Assert.Equal(first.Interchanges[i].FunctionalGroups.Count, second.Interchanges[i].FunctionalGroups.Count);
            for (var g = 0; g < first.Interchanges[i].FunctionalGroups.Count; g++)
            {
                Assert.Equal(first.Interchanges[i].FunctionalGroups[g].Sections.Count, second.Interchanges[i].FunctionalGroups[g].Sections.Count);
                for (var s = 0; s < first.Interchanges[i].FunctionalGroups[g].Sections.Count; s++)
                {
                    Assert.Equal(
                        first.Interchanges[i].FunctionalGroups[g].Sections[s].Segments.Count,
                        second.Interchanges[i].FunctionalGroups[g].Sections[s].Segments.Count);
                }
            }
        }
    }

    private static void AssertSourceMatches(string data, Eddy.Core.SegmentSource source)
    {
        Assert.NotNull(source);
        var actual = data.Substring(source.StartOffset, source.Length);
        Assert.Equal(source.RawText, actual);
        Assert.DoesNotContain('\r', actual);
        Assert.DoesNotContain('\n', actual);
    }
}
