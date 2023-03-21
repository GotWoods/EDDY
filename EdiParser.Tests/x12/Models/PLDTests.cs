using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class PLDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "PLD*3*9*z*9";

        var expected = new PLD_PalletShipmentInformation()
        {
            QuantityOfPalletsShipped = 3,
            PalletExchangeCode = "9",
            WeightUnitCode = "z",
            Weight = 9,
        };

        var actual = Map.MapObject<PLD_PalletShipmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredQuantityOfPalletsShipped(int quantityOfPalletsShipped, bool isValidExpected)
    {
        var subject = new PLD_PalletShipmentInformation();
        if (quantityOfPalletsShipped > 0)
            subject.QuantityOfPalletsShipped = quantityOfPalletsShipped;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v", 0, false)]
    public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
    {
        var subject = new PLD_PalletShipmentInformation();
        subject.QuantityOfPalletsShipped = 3;
        subject.WeightUnitCode = weightUnitCode;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}