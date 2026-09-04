using Eddy.Core.Metadata;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class MainWindowViewModelTests : IDisposable
{
    private readonly string _tempFile;

    public MainWindowViewModelTests()
    {
        _tempFile = Path.Combine(Path.GetTempPath(), $"eddy-notepad-test-{Guid.NewGuid():N}.edi");
        File.WriteAllText(_tempFile, SampleDocuments.GetText("Sample-204-LoadTender"));
    }

    public void Dispose()
    {
        if (File.Exists(_tempFile))
            File.Delete(_tempFile);
    }

    [Fact]
    public void OpenSample_adds_and_activates_a_document()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());

        Assert.False(vm.HasDocuments);

        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

        Assert.True(vm.HasDocuments);
        Assert.Single(vm.Documents);
        Assert.Same(vm.Documents[0], vm.ActiveDocument);
        Assert.Equal("Sample-204-LoadTender", vm.ActiveDocument!.DisplayName);
        Assert.Contains("X12 004010", vm.StatusText);
    }

    [Fact]
    public async Task Opening_the_same_path_twice_does_not_duplicate()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());

        await vm.OpenPathAsync(_tempFile);
        await vm.OpenPathAsync(_tempFile);

        Assert.Single(vm.Documents);
        Assert.Same(vm.Documents[0], vm.ActiveDocument);
    }

    [Fact]
    public void CloseDocument_activates_a_neighbour()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());

        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        vm.OpenSampleCommand.Execute("Sample-210-Invoice");
        vm.OpenSampleCommand.Execute("Sample-214-ShipmentStatus");

        Assert.Equal(3, vm.Documents.Count);
        var middle = vm.Documents[1];
        vm.ActiveDocument = middle;

        vm.CloseDocumentCommand.Execute(middle);

        Assert.Equal(2, vm.Documents.Count);
        Assert.DoesNotContain(middle, vm.Documents);
        Assert.NotNull(vm.ActiveDocument);
        Assert.Contains(vm.ActiveDocument, vm.Documents);
    }

    [Fact]
    public void CloseDocument_on_the_last_tab_clears_the_active_document()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

        vm.CloseDocumentCommand.Execute(vm.Documents[0]);

        Assert.Empty(vm.Documents);
        Assert.Null(vm.ActiveDocument);
        Assert.False(vm.HasDocuments);
    }

    [Fact]
    public async Task OpenPathAsync_on_a_missing_file_sets_StatusText_and_does_not_throw()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        var missingPath = Path.Combine(Path.GetTempPath(), $"does-not-exist-{Guid.NewGuid():N}.edi");

        var exception = await Record.ExceptionAsync(() => vm.OpenPathAsync(missingPath));

        Assert.Null(exception);
        Assert.False(vm.HasDocuments);
        Assert.Contains(Path.GetFileName(missingPath), vm.StatusText);
    }

    [Fact]
    public async Task LoadMetadataPackCommand_adds_a_pack_and_redescribes_the_open_document()
    {
        // A fresh, empty catalog: no D96A pack, so NAD's elements start out with no DE number at all.
        var catalog = new MetadataCatalog();
        var loader = new DocumentLoader(catalog);
        var picker = new FakeFilePicker { NextPath = Path.Combine(RepoRoot(), "metadata", "packs", "edifact-D96A.json") };
        var vm = new MainWindowViewModel(loader, picker, catalog);

        vm.OpenText(SampleDocuments.GetText("Sample-INVOIC-Invoice"), "Sample-INVOIC-Invoice", null);
        var nadBefore = FindNode(vm.ActiveDocument!.Nodes, n => n.Code == "NAD")!;
        Assert.Null(nadBefore.Elements.Single(e => e.Reference == "NAD01").DataElementNumber);

        await vm.LoadMetadataPackCommand.ExecuteAsync(null);

        Assert.Single(vm.LoadedPacks);
        Assert.Equal("EDIFACT", vm.LoadedPacks[0].Standard);
        Assert.Equal("D96A", vm.LoadedPacks[0].Version);
        Assert.Contains("metadata pack", vm.StatusText, StringComparison.OrdinalIgnoreCase);

        // The document was swapped for a freshly reloaded one, describing the same NAD segment with the
        // pack now loaded: it gains a DE number without anyone re-opening the file.
        Assert.Single(vm.Documents);
        var nadAfter = FindNode(vm.ActiveDocument!.Nodes, n => n.Code == "NAD")!;
        Assert.Equal("3035", nadAfter.Elements.Single(e => e.Reference == "NAD01").DataElementNumber);
    }

    private static DocumentNodeViewModel? FindNode(IEnumerable<DocumentNodeViewModel> nodes, Func<DocumentNodeViewModel, bool> match)
    {
        foreach (var node in nodes)
        {
            if (match(node))
                return node;
            var inChildren = FindNode(node.Children, match);
            if (inChildren is not null)
                return inChildren;
        }
        return null;
    }

    private static string RepoRoot()
    {
        var dir = AppContext.BaseDirectory;
        while (dir is not null)
        {
            if (File.Exists(Path.Combine(dir, "EDDY.sln")))
                return dir;
            dir = Path.GetDirectoryName(dir.TrimEnd(Path.DirectorySeparatorChar));
        }
        throw new InvalidOperationException("could not locate repository root (EDDY.sln) from " + AppContext.BaseDirectory);
    }

    private sealed class FakeFilePicker : IFilePicker
    {
        public string? NextPath { get; set; }

        public Task<string?> PickFileAsync() => Task.FromResult(NextPath);

        public Task<string?> PickFileAsync(string title, string[] patterns) => Task.FromResult(NextPath);
    }
}
