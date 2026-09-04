using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

/// <summary>Editing, undo/redo, save and acknowledgment generation as seen through MainWindowViewModel --
/// the reload-and-swap path every edit goes through (see ApplyTextEdit in MainWindowViewModel.cs).</summary>
public class MainWindowViewModelEditingTests : IDisposable
{
    private readonly List<string> _tempFiles = new();

    public void Dispose()
    {
        foreach (var path in _tempFiles)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }

    private string NewTempPath()
    {
        var path = Path.Combine(Path.GetTempPath(), $"eddy-notepad-edit-test-{Guid.NewGuid():N}.edi");
        _tempFiles.Add(path);
        return path;
    }

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

    [Fact]
    public void SetElementValue_marks_the_document_dirty_and_Undo_restores_it()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var document = vm.ActiveDocument!;
        var original = document.RawText;
        Assert.False(document.IsDirty);
        Assert.False(document.CanUndo);

        var n1 = FindNode(document.Nodes, n => n.Code == "N1");
        var n102 = n1.Elements.Single(e => e.Reference == "N102");
        document.SelectedNode = n1;

        vm.SetElementValue(document, n1, n102, "ACME CORP");

        var edited = vm.ActiveDocument!;
        Assert.NotSame(document, edited);
        Assert.True(edited.IsDirty);
        Assert.True(edited.CanUndo);
        Assert.False(edited.CanRedo);
        Assert.Contains("N1*PF*ACME CORP*9*9995555500000", edited.RawText);
        Assert.Equal("N1", edited.SelectedNode?.Code);

        vm.UndoCommand.Execute(null);

        var reverted = vm.ActiveDocument!;
        Assert.False(reverted.IsDirty);
        Assert.False(reverted.CanUndo);
        Assert.True(reverted.CanRedo);
        Assert.Equal(original, reverted.RawText);

        vm.RedoCommand.Execute(null);

