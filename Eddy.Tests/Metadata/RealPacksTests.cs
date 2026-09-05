using System.Linq;
using Eddy.Core.Metadata;
using Xunit;

namespace Eddy.Tests.Metadata;

/// <summary>Loads the three real, checked-in EDIFACT packs from metadata/packs/ (see docs/metadata-packs.md)
/// and exercises them against the actual generated model, so a change to the pack format or to the D96A
/// model's shape is caught here too -- not just against the hand-built fixtures in MetadataPackTests.cs.</summary>
public class RealPacksTests
{
    private static string RepoRoot()
    {
        var dir = AppContext.BaseDirectory;
        while (dir is not null)
        {
            if (File.Exists(Path.Combine(dir, "EDDY.sln")))
                return dir;
            dir = Path.GetDirectoryName(dir.TrimEnd(Path.DirectorySeparatorChar));
        }
        throw new InvalidOperationException("could not locate repository root (EDDY.sln) from " + AppContext.BaseDirectory);
    }

    private static string PackPath(string fileName) => Path.Combine(RepoRoot(), "metadata", "packs", fileName);

    [Fact]
    public void All_three_real_packs_load_and_identify_themselves_as_EDIFACT()
    {
        var packs = new[]
        {
            MetadataPack.Load(PackPath("edifact-D96A.json")),
            MetadataPack.Load(PackPath("edifact-D01B.json")),
            MetadataPack.Load(PackPath("edifact-D07A.json")),
        };

        var versions = packs.Select(p => p.Version).OrderBy(v => v, StringComparer.Ordinal).ToArray();
        Assert.Equal(new[] { "D01B", "D07A", "D96A" }, versions);
        Assert.All(packs, p => Assert.Equal("EDIFACT", p.Standard));
    }

    [Fact]
    public void D96A_pack_describes_NAD_with_DE_3035_on_position_1_and_composite_C082_components_on_position_2()
    {
        var catalog = new MetadataCatalog();
        catalog.AddPack(MetadataPack.Load(PackPath("edifact-D96A.json")));
        catalog.AddPack(MetadataPack.Load(PackPath("edifact-D01B.json")));
        catalog.AddPack(MetadataPack.Load(PackPath("edifact-D07A.json")));

        var def = catalog.Describe(typeof(Eddy.Edifact.Models.D96A.NAD_NameAndAddress));

        Assert.Equal("NAD", def.Id);

        var partyQualifier = def.Elements.Single(e => e.Position == 1);
        Assert.Equal("3035", partyQualifier.DataElementNumber);
        Assert.Equal(ElementDataType.Identifier, partyQualifier.DataType);
        Assert.Equal("3035", partyQualifier.CodeListId);
        Assert.Equal(Requirement.Mandatory, partyQualifier.Requirement);

        var partyIdentification = def.Elements.Single(e => e.Position == 2);
        Assert.Equal(ElementDataType.Composite, partyIdentification.DataType);
        Assert.Equal("C082", partyIdentification.CompositeId);
        Assert.NotEmpty(partyIdentification.Components);
        Assert.Contains(partyIdentification.Components, c => c.DataElementNumber == "3039");
    }
}
