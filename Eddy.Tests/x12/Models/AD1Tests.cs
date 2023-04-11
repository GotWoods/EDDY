using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AD1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AD1*77*9*E*q*Pn";

        var expected = new AD1_AdjustmentAmount
        {
            AdjustmentReasonCode = "77",
            MonetaryAmount = 9,
            AdjustmentReasonCodeCharacteristic = "E",
            FrequencyCode = "q",
            LateReasonCode = "Pn"
        };

        var actual = Map.MapObject<AD1_AdjustmentAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("77", true)]
    public void Validatation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
    {
        var subject = new AD1_AdjustmentAmount();
        subject.AdjustmentReasonCode = adjustmentReasonCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}