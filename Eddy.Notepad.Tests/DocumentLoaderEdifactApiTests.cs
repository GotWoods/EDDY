using Eddy.Core;
using Eddy.Edifact;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>
/// Exercises the loader against the EDIFACT half of the hardened Eddy.Edifact API: the implicit
/// functional group, the UNA service string advice, composites, unknown segments, structural mismatches
/// and source spans. Mirrors DocumentLoaderX12ApiTests.cs so the two suites read alike. See README.md,
/// "Loader contract".
/// </summary>
public class DocumentLoaderEdifactApiTests
{
    private readonly DocumentLoader _loader = new();

    /// <summary>A minimal, well-formed single-message interchange: UNB, UNH, one BGM body segment (no
    /// required fields, so it is always valid on its own), UNT, UNZ. No UNG - the implicit group.</summary>
    private static string BuildInterchange(string interchangeRef, string messageRef, string messageType = "INVOIC") =>
        $"UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+{interchangeRef}'\n" +
        $"UNH+{messageRef}+{messageType}:D:96A:UN'\n" +
        "BGM+16+123456+9'\n" +
        $"UNT+3+{messageRef}'\n" +
        $"UNZ+1+{interchangeRef}'\n";

    [Fact]
    public void Sample_INVOIC_produces_one_interchange_one_implicit_group_and_one_message()
    {
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        var document = _loader.Load(text, "Sample-INVOIC-Invoice", null);

        Assert.StartsWith("EDIFACT", document.Format);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.Equal(0, document.ErrorCount);

        Assert.Single(document.Nodes);
        var interchange = document.Nodes[0];
        Assert.Equal(NodeKind.Interchange, interchange.Kind);
        Assert.Equal("UNB", interchange.Code);
        Assert.Equal(2, interchange.LineNumber); // line 1 is UNA, UNB is line 2

        Assert.Single(interchange.Children);
        var group = interchange.Children[0];
        Assert.Equal(NodeKind.FunctionalGroup, group.Kind);
        Assert.Equal("UNG", group.Code);
        Assert.Equal("Messages", group.Title);
        Assert.Equal("no UNG group header", group.Subtitle);

        Assert.Single(group.Children);
        var message = group.Children[0];
        Assert.Equal(NodeKind.TransactionSet, message.Kind);
        Assert.Equal("INVOIC", message.Code);
        Assert.Equal("UNH INVOIC", message.Title);

        // UNH...UNT holds 15 segments total (UNH + 13 body segments + UNT); the body segments are Segment
        // children of the message node.
        Assert.Equal(13, message.Children.Count);
        Assert.All(message.Children, c => Assert.Equal(NodeKind.Segment, c.Kind));
    }

