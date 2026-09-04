using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>Edit &gt; Find (Ctrl+F, F3/Shift+F3) and File &gt; Export, at the MainWindowViewModel level.
/// Matching itself is covered in DocumentSearchTests.cs; serialisation in DocumentExporterTests.cs.</summary>
public class MainWindowViewModelSearchAndExportTests
{
    private sealed class FakeFilePicker : IFilePicker
    {
        public string? NextPath { get; set; }

        public Task<string?> PickFileAsync() => Task.FromResult(NextPath);

        public Task<string?> PickFileAsync(string title, string[] patterns) => Task.FromResult(NextPath);

        public Task<string?> PickSaveFileAsync(string title, string suggestedFileName) => Task.FromResult(NextPath);
    }

    [Fact]
    public void Setting_the_search_query_selects_the_first_match_and_reports_the_match_counter()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

        vm.OpenSearchCommand.Execute(null);
        Assert.True(vm.IsSearchVisible);

        vm.SearchQuery = "xyz";

        Assert.Equal("1 of 1", vm.SearchStatusText);
        Assert.Equal("N1", vm.ActiveDocument!.SelectedNode!.Code);
    }

    [Fact]
    public void FindNext_and_FindPrevious_cycle_through_matches_in_document_order()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

        // Five L11 segments in the 204 sample -- see DocumentSearchTests.Results_are_returned_in_document_order.
        vm.SearchQuery = "l11";
        Assert.Equal("1 of 5", vm.SearchStatusText);
        var first = vm.ActiveDocument!.SelectedNode;

        for (var expected = 2; expected <= 5; expected++)
        {
            vm.FindNextCommand.Execute(null);
            Assert.Equal(expected, vm.SearchCurrentIndex);
            Assert.NotSame(first, vm.ActiveDocument.SelectedNode);
        }

        // Wraps back to the first match.
        vm.FindNextCommand.Execute(null);
        Assert.Equal(1, vm.SearchCurrentIndex);
        Assert.Same(first, vm.ActiveDocument.SelectedNode);

        // And Previous wraps the other way.
        vm.FindPreviousCommand.Execute(null);
        Assert.Equal(5, vm.SearchCurrentIndex);
    }

    [Fact]
    public void No_matches_reports_a_clear_status_and_does_not_change_the_selection()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var before = vm.ActiveDocument!.SelectedNode;

        vm.SearchQuery = "no-such-text-anywhere-in-this-document";

        Assert.Equal("No matches", vm.SearchStatusText);
        Assert.Same(before, vm.ActiveDocument.SelectedNode);
    }

    [Fact]
    public void CloseSearch_hides_the_bar_and_clears_the_query()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        vm.OpenSearchCommand.Execute(null);
        vm.SearchQuery = "xyz";

        vm.CloseSearchCommand.Execute(null);

        Assert.False(vm.IsSearchVisible);
        Assert.Equal("", vm.SearchQuery);
    }

    [Fact]
    public async Task ExportTextCommand_writes_utf8_without_a_bom_to_the_picked_path()
    {
        var path = Path.Combine(Path.GetTempPath(), $"eddy-notepad-export-{Guid.NewGuid():N}.txt");
        try
        {
            var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker { NextPath = path });
            vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

            await vm.ExportTextCommand.ExecuteAsync(null);

            Assert.True(File.Exists(path));
            var bytes = await File.ReadAllBytesAsync(path);
            Assert.False(bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF);
            Assert.Contains("Exported", vm.StatusText);
        }
        finally
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }

    [Fact]
    public async Task ExportJsonCommand_and_ExportCsvCommand_write_parseable_content()
    {
        var jsonPath = Path.Combine(Path.GetTempPath(), $"eddy-notepad-export-{Guid.NewGuid():N}.json");
        var csvPath = Path.Combine(Path.GetTempPath(), $"eddy-notepad-export-{Guid.NewGuid():N}.csv");
        try
        {
            var picker = new FakeFilePicker();
            var vm = new MainWindowViewModel(new DocumentLoader(), picker);
            vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

            picker.NextPath = jsonPath;
            await vm.ExportJsonCommand.ExecuteAsync(null);
            Assert.True(File.Exists(jsonPath));
            using (var doc = System.Text.Json.JsonDocument.Parse(await File.ReadAllTextAsync(jsonPath)))
                Assert.True(doc.RootElement.TryGetProperty("interchanges", out _));

            picker.NextPath = csvPath;
            await vm.ExportCsvCommand.ExecuteAsync(null);
            Assert.True(File.Exists(csvPath));
            Assert.StartsWith("line,segment,ref,name,value,de,type,req,meaning", await File.ReadAllTextAsync(csvPath));
        }
        finally
        {
            if (File.Exists(jsonPath))
                File.Delete(jsonPath);
            if (File.Exists(csvPath))
                File.Delete(csvPath);
        }
    }

    [Fact]
    public async Task Export_cancelled_by_the_picker_leaves_status_text_unchanged()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker { NextPath = null });
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var before = vm.StatusText;

        await vm.ExportTextCommand.ExecuteAsync(null);

        Assert.Equal(before, vm.StatusText);
    }
}
