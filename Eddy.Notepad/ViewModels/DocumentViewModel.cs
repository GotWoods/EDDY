using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Eddy.Notepad.ViewModels;

/// <summary>One open EDI file: its raw text, parsed tree, and diagnostics.</summary>
public sealed partial class DocumentViewModel : ObservableObject
{
    public DocumentViewModel(string displayName, string? filePath, string format, string rawText)
    {
        DisplayName = displayName;
        FilePath = filePath;
        Format = format;
        RawText = rawText;
    }

    /// <summary>Tab title: the file name, or a sample name.</summary>
    public string DisplayName { get; }

    public string? FilePath { get; }

    /// <summary>"X12 004010" style when parsed successfully, else "X12", "EDIFACT" or "Unknown".</summary>
    public string Format { get; }

    /// <summary>The file text after BOM and surrounding whitespace were removed.</summary>
    public string RawText { get; }

    /// <summary>One entry per non-blank segment, numbered from 1.</summary>
    public IReadOnlyList<RawLineViewModel> RawLines { get; set; } = Array.Empty<RawLineViewModel>();

    /// <summary>Root nodes of the tree. For X12 this is one Interchange node.</summary>
    public ObservableCollection<DocumentNodeViewModel> Nodes { get; } = new();

    public ObservableCollection<DiagnosticViewModel> Diagnostics { get; } = new();

    public int ErrorCount => Diagnostics.Count(d => d.Severity == DiagnosticSeverity.Error);

    public int WarningCount => Diagnostics.Count(d => d.Severity == DiagnosticSeverity.Warning);

    public bool IsValid => ErrorCount == 0;

    /// <summary>One line describing the envelope, e.g. "ISA 000003438 · GS SM 4405197800 → 999999999 · 1 transaction set".</summary>
    public string Summary { get; set; } = "";

    /// <summary>
    /// Selected tree node. Setting it also selects the matching raw line, and vice versa.
    /// Implemented in DocumentViewModel.Selection.cs.
    /// </summary>
    [ObservableProperty]
    private DocumentNodeViewModel? _selectedNode;

    [ObservableProperty]
    private RawLineViewModel? _selectedRawLine;

    /// <summary>Elements of the selected node, for the detail grid.</summary>
    public IReadOnlyList<ElementViewModel> SelectedElements => SelectedNode?.Elements ?? Array.Empty<ElementViewModel>();
}
