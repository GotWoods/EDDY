namespace Eddy.Notepad.Services;

/// <summary>Abstracts the platform file dialog so the view model can be tested without a window.</summary>
public interface IFilePicker
{
    /// <summary>Returns the chosen file path, or null when the user cancelled.</summary>
    Task<string?> PickFileAsync();

    /// <summary>Same as <see cref="PickFileAsync()"/>, with a dialog title and glob patterns for the file
    /// type filter (e.g. "*.json"). Used for File &gt; Load Metadata Pack….</summary>
    Task<string?> PickFileAsync(string title, string[] patterns);

    /// <summary>Shows a save dialog and returns the chosen path, or null when the user cancelled. Used for
    /// File &gt; Save As… (and by Save, for a document with no <see cref="DocumentViewModel"/>.FilePath yet,
    /// e.g. a sample or a generated acknowledgment).</summary>
    Task<string?> PickSaveFileAsync(string title, string suggestedFileName);
}

/// <summary>Placeholder used until the view layer wires a real picker.</summary>
public sealed class NullFilePicker : IFilePicker
{
    public Task<string?> PickFileAsync() => Task.FromResult<string?>(null);

    public Task<string?> PickFileAsync(string title, string[] patterns) => Task.FromResult<string?>(null);

    public Task<string?> PickSaveFileAsync(string title, string suggestedFileName) => Task.FromResult<string?>(null);
}
