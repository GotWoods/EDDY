using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class DocumentSearchTests
{
    private readonly DocumentLoader _loader = new();

    [Fact]
    public void Finds_a_match_in_an_element_value_case_insensitively()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        var results = DocumentSearch.Find(document, "xyz");

        var n1 = document.Nodes[0].Children[0].Children[0].Children.Single(c => c.Code == "N1");
        Assert.Contains(n1, results);
    }

    [Fact]
    public void Finds_a_match_via_the_nodes_own_raw_line_text()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        // "ABCDEFGHIJKLMNO" is the interchange sender id, verbatim in the ISA node's raw line.
        var results = DocumentSearch.Find(document, "abcdefghijklmno");

        Assert.Contains(document.Nodes[0], results);
    }

    [Fact]
    public void Matches_element_names_and_composite_component_values()
    {
        var element = new ElementViewModel("N7-C1", 17, "Weight Unit Code (composite demo)", "WeightUnitComposite", "5300#L")
        {
            Components = new[]
            {
                new ElementViewModel("N7-C1-1", 1, "Weight Unit Code", "WeightUnitCode", "NEEDLE"),
            },
        };
        var node = new DocumentNodeViewModel(NodeKind.Segment, "N7", "N7 Equipment Details", "", 1, null) { Elements = new[] { element } };
        var document = new DocumentViewModel("t", null, "X12", "");
        document.Nodes.Add(node);
        document.RawLines = Array.Empty<RawLineViewModel>();

        Assert.Contains(node, DocumentSearch.Find(document, "needle"));       // composite component value
        Assert.Contains(node, DocumentSearch.Find(document, "weight unit")); // element/component name
        Assert.Empty(DocumentSearch.Find(document, "no-such-text"));
    }

    [Fact]
    public void Empty_query_returns_no_results()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        Assert.Empty(DocumentSearch.Find(document, ""));
    }

    [Fact]
    public void Results_are_returned_in_document_order()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        // Every L11 segment's raw line starts with "L11" -- five of them in the 204 sample.
        var results = DocumentSearch.Find(document, "l11");

        Assert.Equal(5, results.Count);
        Assert.All(results, r => Assert.Equal("L11", r.Code));
        for (var i = 1; i < results.Count; i++)
            Assert.True((results[i - 1].LineNumber ?? 0) < (results[i].LineNumber ?? 0));
    }
}
