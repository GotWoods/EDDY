using System.Collections.ObjectModel;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eddy.Core;
using Eddy.Core.Metadata;
using Eddy.Notepad.Services;
using Eddy.x12;
using Eddy.x12.DomainModels.CommunicationsAndControls.Acknowledgments;

namespace Eddy.Notepad.ViewModels;

/// <summary>Top level state: the open documents, the active one, and the file commands.</summary>
public sealed partial class MainWindowViewModel : ObservableObject
{
    private const string IdleStatusText = "Open an EDI file, or pick a sample from the File menu.";

    private readonly IDocumentLoader _loader;
    private readonly IFilePicker _filePicker;
    private readonly MetadataCatalog _catalog;
    private readonly DocumentEditor _editor;

    /// <summary><paramref name="catalog"/> defaults to <see cref="MetadataCatalog.Default"/>, the same
    /// catalog a parameterless <see cref="DocumentLoader"/> describes segments with; pass an explicit one
    /// (paired with a <see cref="DocumentLoader"/> built from the same catalog) to keep it isolated, e.g. in tests.</summary>
    public MainWindowViewModel(IDocumentLoader loader, IFilePicker filePicker, MetadataCatalog? catalog = null)
    {
        _loader = loader;
        _filePicker = filePicker;
        _catalog = catalog ?? MetadataCatalog.Default;
        _editor = new DocumentEditor(_catalog);
        SampleNames = SampleDocuments.GetNames();
        _statusText = WithPackSuffix(IdleStatusText);
    }

    public ObservableCollection<DocumentViewModel> Documents { get; } = new();

    /// <summary>Metadata packs loaded into the catalog, for Help &gt; Loaded Metadata. Populated with the
    /// embedded/environment packs by the host (App.axaml.cs) and appended to by <see cref="LoadMetadataPackAsync"/>.</summary>
    public ObservableCollection<PackInfoViewModel> LoadedPacks { get; } = new();

    [ObservableProperty]
    private DocumentViewModel? _activeDocument;

    [ObservableProperty]
    private string _statusText;

    /// <summary>Names of the bundled sample files, for the File > Open Sample menu.</summary>
    public IReadOnlyList<string> SampleNames { get; }

    public bool HasDocuments => Documents.Count > 0;

    /// <summary>View &gt; Fix Control Counts Automatically. When true (the default), deleting or inserting a
    /// segment on an X12 or EDIFACT document runs <see cref="DocumentEditor.RecalculateCounts(DocumentViewModel)"/>
    /// as part of the same edit.</summary>
    [ObservableProperty]
    private bool _fixControlCountsAutomatically = true;

    partial void OnActiveDocumentChanged(DocumentViewModel? value)
    {
        GenerateFunctionalAcknowledgmentCommand.NotifyCanExecuteChanged();
        GenerateImplementationAcknowledgmentCommand.NotifyCanExecuteChanged();
    }

    /// <summary>Shows the file picker and opens the chosen file.</summary>
    [RelayCommand]
    private async Task OpenFileAsync()
    {
        var path = await _filePicker.PickFileAsync();
        if (path is null)
            return;
        await OpenPathAsync(path);
    }

    /// <summary>Opens one of the bundled samples by name.</summary>
    [RelayCommand]
    private void OpenSample(string name)
    {
        OpenText(SampleDocuments.GetText(name), name, null);
    }

    [RelayCommand]
    private void CloseDocument(DocumentViewModel? document)
    {
        if (document is null)
            return;

        var index = Documents.IndexOf(document);
        if (index < 0)
            return;

        Documents.RemoveAt(index);
        OnPropertyChanged(nameof(HasDocuments));

        if (ReferenceEquals(ActiveDocument, document))
        {
            ActiveDocument = Documents.Count == 0
                ? null
                : Documents[Math.Min(index, Documents.Count - 1)];
        }

        StatusText = ActiveDocument is null
            ? WithPackSuffix(IdleStatusText)
            : WithPackSuffix(BuildStatusText(ActiveDocument));
    }

