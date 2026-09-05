using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Views.Design;

/// <summary>
/// Design-time (and startup-with-EDDY_NOTEPAD_DESIGN_DATA) data for the previewer and headless
/// render test. Builds a <see cref="MainWindowViewModel"/> with one document already open, without
/// going through the (separately implemented) MainWindowViewModel.OpenText/OpenPathAsync flow.
/// </summary>
public static class DesignData
{
    /// <summary>A <see cref="MainWindowViewModel"/> with one design document open and active.</summary>
    public static MainWindowViewModel Instance { get; } = CreateViewModel();

    /// <summary>Creates a fresh view model with one design document open and active.</summary>
    public static MainWindowViewModel CreateViewModel()
    {
        var loader = new DesignDocumentLoader();
        var viewModel = new MainWindowViewModel(loader, new NullFilePicker());
        AddDesignDocument(viewModel, loader);
        return viewModel;
    }

    /// <summary>Loads and activates one design document on the given view model.</summary>
    public static DocumentViewModel AddDesignDocument(MainWindowViewModel viewModel, DesignDocumentLoader? loader = null)
    {
        var document = (loader ?? new DesignDocumentLoader()).Load(string.Empty, "Sample-204-LoadTender", null);
        viewModel.Documents.Add(document);
        viewModel.ActiveDocument = document;
        viewModel.StatusText = "X12 004010 · 1 interchange · 1 group · 1 transaction set · 1 error · 1 warning";
        return document;
    }
}
