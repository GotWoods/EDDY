using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AMTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AMT*3*8*i";

        var expected = new AMT_MonetaryAmountInformation
        {
            AmountQualifierCode = "3",
            MonetaryAmount = 8,
            CreditDebitFlagCode = "i"
        };

        var actual = Map.MapObject<AMT_MonetaryAmountInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("3", true)]
    public void Validatation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
    {
        var subject = new AMT_MonetaryAmountInformation();
        subject.MonetaryAmount = 8;
        subject.AmountQualifierCode = amountQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new AMT_MonetaryAmountInformation();
        subject.AmountQualifierCode = "3";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}