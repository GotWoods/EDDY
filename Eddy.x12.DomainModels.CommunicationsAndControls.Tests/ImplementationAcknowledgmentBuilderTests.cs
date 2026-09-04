using System;
using Eddy.x12;
using Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments;
using Xunit;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Tests;

public class ImplementationAcknowledgmentBuilderTests
{
    private static readonly ImplementationAcknowledgmentBuilder Builder = new();

    [Fact]
    public void FiveTenInputWithError_ProducesIk3Ik4Ik5()
    {
        var text5010 = SampleData.As5010(SampleData.With204N101Blanked());
        var input = x12Document.Parse(text5010, new x12ParseOptions { Lenient = true });

        var outputText = Builder.Build999Text(input);

        var ik3 = TestHelpers.SingleSegmentOf(outputText, "IK3");
        var ik3Fields = ik3.Split('*');
        Assert.Equal("N1", ik3Fields[1]);
        Assert.Equal("7", ik3Fields[2]);
        Assert.Equal("8", ik3Fields[4]);

        Assert.Equal("IK4*1**1", TestHelpers.SingleSegmentOf(outputText, "IK4"));
        Assert.Equal("IK5*E*5", TestHelpers.SingleSegmentOf(outputText, "IK5")); // 5 = one or more segments in error
        Assert.Equal("AK9*E*1*1*1", TestHelpers.SingleSegmentOf(outputText, "AK9"));
    }

    // Eddy.x12.Mapping.Map only recognizes a property as a composite when its declared type's *immediate* base
    // class is EdiX12Component (see Map.MapObject/ItemToString). IK4's PositionInSegment (C030) was introduced
    // fresh in the v5010 model set several versioned subclasses below EdiX12Component
    // (v5010 -> v4060 -> ... -> v4020 -> EdiX12Component), so that check never recognizes it, and re-parsing a
    // line where it carries a value throws inside the (out-of-scope) Eddy.x12 parser. The scenario above proves
    // Build999Text writes IK4 correctly (via an internal ToString() override -- see Ik4PositionInSegment); this
    // one proves a 999 round-trips cleanly using a segment-identity error (IK3 only, no IK4 value), which the
    // parser bug does not affect.
    [Fact]
    public void FiveTenInputWithUnknownSegment_ProducesIk3_AndReparsesCleanly()
    {
        var text5010 = SampleData.As5010(SampleData.With204UnknownSegment());
        var input = x12Document.Parse(text5010, new x12ParseOptions { Lenient = true });

        var outputText = Builder.Build999Text(input);

        var ik3 = TestHelpers.SingleSegmentOf(outputText, "IK3");
        var ik3Fields = ik3.Split('*');
        Assert.Equal("ZZZ", ik3Fields[1]);
        Assert.Equal("1", ik3Fields[4]);
        Assert.Empty(TestHelpers.SegmentsOf(outputText, "IK4"));
        Assert.Equal("IK5*R*5", TestHelpers.SingleSegmentOf(outputText, "IK5"));

        var reparsed = x12Document.Parse(outputText);
        Assert.Empty(reparsed.ValidationErrors);

        var section = reparsed.Interchanges.Single().FunctionalGroups.Single().Sections.Single();
        Assert.Equal("999", section.SectionType);
        Assert.Equal(section.Segments.Count + 2, section.TransactionSetTrailer.NumberOfIncludedSegments);
    }

    [Fact]
    public void CleanFiveTenInput_IsAcceptedWithNoErrors()
    {
        var input = x12Document.Parse(SampleData.As5010(SampleData.LoadClean204()));
        var outputText = Builder.Build999Text(input);

        Assert.Equal("IK5*A", TestHelpers.SingleSegmentOf(outputText, "IK5"));
        Assert.Equal("AK9*A*1*1*1", TestHelpers.SingleSegmentOf(outputText, "AK9"));
        Assert.Empty(TestHelpers.SegmentsOf(outputText, "IK3"));

        var reparsed = x12Document.Parse(outputText);
        Assert.Empty(reparsed.ValidationErrors);
    }

    [Fact]
    public void FourZeroTenInput_Throws()
    {
        var input = x12Document.Parse(SampleData.LoadClean204());
        Assert.Throws<ArgumentException>(() => Builder.Build999(input));
    }

    [Fact]
    public void Build999_ThrowsOnNullInput()
    {
        Assert.Throws<ArgumentNullException>(() => Builder.Build999(null));
    }
}
