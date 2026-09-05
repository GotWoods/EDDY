using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>Exercises Services/DocumentEditor.cs directly (no MainWindowViewModel, no UI): every edit is a
/// text transformation over an already-loaded DocumentViewModel, so these tests load a document once with
/// the real DocumentLoader, ask DocumentEditor for the new text, and reload that text to see the result --
/// exactly the round trip MainWindowViewModel.ApplyTextEdit performs.</summary>
public class DocumentEditorTests
{
    private readonly DocumentLoader _loader = new();
    private readonly DocumentEditor _editor = new();

    private static DocumentNodeViewModel FindNode(IEnumerable<DocumentNodeViewModel> nodes, Func<DocumentNodeViewModel, bool> match)
    {
        foreach (var node in nodes)
        {
            if (match(node))
                return node;
            var found = FindNodeOrNull(node.Children, match);
            if (found is not null)
                return found;
        }

        throw new InvalidOperationException("No matching node found.");
    }

    private static DocumentNodeViewModel? FindNodeOrNull(IEnumerable<DocumentNodeViewModel> nodes, Func<DocumentNodeViewModel, bool> match)
    {
        foreach (var node in nodes)
        {
            if (match(node))
                return node;
            var found = FindNodeOrNull(node.Children, match);
            if (found is not null)
                return found;
        }

        return null;
    }

    private static List<DocumentNodeViewModel> FindAllNodes(IEnumerable<DocumentNodeViewModel> nodes, Func<DocumentNodeViewModel, bool> match)
    {
        var result = new List<DocumentNodeViewModel>();
        foreach (var node in nodes)
        {
            if (match(node))
                result.Add(node);
            result.AddRange(FindAllNodes(node.Children, match));
        }

        return result;
    }

    [Fact]
    public void ReplaceElementValue_on_N102_changes_only_that_segments_bytes()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var n1 = FindNode(document.Nodes, n => n.Code == "N1");
        var n102 = n1.Elements.Single(e => e.Reference == "N102");
        Assert.Equal("XYZ CORP", n102.Value);

        const string originalLine = "N1*PF*XYZ CORP*9*9995555500000";
        const string expectedLine = "N1*PF*ACME CORP*9*9995555500000";
        Assert.Contains(originalLine, document.RawText);

        var newText = _editor.ReplaceElementValue(document, n1, n102, "ACME CORP");

        Assert.Contains(expectedLine, newText);
        Assert.DoesNotContain(originalLine, newText);

        // Everything before and after the changed segment is byte-for-byte identical (compared against
        // document.RawText, the loader's normalised text -- what ReplaceElementValue actually edits).
        var changeIndex = document.RawText.IndexOf(originalLine, StringComparison.Ordinal);
        var suffix = document.RawText[(changeIndex + originalLine.Length)..];
        Assert.Equal(document.RawText[..changeIndex], newText[..changeIndex]);
        Assert.EndsWith(suffix, newText);

