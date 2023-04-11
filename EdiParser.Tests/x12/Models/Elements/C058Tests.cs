using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C058Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "s*o*o*q*C*P*i";

        var expected = new C058_AdjustmentReason()
        {
            ClaimAdjustmentReasonCode = "s",
            CodeListQualifierCode = "o",
            IndustryCode = "o",
            IndustryCode2 = "q",
            IndustryCode3 = "C",
            IndustryCode4 = "P",
            IndustryCode5 = "i",
        };

        var actual = Map.MapObject<C058_AdjustmentReason>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("s", true)]
    public void Validatation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("o", "o", true)]
    [InlineData("", "o", false)]
    [InlineData("o", "", false)]
    public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = "s";
        subject.CodeListQualifierCode = codeListQualifierCode;
        subject.IndustryCode = industryCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "o", true)]
    [InlineData("q", "", false)]
    public void Validation_ARequiresBIndustryCode2(string industryCode2, string industryCode, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = "s";
        subject.IndustryCode2 = industryCode2;
        subject.IndustryCode = industryCode;

        if (industryCode != "")
            subject.CodeListQualifierCode = "A";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "q", true)]
    [InlineData("C", "", false)]
    public void Validation_ARequiresBIndustryCode3(string industryCode3, string industryCode2, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = "s";
        subject.IndustryCode3 = industryCode3;
        subject.IndustryCode2 = industryCode2;

        if (industryCode2 != "")
        {
            subject.IndustryCode = "A";
            subject.CodeListQualifierCode = "A";
        }
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "C", true)]
    [InlineData("P", "", false)]
    public void Validation_ARequiresBIndustryCode4(string industryCode4, string industryCode3, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = "s";
        subject.IndustryCode4 = industryCode4;
        subject.IndustryCode3 = industryCode3;

        if (subject.IndustryCode3 != "")
        {
            subject.IndustryCode2 = "A";
            subject.IndustryCode = "A";
            subject.CodeListQualifierCode = "A";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "P", true)]
    [InlineData("i", "", false)]
    public void Validation_ARequiresBIndustryCode5(string industryCode5, string industryCode4, bool isValidExpected)
    {
        var subject = new C058_AdjustmentReason();
        subject.ClaimAdjustmentReasonCode = "s";
        subject.IndustryCode5 = industryCode5;
        subject.IndustryCode4 = industryCode4;

        if (subject.IndustryCode4 != "")
        {
            subject.IndustryCode3 = "A";
            subject.IndustryCode2 = "A";
            subject.IndustryCode = "A";
            subject.CodeListQualifierCode = "A";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}