    /// <summary>Reads a file from disk and opens it as a new tab.</summary>
    public async Task OpenPathAsync(string path)
    {
        var existing = Documents.FirstOrDefault(d => d.FilePath == path);
        if (existing is not null)
        {
            ActiveDocument = existing;
            StatusText = WithPackSuffix(BuildStatusText(existing));
            return;
        }

        string text;
        try
        {
            text = await File.ReadAllTextAsync(path).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not open '{Path.GetFileName(path)}': {ex.Message}";
            return;
        }

        OpenText(text, Path.GetFileName(path), path);
    }

    /// <summary>Parses text into a document, adds it to the tabs and activates it.</summary>
    public void OpenText(string text, string displayName, string? filePath)
    {
        var document = _loader.Load(text, displayName, filePath);
        Documents.Add(document);
        OnPropertyChanged(nameof(HasDocuments));
        ActiveDocument = document;
        document.SelectedNode = InitialSelection(document);
        StatusText = WithPackSuffix(BuildStatusText(document));
    }

    /// <summary>Shows the file picker and loads the chosen metadata pack into the catalog, then re-describes
    /// every open document so the element grid picks up its data (File &gt; Load Metadata Pack…).</summary>
    [RelayCommand]
    private async Task LoadMetadataPackAsync()
    {
        var path = await _filePicker.PickFileAsync("Load Metadata Pack", new[] { "*.json" });
        if (path is null)
            return;

        MetadataPack pack;
        try
        {
            pack = MetadataPack.Load(path);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not load metadata pack '{Path.GetFileName(path)}': {ex.Message}";
            return;
        }

        _catalog.AddPack(pack);
        LoadedPacks.Add(new PackInfoViewModel(pack.Name, pack.Standard, pack.Version, Path.GetFileName(path)));

        ReloadOpenDocuments();
        StatusText = WithPackSuffix($"Loaded metadata pack '{pack.Name}' ({pack.Standard} {pack.Version})");
    }

    /// <summary>Records a metadata pack the host already added to the catalog before this view model's
    /// window was shown (the embedded and EDDY_METADATA_PACKS packs; see App.axaml.cs), so it shows up in
    /// Help &gt; Loaded Metadata and the status bar's pack count.</summary>
    public void RegisterLoadedPack(PackInfoViewModel pack)
    {
        LoadedPacks.Add(pack);
        StatusText = ActiveDocument is null ? WithPackSuffix(IdleStatusText) : WithPackSuffix(BuildStatusText(ActiveDocument));
    }

    /// <summary>Appends "· N metadata packs" when any are loaded, matching the "· N errors" style already used here.</summary>
    private string WithPackSuffix(string status) =>
        LoadedPacks.Count > 0 ? $"{status} · {LoadedPacks.Count} metadata pack{(LoadedPacks.Count == 1 ? "" : "s")}" : status;

    /// <summary>Reparses every open document's text through the loader, so freshly loaded pack data shows
    /// up in the element grid, preserving which tab is active.</summary>
    private void ReloadOpenDocuments()
    {
        var active = ActiveDocument;
        for (var i = 0; i < Documents.Count; i++)
        {
            var document = Documents[i];
            var reloaded = _loader.Load(document.RawText, document.DisplayName, document.FilePath);
            reloaded.SelectedNode = InitialSelection(reloaded);
            Documents[i] = reloaded;

            if (ReferenceEquals(document, active))
                active = reloaded;
        }

        ActiveDocument = active;
    }

    /// <summary>The first node with a problem, else the first transaction set, else the root: something useful is always shown.</summary>
    private static DocumentNodeViewModel? InitialSelection(DocumentViewModel document)
    {
        var firstError = document.Diagnostics.FirstOrDefault(d => d.Node is not null)?.Node;
        if (firstError is not null)
            return firstError;

        var interchange = document.Nodes.FirstOrDefault();
        var group = interchange?.Children.FirstOrDefault();
        return group?.Children.FirstOrDefault() ?? group ?? interchange;
    }