        var redone = vm.ActiveDocument!;
        Assert.True(redone.IsDirty);
        Assert.Contains("N1*PF*ACME CORP*9*9995555500000", redone.RawText);
    }

    [Fact]
    public void SetElementValue_with_an_unconvertible_value_reports_an_error_and_leaves_the_document_unchanged()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var document = vm.ActiveDocument!;

        var s5 = FindNode(document.Nodes, n => n.Code == "S5");
        var stopSequence = s5.Elements.Single(e => e.PropertyName == "StopSequenceNumber");

        vm.SetElementValue(document, s5, stopSequence, "not-a-number");

        Assert.Same(document, vm.ActiveDocument);
        Assert.False(document.IsDirty);
        Assert.Contains("not-a-number", vm.StatusText);
    }

    [Fact]
    public void DeleteSegment_recalculates_control_counts_automatically()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var document = vm.ActiveDocument!;
        Assert.True(vm.FixControlCountsAutomatically);

        var l11 = FindNode(document.Nodes, n => n.Code == "L11");
        document.SelectedNode = l11;

        vm.DeleteSegmentCommand.Execute(null);

        var edited = vm.ActiveDocument!;
        Assert.True(edited.IsDirty);
        Assert.True(edited.IsValid);
        Assert.Contains("SE*15*0001", edited.RawText);
    }

    [Fact]
    public void InsertSegment_after_B2A_recalculates_control_counts_automatically()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        var document = vm.ActiveDocument!;

        var b2a = FindNode(document.Nodes, n => n.Code == "B2A");
        document.SelectedNode = b2a;

        vm.InsertSegment(before: false, "NTE**HELLO");

        var edited = vm.ActiveDocument!;
        Assert.True(edited.IsValid, string.Join("; ", edited.Diagnostics.Select(d => d.Message)));
        Assert.Contains("SE*17*0001", edited.RawText);

        var newNte = FindNode(edited.Nodes, n => n.Code == "NTE" && n.Elements.Single(e => e.Reference == "NTE02").Value == "HELLO");
        Assert.Equal(6, newNte.LineNumber);
    }

    [Fact]
    public void RecalculateControlCountsCommand_reports_the_number_of_fixed_values()
    {
        var brokenText = SampleDocuments.GetText("Sample-204-LoadTender").Replace("SE*16*0001", "SE*99*0001");
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenText(brokenText, "broken", null);

        vm.RecalculateControlCountsCommand.Execute(null);

        Assert.Contains("Updated 1 trailer value", vm.StatusText);
        Assert.True(vm.ActiveDocument!.IsDirty);
        Assert.Contains("SE*16*0001", vm.ActiveDocument!.RawText);
    }

    [Fact]
    public void RecalculateControlCountsCommand_reports_counts_already_correct_when_nothing_changed()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");

        vm.RecalculateControlCountsCommand.Execute(null);

        Assert.Contains("Counts already correct", vm.StatusText);
        Assert.False(vm.ActiveDocument!.IsDirty);
    }

    [Fact]
    public async Task SaveAsync_writes_the_exact_text_to_the_documents_file_and_clears_dirty()
    {
        var path = NewTempPath();
        var original = SampleDocuments.GetText("Sample-204-LoadTender");
        await File.WriteAllTextAsync(path, original);

        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        await vm.OpenPathAsync(path);
        var document = vm.ActiveDocument!;

        var n1 = FindNode(document.Nodes, n => n.Code == "N1");
        var n102 = n1.Elements.Single(e => e.Reference == "N102");
        vm.SetElementValue(document, n1, n102, "ACME CORP");
        var edited = vm.ActiveDocument!;
        Assert.True(edited.IsDirty);

        await vm.SaveCommand.ExecuteAsync(null);

        Assert.False(vm.ActiveDocument!.IsDirty);
        var onDisk = await File.ReadAllTextAsync(path);
        Assert.Equal(edited.RawText, onDisk);
        Assert.Contains("N1*PF*ACME CORP*9*9995555500000", onDisk);
    }

    [Fact]
    public async Task SaveAsAsync_uses_the_file_pickers_path_and_adopts_it()
    {
        var path = NewTempPath();
        var picker = new FakeFilePicker { NextSavePath = path };
        var vm = new MainWindowViewModel(new DocumentLoader(), picker);
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        Assert.Null(vm.ActiveDocument!.FilePath);

        await vm.SaveAsCommand.ExecuteAsync(null);

        Assert.Equal(path, vm.ActiveDocument!.FilePath);
        Assert.False(vm.ActiveDocument!.IsDirty);
        var onDisk = await File.ReadAllTextAsync(path);
        Assert.Equal(vm.ActiveDocument!.RawText, onDisk);
    }

    [Fact]
    public void GenerateFunctionalAcknowledgment_opens_a_tab_with_AK3_and_AK4_nodes()
    {
        const string originalLine = "N1*PF*XYZ CORP*9*9995555500000";
        const string plantedErrorLine = "N1**XYZ CORP*9*9995555500000"; // blanks N101, a required element
        var text = SampleDocuments.GetText("Sample-204-LoadTender").Replace(originalLine, plantedErrorLine);

        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenText(text, "planted-204", null);
        Assert.True(vm.GenerateFunctionalAcknowledgmentCommand.CanExecute(null));

        vm.GenerateFunctionalAcknowledgmentCommand.Execute(null);

        Assert.Equal(2, vm.Documents.Count);
        var ackTab = vm.ActiveDocument!;
        Assert.StartsWith("997 for", ackTab.DisplayName);
        Assert.Null(ackTab.FilePath);
        Assert.StartsWith("X12", ackTab.Format);

        var ak3 = FindNodeOrNull(ackTab.Nodes, n => n.Code == "AK3");
        var ak4 = FindNodeOrNull(ackTab.Nodes, n => n.Code == "AK4");
        Assert.NotNull(ak3);
        Assert.NotNull(ak4);
    }

    [Fact]
    public void GenerateImplementationAcknowledgment_is_unavailable_for_4010_and_available_for_5010()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenSampleCommand.Execute("Sample-204-LoadTender");
        Assert.False(vm.GenerateImplementationAcknowledgmentCommand.CanExecute(null));

        var text5010 = SampleDocuments.GetText("Sample-204-LoadTender").Replace("*X*004010", "*X*005010");
        vm.OpenText(text5010, "204-5010", null);
        Assert.True(vm.GenerateImplementationAcknowledgmentCommand.CanExecute(null));

        vm.GenerateImplementationAcknowledgmentCommand.Execute(null);

        var ackTab = vm.ActiveDocument!;
        Assert.StartsWith("999 for", ackTab.DisplayName);
        Assert.StartsWith("X12", ackTab.Format);
    }

    [Fact]
    public void Acknowledgment_commands_are_disabled_for_EDIFACT_documents()
    {
        var vm = new MainWindowViewModel(new DocumentLoader(), new FakeFilePicker());
        vm.OpenText(SampleDocuments.GetText("Sample-INVOIC-Invoice"), "Sample-INVOIC-Invoice", null);

        Assert.False(vm.GenerateFunctionalAcknowledgmentCommand.CanExecute(null));
        Assert.False(vm.GenerateImplementationAcknowledgmentCommand.CanExecute(null));
    }

    private sealed class FakeFilePicker : IFilePicker
    {
        public string? NextPath { get; set; }
        public string? NextSavePath { get; set; }

        public Task<string?> PickFileAsync() => Task.FromResult(NextPath);

        public Task<string?> PickFileAsync(string title, string[] patterns) => Task.FromResult(NextPath);

        public Task<string?> PickSaveFileAsync(string title, string suggestedFileName) => Task.FromResult(NextSavePath);
    }
}
