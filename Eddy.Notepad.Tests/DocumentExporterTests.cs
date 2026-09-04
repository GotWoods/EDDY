using System.Text.Json;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>File &gt; Export ▸ Text/JSON/CSV: see Services/DocumentExporter.cs and README.md, "Export".</summary>
public class DocumentExporterTests
{
    private readonly DocumentLoader _loader = new();

    [Fact]
    public void ExportJson_shape_is_interchange_group_transactionSet_segment_element_and_carries_diagnostics()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);
        var planted = new DiagnosticViewModel(DiagnosticSeverity.Warning, 9, "N1", "planted test diagnostic");
        document.Diagnostics.Add(planted);

        var json = DocumentExporter.ExportJson(document);
        using var parsed = JsonDocument.Parse(json);
        var root = parsed.RootElement;

        Assert.Equal("X12 004010", root.GetProperty("format").GetString());

        var diagnostic = Assert.Single(
            root.GetProperty("diagnostics").EnumerateArray(),
            d => d.GetProperty("message").GetString() == "planted test diagnostic");
        Assert.Equal("Warning", diagnostic.GetProperty("severity").GetString());
        Assert.Equal(9, diagnostic.GetProperty("line").GetInt32());

        var interchange = root.GetProperty("interchanges")[0];
        Assert.Equal("Interchange", interchange.GetProperty("kind").GetString());
        Assert.Equal("ISA", interchange.GetProperty("code").GetString());

        var group = interchange.GetProperty("children")[0];
        Assert.Equal("FunctionalGroup", group.GetProperty("kind").GetString());
        Assert.Equal("GS", group.GetProperty("code").GetString());

        var transactionSet = group.GetProperty("children")[0];
        Assert.Equal("TransactionSet", transactionSet.GetProperty("kind").GetString());
        Assert.Equal("204", transactionSet.GetProperty("code").GetString());

        var segment = transactionSet.GetProperty("children").EnumerateArray()
            .Single(s => s.GetProperty("code").GetString() == "N1");
        Assert.Equal("Segment", segment.GetProperty("kind").GetString());

        var element = segment.GetProperty("elements").EnumerateArray()
            .Single(e => e.GetProperty("ref").GetString() == "N102");
        Assert.Equal("XYZ CORP", element.GetProperty("value").GetString());
        Assert.True(element.TryGetProperty("name", out _));
        Assert.True(element.TryGetProperty("de", out _));
        Assert.True(element.TryGetProperty("type", out _));
    }

    [Fact]
    public void ExportCsv_header_and_row_count_match_the_documents_elements()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        var csv = DocumentExporter.ExportCsv(document);
        var lines = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        Assert.Equal("line,segment,ref,name,value,de,type,req,meaning", lines[0]);
        Assert.Equal(CountElements(document.Nodes), lines.Length - 1);

        // The header row's own column count matches every data row's.
        Assert.All(lines.Skip(1), row => Assert.Equal(9, row.Split(',').Length));
    }

    [Fact]
    public void ExportCsv_quotes_a_value_containing_a_comma_or_quote()
    {
        var document = new DocumentViewModel("t", null, "X12", "");
        var node = new DocumentNodeViewModel(NodeKind.Segment, "N9", "N9", "", 1, null)
        {
            Elements = new[] { new ElementViewModel("N901", 1, "Reference", "Reference", "a,\"b\"") },
        };
        document.Nodes.Add(node);

        var csv = DocumentExporter.ExportCsv(document);
        var row = csv.Split('\n', StringSplitOptions.RemoveEmptyEntries)[1];

        Assert.Contains("\"a,\"\"b\"\"\"", row);
    }

    [Fact]
    public void ExportText_inserts_a_newline_after_each_terminator_when_the_file_has_none()
    {
        var singleLine = NotepadTestFixtures.SingleValidInterchange(newline: "~");
        var document = _loader.Load(singleLine, "single-line", null);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.DoesNotContain('\n', document.RawText);

        var exported = DocumentExporter.ExportText(document);

        var lines = exported.Split('\n', StringSplitOptions.RemoveEmptyEntries);
        Assert.True(lines.Length > 1);
        Assert.All(lines, line => Assert.EndsWith("~", line));
    }

    [Fact]
    public void ExportText_is_unchanged_when_the_terminator_already_has_a_newline_after_it()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        Assert.Equal(document.RawText, DocumentExporter.ExportText(document));
    }

    private static int CountElements(IEnumerable<DocumentNodeViewModel> nodes)
    {
        var count = 0;
        foreach (var node in nodes)
        {
            count += node.Elements.Count;
            count += CountElements(node.Children);
        }

        return count;
    }
}
