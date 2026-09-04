using System.Reflection;
using Eddy.Core.Metadata;

namespace Eddy.Notepad.Services;

/// <summary>
/// Loads the metadata packs Eddy Notepad ships with, plus any the host machine adds through the
/// EDDY_METADATA_PACKS environment variable. See docs/metadata-packs.md, "Loading packs".
/// </summary>
public static class MetadataPacks
{
    /// <summary>One pack that was successfully loaded into the catalog.</summary>
    public sealed record LoadedPack(string Name, string Standard, string Version, string Source);

    /// <summary>Every metadata/packs/*.json file, embedded into this assembly (see Eddy.Notepad.csproj).</summary>
    private const string EmbeddedResourcePrefix = "Eddy.Notepad.Metadata.Packs.";

    /// <summary>
    /// Loads every embedded pack, then (when set) every *.json file in the directory named by the
    /// EDDY_METADATA_PACKS environment variable, into <paramref name="catalog"/>. Returns what loaded and
    /// what was skipped (a file that failed to parse as a pack), in load order.
    /// </summary>
    public static (IReadOnlyList<LoadedPack> Loaded, IReadOnlyList<string> Skipped) LoadDefaults(MetadataCatalog catalog)
    {
        if (catalog is null)
            throw new ArgumentNullException(nameof(catalog));

        var loaded = new List<LoadedPack>();
        var skipped = new List<string>();

        LoadEmbedded(catalog, loaded, skipped);
        LoadFromEnvironmentDirectory(catalog, loaded, skipped);

        return (loaded, skipped);
    }

    private static void LoadEmbedded(MetadataCatalog catalog, List<LoadedPack> loaded, List<string> skipped)
    {
        var assembly = typeof(MetadataPacks).Assembly;
        var resourceNames = assembly.GetManifestResourceNames()
            .Where(n => n.StartsWith(EmbeddedResourcePrefix, StringComparison.Ordinal) && n.EndsWith(".json", StringComparison.Ordinal))
            .OrderBy(n => n, StringComparer.Ordinal);

        foreach (var resourceName in resourceNames)
        {
            try
            {
                using var stream = assembly.GetManifestResourceStream(resourceName)
                    ?? throw new InvalidOperationException($"embedded resource '{resourceName}' was not found");
                var pack = MetadataPack.Load(stream);
                catalog.AddPack(pack);
                loaded.Add(new LoadedPack(pack.Name, pack.Standard, pack.Version, "embedded"));
            }
            catch (Exception ex)
            {
                skipped.Add($"{resourceName}: {ex.Message}");
            }
        }
    }

    private static void LoadFromEnvironmentDirectory(MetadataCatalog catalog, List<LoadedPack> loaded, List<string> skipped)
    {
        var directory = Environment.GetEnvironmentVariable("EDDY_METADATA_PACKS");
        if (string.IsNullOrEmpty(directory) || !Directory.Exists(directory))
            return;

        var files = Directory.GetFiles(directory, "*.json").OrderBy(f => Path.GetFileName(f), StringComparer.Ordinal);
        foreach (var file in files)
        {
            try
            {
                var pack = MetadataPack.Load(file);
                catalog.AddPack(pack);
                loaded.Add(new LoadedPack(pack.Name, pack.Standard, pack.Version, Path.GetFileName(file)));
            }
            catch (Exception ex)
            {
                skipped.Add($"{Path.GetFileName(file)}: {ex.Message}");
            }
        }
    }
}
