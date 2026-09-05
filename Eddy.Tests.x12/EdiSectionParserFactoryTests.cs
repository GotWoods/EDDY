namespace Eddy.x12.Tests;

public class EdiSectionParserFactoryTests
{
    static EdiSectionParserFactoryTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    [Fact]
    public void TryGetSegmentForReturnsTrueForARegisteredSegment()
    {
        var found = EdiSectionParserFactory.TryGetSegmentFor("4010", "N1", out var type);

        Assert.True(found);
        Assert.NotNull(type);
    }

    [Fact]
    public void TryGetSegmentForReturnsFalseInsteadOfThrowingForAnUnregisteredSegment()
    {
        var found = EdiSectionParserFactory.TryGetSegmentFor("4010", "NOTASEGMENT", out var type);

        Assert.False(found);
        Assert.Null(type);
    }

    [Fact]
    public void GetSegmentForStillThrowsForCallersThatWantThat()
    {
        Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => EdiSectionParserFactory.GetSegmentFor("4010", "NOTASEGMENT"));
    }
}