    private static string BuildStatusText(DocumentViewModel document)
    {
        if (document.Nodes.Count == 0)
        {
            return document.ErrorCount > 0
                ? $"{document.Format} · {document.ErrorCount} error{(document.ErrorCount == 1 ? "" : "s")}"
                : document.Format;
        }

        // A document can have several interchanges, each with several groups (and an orphan segment can
        // sit alongside a group as a sibling Segment node), so count by Kind rather than by position.
        var interchanges = document.Nodes.Where(n => n.Kind == NodeKind.Interchange).ToList();
        var groups = interchanges.SelectMany(i => i.Children.Where(c => c.Kind == NodeKind.FunctionalGroup)).ToList();
        var transactionSetCount = groups.Sum(g => g.Children.Count(c => c.Kind == NodeKind.TransactionSet));
        var interchangeCount = interchanges.Count;
        var groupCount = groups.Count;
        var errorCount = document.ErrorCount;

        // EDIFACT's TransactionSet nodes are UNH messages, not X12 ST transaction sets, so the wording
        // matches the format: "... 1 message ..." vs "... 1 transaction set ...".
        var leafWord = document.Format.StartsWith("EDIFACT", StringComparison.Ordinal) ? "message" : "transaction set";

        return $"{document.Format} · {interchangeCount} interchange{(interchangeCount == 1 ? "" : "s")} · " +
               $"{groupCount} group{(groupCount == 1 ? "" : "s")} · " +
               $"{transactionSetCount} {leafWord}{(transactionSetCount == 1 ? "" : "s")} · " +
               $"{errorCount} error{(errorCount == 1 ? "" : "s")}";
    }

    // ==== editing: reload-and-swap, undo/redo, element/segment edits ====================================
    //
    // Every edit is a text transformation (see Services/DocumentEditor.cs): it never mutates the parsed
    // tree in place. Instead it produces new document text, which is reloaded through the same
    // IDocumentLoader used to open files and swapped into Documents at the edited document's index, with
    // its undo/redo history, dirty flag and selection (by line number, since the tree is rebuilt from
    // scratch) carried over. Swap is the one place that does this; ApplyTextEdit, Undo and Redo all go
    // through it.

    /// <summary>Reloads <paramref name="newText"/> through the loader and replaces <paramref name="oldDocument"/>
    /// in <see cref="Documents"/> at the same index (keeping it active if it was), restoring the selected
    /// node by line number. <paramref name="statusMessage"/> becomes <see cref="StatusText"/> (with the
    /// metadata pack suffix).</summary>
    private DocumentViewModel Swap(
        DocumentViewModel oldDocument,
        string displayName,
        string? filePath,
        string newText,
        IEnumerable<string> undoStack,
        IEnumerable<string> redoStack,
        string savedText,
        string statusMessage)
    {
        var index = Documents.IndexOf(oldDocument);
        if (index < 0)
            return oldDocument;

        var reloaded = _loader.Load(newText, displayName, filePath);
        reloaded.UndoStack.AddRange(undoStack);
        reloaded.RedoStack.AddRange(redoStack);
        reloaded.SavedText = savedText;
        reloaded.IsDirty = reloaded.RawText != reloaded.SavedText;

        reloaded.SelectedNode = oldDocument.SelectedNode?.LineNumber is int line
            ? FindNodeByLine(reloaded.Nodes, line) ?? InitialSelection(reloaded)
            : InitialSelection(reloaded);

        // Never replace the item in place: a Replace notification makes the tab control drop its
        // selection and push null back into ActiveDocument, which empties every pane. Insert the new
        // document beside the old one, activate it, then remove the old one, so selection stays valid.
        var wasActive = ReferenceEquals(ActiveDocument, oldDocument);
        Documents.Insert(index, reloaded);
        if (wasActive)
            ActiveDocument = reloaded;
        Documents.Remove(oldDocument);
        if (wasActive && !ReferenceEquals(ActiveDocument, reloaded))
            ActiveDocument = reloaded;

        StatusText = WithPackSuffix(statusMessage);
        return reloaded;
    }

