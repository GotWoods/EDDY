using Eddy.Core;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;
using Eddy.x12;
using Eddy.x12.Models.v4010;

namespace Eddy.Notepad.Tests;

/// <summary>View &gt; Show Loops (Ctrl+L): see Services/LoopViewBuilder.cs and README.md, "Loop view".</summary>
public class LoopViewTests
{
    private readonly DocumentLoader _loader = new();

    [Fact]
    public void Sample_204_loop_view_groups_N1_N3_N4_under_an_L0100_loop_using_the_same_node_instances_as_the_flat_view()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        var transactionSet = document.Nodes[0].Children[0].Children[0];
        Assert.Equal(NodeKind.TransactionSet, transactionSet.Kind);
        Assert.True(transactionSet.HasLoopView);
        Assert.NotEmpty(transactionSet.LoopChildren);

        var l0100 = Assert.Single(transactionSet.LoopChildren, c => c.Kind == NodeKind.Loop && c.Code == "L0100");
        Assert.StartsWith("L0100", l0100.Title);

        var flatN1 = transactionSet.Children.Single(c => c.Code == "N1");
        var flatN3 = transactionSet.Children.Single(c => c.Code == "N3");
        var flatN4 = transactionSet.Children.Single(c => c.Code == "N4");

        // Same instances, not just equal-looking nodes: selection, diagnostics and the raw-line link on the
        // flat node keep working no matter which view found it.
        Assert.Same(flatN1, l0100.Children.Single(c => c.Code == "N1"));
        Assert.Same(flatN3, l0100.Children.Single(c => c.Code == "N3"));
        Assert.Same(flatN4, l0100.Children.Single(c => c.Code == "N4"));

        // The flat list is still there too, regardless of the loop view.
        Assert.Equal(14, transactionSet.Children.Count);
    }

    [Fact]
    public void An_inserted_unexpected_segment_lands_under_unmapped_segments_with_a_warning()
    {
        var data = SampleDocuments.GetText("Sample-204-LoadTender");
        var originalDoc = x12Document.Parse(data);
        Assert.True(originalDoc.IsValid, string.Join("; ", originalDoc.ValidationErrors.Select(e => e.ToString())));

        // N7 (line 12) is right after the N1/N3/N4 name loop -- insert an N9 (unexpected there) before it.
        var n7 = originalDoc.Sections[0].Segments.OfType<N7_EquipmentDetails>().Single();
        Assert.Equal(12, n7.Source.LineNumber);
        var modified = SourceEdit.InsertBefore(data, n7.Source, '\n', "N9*TN*12345");

        var document = _loader.Load(modified, "modified-204", null);

        var transactionSet = document.Nodes[0].Children[0].Children[0];
        Assert.True(transactionSet.HasLoopView);

        var unmapped = Assert.Single(transactionSet.LoopChildren, c => c.Kind == NodeKind.Loop && c.Title == "Unmapped segments");

        // Everything from the inserted N9 onward (N9, N7, S5, and the four trailing L11s -- see
        // Eddy.Tests.x12/DomainMapperDiagnosticsTests.cs) is unmapped.
        Assert.Equal(7, unmapped.Children.Count);
        var n9Node = Assert.Single(unmapped.Children, c => c.Code == "N9");
        Assert.Equal(12, n9Node.LineNumber);

        var warnings = document.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Warning).ToList();
        Assert.Equal(7, warnings.Count);

        var n9Warning = Assert.Single(warnings, w => w.SegmentCode == "N9");
        Assert.Same(n9Node, n9Warning.Node);
        Assert.Equal(12, n9Warning.LineNumber);
        Assert.Equal("Segment N9 at line 12 was not expected by the 204 structure", n9Warning.Message);

        // The warning is on the segment node's own diagnostics too, so it shows selected there as well.
        Assert.Contains(n9Warning, n9Node.Diagnostics);
    }

    [Fact]
    public void Edifact_invoic_message_has_no_loop_view()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-INVOIC-Invoice"), "Sample-INVOIC-Invoice", null);

        var message = document.Nodes[0].Children[0].Children[0];
        Assert.Equal(NodeKind.TransactionSet, message.Kind);
        Assert.False(message.HasLoopView);
        Assert.Empty(message.LoopChildren);
        Assert.NotEmpty(message.Children);
    }

    [Fact]
    public void A_transaction_set_with_no_domain_model_falls_back_to_the_flat_list_in_both_modes_with_a_subtitle_note()
    {
        // "850" is not a code either Eddy.x12.DomainModels.Transportation or .CommunicationsAndControls
        // (the only two domain model assemblies Eddy.Notepad references) has a model for.
        var body = string.Join("", NotepadTestFixtures.GoodBody.Select(l => l.Replace("~", "~\n")));
        var text =
            NotepadTestFixtures.Isa("000000001") +
            NotepadTestFixtures.Gs("2100") +
            "ST*850*0001~\n" +
            body +
            NotepadTestFixtures.Se(NotepadTestFixtures.GoodBody.Length + 2, "0001") +
            NotepadTestFixtures.Ge(1, "2100") +
            NotepadTestFixtures.Iea(1, "000000001");

        var document = _loader.Load(text, "no-model", null);

        var transactionSet = document.Nodes[0].Children[0].Children[0];
        Assert.Equal(NodeKind.TransactionSet, transactionSet.Kind);
        Assert.False(transactionSet.HasLoopView);
        Assert.Empty(transactionSet.LoopChildren);
        Assert.Contains("no loop model for 850 004010", transactionSet.Subtitle);
        Assert.Equal(NotepadTestFixtures.GoodBody.Length, transactionSet.Children.Count);

        // Both view modes show the same flat list when there's no loop view.
        transactionSet.ShowLoops = true;
        Assert.Same(transactionSet.Children, transactionSet.VisibleChildren);
        transactionSet.ShowLoops = false;
        Assert.Same(transactionSet.Children, transactionSet.VisibleChildren);
    }

    [Fact]
    public void VisibleChildren_switches_between_flat_and_loop_children_as_ShowLoops_is_set()
    {
        var document = _loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);
        var transactionSet = document.Nodes[0].Children[0].Children[0];

        Assert.Same(transactionSet.Children, transactionSet.VisibleChildren);

        document.ShowLoops = true;
        Assert.Same(transactionSet.LoopChildren, transactionSet.VisibleChildren);

        document.ShowLoops = false;
        Assert.Same(transactionSet.Children, transactionSet.VisibleChildren);
    }
}
