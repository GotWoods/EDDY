using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Eddy.Notepad.Services;

namespace Eddy.Notepad.ViewModels;

/// <summary>Top level state: the open documents, the active one, and the file commands.</summary>
public sealed partial class MainWindowViewModel : ObservableObject
{
    private readonly IDocumentLoader _loader;
    private readonly IFilePicker _filePicker;

    public MainWindowViewModel(IDocumentLoader loader, IFilePicker filePicker)
    {
        _loader = loader;
        _filePicker = filePicker;
        SampleNames = SampleDocuments.GetNames();
    }

    public ObservableCollection<DocumentViewModel> Documents { get; } = new();

    [ObservableProperty]
    private DocumentViewModel? _activeDocument;

    [ObservableProperty]
    private string _statusText = "Open an EDI file, or pick a sample from the File menu.";

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
            ? "Open an EDI file, or pick a sample from the File menu."
            : BuildStatusText(ActiveDocument);
    }

    /// <summary>Reads a file from disk and opens it as a new tab.</summary>
    public async Task OpenPathAsync(string path)
    {
        var existing = Documents.FirstOrDefault(d => d.FilePath == path);
        if (existing is not null)
        {
            ActiveDocument = existing;
            StatusText = BuildStatusText(existing);
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
        StatusText = BuildStatusText(document);
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

        return $"{document.Format} · {interchangeCount} interchange{(interchangeCount == 1 ? "" : "s")} · " +
               $"{groupCount} group{(groupCount == 1 ? "" : "s")} · " +
               $"{transactionSetCount} transaction set{(transactionSetCount == 1 ? "" : "s")} · " +
               $"{errorCount} error{(errorCount == 1 ? "" : "s")}";
    }
}
