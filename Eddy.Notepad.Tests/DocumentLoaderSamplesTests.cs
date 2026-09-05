using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class DocumentLoaderSamplesTests
{
    private readonly DocumentLoader _loader = new();

    [Theory]
    [InlineData("Sample-204-LoadTender", 14, 20)]
    [InlineData("Sample-210-Invoice", 19, 25)]
    [InlineData("Sample-214-ShipmentStatus", 16, 22)]
    public void Sample_produces_one_interchange_group_and_transaction_set(string sampleName, int expectedSegmentCount, int expectedRawLineCount)
    {
        var text = SampleDocuments.GetText(sampleName);
        var document = _loader.Load(text, sampleName, null);

        Assert.Equal("X12 004010", document.Format);
        Assert.True(document.IsValid, string.Join("; ", document.Diagnostics.Select(d => d.Message)));
        Assert.Equal(0, document.ErrorCount);

        Assert.Equal(expectedRawLineCount, document.RawLines.Count);

        Assert.Single(document.Nodes);
        var interchange = document.Nodes[0];
        Assert.Equal(NodeKind.Interchange, interchange.Kind);
        Assert.Equal("ISA", interchange.Code);
        Assert.Equal(1, interchange.LineNumber);

        Assert.Single(interchange.Children);
        var group = interchange.Children[0];
        Assert.Equal(NodeKind.FunctionalGroup, group.Kind);
        Assert.Equal("GS", group.Code);
        Assert.Equal(2, group.LineNumber);

        Assert.Single(group.Children);
        var transactionSet = group.Children[0];
        Assert.Equal(NodeKind.TransactionSet, transactionSet.Kind);
        Assert.Equal(3, transactionSet.LineNumber);

        Assert.Equal(expectedSegmentCount, transactionSet.Children.Count);
        for (var i = 0; i < transactionSet.Children.Count; i++)
        {
            var segment = transactionSet.Children[i];
            Assert.Equal(NodeKind.Segment, segment.Kind);
            Assert.Equal(4 + i, segment.LineNumber);
        }
    }

    [Theory]
    [InlineData("Sample-204-LoadTender")]
    [InlineData("Sample-210-Invoice")]
    [InlineData("Sample-214-ShipmentStatus")]
    public void SE_GE_and_IEA_raw_lines_exist_but_are_not_segment_nodes(string sampleName)
    {
        var text = SampleDocuments.GetText(sampleName);
        var document = _loader.Load(text, sampleName, null);

        var se = document.RawLines.Single(r => r.Text.StartsWith("SE*", StringComparison.Ordinal));
        var ge = document.RawLines.Single(r => r.Text.StartsWith("GE*", StringComparison.Ordinal));
        var iea = document.RawLines.Single(r => r.Text.StartsWith("IEA*", StringComparison.Ordinal));

        // They exist as raw lines...
        Assert.NotNull(se);
        Assert.NotNull(ge);
        Assert.NotNull(iea);

        // ...but none of them was turned into a tree Segment node.
        Assert.True(se.Node is null || se.Node.Kind != NodeKind.Segment);
        Assert.True(ge.Node is null || ge.Node.Kind != NodeKind.Segment);
        Assert.True(iea.Node is null || iea.Node.Kind != NodeKind.Segment);

        // The IEA line is the very last raw line, and it is the last line in the file.
        Assert.Equal(document.RawLines[^1].LineNumber, iea.LineNumber);
    }
}
