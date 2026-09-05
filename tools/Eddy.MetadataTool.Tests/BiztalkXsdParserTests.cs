using Xunit;

namespace Eddy.MetadataTool.Tests;

public class BiztalkXsdParserTests
{
    private readonly BiztalkFileImport _result = BiztalkXsdParser.Parse(RepoPaths.Fixture("EFACT_TEST_NAD.xsd"));

    [Fact]
    public void Parses_the_segment_with_its_name_and_element_positions()
    {
        Assert.True(_result.Segments.TryGetValue("NAD", out var nad));
        Assert.Equal("Name And Address", nad!.Name);
        Assert.Equal(2, nad.Elements.Count);

        var first = nad.Elements.Single(e => e.Pos == 1);
        Assert.Equal("3035", first.De);
        Assert.Null(first.Composite);
        Assert.Equal("M", first.Req);

        var second = nad.Elements.Single(e => e.Pos == 2);
        Assert.Null(second.De);
        Assert.Equal("C082", second.Composite);
        Assert.Equal("C", second.Req);
    }

    [Fact]
    public void Parses_the_composite_with_its_name_and_element_positions()
    {
        Assert.True(_result.Composites.TryGetValue("C082", out var c082));
        Assert.Equal("Party Identification Details", c082!.Name);
        Assert.Equal(2, c082.Elements.Count);

        var first = c082.Elements.Single(e => e.Pos == 1);
        Assert.Equal("3039", first.De);
        Assert.Equal("M", first.Req);

        var second = c082.Elements.Single(e => e.Pos == 2);
        Assert.Equal("1131", second.De);
        Assert.Equal("C", second.Req);
    }

    [Fact]
    public void Parses_the_ID_data_element_with_its_codes()
    {
        Assert.True(_result.DataElements.TryGetValue("3035", out var de));
        Assert.Equal("Party qualifier", de!.Name);
        Assert.Equal("ID", de.Type);
        Assert.Equal(1, de.Min);
        Assert.Equal(2, de.Max); // longest enumerated code ("BY"/"SU"/"DP") is 2 characters

        Assert.True(_result.Codes.TryGetValue("3035", out var codes));
        Assert.Equal(new[] { "BY", "DP", "SU" }, codes!.Keys.OrderBy(k => k));
        Assert.All(codes.Values, v => Assert.Equal("", v));
    }

    [Fact]
    public void Parses_the_AN_data_element_with_its_lengths()
    {
        Assert.True(_result.DataElements.TryGetValue("3039", out var de));
        Assert.Equal("Party id. identification", de!.Name);
        Assert.Equal("AN", de.Type);
        Assert.Equal(1, de.Min);
        Assert.Equal(35, de.Max);
    }
}
