using Xunit;

namespace Eddy.MetadataTool.Tests;

/// <summary>Asserts against the actual generated metadata/packs/edifact-D96A.json checked into the
/// repository, so a change to the importer that breaks the real pack is caught here too.</summary>
public class GeneratedD96APackTests
{
    private readonly MetadataPackModel _pack = PackJson.Load(
        Path.Combine(RepoPaths.Root(), "metadata", "packs", "edifact-D96A.json"));

    [Fact]
    public void Pack_identifies_itself_as_EDIFACT_D96A()
    {
        Assert.Equal("EDIFACT", _pack.Standard);
        Assert.Equal("D96A", _pack.Version);
        Assert.Equal("eddy-metadata-pack/1", _pack.Format);
    }

    [Fact]
    public void NAD_has_element_1_as_data_element_3035_mandatory_and_element_2_as_composite_C082_conditional()
    {
        Assert.True(_pack.Segments.TryGetValue("NAD", out var nad));

        var first = nad!.Elements.Single(e => e.Pos == 1);
        Assert.Equal("3035", first.De);
        Assert.Null(first.Composite);
        Assert.Equal("M", first.Req);

        var second = nad.Elements.Single(e => e.Pos == 2);
        Assert.Equal("C082", second.Composite);
        Assert.Null(second.De);
    }

    [Fact]
    public void Data_element_3035_is_ID_with_length_1_to_3()
    {
        Assert.True(_pack.DataElements.TryGetValue("3035", out var de));
        Assert.Equal("ID", de!.Type);
        Assert.Equal(1, de.Min);
        Assert.Equal(3, de.Max);
    }

    [Fact]
    public void Codes_for_3035_include_BY_and_SU()
    {
        Assert.True(_pack.Codes.TryGetValue("3035", out var codes));
        Assert.Contains("BY", codes!.Keys);
        Assert.Contains("SU", codes.Keys);
    }
}
