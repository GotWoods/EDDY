using Eddy.Core.Metadata;
using Eddy.Notepad.Services;

namespace Eddy.Notepad.Tests;

/// <summary>Exercises Services/MetadataPacks.cs: the embedded packs and the EDDY_METADATA_PACKS directory.
/// See docs/metadata-packs.md, "Loading packs".</summary>
public class MetadataPacksTests
{
    /// <summary>Clears EDDY_METADATA_PACKS for the duration of a test and restores whatever it was,
    /// so these tests are not at the mercy of the ambient environment.</summary>
    private sealed class EnvironmentVariableScope : IDisposable
    {
        private const string Name = "EDDY_METADATA_PACKS";
        private readonly string? _original;

        public EnvironmentVariableScope(string? value)
        {
            _original = Environment.GetEnvironmentVariable(Name);
            Environment.SetEnvironmentVariable(Name, value);
        }

        public void Dispose() => Environment.SetEnvironmentVariable(Name, _original);
    }

    [Fact]
    public void LoadDefaults_loads_the_three_embedded_edifact_packs_and_skips_nothing()
    {
        using var _ = new EnvironmentVariableScope(null);

        var catalog = new MetadataCatalog();
        var (loaded, skipped) = MetadataPacks.LoadDefaults(catalog);

        Assert.Equal(3, loaded.Count);
        Assert.All(loaded, p => Assert.Equal("EDIFACT", p.Standard));
        Assert.All(loaded, p => Assert.Equal("embedded", p.Source));
        Assert.Contains(loaded, p => p.Version == "D96A");
        Assert.Contains(loaded, p => p.Version == "D01B");
        Assert.Contains(loaded, p => p.Version == "D07A");
        Assert.Empty(skipped);

        // The catalog actually has the packs, not just the report: NAD picks up a DE number.
        var def = catalog.Describe(typeof(Eddy.Edifact.Models.D96A.NAD_NameAndAddress));
        Assert.Equal("3035", def.Elements.Single(e => e.Position == 1).DataElementNumber);
    }

    [Fact]
    public void LoadDefaults_also_loads_a_pack_from_EDDY_METADATA_PACKS_and_reports_a_junk_file()
    {
        var dir = Path.Combine(Path.GetTempPath(), "eddy-notepad-metadata-packs-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        using var _ = new EnvironmentVariableScope(dir);
        try
        {
            var goodPack = new MetadataPack { Name = "env-dir test pack", Standard = "X12", Version = "004010" };
            goodPack.Save(Path.Combine(dir, "a-good.json"));
            File.WriteAllText(Path.Combine(dir, "b-junk.json"), "{\"not\":\"a pack\"}");

            var catalog = new MetadataCatalog();
            var (loaded, skipped) = MetadataPacks.LoadDefaults(catalog);

            // The 3 embedded packs, plus the one good file from the env dir.
            Assert.Equal(4, loaded.Count);
            Assert.Contains(loaded, p => p.Name == "env-dir test pack" && p.Source == "a-good.json");

            var skippedEntry = Assert.Single(skipped);
            Assert.Contains("b-junk.json", skippedEntry);
        }
        finally
        {
            Directory.Delete(dir, true);
        }
    }
}