    /// <summary>Reloads <paramref name="newText"/> as a new revision of <paramref name="document"/>: pushes
    /// its current text onto the undo stack, clears redo, marks it dirty, and swaps it in (same tab,
    /// selection restored by line number). Used by every element/segment edit and by the explicit
    /// Recalculate Control Counts command; Undo and Redo below do the equivalent for their own direction.</summary>
    public void ApplyTextEdit(DocumentViewModel document, string newText, string description)
    {
        var undo = new List<string>(document.UndoStack) { document.RawText };
        Swap(document, document.DisplayName, document.FilePath, newText, undo, Array.Empty<string>(), document.SavedText, description);
    }

    [RelayCommand]
    private void Undo()
    {
        if (ActiveDocument is not { } document || document.UndoStack.Count == 0)
            return;

        var text = document.UndoStack[^1];
        var undo = document.UndoStack.Take(document.UndoStack.Count - 1);
        var redo = new List<string>(document.RedoStack) { document.RawText };
        Swap(document, document.DisplayName, document.FilePath, text, undo, redo, document.SavedText, "Undo");
    }

    [RelayCommand]
    private void Redo()
    {
        if (ActiveDocument is not { } document || document.RedoStack.Count == 0)
            return;

        var text = document.RedoStack[^1];
        var redo = document.RedoStack.Take(document.RedoStack.Count - 1);
        var undo = new List<string>(document.UndoStack) { document.RawText };
        Swap(document, document.DisplayName, document.FilePath, text, undo, redo, document.SavedText, "Redo");
    }

    private static DocumentNodeViewModel? FindNodeByLine(IEnumerable<DocumentNodeViewModel> nodes, int lineNumber)
    {
        foreach (var node in nodes)
        {
            if (node.LineNumber == lineNumber)
                return node;

            var found = FindNodeByLine(node.Children, lineNumber);
            if (found is not null)
                return found;
        }

        return null;
    }

    /// <summary>Commits an in-place element edit (see Views/MainWindow.axaml.cs): converts and sets the
    /// value on the underlying model and applies the resulting text, or reports a clear error in
    /// <see cref="StatusText"/> and leaves the document untouched.</summary>
    public void SetElementValue(DocumentViewModel document, DocumentNodeViewModel node, ElementViewModel element, string newValue)
    {
        string newText;
        try
        {
            newText = _editor.ReplaceElementValue(document, node, element, newValue);
        }
        catch (DocumentEditorException ex)
        {
            StatusText = ex.Message;
            return;
        }

        ApplyTextEdit(document, newText, $"Updated {element.Reference}");
    }

    /// <summary>Edit &gt; Delete Segment / Delete key with the tree focused. No-op (not an error) when
    /// nothing is selected; reports a clear error for an envelope node, which cannot be deleted.</summary>
    [RelayCommand]
    private void DeleteSegment()
    {
        if (ActiveDocument is not { SelectedNode: { } node } document)
            return;

        string newText;
        try
        {
            newText = _editor.RemoveSegment(document, node);
        }
        catch (DocumentEditorException ex)
        {
            StatusText = ex.Message;
            return;
        }

        var (finalText, message) = MaybeAutoFix(document.Format, newText, $"Removed segment {node.Code}");
        ApplyTextEdit(document, finalText, message);
    }

    /// <summary>Edit &gt; Insert Segment After/Before (and the tree context menu): <paramref name="rawSegmentText"/>
    /// is the segment text the user typed, without a terminator. Called from the view after its input
    /// dialog returns non-null text.</summary>
    public void InsertSegment(bool before, string rawSegmentText)
    {
        if (ActiveDocument is not { SelectedNode: { } node } document)
            return;

        string newText;
        try
        {
            newText = before
                ? _editor.InsertSegmentBefore(document, node, rawSegmentText)
                : _editor.InsertSegmentAfter(document, node, rawSegmentText);
        }
        catch (DocumentEditorException ex)
        {
            StatusText = ex.Message;
            return;
        }

        var (finalText, message) = MaybeAutoFix(document.Format, newText, $"Inserted segment {(before ? "before" : "after")} {node.Code}");
        ApplyTextEdit(document, finalText, message);
    }

