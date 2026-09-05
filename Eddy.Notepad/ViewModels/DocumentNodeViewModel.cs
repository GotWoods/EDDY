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

    /// <summary>
    /// The alternate, loop-shaped view of this node's contents (View &gt; Show Loops, Ctrl+L): built only
    /// for an X12 TransactionSet node whose transaction set code and version resolve to a domain model
    /// (see Services/LoopViewBuilder.cs). Made of the same <see cref="DocumentNodeViewModel"/> instances
    /// as <see cref="Children"/> for segments (so selection, diagnostics and the raw-line link keep
    /// working), grouped under new <see cref="NodeKind.Loop"/> nodes for repeating loops, with a trailing
    /// "Unmapped segments" loop node for anything the domain model did not expect. Empty when
    /// <see cref="HasLoopView"/> is false.
    /// </summary>
    public ObservableCollection<DocumentNodeViewModel> LoopChildren { get; } = new();

    /// <summary>True when <see cref="LoopChildren"/> holds a real alternate view of this node's contents
    /// (only ever true for a TransactionSet node whose transaction set resolved to a domain model). A node
    /// with this false always shows <see cref="Children"/>, in both view modes -- see <see cref="VisibleChildren"/>.</summary>
    public bool HasLoopView { get; set; }

    /// <summary>
    /// Set (recursively, on every node of every open document) by MainWindowViewModel whenever
    /// View &gt; Show Loops is toggled. Not itself the source of truth for which mode is showing --
    /// <see cref="DocumentViewModel.ShowLoops"/> is -- just this node's copy of it, so <see cref="VisibleChildren"/>
    /// can be a plain per-node computed property that the existing TreeView binding (ItemsSource="{Binding
    /// VisibleChildren}") picks up through <see cref="NotifyPropertyChangedForAttribute"/> without the tree
    /// needing two separate ItemsSource paths or a second TreeView.
    /// </summary>
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(VisibleChildren))]
    private bool _showLoops;

    /// <summary><see cref="LoopChildren"/> when loop view is on for this node and it has one, else
    /// <see cref="Children"/> -- always <see cref="Children"/> for every node kind except a resolved
    /// TransactionSet, so toggling the mode only actually changes anything at that one level of the tree.</summary>
    public ObservableCollection<DocumentNodeViewModel> VisibleChildren => ShowLoops && HasLoopView ? LoopChildren : Children;

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
