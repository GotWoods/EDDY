namespace Eddy.Notepad.ViewModels;

/// <summary>One metadata pack loaded into the catalog, for Help &gt; Loaded Metadata. See docs/metadata-packs.md.</summary>
public sealed class PackInfoViewModel
{
    public PackInfoViewModel(string name, string standard, string version, string source)
    {
        Name = name;
        Standard = standard;
        Version = version;
        Source = source;
    }

    public string Name { get; }

    public string Standard { get; }

    public string Version { get; }

    /// <summary>"embedded", or the file name it was loaded from.</summary>
    public string Source { get; }
}
