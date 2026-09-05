using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class DocumentViewModelSelectionTests
{
    [Fact]
    public void Selecting_a_node_selects_the_raw_line_with_the_same_line_number_and_vice_versa()
    {
        var loader = new DocumentLoader();
        var document = loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        var n1Node = document.Nodes[0].Children[0].Children[0].Children.Single(c => c.Code == "N1");
        Assert.Equal(9, n1Node.LineNumber);

        document.SelectedNode = n1Node;
        Assert.NotNull(document.SelectedRawLine);
        Assert.Equal(9, document.SelectedRawLine!.LineNumber);

        document.SelectedNode = null;
        Assert.Null(document.SelectedRawLine);

        var line10 = document.RawLines.Single(r => r.LineNumber == 10);
        document.SelectedRawLine = line10;
        Assert.NotNull(document.SelectedNode);
        Assert.Equal(10, document.SelectedNode!.LineNumber);
        Assert.Same(line10.Node, document.SelectedNode);
    }

    [Fact]
    public void SelectedElements_tracks_the_selected_node()
    {
        var loader = new DocumentLoader();
        var document = loader.Load(SampleDocuments.GetText("Sample-204-LoadTender"), "Sample-204-LoadTender", null);

        Assert.Empty(document.SelectedElements);

        var n1Node = document.Nodes[0].Children[0].Children[0].Children.Single(c => c.Code == "N1");
        document.SelectedNode = n1Node;

        Assert.Same(n1Node.Elements, document.SelectedElements);
    }
}
