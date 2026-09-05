namespace Eddy.Notepad.ViewModels;

/// <summary>
/// Keeps <see cref="DocumentViewModel.SelectedNode"/> and <see cref="DocumentViewModel.SelectedRawLine"/> in
/// sync: selecting one selects the other. See README.md, "Loader contract" footer, "Selection sync".
/// </summary>
public sealed partial class DocumentViewModel
{
    private bool _syncingSelection;

    partial void OnSelectedNodeChanged(DocumentNodeViewModel? value)
    {
        // The detail grid always reflects the node, whether this change came from here directly or was
        // driven by a raw line selection below.
        OnPropertyChanged(nameof(SelectedElements));

        if (_syncingSelection)
            return;

        _syncingSelection = true;
        try
        {
            SelectedRawLine = value?.LineNumber is int line
                ? RawLines.FirstOrDefault(r => r.LineNumber == line)
                : null;
        }
        finally
        {
            _syncingSelection = false;
        }
    }

    partial void OnSelectedRawLineChanged(RawLineViewModel? value)
    {
        if (_syncingSelection)
            return;

        _syncingSelection = true;
        try
        {
            SelectedNode = value?.Node;
        }
        finally
        {
            _syncingSelection = false;
        }
    }
}
