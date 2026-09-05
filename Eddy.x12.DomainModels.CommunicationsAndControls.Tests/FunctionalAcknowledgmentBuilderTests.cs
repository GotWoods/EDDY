using System;
using System.Linq;
using Eddy.x12;
using Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments;
using Xunit;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.Tests;

public class FunctionalAcknowledgmentBuilderTests
{
    private static readonly FunctionalAcknowledgmentBuilder Builder = new();

    [Fact]
    public void CleanDocument_IsAcceptedWithNoErrors()
    {
        var input = x12Document.Parse(SampleData.LoadClean204());
        var text = Builder.Build997Text(input);
        var lines = TestHelpers.Segments(text);

        Assert.Single(TestHelpers.SegmentsOf(text, "AK2"));
        Assert.Equal("AK5*A", TestHelpers.SingleSegmentOf(text, "AK5"));
        Assert.Equal("AK9*A*1*1*1", TestHelpers.SingleSegmentOf(text, "AK9"));
        Assert.Empty(TestHelpers.SegmentsOf(text, "AK3"));

        var gs = TestHelpers.SingleSegmentOf(text, "GS");
        Assert.Equal("FA", gs.Split('*')[1]);

        var isa = lines.First();
        Assert.StartsWith("ISA*", isa);
        // ISA06 (sender) is the input's ISA08 (receiver), and ISA08 (receiver) is the input's ISA06 (sender).
        Assert.Contains("*123456789012345*", isa);
        Assert.Contains("*ABCDEFGHIJKLMNO*", isa);
        var isaFields = isa.Split('*');
        Assert.Equal("123456789012345", isaFields[6]);
        Assert.Equal("ABCDEFGHIJKLMNO", isaFields[8]);
    }

    [Fact]
    public void CleanDocument_ReparsesWithNoValidationErrorsAndCorrectCounts()
    {
        var input = x12Document.Parse(SampleData.LoadClean204());
        var text = Builder.Build997Text(input);

        var reparsed = x12Document.Parse(text);
        Assert.Empty(reparsed.ValidationErrors);

        var interchange = reparsed.Interchanges.Single();
        Assert.Equal(interchange.FunctionalGroups.Count, interchange.Trailer.NumberOfIncludedFunctionalGroups);

        var group = interchange.FunctionalGroups.Single();
        Assert.Equal(group.Sections.Count, group.Trailer.NumberOfTransactionSetsIncluded);

        var section = group.Sections.Single();
        Assert.Equal(section.Segments.Count + 2, section.TransactionSetTrailer.NumberOfIncludedSegments);
    }

    [Fact]
    public void RequiredElementMissing_ProducesAk3AndAk4_AndAcceptsWithErrorsByDefault()
    {
        var input = x12Document.Parse(SampleData.With204N101Blanked());
        var text = Builder.Build997Text(input);

        var ak3 = TestHelpers.SingleSegmentOf(text, "AK3");
        var ak3Fields = ak3.Split('*');
        Assert.Equal("N1", ak3Fields[1]);
        Assert.Equal("7", ak3Fields[2]); // ST=1, B2=2, B2A=3, L11=4, MS3=5, NTE=6, N1=7
        Assert.Equal("8", ak3Fields[4]); // segment has data element errors

        Assert.Equal("AK4*1**1", TestHelpers.SingleSegmentOf(text, "AK4"));
        Assert.Equal("AK5*E*5", TestHelpers.SingleSegmentOf(text, "AK5")); // 5 = one or more segments in error
        Assert.Equal("AK9*E*1*1*1", TestHelpers.SingleSegmentOf(text, "AK9"));
    }

    [Fact]
    public void RequiredElementMissing_IsRejectedWhenAcceptWithErrorsIsFalse()
    {
        var input = x12Document.Parse(SampleData.With204N101Blanked());
        var options = new AcknowledgmentOptions { AcceptWithErrors = false };
        var text = Builder.Build997Text(input, options);

        Assert.Equal("AK5*R*5", TestHelpers.SingleSegmentOf(text, "AK5"));
        Assert.Equal("AK9*R*1*1*0", TestHelpers.SingleSegmentOf(text, "AK9"));
    }

    [Fact]
    public void WrongSegmentCount_IsRejectedWithSyntaxCode4()
    {
        var input = x12Document.Parse(SampleData.With204WrongSegmentCount());
        var text = Builder.Build997Text(input);

        Assert.Equal("AK5*R*4", TestHelpers.SingleSegmentOf(text, "AK5"));
        Assert.Empty(TestHelpers.SegmentsOf(text, "AK3"));
    }

    [Fact]
    public void UnknownSegment_ProducesAk3WithSyntaxCode1()
    {
        var input = x12Document.Parse(SampleData.With204UnknownSegment(), new x12ParseOptions { Lenient = true });
        var text = Builder.Build997Text(input);

        var ak3 = TestHelpers.SingleSegmentOf(text, "AK3");
        var ak3Fields = ak3.Split('*');
        Assert.Equal("ZZZ", ak3Fields[1]);
        Assert.Equal("1", ak3Fields[4]);
        Assert.Empty(TestHelpers.SegmentsOf(text, "AK4"));
        Assert.Equal("AK5*R*5", TestHelpers.SingleSegmentOf(text, "AK5"));
    }

    [Fact]
    public void TwoTransactionSetsInOneGroup_ProduceTwoAk2LoopsAndGroupCounts()
    {
        var input = x12Document.Parse(SampleData.With204TwoTransactionSets());
        var text = Builder.Build997Text(input);

        Assert.Equal(2, TestHelpers.SegmentsOf(text, "AK2").Count);
        Assert.Equal(2, TestHelpers.SegmentsOf(text, "AK5").Count);
        Assert.Equal("AK9*A*2*2*2", TestHelpers.SingleSegmentOf(text, "AK9"));

        var reparsed = x12Document.Parse(text);
        Assert.Empty(reparsed.ValidationErrors);
    }

    [Fact]
    public void Build997_ThrowsOnNullInput()
    {
        Assert.Throws<ArgumentNullException>(() => Builder.Build997(null));
    }
}
