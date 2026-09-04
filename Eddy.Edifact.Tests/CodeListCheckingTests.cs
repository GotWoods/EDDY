using Eddy.Core.Metadata;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Tests;

/// <summary>
/// Exercises <c>EdifactParseOptions.CodeListChecking</c> end to end against the real D96A NAD segment
/// (data element 3035, PartyQualifier) using the real, checked-in edifact-D96A.json pack - not a
/// hand-built fixture, so a change to the pack or to the code list rule's wiring is caught here too.
/// <see cref="MetadataCatalog"/> has no API to remove a source once added, so this loads the pack into
/// the shared <see cref="MetadataCatalog.Default"/> once (a static constructor, so it runs before any
/// test in this class) and leaves it there - safe because this test project runs as its own process.
/// </summary>
public class CodeListCheckingTests
{
    static CodeListCheckingTests()
    {
        MetadataCatalog.Default.AddPack(MetadataPack.Load(PackPath("edifact-D96A.json")));
    }

    private static string RepoRoot()
    {
        var dir = AppContext.BaseDirectory;
        while (dir is not null)
        {
            if (File.Exists(Path.Combine(dir, "EDDY.sln")))
                return dir;
            dir = Path.GetDirectoryName(dir.TrimEnd(Path.DirectorySeparatorChar));
        }
        throw new InvalidOperationException("could not locate repository root (EDDY.sln) from " + AppContext.BaseDirectory);
    }

    private static string PackPath(string fileName) => Path.Combine(RepoRoot(), "metadata", "packs", fileName);

    private static string BuildDocument(string partyQualifier)
    {
        return "UNB+UNOA:1+123456789:14+987654321:14+230815:1200+987654++++++1'\n"
            + "UNH+1+APERAK:D:96A:UN'\n"
            + "BGM+16+123456+9'\n"
            + $"NAD+{partyQualifier}'\n"
            + "UNT+4+1'\n"
            + "UNZ+1+987654'\n";
    }

    [Fact]
    public void Off_ByDefault_RecordsNoCodeListEntry()
    {
        var doc = EdiFactDocument.Parse(BuildDocument("ZQ"));

        Assert.Empty(doc.ValidationErrors.SelectMany(vr => vr.Errors).Where(e => e.ErrorCode == ErrorCodes.UnknownCodeValue));
    }

    [Fact]
    public void Warn_FlagsANadWithAPartyQualifierNotInTheD96APack()
    {
        var doc = EdiFactDocument.Parse(BuildDocument("ZQ"), new EdifactParseOptions { CodeListChecking = CodeListChecking.Warn });

        var error = doc.ValidationErrors.SelectMany(vr => vr.Errors).Single(e => e.ErrorCode == ErrorCodes.UnknownCodeValue);
        Assert.Equal(ErrorSeverity.Warning, error.Severity);
        Assert.Equal("PartyQualifier", error.PropertyName);
        Assert.Equal(1, error.ElementPosition);
    }

    [Fact]
    public void Warn_DoesNotFlagANadWithAPartyQualifierKnownToTheD96APack()
    {
        var doc = EdiFactDocument.Parse(BuildDocument("BY"), new EdifactParseOptions { CodeListChecking = CodeListChecking.Warn });

        Assert.Empty(doc.ValidationErrors.SelectMany(vr => vr.Errors).Where(e => e.ErrorCode == ErrorCodes.UnknownCodeValue));
    }

    [Fact]
    public void Error_FlagsWithErrorSeverityInstead()
    {
        var doc = EdiFactDocument.Parse(BuildDocument("ZQ"), new EdifactParseOptions { CodeListChecking = CodeListChecking.Error });

        var error = doc.ValidationErrors.SelectMany(vr => vr.Errors).Single(e => e.ErrorCode == ErrorCodes.UnknownCodeValue);
        Assert.Equal(ErrorSeverity.Error, error.Severity);
    }
}
