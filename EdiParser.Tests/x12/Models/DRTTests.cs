using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DRTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "DRT*n*8K*7*8*F*o";

        var expected = new DRT_CarHireRateDetail
        {
            LoadEmptyStatusCode = "n",
            BilledRatedAsQualifier = "8K",
            MonetaryAmount = 7,
            PercentageAsDecimal = 8,
            ChangeTypeCode = "F",
            YesNoConditionOrResponseCode = "o"
        };

        var actual = Map.MapObject<DRT_CarHireRateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "8K", true)]
    [InlineData(7, "", false)]
    public void Validation_ARequiresBMonetaryAmount(decimal monetaryAmount, string billedRatedAsQualifier, bool isValidExpected)
    {
        var subject = new DRT_CarHireRateDetail();
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        subject.BilledRatedAsQualifier = billedRatedAsQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(7, 8, false)]
    [InlineData(0, 8, true)]
    [InlineData(7, 0, true)]
    public void Validation_OnlyOneOfMonetaryAmount(decimal monetaryAmount, decimal percentageAsDecimal, bool isValidExpected)
    {
        var subject = new DRT_CarHireRateDetail();
        if (monetaryAmount > 0)
        {
            subject.MonetaryAmount = monetaryAmount;
            subject.BilledRatedAsQualifier = "AB";
        }
        if (percentageAsDecimal > 0)
        {
            subject.PercentageAsDecimal = percentageAsDecimal;
            subject.BilledRatedAsQualifier = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(0, "8K", true)]
    [InlineData(8, "", false)]
    public void Validation_ARequiresBPercentageAsDecimal(decimal percentageAsDecimal, string billedRatedAsQualifier, bool isValidExpected)
    {
        var subject = new DRT_CarHireRateDetail();
        if (percentageAsDecimal > 0)
            subject.PercentageAsDecimal = percentageAsDecimal;
        subject.BilledRatedAsQualifier = billedRatedAsQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}