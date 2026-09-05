using Eddy.Tests.x12;
using Eddy.Tests.x12.Codes;
using Eddy.x12.Mapping;
using Xunit;

namespace Eddy.Tests.x12.Codes;

/// <summary>Exercises Eddy.x12.Mapping.Map reading and writing a Code&lt;TList&gt; property, both
/// directions, using <see cref="ZZC_CodeMappingTestSegment"/>.</summary>
public class CodeMappingTests
{
    [Fact]
    public void MapObject_ReadsCodePropertyThroughItsStringConstructor()
    {
        var line = "ZZC*BY*hello";

        var segment = Map.MapObject<ZZC_CodeMappingTestSegment>(line, MapOptionsForTesting.x12DefaultEndsWithTilde);

        Assert.NotNull(segment.EntityCode);
        Assert.Equal("BY", segment.EntityCode.Value);
        Assert.Equal("hello", segment.Plain);
    }

    [Fact]
    public void MapObject_LeavesCodePropertyNullWhenElementIsAbsent()
    {
        var line = "ZZC";

        var segment = Map.MapObject<ZZC_CodeMappingTestSegment>(line, MapOptionsForTesting.x12DefaultEndsWithTilde);

        Assert.Null(segment.EntityCode);
    }

    [Fact]
    public void SegmentToString_WritesCodePropertyThroughToString()
    {
        var segment = new ZZC_CodeMappingTestSegment
        {
            EntityCode = "BY", // implicit conversion from string
            Plain = "hello",
        };

        var text = Map.SegmentToString(segment, MapOptionsForTesting.x12DefaultEndsWithTilde);

        Assert.Equal("ZZC*BY*hello~", text);
    }

    [Fact]
    public void RoundTrip_PreservesAPartnerSpecificValueOutsideTheStandardList()
    {
        var line = "ZZC*QQQ*hello";

        var segment = Map.MapObject<ZZC_CodeMappingTestSegment>(line, MapOptionsForTesting.x12DefaultEndsWithTilde);

        Assert.Equal("QQQ", segment.EntityCode.Value);
        Assert.False(segment.EntityCode.IsStandard); // no code list loaded by default - never "standard"

        var text = Map.SegmentToString(segment, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equal(line + "~", text);
    }
}
