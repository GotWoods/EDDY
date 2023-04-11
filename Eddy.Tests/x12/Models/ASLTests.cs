using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ASLTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ASL*A*1*2c*i";

        var expected = new ASL_AssetLiability
        {
            AmountQualifierCode = "A",
            MonetaryAmount = 1,
            AssetLiabilityTypeCode = "2c",
            FrequencyCode = "i"
        };

        var actual = Map.MapObject<ASL_AssetLiability>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("A", true)]
    public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
    {
        var subject = new ASL_AssetLiability();
        subject.MonetaryAmount = 1;
        subject.AmountQualifierCode = amountQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new ASL_AssetLiability();
        subject.AmountQualifierCode = "A";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}