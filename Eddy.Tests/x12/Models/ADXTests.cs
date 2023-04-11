using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ADXTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ADX*1*Ul*b5*R";

        var expected = new ADX_Adjustment
        {
            MonetaryAmount = 1,
            AdjustmentReasonCode = "Ul",
            ReferenceIdentificationQualifier = "b5",
            ReferenceIdentification = "R"
        };

        var actual = Map.MapObject<ADX_Adjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
    {
        var subject = new ADX_Adjustment();
        subject.AdjustmentReasonCode = "Ul";
        if (monetaryAmount > 0)
            subject.MonetaryAmount = monetaryAmount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Ul", true)]
    public void Validatation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
    {
        var subject = new ADX_Adjustment();
        subject.MonetaryAmount = 1;
        subject.AdjustmentReasonCode = adjustmentReasonCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("b5", "R", true)]
    [InlineData("", "R", false)]
    [InlineData("b5", "", false)]
    public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
    {
        var subject = new ADX_Adjustment();
        subject.MonetaryAmount = 1;
        subject.AdjustmentReasonCode = "Ul";
        subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
        subject.ReferenceIdentification = referenceIdentification;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}