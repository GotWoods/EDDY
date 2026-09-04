using Avalonia.Controls;
using Avalonia.Platform.Storage;
using Eddy.Notepad.Services;

namespace Eddy.Notepad.Views;

/// <summary>Real <see cref="IFilePicker"/> backed by the owning window's <see cref="IStorageProvider"/>.</summary>
public sealed class StorageProviderFilePicker : IFilePicker
{
    private readonly Window _owner;

    public StorageProviderFilePicker(Window owner)
    {
        _owner = owner;
    }

    public async Task<string?> PickFileAsync()
    {
        var options = new FilePickerOpenOptions
        {
            Title = "Open EDI File",
            AllowMultiple = false,
            FileTypeFilter = new FilePickerFileType[]
            {
                new("EDI files") { Patterns = new[] { "*.edi", "*.x12" } },
                new("Text files") { Patterns = new[] { "*.txt" } },
                FilePickerFileTypes.All,
            },
        };

        var files = await _owner.StorageProvider.OpenFilePickerAsync(options);
        return files.Count > 0 ? files[0].Path.LocalPath : null;
    }
}