        var reloaded = _loader.Load(newText, "Sample-204-LoadTender", null);
        var reloadedN1 = FindNode(reloaded.Nodes, n => n.Code == "N1");
        Assert.Equal("ACME CORP", reloadedN1.Elements.Single(e => e.Reference == "N102").Value);
        Assert.True(reloaded.IsValid);
    }

    [Fact]
    public void ReplaceElementValue_on_a_NAD_C082_component_escapes_a_plus_in_the_new_value()
    {
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice");
        var document = _loader.Load(text, "Sample-INVOIC-Invoice", null);

        var nad = FindAllNodes(document.Nodes, n => n.Code == "NAD")
            .Single(n => n.Elements.Single(e => e.Reference == "NAD01").Value == "BY");
        var c082 = nad.Elements.Single(e => e.Reference == "NAD02");
        Assert.True(c082.IsComposite);
        var partyId = c082.Components.Single(e => e.Reference == "NAD0201");
        Assert.Equal("5412345678915", partyId.Value);

        var newText = _editor.ReplaceElementValue(document, nad, partyId, "54123+45678915");

        // The release character ('?', per the sample's UNA) escapes the literal '+' so it is not mistaken
        // for the element separator when the line is re-parsed.
        Assert.Contains("NAD+BY+54123?+45678915::9++GLOBAL IMPORT CO+456 OAK AVE+PARIS++75001+FR", newText);

        var reloaded = _loader.Load(newText, "Sample-INVOIC-Invoice", null);
        var reloadedNad = FindAllNodes(reloaded.Nodes, n => n.Code == "NAD")
            .Single(n => n.Elements.Single(e => e.Reference == "NAD01").Value == "BY");
        var reloadedPartyId = reloadedNad.Elements.Single(e => e.Reference == "NAD02").Components.Single(e => e.Reference == "NAD0201");
        Assert.Equal("54123+45678915", reloadedPartyId.Value);
    }

    [Fact]
    public void ReplaceElementValue_on_ISA13_rewrites_the_ISA_line_at_the_same_fixed_width()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var isa = document.Nodes[0];
        var isa13 = isa.Elements.Single(e => e.PropertyName == "InterchangeControlNumber");
        Assert.Equal("3438", isa13.Value); // ISA has no [Position] metadata, so the grid shows the raw int, not the padded field.

        var originalIsaLine = document.RawText.Split('\n')[0];

        var newText = _editor.ReplaceElementValue(document, isa, isa13, "42");

        var newIsaLine = newText.Split('\n')[0];
        Assert.Equal(originalIsaLine.Length, newIsaLine.Length);
        Assert.Contains("*000000042*", newIsaLine);
        Assert.DoesNotContain("*000003438*", newIsaLine);

        var reloaded = _loader.Load(newText, "Sample-204-LoadTender", null);
        Assert.Equal("42", reloaded.Nodes[0].Elements.Single(e => e.PropertyName == "InterchangeControlNumber").Value);
    }

    [Fact]
    public void ReplaceElementValue_on_an_Unknown_Segment_element_rewrites_the_segment()
    {
        const string isa = "ISA*01*0000000000*01*0000000000*ZZ*ABCDEFGHIJKLMNO*ZZ*123456789012345*101127*1719*U*00401*000000001*0*P*>";
        var text = string.Join(
            "\n",
            isa,
            "GS*SM*SENDER*RECEIVER*20240101*1200*1*X*004010",
            "ST*204*0001",
            "ZZZ*1",
            "SE*3*0001",
            "GE*1*1",
            "IEA*1*000000001");

        var document = _loader.Load(text, "unknown-segment", null);
        var unknown = FindNode(document.Nodes, n => n.Title == "ZZZ Unknown segment");
        var element1 = unknown.Elements.Single(e => e.Reference == "ZZZ01");
        Assert.Equal("1", element1.Value);

        var newText = _editor.ReplaceElementValue(document, unknown, element1, "HELLO");

        Assert.Contains("ZZZ*HELLO", newText);

        var reloaded = _loader.Load(newText, "unknown-segment", null);
        var reloadedUnknown = FindNode(reloaded.Nodes, n => n.Title == "ZZZ Unknown segment");
        Assert.Equal("HELLO", reloadedUnknown.Elements.Single(e => e.Reference == "ZZZ01").Value);
    }

    [Fact]
    public void RemoveSegment_then_recalculating_counts_yields_zero_diagnostics_and_one_fewer_SE_count()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);
        Assert.Contains("SE*16*0001", text);

        var firstL11 = FindNode(document.Nodes, n => n.Code == "L11");

        var afterRemove = _editor.RemoveSegment(document, firstL11);
        Assert.DoesNotContain("L11*NONPRIMARY*OK", afterRemove);

        var result = DocumentEditor.RecalculateCounts(afterRemove, document.Format);
        Assert.Contains(result.Changes, c => c.Trailer == "SE" && c.OldValue == "16" && c.NewValue == "15");

        var reloaded = _loader.Load(result.Text, "Sample-204-LoadTender", null);
        Assert.True(reloaded.IsValid, string.Join("; ", reloaded.Diagnostics.Select(d => d.Message)));
        Assert.Equal(0, reloaded.ErrorCount);
        Assert.Contains("SE*15*0001", result.Text);
    }

    [Fact]
    public void InsertSegmentAfter_places_the_new_segment_right_after_the_target()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var b2a = FindNode(document.Nodes, n => n.Code == "B2A");
        Assert.Equal(5, b2a.LineNumber);

        var afterInsert = _editor.InsertSegmentAfter(document, b2a, "NTE**HELLO");
        var result = DocumentEditor.RecalculateCounts(afterInsert, document.Format);

        Assert.Contains(result.Changes, c => c.Trailer == "SE" && c.OldValue == "16" && c.NewValue == "17");

        var reloaded = _loader.Load(result.Text, "Sample-204-LoadTender", null);
        Assert.True(reloaded.IsValid, string.Join("; ", reloaded.Diagnostics.Select(d => d.Message)));

        var newNte = FindAllNodes(reloaded.Nodes, n => n.Code == "NTE")
            .Single(n => n.Elements.Single(e => e.Reference == "NTE02").Value == "HELLO");
        Assert.Equal(6, newNte.LineNumber);
        Assert.Contains("SE*17*0001", result.Text);
    }

    [Fact]
    public void InsertSegment_rejects_text_containing_the_terminator()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);
        var b2a = FindNode(document.Nodes, n => n.Code == "B2A");

        Assert.Throws<DocumentEditorException>(() => _editor.InsertSegmentAfter(document, b2a, "NTE**HELLO\n"));
    }

    [Fact]
    public void RemoveSegment_rejects_an_envelope_node()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        Assert.Throws<DocumentEditorException>(() => _editor.RemoveSegment(document, document.Nodes[0]));
    }

    [Fact]
    public void RecalculateCounts_on_a_hand_broken_SE_count_reports_one_change()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender").Replace("SE*16*0001", "SE*99*0001");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var result = _editor.RecalculateCounts(document);

        var change = Assert.Single(result.Changes);
        Assert.Equal("SE", change.Trailer);
        Assert.Equal("99", change.OldValue);
        Assert.Equal("16", change.NewValue);
        Assert.Contains("SE*16*0001", result.Text);
    }

    [Fact]
    public void ReplaceElementValue_reports_a_clear_error_for_an_unconvertible_value()
    {
        var text = SampleDocuments.GetText("Sample-204-LoadTender");
        var document = _loader.Load(text, "Sample-204-LoadTender", null);

        var s5 = FindNode(document.Nodes, n => n.Code == "S5");
        var stopSequence = s5.Elements.Single(e => e.PropertyName == "StopSequenceNumber");

        var ex = Assert.Throws<DocumentEditorException>(() => _editor.ReplaceElementValue(document, s5, stopSequence, "not-a-number"));
        Assert.Contains("not-a-number", ex.Message);
    }
}
