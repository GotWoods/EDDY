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
        SavedText = rawText;
    }

    partial void OnIsDirtyChanged(bool value) => OnPropertyChanged(nameof(TabTitle));

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

    /// <summary>The text this document would revert to if every pending edit were undone back past its
    /// last save (or, for a document never saved, back to what was first opened). Compared against
    /// <see cref="RawText"/> to derive <see cref="IsDirty"/> whenever a document is reloaded after an
    /// edit, undo, redo or save; see MainWindowViewModel.ApplyTextEdit/Undo/Redo/SaveAsync.</summary>
    public string SavedText { get; set; } = "";

    /// <summary>True when <see cref="RawText"/> differs from <see cref="SavedText"/>. Drives the "•" tab
    /// title suffix (<see cref="TabTitle"/>) and the close/exit confirmation prompts.</summary>
    [ObservableProperty]
    private bool _isDirty;

    /// <summary>Text snapshots to go back to on Undo, oldest first (the last entry is what Undo would
    /// restore next). Empty for a freshly opened document.</summary>
    public List<string> UndoStack { get; } = new();

    /// <summary>Text snapshots to go forward to on Redo, oldest first. Cleared by any new edit.</summary>
    public List<string> RedoStack { get; } = new();

    public bool CanUndo => UndoStack.Count > 0;

    public bool CanRedo => RedoStack.Count > 0;

    /// <summary><see cref="DisplayName"/> with a "•" suffix while <see cref="IsDirty"/>, for the tab strip.</summary>
    public string TabTitle => IsDirty ? DisplayName + " •" : DisplayName;

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

    /// <summary>View &gt; Show Loops (Ctrl+L). When true, the tree shows each TransactionSet node's
    /// <see cref="DocumentNodeViewModel.LoopChildren"/> instead of its flat <see cref="DocumentNodeViewModel.Children"/>,
    /// for whichever transaction sets have one (see Services/LoopViewBuilder.cs); everything else in the
    /// tree is unaffected. Per document, default false. Setting this walks every node in <see cref="Nodes"/>
    /// and sets its own <see cref="DocumentNodeViewModel.ShowLoops"/> to match, since the TreeView binds
    /// each node's ItemsSource to its own <see cref="DocumentNodeViewModel.VisibleChildren"/>.</summary>
    [ObservableProperty]
    private bool _showLoops;

    partial void OnShowLoopsChanged(bool value)
    {
        foreach (var node in Nodes)
            SetShowLoopsRecursive(node, value);
    }

    private static void SetShowLoopsRecursive(DocumentNodeViewModel node, bool value)
    {
        node.ShowLoops = value;
        foreach (var child in node.Children)
            SetShowLoopsRecursive(child, value);
        foreach (var child in node.LoopChildren)
            SetShowLoopsRecursive(child, value);
    }
}