    /// <summary>When <see cref="FixControlCountsAutomatically"/> is on and the format is X12 or EDIFACT,
    /// folds a control-count recalculation into the same edit (so Delete/Insert Segment produce exactly
    /// one undo step, not two) and reports whatever it changed instead of <paramref name="fallbackMessage"/>.</summary>
    private (string Text, string Message) MaybeAutoFix(string format, string text, string fallbackMessage)
    {
        if (!FixControlCountsAutomatically)
            return (text, fallbackMessage);
        if (!format.StartsWith("X12", StringComparison.Ordinal) && !format.StartsWith("EDIFACT", StringComparison.Ordinal))
            return (text, fallbackMessage);

        var result = DocumentEditor.RecalculateCounts(text, format);
        if (result.Changes.Count == 0)
            return (text, fallbackMessage);

        return (result.Text, $"{fallbackMessage} · {DescribeRecalculation(result)}");
    }

    /// <summary>Edit &gt; Recalculate Control Counts: applies <see cref="DocumentEditor.RecalculateCounts(DocumentViewModel)"/>
    /// and reports "Updated N trailer values" or "Counts already correct", plus any missing trailers.</summary>
    [RelayCommand]
    private void RecalculateControlCounts()
    {
        if (ActiveDocument is not { } document)
            return;

        if (!document.Format.StartsWith("X12", StringComparison.Ordinal) && !document.Format.StartsWith("EDIFACT", StringComparison.Ordinal))
        {
            StatusText = WithPackSuffix("Control counts only apply to X12 or EDIFACT documents.");
            return;
        }

        var result = _editor.RecalculateCounts(document);
        var message = DescribeRecalculation(result);

        if (result.Text != document.RawText)
            ApplyTextEdit(document, result.Text, message);
        else
            StatusText = WithPackSuffix(message);
    }

    private static string DescribeRecalculation(ControlCountResult result)
    {
        var applied = result.Changes.Count(c => c.OldValue is not null);
        var missingTrailers = result.Changes.Where(c => c.OldValue is null).Select(c => c.Trailer).Distinct().ToList();

        var message = applied > 0
            ? $"Updated {applied} trailer value{(applied == 1 ? "" : "s")}"
            : "Counts already correct";

        if (missingTrailers.Count > 0)
            message += $" · missing trailer{(missingTrailers.Count == 1 ? "" : "s")}: {string.Join(", ", missingTrailers)}";

        return message;
    }

    // ==== save ============================================================================================

    /// <summary>File &gt; Save (Ctrl+S): writes the document's text to its FilePath, UTF-8 without a BOM, with
    /// no newline changes. A document with no FilePath yet (a sample, or a generated acknowledgment tab)
    /// falls back to Save As.</summary>
    [RelayCommand]
    private async Task SaveAsync()
    {
        if (ActiveDocument is not { } document)
            return;

        if (document.FilePath is null)
        {
            await SaveAsAsync();
            return;
        }

        try
        {
            await WriteFileAsync(document.FilePath, document.RawText);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not save '{document.DisplayName}': {ex.Message}";
            return;
        }

        document.SavedText = document.RawText;
        document.IsDirty = false;
        StatusText = WithPackSuffix($"Saved {document.DisplayName}");
    }

