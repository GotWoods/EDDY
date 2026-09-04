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
        // TODO(core): remove the document, activate a neighbour, update status.
        throw new NotImplementedException();
    }

    /// <summary>Reads a file from disk and opens it as a new tab.</summary>
    public async Task OpenPathAsync(string path)
    {
        // TODO(core): read the file (async), then OpenText. Report IO failures in StatusText, never throw.
        await Task.CompletedTask;
        throw new NotImplementedException();
    }

    /// <summary>Parses text into a document, adds it to the tabs and activates it.</summary>
    public void OpenText(string text, string displayName, string? filePath)
    {
        // TODO(core): loader.Load, add to Documents, set ActiveDocument, set StatusText, raise HasDocuments.
        throw new NotImplementedException();
    }
}