    [Fact]
    public void Sample_INVOIC_UNA_and_UNB_raw_lines_have_the_right_line_numbers_and_source_offsets()
    {
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        var document = _loader.Load(text, "Sample-INVOIC-Invoice", null);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));

        var una = document.RawLines.Single(r => r.LineNumber == 1);
        Assert.StartsWith("UNA", una.Text);

        var unb = document.RawLines.Single(r => r.LineNumber == 2);
        Assert.StartsWith("UNB", unb.Text);

        // Re-parse the exact text the loader normalised to, so Source offsets line up with document.RawText.
        var parsed = EdiFactDocument.Parse(document.RawText, new EdifactParseOptions { Lenient = true });

        void AssertLine(SegmentSource? source)
        {
            Assert.NotNull(source);
            var expected = document.RawText.Substring(source!.StartOffset, source.Length);
            Assert.Equal(source.RawText, expected);

            var rawLine = document.RawLines.Single(r => r.LineNumber == source.LineNumber);
            Assert.Equal(expected, rawLine.Text);
        }

        AssertLine(parsed.ServiceStringAdvice!.Source);
        var interchange = parsed.Interchanges.Single();
        AssertLine(interchange.Header!.Source);
        AssertLine(interchange.Trailer!.Source);

        var group = interchange.FunctionalGroups.Single();
        var message = group.Messages.Single();
        AssertLine(message.Header!.Source);
        AssertLine(message.Trailer!.Source);
        foreach (var segment in message.Segments)
            AssertLine(segment.Source);
    }

    [Fact]
    public void Sample_INVOIC_NAD_node_has_a_composite_element_with_components()
    {
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        var document = _loader.Load(text, "Sample-INVOIC-Invoice", null);

        var message = document.Nodes[0].Children[0].Children[0];
        var nad = message.Children.First(c => c.Code == "NAD");

        // Position 2 is C082 PartyIdentificationDetails, a composite.
        var composite = nad.Elements.Single(e => e.Reference == "NAD02");
        Assert.True(composite.IsComposite);
        Assert.NotEmpty(composite.Components);
        Assert.Equal("5412345678915", composite.Components[0].Value);
        Assert.Equal("NAD0201", composite.Components[0].Reference);
    }

    [Fact]
    public void Sample_INVOIC_release_character_escapes_a_separator_inside_a_value()
    {
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        var document = _loader.Load(text, "Sample-INVOIC-Invoice", null);

        var message = document.Nodes[0].Children[0].Children[0];
        var supplierNad = message.Children.Last(c => c.Code == "NAD");

        // Position 4 is C080 PartyName; the raw text has "ACME?+SONS LTD" (the release character '?'
        // escaping the '+' element separator), which must decode to a literal '+'.
        var partyName = supplierNad.Elements.Single(e => e.Reference == "NAD04");
        Assert.Contains("ACME+SONS LTD", partyName.Value);
    }

    [Fact]
    public void Blanking_a_required_element_produces_a_diagnostic_on_the_right_line_and_node()
    {
        const string originalLine = "NAD+BY+5412345678915::9++GLOBAL IMPORT CO+456 OAK AVE+PARIS++75001+FR'";
        const string plantedLine = "NAD++5412345678915::9++GLOBAL IMPORT CO+456 OAK AVE+PARIS++75001+FR'";

        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        Assert.Contains(originalLine, text);
        var planted = text.Replace(originalLine, plantedLine);

        var document = _loader.Load(planted, "planted", null);

        Assert.False(document.IsValid);
        Assert.Equal(1, document.ErrorCount);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(6, diagnostic.LineNumber); // the buyer NAD is raw line 6
        Assert.Equal("NAD", diagnostic.SegmentCode);
        Assert.Contains("PartyQualifier", diagnostic.Message);

        Assert.NotNull(diagnostic.Node);
        Assert.Equal(NodeKind.Segment, diagnostic.Node!.Kind);
        Assert.Equal("NAD", diagnostic.Node.Code);
        Assert.True(diagnostic.Node.HasErrors);

        var nad01 = diagnostic.Node.Elements.Single(e => e.Reference == "NAD01");
        Assert.True(nad01.HasError);
        Assert.False(nad01.HasValue);
    }

    [Fact]
    public void Unknown_segment_inside_a_message_becomes_an_unknown_segment_node()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" + // line 1
            "UNH+1+APERAK:D:96A:UN'\n" +                             // line 2
            "ZZZ+1'\n" +                                             // line 3 - not a real EDIFACT segment
            "UNT+3+1'\n" +                                           // line 4
            "UNZ+1+REF1'\n";                                         // line 5

        var document = _loader.Load(data, "unknown-segment", null);

        var message = document.Nodes[0].Children[0].Children[0];
        var unknown = Assert.Single(message.Children);
        Assert.Equal(NodeKind.Segment, unknown.Kind);
        Assert.Equal("ZZZ Unknown segment", unknown.Title);
        Assert.Equal(3, unknown.LineNumber);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(3, diagnostic.LineNumber);
        Assert.Contains("ZZZ", diagnostic.Message);
        Assert.Same(unknown, diagnostic.Node);
    }

    [Fact]
    public void UNT_count_mismatch_puts_the_diagnostic_on_the_message_node()
    {
        var data =
            "UNB+UNOA:1+SENDER:14+RECEIVER:14+230815:1200+REF1'\n" + // line 1
            "UNH+1+APERAK:D:96A:UN'\n" +                             // line 2
            "BGM+16+123456+9'\n" +                                   // line 3
            "UNT+99+1'\n" +                                          // line 4 - wrong count, should be 3
            "UNZ+1+REF1'\n";                                         // line 5

        var document = _loader.Load(data, "unt-mismatch", null);

        Assert.False(document.IsValid);
        var message = document.Nodes[0].Children[0].Children[0];
        Assert.Equal(NodeKind.TransactionSet, message.Kind);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(4, diagnostic.LineNumber);
        Assert.Contains("Number of Segments", diagnostic.Message);
        Assert.Same(message, diagnostic.Node);
        Assert.True(message.HasErrors);
    }

    [Fact]
    public void Two_interchanges_in_one_file_yield_two_interchange_nodes_and_the_right_status_text()
    {
        var data = BuildInterchange("REF1", "1") + BuildInterchange("REF2", "1");

        var document = _loader.Load(data, "multi", null);

        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.StartsWith("EDIFACT", document.Format);

        Assert.Equal(2, document.Nodes.Count);
        Assert.All(document.Nodes, n => Assert.Equal(NodeKind.Interchange, n.Kind));
        Assert.All(document.Nodes, n => Assert.Single(n.Children)); // one implicit group each
        Assert.All(document.Nodes.SelectMany(n => n.Children), g => Assert.Single(g.Children)); // one message each

        var vm = new MainWindowViewModel(_loader, new NullFilePicker());
        vm.OpenText(data, "multi", null);
        Assert.Equal("EDIFACT D96A · 2 interchanges · 2 groups · 2 messages · 0 errors", vm.StatusText);
    }
}
