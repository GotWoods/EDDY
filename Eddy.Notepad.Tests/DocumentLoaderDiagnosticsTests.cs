using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class DocumentLoaderDiagnosticsTests
{
    private readonly DocumentLoader _loader = new();

    private const string PlantedErrorLine = "N1**XYZ CORP*9*9995555500000";
    private const string OriginalLine = "N1*PF*XYZ CORP*9*9995555500000";

    [Fact]
    public void Blanking_a_required_element_produces_a_diagnostic_on_the_right_line_and_node()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        Assert.Contains(OriginalLine, text);
        var planted = text.Replace(OriginalLine, PlantedErrorLine);

        var document = _loader.Load(planted, "planted", null);

        Assert.False(document.IsValid);
        Assert.Equal(1, document.ErrorCount);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(9, diagnostic.LineNumber);
        Assert.Equal("N1", diagnostic.SegmentCode);
        Assert.Contains("EntityIdentifierCode", diagnostic.Message);

        Assert.NotNull(diagnostic.Node);
        Assert.Equal(NodeKind.Segment, diagnostic.Node!.Kind);
        Assert.Equal("N1", diagnostic.Node.Code);
        Assert.Equal(9, diagnostic.Node.LineNumber);

        // The tree badges count diagnostics attached to the node and its ancestors.
        Assert.True(diagnostic.Node.HasErrors);
        Assert.Equal(1, diagnostic.Node.ErrorCount);
        Assert.Equal(1, document.Nodes[0].ErrorCount);

        var rawLine = document.RawLines.Single(r => r.LineNumber == 9);
        Assert.True(rawLine.HasError);
        Assert.Same(diagnostic.Node, rawLine.Node);

        var n101 = diagnostic.Node.Elements.Single(e => e.Reference == "N101");
        Assert.True(n101.HasError);
        Assert.False(n101.HasValue);

        // The other N1 elements are untouched by this error.
        var n102 = diagnostic.Node.Elements.Single(e => e.Reference == "N102");
        Assert.False(n102.HasError);
    }

    [Fact]
    public void N1_segment_elements_have_the_expected_references_names_and_values()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var transactionSet = document.Nodes[0].Children[0].Children[0];
        var n1 = transactionSet.Children.Single(c => c.Code == "N1");

        Assert.Equal(6, n1.Elements.Count);
        Assert.Equal(new[] { "N101", "N102", "N103", "N104", "N105", "N106" }, n1.Elements.Select(e => e.Reference));
        Assert.Equal(
            new[]
            {
                "Entity Identifier Code",
                "Name",
                "Identification Code Qualifier",
                "Identification Code",
                "Entity Relationship Code",
                "Entity Identifier Code 2",
            },
            n1.Elements.Select(e => e.Name));

        Assert.Equal("PF", n1.Elements[0].Value);
        Assert.Equal("XYZ CORP", n1.Elements[1].Value);
        Assert.Equal("9", n1.Elements[2].Value);
        Assert.Equal("9995555500000", n1.Elements[3].Value);

        Assert.True(n1.Elements[0].HasValue);
        Assert.True(n1.Elements[1].HasValue);
        Assert.True(n1.Elements[2].HasValue);
        Assert.True(n1.Elements[3].HasValue);

        // Absent elements are still present in the grid, per the loader contract.
        Assert.False(n1.Elements[4].HasValue);
        Assert.False(n1.Elements[5].HasValue);
        Assert.Null(n1.Elements[4].Value);
        Assert.Null(n1.Elements[5].Value);

        Assert.All(n1.Elements, e => Assert.False(e.IsComposite));
    }

    [Fact]
    public void Composite_element_is_split_into_components()
    {
        // ASO_AssetOwnership (v4010) has a C007_AmountQualifyingDescription composite at position 6.
        // None of the bundled samples uses a segment with a composite element, so this builds one directly.
        // The ISA's component element separator is the character right before the segment terminator
        // (position 104): use ':' here so the composite value below can be split on it.
        const string isa = "ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000000001*0*P*:";
        var text = string.Join(
            "\n",
            isa,
            "GS*SM*SENDER*RECEIVER*20240101*1200*1*X*004010",
            "ST*204*0001",
            "ASO*O*RE**Hello*Y*IN:AC:V:MM:MO:N:M2:Desc*1000*10*5*ZZ*REF1",
            "SE*3*0001",
            "GE*1*1",
            "IEA*1*000000001");

        var loader = new DocumentLoader();
        var document = loader.Load(text, "composite", null);

        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));

        var transactionSet = document.Nodes[0].Children[0].Children[0];
        var aso = transactionSet.Children.Single(c => c.Code == "ASO");

        var composite = aso.Elements.Single(e => e.Reference == "ASO06");
        Assert.True(composite.IsComposite);
        Assert.Equal(8, composite.Components.Count);

        Assert.Equal("ASO0601", composite.Components[0].Reference);
        Assert.Equal("IN", composite.Components[0].Value);
        Assert.Equal("AC", composite.Components[1].Value);
        Assert.Equal("V", composite.Components[2].Value);
        Assert.Equal("MM", composite.Components[3].Value);
        Assert.Equal("MO", composite.Components[4].Value);
        Assert.Equal("N", composite.Components[5].Value);
        Assert.Equal("M2", composite.Components[6].Value);
        Assert.Equal("Desc", composite.Components[7].Value);

        Assert.Contains("IN", composite.Value);
        Assert.Contains("Desc", composite.Value);
    }
}
