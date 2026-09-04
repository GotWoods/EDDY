using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Eddy.Notepad.ViewModels;

/// <summary>A node in the document tree: interchange, group, transaction set or segment.</summary>
public sealed partial class DocumentNodeViewModel : ObservableObject
{
    public DocumentNodeViewModel(NodeKind kind, string code, string title, string subtitle, int? lineNumber, object? model)
    {
        Kind = kind;
        Code = code;
        Title = title;
        Subtitle = subtitle;
        LineNumber = lineNumber;
        Model = model;
    }

    public NodeKind Kind { get; }

    /// <summary>Segment identifier ("ISA", "GS", "N1") or transaction set code ("204").</summary>
    public string Code { get; }

    /// <summary>Primary label, e.g. "N1 Name" or "204 Motor Carrier Load Tender".</summary>
    public string Title { get; }

    /// <summary>Secondary label, e.g. the first few element values, or control numbers for envelopes.</summary>
    public string Subtitle { get; }

    /// <summary>1-based raw line number of the segment that starts this node, or null when unknown.</summary>
    public int? LineNumber { get; }

    /// <summary>The underlying Eddy model object (an EdiX12Segment, a header, or null).</summary>
    public object? Model { get; }

    public ObservableCollection<DocumentNodeViewModel> Children { get; } = new();

    /// <summary>Elements shown in the detail grid when this node is selected. Empty for envelope nodes without a model.</summary>
    public IReadOnlyList<ElementViewModel> Elements { get; set; } = Array.Empty<ElementViewModel>();

    /// <summary>Diagnostics attached directly to this node.</summary>
    public List<DiagnosticViewModel> Diagnostics { get; } = new();

    /// <summary>Diagnostics on this node plus all descendants.</summary>
    public int ErrorCount => Diagnostics.Count + Children.Sum(c => c.ErrorCount);

    public bool HasErrors => ErrorCount > 0;

    [ObservableProperty]
    private bool _isExpanded = true;

    [ObservableProperty]
    private bool _isSelected;

    public override string ToString() => Title;
}