    /// <summary>File &gt; Save As… (Ctrl+Shift+S): asks the file picker for a path, writes the document's
    /// text there, and adopts that path/name for future Ctrl+S saves.</summary>
    [RelayCommand]
    private async Task SaveAsAsync()
    {
        if (ActiveDocument is not { } document)
            return;

        var suggestedName = document.FilePath is not null ? Path.GetFileName(document.FilePath) : document.DisplayName + ".edi";
        var path = await _filePicker.PickSaveFileAsync("Save EDI File", suggestedName);
        if (path is null)
            return;

        try
        {
            await WriteFileAsync(path, document.RawText);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not save '{Path.GetFileName(path)}': {ex.Message}";
            return;
        }

        Swap(document, Path.GetFileName(path), path, document.RawText,
            document.UndoStack, document.RedoStack, document.RawText, $"Saved {Path.GetFileName(path)}");
    }

    private static Task WriteFileAsync(string path, string text) =>
        File.WriteAllTextAsync(path, text, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

    // ==== acknowledgments =================================================================================

    public bool CanGenerateFunctionalAcknowledgment =>
        ActiveDocument is { } document && document.Format.StartsWith("X12", StringComparison.Ordinal);

    /// <summary>Tools &gt; Generate 997: parses the active document leniently and opens the resulting 997
    /// Functional Acknowledgment as a new, unsaved tab. Disabled for EDIFACT and Unknown documents.</summary>
    [RelayCommand(CanExecute = nameof(CanGenerateFunctionalAcknowledgment))]
    private void GenerateFunctionalAcknowledgment()
    {
        if (ActiveDocument is not { } document)
            return;

        string text;
        try
        {
            var parsed = x12Document.Parse(document.RawText, new x12ParseOptions { Lenient = true });
            text = new FunctionalAcknowledgmentBuilder().Build997Text(parsed);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not generate a 997 for '{document.DisplayName}': {ex.Message}";
            return;
        }

        OpenText(text, $"997 for {document.DisplayName}", null);
        StatusText = WithPackSuffix($"Generated 997 for {document.DisplayName}");
    }

    public bool CanGenerateImplementationAcknowledgment =>
        ActiveDocument is { } document
        && document.Format.StartsWith("X12", StringComparison.Ordinal)
        && IsVersion5010OrHigher(FirstGroupVersion(document.RawText));

    /// <summary>Tools &gt; Generate 999: same as Generate 997, but only enabled when the active document's
    /// first functional group is version 005010 or higher (a 999 Implementation Acknowledgment does not
    /// exist for older versions).</summary>
    [RelayCommand(CanExecute = nameof(CanGenerateImplementationAcknowledgment))]
    private void GenerateImplementationAcknowledgment()
    {
        if (ActiveDocument is not { } document)
            return;

        string text;
        try
        {
            var parsed = x12Document.Parse(document.RawText, new x12ParseOptions { Lenient = true });
            text = new ImplementationAcknowledgmentBuilder().Build999Text(parsed);
        }
        catch (Exception ex)
        {
            StatusText = $"Could not generate a 999 for '{document.DisplayName}': {ex.Message}";
            return;
        }

        OpenText(text, $"999 for {document.DisplayName}", null);
        StatusText = WithPackSuffix($"Generated 999 for {document.DisplayName}");
    }

    private static string? FirstGroupVersion(string rawText)
    {
        try
        {
            var parsed = x12Document.Parse(rawText, new x12ParseOptions { Lenient = true });
            return parsed.Interchanges
                .SelectMany(i => i.FunctionalGroups)
                .Select(g => g.Header?.VersionReleaseIndustryIdentifierCode)
                .FirstOrDefault(v => !string.IsNullOrWhiteSpace(v));
        }
        catch
        {
            return null;
        }
    }

    /// <summary>Mirrors the version bucketing FunctionalAcknowledgmentBuilder/ImplementationAcknowledgmentBuilder
    /// use internally (003xxx/004xxx vs everything else) but treats an undetermined version as not
    /// eligible, rather than assuming 5010+.</summary>
    private static bool IsVersion5010OrHigher(string? version) =>
        !string.IsNullOrWhiteSpace(version)
        && !version.StartsWith("003", StringComparison.Ordinal)
        && !version.StartsWith("004", StringComparison.Ordinal);
}
