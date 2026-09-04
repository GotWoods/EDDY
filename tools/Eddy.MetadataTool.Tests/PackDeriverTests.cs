using Xunit;

namespace Eddy.MetadataTool.Tests;

/// <summary>Exercises the `derive` command's underlying logic (PackDeriver), which builds a pack purely
/// from what Eddy.Core.Metadata.DerivedSegmentMetadata can compute from the Eddy.Edifact/Eddy.x12 model
/// types. See docs/metadata-packs.md, "Tool".</summary>
public class PackDeriverTests
{
    [Fact]
    public void Derive_EDIFACT_D96A_writes_a_pack_where_NAD_has_9_elements_and_the_pack_validates()
    {
        var pack = PackDeriver.Derive("EDIFACT", "D96A");

        Assert.Equal("EDIFACT", pack.Standard);
        Assert.Equal("D96A", pack.Version);

        Assert.True(pack.Segments.TryGetValue("NAD", out var nad));
        Assert.Equal(9, nad!.Elements.Count);

        var outPath = Path.Combine(Path.GetTempPath(), $"eddy-metadatatool-derive-tests-{Guid.NewGuid():N}.json");
        try
        {
            PackJson.Save(pack, outPath);

            var reloaded = PackJson.Load(outPath);
            var result = PackValidator.Validate(reloaded);

            Assert.True(result.IsValid, string.Join("; ", result.Problems));
            Assert.True(result.SegmentCount > 100);
            Assert.True(result.CompositeCount > 100);
            Assert.True(result.DataElementCount > 0);
        }
        finally
        {
            if (File.Exists(outPath))
                File.Delete(outPath);
        }
    }

    [Fact]
    public void Derive_rejects_an_unrecognised_standard()
    {
        Assert.Throws<ArgumentException>(() => PackDeriver.Derive("EDIFOO", "D96A"));
    }

    [Fact]
    public void Derive_throws_when_no_model_types_exist_for_the_version()
    {
        Assert.Throws<InvalidOperationException>(() => PackDeriver.Derive("EDIFACT", "D99Z"));
    }
}
