using Xunit;

namespace Eddy.MetadataTool.Tests;

public class PackValidatorTests
{
    [Fact]
    public void Valid_pack_reports_no_problems_and_correct_counts()
    {
        var pack = new MetadataPackModel { Standard = "EDIFACT", Version = "D96A" };
        pack.DataElements["3035"] = new DataElementDef { Type = "ID", Min = 1, Max = 3 };
        pack.DataElements["3039"] = new DataElementDef { Type = "AN", Min = 1, Max = 35 };
        pack.Composites["C082"] = new ComponentDef
        {
            Elements = { new ElementRef { Pos = 1, De = "3039", Req = "M" } },
        };
        pack.Segments["NAD"] = new ComponentDef
        {
            Elements =
            {
                new ElementRef { Pos = 1, De = "3035", Req = "M" },
                new ElementRef { Pos = 2, Composite = "C082", Req = "C" },
            },
        };
        pack.Codes["3035"] = new Dictionary<string, string> { ["BY"] = "", ["SU"] = "" };

        var result = PackValidator.Validate(pack);

        Assert.True(result.IsValid);
        Assert.Equal(1, result.SegmentCount);
        Assert.Equal(1, result.CompositeCount);
        Assert.Equal(2, result.DataElementCount);
        Assert.Equal(1, result.CodeListCount);
        Assert.Equal(2, result.CodeCount);
    }

    [Fact]
    public void Catches_a_missing_composite_reference()
    {
        var pack = new MetadataPackModel { Standard = "EDIFACT", Version = "D96A" };
        pack.Segments["NAD"] = new ComponentDef
        {
            Elements = { new ElementRef { Pos = 1, Composite = "C082", Req = "C" } },
        };
        // Note: "C082" is never added to pack.Composites.

        var result = PackValidator.Validate(pack);

        Assert.False(result.IsValid);
        Assert.Contains(result.Problems, p => p.Contains("C082") && p.Contains("does not resolve"));
    }

    [Fact]
    public void Catches_a_duplicate_position()
    {
        var pack = new MetadataPackModel { Standard = "EDIFACT", Version = "D96A" };
        pack.DataElements["3035"] = new DataElementDef { Type = "ID" };
        pack.DataElements["3036"] = new DataElementDef { Type = "AN" };
        pack.Segments["NAD"] = new ComponentDef
        {
            Elements =
            {
                new ElementRef { Pos = 1, De = "3035", Req = "M" },
                new ElementRef { Pos = 1, De = "3036", Req = "C" },
            },
        };

        var result = PackValidator.Validate(pack);

        Assert.False(result.IsValid);
        Assert.Contains(result.Problems, p => p.Contains("duplicate position"));
    }

    [Fact]
    public void Catches_an_element_with_neither_or_both_of_de_and_composite()
    {
        var pack = new MetadataPackModel { Standard = "EDIFACT", Version = "D96A" };
        pack.Segments["NAD"] = new ComponentDef
        {
            Elements = { new ElementRef { Pos = 1 } }, // neither de nor composite set
        };

        var result = PackValidator.Validate(pack);

        Assert.False(result.IsValid);
        Assert.Contains(result.Problems, p => p.Contains("exactly one of de/composite"));
    }
}
