using Xunit;

namespace Eddy.MetadataTool.Tests;

/// <summary>Exercises the `gen-codes` command's underlying logic (CodeListGenerator). See
/// docs/metadata-packs.md, "Tool".</summary>
public class CodeListGeneratorTests
{
    [Fact]
    public void GenCodes_FromTheRealD96APack_Writes3035AsPartyQualifierCodes()
    {
        var outDir = MakeTempDir();
        try
        {
            var options = new CodeListGenerator.Options
            {
                PackPaths = new List<string> { Path.Combine(RepoPaths.Root(), "metadata", "packs", "edifact-D96A.json") },
                Namespace = "Eddy.Edifact.Codes.D96A",
                OutDir = outDir,
            };

            var generated = CodeListGenerator.Generate(options);

            var entry = Assert.Single(generated, g => g.DataElementNumber == "3035");
            Assert.Equal("PartyQualifierCodes", entry.ClassName);
            Assert.True(File.Exists(entry.Path));

            var text = File.ReadAllText(entry.Path);
            Assert.Contains("namespace Eddy.Edifact.Codes.D96A;", text);
            Assert.Contains("public sealed class PartyQualifierCodes : CodeList", text);
            Assert.Contains("public override string Standard => \"EDIFACT\";", text);
            Assert.Contains("public override string DataElementNumber => \"3035\";", text);
            Assert.Contains("public const string BY = \"BY\";", text);
        }
        finally
        {
            CleanUp(outDir);
        }
    }

    [Fact]
    public void GenCodes_WritesOneFilePerDataElementThatHasCodes()
    {
        var outDir = MakeTempDir();
        try
        {
            var options = new CodeListGenerator.Options
            {
                PackPaths = new List<string> { Path.Combine(RepoPaths.Root(), "metadata", "packs", "edifact-D96A.json") },
                Namespace = "Eddy.Edifact.Codes.D96A",
                OutDir = outDir,
            };

            var pack = PackJson.Load(options.PackPaths[0]);
            var generated = CodeListGenerator.Generate(options);

            Assert.Equal(pack.Codes.Count, generated.Count);
            Assert.All(generated, g => Assert.True(File.Exists(g.Path)));
        }
        finally
        {
            CleanUp(outDir);
        }
    }

    [Fact]
    public void GenCodes_WithEnums_NamesMembersFromDescriptionsAndFallsBackToTheCodeWhenBlank()
    {
        var outDir = MakeTempDir();
        try
        {
            var pack = new MetadataPackModel { Standard = "X12", Version = "004010", Name = "test" };
            pack.DataElements["98"] = new DataElementDef { Name = "Entity Identifier Code", Type = "ID" };
            pack.Codes["98"] = new Dictionary<string, string> { ["BY"] = "Buyer", ["100"] = "" };
            var packFile = Path.Combine(outDir, "src.json");
            Directory.CreateDirectory(outDir);
            PackJson.Save(pack, packFile);

            var options = new CodeListGenerator.Options
            {
                PackPaths = new List<string> { packFile },
                Namespace = "Eddy.Test.Codes",
                OutDir = outDir,
                Enums = true,
            };

            var generated = CodeListGenerator.Generate(options);
            var entry = Assert.Single(generated);
            // "Entity Identifier Code" ends with "Code" - the suffix is folded into "...Codes" rather
            // than doubled.
            Assert.Equal("EntityIdentifierCodes", entry.ClassName);

            var text = File.ReadAllText(entry.Path);
            Assert.Contains("public const string Buyer = \"BY\";", text);
            Assert.Contains("public const string _100 = \"100\";", text); // blank description -> named from the (digit-leading) code
            Assert.Contains("public enum EntityIdentifierCode", text);
            Assert.Contains("[CodeValue(\"BY\")]", text);
            Assert.Contains("[CodeValue(\"100\")]", text);
        }
        finally
        {
            CleanUp(outDir);
        }
    }

    [Fact]
    public void GenCodes_WithoutEnums_NeverGeneratesAnEnum()
    {
        var outDir = MakeTempDir();
        try
        {
            var pack = new MetadataPackModel { Standard = "X12", Version = "004010", Name = "test" };
            pack.DataElements["98"] = new DataElementDef { Name = "Entity Identifier Code", Type = "ID" };
            pack.Codes["98"] = new Dictionary<string, string> { ["BY"] = "Buyer" };
            var packFile = Path.Combine(outDir, "src.json");
            Directory.CreateDirectory(outDir);
            PackJson.Save(pack, packFile);

            var options = new CodeListGenerator.Options
            {
                PackPaths = new List<string> { packFile },
                Namespace = "Eddy.Test.Codes",
                OutDir = outDir,
                Enums = false,
            };

            var generated = CodeListGenerator.Generate(options);
            var text = File.ReadAllText(Assert.Single(generated).Path);

            Assert.DoesNotContain("public enum", text);
        }
        finally
        {
            CleanUp(outDir);
        }
    }

    private static string MakeTempDir() => Path.Combine(Path.GetTempPath(), $"eddy-metadatatool-gencodes-tests-{Guid.NewGuid():N}");

    private static void CleanUp(string dir)
    {
        if (Directory.Exists(dir))
            Directory.Delete(dir, recursive: true);
    }
}
