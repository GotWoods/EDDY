using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eddy.Core.Metadata;
using Eddy.Notepad.Services;

namespace Eddy.Notepad.ViewModels;

/// <summary>Top level state: the open documents, the active one, and the file commands.</summary>
public sealed partial class MainWindowViewModel : ObservableObject
{
    private const string IdleStatusText = "Open an EDI file, or pick a sample from the File menu.";

    private readonly IDocumentLoader _loader;
    private readonly IFilePicker _filePicker;
    private readonly MetadataCatalog _catalog;

    /// <summary><paramref name="catalog"/> defaults to <see cref="MetadataCatalog.Default"/>, the same
    /// catalog a parameterless <see cref="DocumentLoader"/> describes segments with; pass an explicit one
    /// (paired with a <see cref="DocumentLoader"/> built from the same catalog) to keep it isolated, e.g. in tests.</summary>
    public MainWindowViewModel(IDocumentLoader loader, IFilePicker filePicker, MetadataCatalog? catalog = null)
    {
        _loader = loader;
        _filePicker = filePicker;
        _catalog = catalog ?? MetadataCatalog.Default;
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
}
