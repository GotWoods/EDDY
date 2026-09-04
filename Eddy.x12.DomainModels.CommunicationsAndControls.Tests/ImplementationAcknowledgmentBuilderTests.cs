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

    // Map now recognises composites anywhere in the EdiX12Component inheritance chain, so a 999 whose IK4
    // carries an element position must round-trip through the strict parser with the composite populated.
    [Fact]
    public void FiveTenInputWithElementError_Reparses_WithIk4CompositePopulated()
    {
        var text5010 = SampleData.As5010(SampleData.With204N101Blanked());
        var input = x12Document.Parse(text5010, new x12ParseOptions { Lenient = true });

        var outputText = Builder.Build999Text(input);
        var reparsed = x12Document.Parse(outputText);
        Assert.Empty(reparsed.ValidationErrors);

        var ik4 = reparsed.Sections.Single().Segments.OfType<Eddy.x12.Models.v5010.IK4_ImplementationDataElementNote>().Single();
        Assert.NotNull(ik4.PositionInSegment);
        Assert.Equal(1, ik4.PositionInSegment.ElementPositionInSegment);
    }

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
