using System.Collections.Generic;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12.Tests;

public class MapTests
{
    [Fact]
    public void UnknownSegmentRoundTripsThroughSegmentToString()
    {
        var segment = new Unknown_Segment
        {
            SegmentId = "ZZZ9",
            Elements = new List<string> { "1", "2", "" }, //trailing empty element should be trimmed
            Version = "4010"
        };

        var text = Map.SegmentToString(segment, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ZZZ9*1*2~", text);

        var withoutTerminator = Map.SegmentToString(segment, MapOptionsForTesting.x12DefaultEndsWithTilde, false);
        Assert.Equal("ZZZ9*1*2", withoutTerminator);

        //re-parses back into an equivalent Unknown_Segment
        var data = x12TestFixtures.Isa("000000001") +
                   x12TestFixtures.Gs("2100") +
                   x12TestFixtures.St("0001") +
                   text + "\n" +
                   x12TestFixtures.Se(3, "0001") +
                   x12TestFixtures.Ge(1, "2100") +
                   x12TestFixtures.Iea(1, "000000001");
        var doc = x12Document.Parse(data, new x12ParseOptions { Lenient = true });
        var reparsed = Assert.IsType<Unknown_Segment>(doc.Sections[0].Segments[0]);
        Assert.Equal("ZZZ9", reparsed.SegmentId);
        Assert.Equal(new[] { "1", "2" }, reparsed.Elements);
    }

    [Fact]
    public void UnknownSegmentWithNoElementsRendersJustTheSegmentId()
    {
        var segment = new Unknown_Segment { SegmentId = "ZZZ9", Elements = new List<string>() };

        var text = Map.SegmentToString(segment, MapOptionsForTesting.x12DefaultEndsWithTilde, false);

        Assert.Equal("ZZZ9", text);
    }

    [Fact]
    public void ShouldConvertToString()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "CD";
        header.ImplementationConventionReference = "EF";
        
        

        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB*CD*EF~", actual);
    }


    [Fact]
    public void ShouldConvertToStringWhenElementNull()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "CD";
        //header.ImplementationConventionReference = "EF"; 

        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB*CD~", actual);
    }

    [Fact]
    public void ShouldConvertToStringWhenPropertyNull()
    {
        var header = new ST_TransactionSetHeader();
        header.TransactionSetIdentifierCode = "AB";
        header.TransactionSetControlNumber = "\0";
        
        var actual = Map.SegmentToString(header, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal("ST*AB~", actual);
    }
}
public class CompositeInheritanceMapTests
{
    // C030_PositionInSegment was introduced at v4020, so in v5010 it sits several subclasses below
    // EdiX12Component. Map used to detect composites only by the immediate base class and failed on both
    // read and write for such properties.
    [Fact]
    public void Composite_declared_several_versions_below_EdiX12Component_is_read_and_written()
    {
        var options = new Eddy.x12.Mapping.MapOptions { Separator = "*", ComponentElementSeparator = ":", LineEnding = "~", StandardsVersion = "5010" };

        var parsed = Eddy.x12.Mapping.Map.MapObject<Eddy.x12.Models.v5010.IK4_ImplementationDataElementNote>("IK4*3:2**1", options);
        Assert.NotNull(parsed.PositionInSegment);
        Assert.Equal(3, parsed.PositionInSegment.ElementPositionInSegment);
        Assert.Equal(2, parsed.PositionInSegment.ComponentDataElementPositionInComposite);

        Assert.Equal("IK4*3:2**1~", Eddy.x12.Mapping.Map.SegmentToString(parsed, options));
    }
}
