using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class DocumentLoaderMalformedInputTests
{
    private readonly DocumentLoader _loader = new();

    [Fact]
    public void Leading_BOM_and_whitespace_before_ISA_still_parses()
    {
        var clean = SampleDocuments.GetText("Sample-204-LoadTender");
        var dirty = "﻿   \r\n\t  " + clean;

        var document = _loader.Load(dirty, "dirty", null);

        Assert.Equal("X12 004010", document.Format);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.Single(document.Nodes);
        Assert.Equal(1, document.Nodes[0].LineNumber);
    }

    [Fact]
    public void Text_starting_with_UNB_is_reported_as_unsupported_EDIFACT()
    {
        var text = "UNB+UNOA:1+SENDER+RECEIVER+240101:1200+1'";

        var document = _loader.Load(text, "edifact", null);

        Assert.Equal("EDIFACT", document.Format);
        Assert.Empty(document.Nodes);
        Assert.NotEmpty(document.RawLines);
        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Info, diagnostic.Severity);
    }

    [Fact]
    public void Unrecognised_text_is_reported_as_Unknown()
    {
        var document = _loader.Load("hello", "unknown", null);

        Assert.Equal("Unknown", document.Format);
        Assert.Empty(document.Nodes);
        Assert.Single(document.RawLines);
        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Info, diagnostic.Severity);
    }

    [Fact]
    public void ISA_that_is_too_short_yields_an_error_diagnostic_without_throwing()
    {
        var text = "ISA*01*000";

        var document = _loader.Load(text, "short-isa", null);

        Assert.Empty(document.Nodes);
        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(1, diagnostic.LineNumber);
        Assert.Equal("ISA", diagnostic.SegmentCode);
    }

    [Fact]
    public void Unknown_segment_code_becomes_a_segment_node_and_the_rest_of_the_document_still_parses()
    {
        // The old x12Document.Parse() threw on an unrecognised segment code, so the loader could only
        // report a bare diagnostic with no tree. The hardened parser's lenient mode instead turns it into
        // an Unknown_Segment and keeps going: the loader now shows a tree with a node for it, and the rest
        // of the document (the following SE/GE/IEA trailers included) parses normally.
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

        Assert.Single(document.Nodes);
        var transactionSet = document.Nodes[0].Children[0].Children[0];
        var unknown = Assert.Single(transactionSet.Children);
        Assert.Equal(NodeKind.Segment, unknown.Kind);
        Assert.Equal("ZZZ Unknown segment", unknown.Title);
        Assert.Equal(4, unknown.LineNumber);

        var diagnostic = Assert.Single(document.Diagnostics);
        Assert.Equal(DiagnosticSeverity.Error, diagnostic.Severity);
        Assert.Equal(4, diagnostic.LineNumber);
        Assert.Contains("ZZZ", diagnostic.Message);
        Assert.Same(unknown, diagnostic.Node);
    }

    [Fact]
    public void Loader_never_throws_for_empty_text()
    {
        var document = _loader.Load("", "empty", null);

        Assert.Equal("Unknown", document.Format);
        Assert.Empty(document.Nodes);
    }
}
