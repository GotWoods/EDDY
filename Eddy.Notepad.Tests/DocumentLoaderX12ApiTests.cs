using Eddy.Core;
using Eddy.Core.Validation;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
using Eddy.x12.Models.v4010;

namespace Eddy.Notepad.Tests;

/// <summary>
/// Exercises the loader against the multi-interchange, lenient-parsing behaviour of the hardened Eddy.x12
/// API: several interchanges/groups, orphan segments, unknown segments, structural mismatches and source
/// spans. See README.md, "Loader contract".
/// </summary>
public class DocumentLoaderX12ApiTests
{
    private readonly DocumentLoader _loader = new();

    [Fact]
    public void Two_interchange_three_group_document_has_the_right_tree_shape_raw_line_count_and_status_text()
    {
        var data =
            NotepadTestFixtures.Isa("000000001") +
            NotepadTestFixtures.Gs("2100") + NotepadTestFixtures.Section("0001") + NotepadTestFixtures.Ge(1, "2100") +
            NotepadTestFixtures.Gs("2200") + NotepadTestFixtures.Section("0002") + NotepadTestFixtures.Ge(1, "2200") +
            NotepadTestFixtures.Iea(2, "000000001") +
            NotepadTestFixtures.Isa("000000002") +
            NotepadTestFixtures.Gs("3100") + NotepadTestFixtures.Section("0001") + NotepadTestFixtures.Ge(1, "3100") +
            NotepadTestFixtures.Iea(1, "000000002");

        var document = _loader.Load(data, "multi", null);

        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.Equal("X12 004010", document.Format);

        Assert.Equal(2, document.Nodes.Count);
        Assert.All(document.Nodes, n => Assert.Equal(NodeKind.Interchange, n.Kind));

        Assert.Equal(2, document.Nodes[0].Children.Count);
        Assert.Single(document.Nodes[1].Children);
        Assert.All(document.Nodes.SelectMany(i => i.Children), g => Assert.Equal(NodeKind.FunctionalGroup, g.Kind));

        var transactionSets = document.Nodes.SelectMany(i => i.Children).SelectMany(g => g.Children).ToList();
        Assert.Equal(3, transactionSets.Count);
        Assert.All(transactionSets, t => Assert.Equal(NodeKind.TransactionSet, t.Kind));

        // Every ISA/GS/ST/body-segment/SE/GE/IEA is one raw line: 2 interchanges x (ISA + IEA) plus
        // 3 groups x (GS + GE) plus 3 sections x (ST + 6 body segments + SE).
        var expectedRawLines = 2 * 2 + 3 * 2 + 3 * (2 + NotepadTestFixtures.GoodBody.Length);
        Assert.Equal(expectedRawLines, document.RawLines.Count);

        var vm = new MainWindowViewModel(_loader, new NullFilePicker());
        vm.OpenText(data, "multi", null);
        Assert.Equal("X12 004010 · 2 interchanges · 3 groups · 3 transaction sets · 0 errors", vm.StatusText);
    }

    [Fact]
    public void Segment_between_GE_and_IEA_yields_a_warning_and_an_orphan_node_under_the_interchange()
    {
        var data =
            NotepadTestFixtures.Isa("000000001") +
            NotepadTestFixtures.Gs("2100") + NotepadTestFixtures.Section("0001") + NotepadTestFixtures.Ge(1, "2100") +
            "REF*XX*ORPHAN~\n" +
            NotepadTestFixtures.Iea(1, "000000001");

        var document = _loader.Load(data, "orphan", null);

        // SegmentOutsideTransactionSet is a warning, not an error: the document is still "valid".
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.Equal(1, document.WarningCount);
        Assert.Equal(0, document.ErrorCount);

        var interchange = Assert.Single(document.Nodes);
        var orphan = Assert.Single(interchange.Children, c => c.Kind == NodeKind.Segment);
        Assert.Equal("REF", orphan.Code);
        Assert.StartsWith("(outside any transaction set)", orphan.Subtitle);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Warning, diagnostic.Severity);
        Assert.Same(orphan, diagnostic.Node);
    }

    [Fact]
    public void SE_segment_count_mismatch_puts_the_diagnostic_on_the_transaction_set_node()
    {
        var data =
            NotepadTestFixtures.Isa("000000001") +
            NotepadTestFixtures.Gs("2100") +
            NotepadTestFixtures.St("0001") +
            "N1*PF*XYZ CORP*9*9995555500000~\n" +
            NotepadTestFixtures.Se(99, "0001") + // wrong: should be 3 (ST + N1 + SE)
            NotepadTestFixtures.Ge(1, "2100") +
            NotepadTestFixtures.Iea(1, "000000001");

        var document = _loader.Load(data, "se-mismatch", null);

        Assert.False(document.IsValid);
        var transactionSet = document.Nodes[0].Children[0].Children[0];
        Assert.Equal(NodeKind.TransactionSet, transactionSet.Kind);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Contains("Number of Included Segments", diagnostic.Message);
        Assert.Same(transactionSet, diagnostic.Node);
        Assert.True(transactionSet.HasErrors);
    }

    [Fact]
    public void HasError_matches_by_position_only_when_the_error_names_no_property()
    {
        // Structural checks may tag only ElementPosition; those match by position. An error that names a
        // property applies to that property alone, so a position-only match must not tint another element
        // (in particular not the first component of every composite, whose positions restart at 1).
        var n1 = new N1_Name { EntityIdentifierCode = "PF", Name = "XYZ CORP" };
        var reader = new SegmentElementReader(Eddy.Core.Metadata.MetadataCatalog.Default);

        var positionOnly = new List<Error> { new(ErrorCodes.Required, "structural") { PropertyName = null, ElementPosition = 1 } };
        var elements = reader.Read(n1, "N1", positionOnly);
        Assert.True(elements.Single(e => e.Reference == "N101").HasError);
        Assert.False(elements.Single(e => e.Reference == "N102").HasError);

        var namedElsewhere = new List<Error> { new(ErrorCodes.Required, "named") { PropertyName = "Name", ElementPosition = 1 } };
        elements = reader.Read(n1, "N1", namedElsewhere);
        Assert.False(elements.Single(e => e.Reference == "N101").HasError);
        Assert.True(elements.Single(e => e.Reference == "N102").HasError);
    }

    [Fact]
    public void Tilde_terminator_followed_by_newlines_gives_raw_text_matching_the_parser_source_offsets()
    {
        var data = NotepadTestFixtures.SingleValidInterchange(newline: "~\n");

        var document = _loader.Load(data, "tilde", null);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));

        // Re-parse the exact text the loader normalised to, so Source offsets line up with document.RawText.
        var parsed = x12Document.Parse(document.RawText, new x12ParseOptions { Lenient = true });
        var interchange = parsed.Interchanges.Single();
        var group = interchange.FunctionalGroups.Single();
        var section = group.Sections.Single();

        void AssertLine(SegmentSource? source)
        {
            Assert.NotNull(source);
            var expected = document.RawText.Substring(source!.StartOffset, source.Length);
            Assert.Equal(source.RawText, expected);

            var rawLine = document.RawLines.Single(r => r.LineNumber == source.LineNumber);
            Assert.Equal(expected, rawLine.Text);
        }

        AssertLine(interchange.Header.Source);
        AssertLine(group.Header!.Source);
        AssertLine(section.TransactionSetHeader!.Source);
        foreach (var segment in section.Segments)
            AssertLine(((ISourceTracked)segment).Source);
        AssertLine(section.TransactionSetTrailer!.Source);
        AssertLine(group.Trailer!.Source);
        AssertLine(interchange.Trailer!.Source);
    }
}
