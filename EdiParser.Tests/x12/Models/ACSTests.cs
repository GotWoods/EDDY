using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ACSTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ACS*x*Sbc*x*Sc";

        var expected = new ACS_AncillaryCharges
        {
            Amount = "x",
            SpecialChargeOrAllowanceCode = "Sbc",
            Description = "x",
            ShipmentMethodOfPaymentCode = "Sc"
        };

        var actual = Map.MapObject<ACS_AncillaryCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("x", true)]
    public void Validatation_RequiredAmount(string amount, bool isValidExpected)
    {
        var subject = new ACS_AncillaryCharges();
        subject.SpecialChargeOrAllowanceCode = "Sbc";
        subject.Amount = amount;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Sbc", true)]
    public void Validatation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
    {
        var subject = new ACS_AncillaryCharges();
        subject.Amount = "x";
        subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}