namespace Eddy.Notepad.Services;

/// <summary>Abstracts the platform file dialog so the view model can be tested without a window.</summary>
public interface IFilePicker
{
    /// <summary>Returns the chosen file path, or null when the user cancelled.</summary>
    Task<string?> PickFileAsync();
}

/// <summary>Placeholder used until the view layer wires a real picker.</summary>
public sealed class NullFilePicker : IFilePicker
{
    public Task<string?> PickFileAsync() => Task.FromResult<string?>(null);
}
