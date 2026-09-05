using Eddy.Core.Metadata;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>
/// Exercises the metadata columns the element grid gained on top of the reflection-only reader: DE
/// number, formal type, requirement and code meaning, sourced from MetadataCatalog.Describe(). See
/// docs/metadata-packs.md and README.md, "The screen" / "Loader contract" rule 5.
/// </summary>
public class SegmentElementReaderMetadataTests
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

    private static DocumentNodeViewModel? FindNode(IEnumerable<DocumentNodeViewModel> nodes, Func<DocumentNodeViewModel, bool> match)
    {
        foreach (var node in nodes)
        {
            if (match(node))
                return node;
            var inChildren = FindNode(node.Children, match);
            if (inChildren is not null)
                return inChildren;
        }
        return null;
    }

    [Fact]
    public void NAD_from_a_loaded_D96A_pack_shows_DE_type_requirement_and_a_valid_code_meaning()
    {
        var catalog = new MetadataCatalog();
        catalog.AddPack(MetadataPack.Load(Path.Combine(RepoRoot(), "metadata", "packs", "edifact-D96A.json")));
        var loader = new DocumentLoader(catalog);

        var document = loader.Load(SampleDocuments.GetText("Sample-INVOIC-Invoice"), "Sample-INVOIC-Invoice", null);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));

        var nad = FindNode(document.Nodes, n => n.Code == "NAD")!;
        Assert.NotNull(nad);

        var nad01 = nad.Elements.Single(e => e.Reference == "NAD01");
        Assert.Equal("3035", nad01.DataElementNumber);
        Assert.True(nad01.HasDataElementNumber);
        Assert.Equal("ID 1..3", nad01.DataTypeLabel);
        Assert.Equal("M", nad01.Requirement);

        // NAD01 is "BY" (the first NAD line in the sample): a known code in the pack with no description
        // text (docs/metadata-packs.md, "codes.<number>: ... An empty description is allowed and means the
        // value is known to be valid").
        Assert.Equal("BY", nad01.Value);
        Assert.Equal("", nad01.CodeDescription);
        Assert.Equal("valid code", nad01.Meaning);
        Assert.True(nad01.MeaningIsDimmed);
        Assert.False(nad01.IsUnrecognizedCode);

        var nad02 = nad.Elements.Single(e => e.Reference == "NAD02");
        Assert.True(nad02.IsComposite);
        Assert.NotEmpty(nad02.Components);
        Assert.Equal("3039", nad02.Components[0].DataElementNumber);
        Assert.All(nad02.Components, c => Assert.True(c.HasDataElementNumber));
    }

    [Fact]
    public void N1_with_no_pack_loaded_has_no_DE_number_but_still_has_derived_type_and_requirement()
    {
        var catalog = new MetadataCatalog(); // X12 has no bundled pack; a fresh catalog matches that.
        var loader = new DocumentLoader(catalog);

        var document = loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));

        var n1 = FindNode(document.Nodes, n => n.Code == "N1")!;
        Assert.NotNull(n1);

        var n101 = n1.Elements.Single(e => e.Reference == "N101");
        Assert.Null(n101.DataElementNumber);
        Assert.False(n101.HasDataElementNumber);
        Assert.Equal("M", n101.Requirement);

        var n102 = n1.Elements.Single(e => e.Reference == "N102");
        Assert.Null(n102.DataElementNumber);
        Assert.Equal("AN 1..60", n102.DataTypeLabel);
    }

    [Fact]
    public void An_Identifier_element_whose_value_is_not_in_a_loaded_code_list_gets_the_not_in_code_list_warning()
    {
        // A small synthetic pack: N101 is Identifier-typed, with a code list that does not include "PF"
        // (the value Sample-204-LoadTender actually uses).
        var pack = new MetadataPack { Name = "N1 code-list test pack", Standard = "X12", Version = "004010" };
        pack.DataElements["98"] = new DataElementDefinition { Number = "98", Name = "Entity Identifier Code", DataType = ElementDataType.Identifier, MinLength = 2, MaxLength = 3 };
        var n1 = new SegmentDefinition { Id = "N1", Name = "Name" };
        n1.Elements.Add(new ElementDefinition { Position = 1, DataElementNumber = "98", Requirement = Requirement.Mandatory });
        pack.Segments["N1"] = n1;
        pack.Codes["98"] = new Dictionary<string, string> { { "SE", "Selling party" } }; // "PF" deliberately absent

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);
        var loader = new DocumentLoader(catalog);

        var document = loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);
        var n1Node = FindNode(document.Nodes, n => n.Code == "N1")!;
        var n101 = n1Node.Elements.Single(e => e.Reference == "N101");

        Assert.Equal("PF", n101.Value);
        Assert.Equal("ID 2..3", n101.DataTypeLabel);
        Assert.Null(n101.CodeDescription);
        Assert.True(n101.IsUnrecognizedCode);
        Assert.False(n101.MeaningIsDimmed);
        Assert.Equal("not in code list", n101.Meaning);
    }
}
