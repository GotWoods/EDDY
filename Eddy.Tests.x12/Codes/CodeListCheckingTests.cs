using System.Collections.Generic;
using System.Linq;
using Eddy.Core.Metadata;
using Eddy.Core.Validation;
using Eddy.x12;
using Eddy.x12.Tests;
using Xunit;

namespace Eddy.Tests.x12.Codes;

/// <summary>
/// Exercises <c>x12ParseOptions.CodeListChecking</c> end to end against the real N1 segment (X12 data
/// element 98, EntityIdentifierCode). <see cref="MetadataCatalog"/> has no API to remove a source once
/// added, so this loads a small hand-made pack for X12 004010/DE 98 into the shared
/// <see cref="MetadataCatalog.Default"/> once (a static constructor, so it runs before any test in this
/// class) and leaves it there - safe because this test project runs as its own process and no other
/// test here depends on the default catalog knowing nothing about data element 98.
/// </summary>
public class CodeListCheckingTests
{
    static CodeListCheckingTests()
    {
        var pack = new MetadataPack { Standard = "X12", Version = "004010", Name = "CodeListCheckingTests pack" };
        pack.Codes["98"] = new Dictionary<string, string> { ["BY"] = "Buyer" };
        // N1-01 (EntityIdentifierCode) is DE 98 - needed so the overlay can attach a CodeListId to it;
        // without a segment definition here, the pack's codes are never linked to N1's position 1.
        pack.Segments["N1"] = new SegmentDefinition
        {
            Id = "N1",
            Elements = { new ElementDefinition { Position = 1, DataElementNumber = "98" } },
        };
        MetadataCatalog.Default.AddPack(pack);
    }

    private static string BuildDocument(string entityIdentifierCode)
    {
        const string newline = "~\n";
        return x12TestFixtures.Isa("000000001", newline)
            + x12TestFixtures.Gs("2100", newline)
            + x12TestFixtures.St("0001", newline)
            + $"N1*{entityIdentifierCode}*Acme Corp" + newline
            + x12TestFixtures.Se(3, "0001", newline)
            + x12TestFixtures.Ge(1, "2100", newline)
            + x12TestFixtures.Iea(1, "000000001", newline);
    }

    [Fact]
    public void Off_ByDefault_RecordsNoCodeListEntry()
    {
        var doc = x12Document.Parse(BuildDocument("ZZ"));

        Assert.Empty(doc.ValidationErrors.SelectMany(vr => vr.Errors).Where(e => e.ErrorCode == ErrorCodes.UnknownCodeValue));
    }

    [Fact]
    public void Warn_FlagsAValueNotInTheLoadedList()
    {
        var doc = x12Document.Parse(BuildDocument("ZZ"), new x12ParseOptions { CodeListChecking = CodeListChecking.Warn });

        var error = doc.ValidationErrors.SelectMany(vr => vr.Errors).Single(e => e.ErrorCode == ErrorCodes.UnknownCodeValue);
        Assert.Equal(ErrorSeverity.Warning, error.Severity);
        Assert.Equal("EntityIdentifierCode", error.PropertyName);
        Assert.Equal(1, error.ElementPosition);
    }

    [Fact]
    public void Warn_DoesNotFlagAKnownCode()
    {
        var doc = x12Document.Parse(BuildDocument("BY"), new x12ParseOptions { CodeListChecking = CodeListChecking.Warn });

        Assert.Empty(doc.ValidationErrors.SelectMany(vr => vr.Errors).Where(e => e.ErrorCode == ErrorCodes.UnknownCodeValue));
    }

    [Fact]
    public void Error_FlagsWithErrorSeverityInstead()
    {
        var doc = x12Document.Parse(BuildDocument("ZZ"), new x12ParseOptions { CodeListChecking = CodeListChecking.Error });

        var error = doc.ValidationErrors.SelectMany(vr => vr.Errors).Single(e => e.ErrorCode == ErrorCodes.UnknownCodeValue);
        Assert.Equal(ErrorSeverity.Error, error.Severity);
        Assert.False(doc.IsValid);
    }
}
