using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CDDTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "CDD*o9*x*L*n*O*6*2*7m*9*Rzr*8*8rE*1*p";

        var expected = new CDD_CreditDebitAdjustmentDetail
        {
            AdjustmentReasonCode = "o9",
            CreditDebitFlagCode = "x",
            AssignedIdentification = "L",
            Amount = "n",
            YesNoConditionOrResponseCode = "O",
            PriceBracketIdentifier = "6",
            CreditDebitQuantity = 2,
            UnitOrBasisForMeasurementCode = "7m",
            UnitPriceDifference = 9,
            PriceIdentifierCode = "Rzr",
            UnitPrice = 8,
            PriceIdentifierCode2 = "8rE",
            UnitPrice2 = 1,
            FreeFormMessageText = "p"
        };

        var actual = Map.MapObject<CDD_CreditDebitAdjustmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o9", true)]
    public void Validation_RequiredAdjustmentReasonCode(string adjustmentReasonCode, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.CreditDebitFlagCode = "x";
        subject.AdjustmentReasonCode = adjustmentReasonCode;

        subject.Amount = "12";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("x", true)]
    public void Validation_RequiredCreditDebitFlagCode(string creditDebitFlagCode, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = creditDebitFlagCode;

        subject.Amount = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("n", 2, true)]
    [InlineData("", 2, true)]
    [InlineData("n", 0, true)]
    public void Validation_AtLeastOneAmount(string amount, decimal creditDebitQuantity, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = "x";
        subject.Amount = amount;
        if (creditDebitQuantity > 0)
        {
            subject.CreditDebitQuantity = creditDebitQuantity;
            subject.UnitPrice = 1;
            subject.PriceIdentifierCode = "ABC";
            subject.UnitOrBasisForMeasurementCode = "AB";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(2, "7m", true)]
    [InlineData(0, "7m", false)]
    [InlineData(2, "", false)]
    public void Validation_AllAreRequiredCreditDebitQuantity(decimal creditDebitQuantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = "x";
        if (creditDebitQuantity > 0)
        {
            subject.CreditDebitQuantity = creditDebitQuantity;
            subject.UnitPrice = 1;
            subject.PriceIdentifierCode = "ABC";
        }
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        subject.Amount = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(0, 8, true)]
    [InlineData(2, 0, false)]
    public void Validation_ARequiresBCreditDebitQuantity(decimal creditDebitQuantity, decimal unitPrice, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = "x";
        if (creditDebitQuantity > 0)
        {
            subject.CreditDebitQuantity = creditDebitQuantity;
            subject.UnitOrBasisForMeasurementCode = "AB";
        }
        if (unitPrice > 0)
        {
            subject.UnitPrice = unitPrice;
            subject.PriceIdentifierCode = "AAA";
        }
        subject.Amount = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("Rzr", 8, true)]
    [InlineData("", 8, false)]
    [InlineData("Rzr", 0, false)]
    public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = "x";
        subject.PriceIdentifierCode = priceIdentifierCode;
        if (unitPrice > 0)
            subject.UnitPrice = unitPrice;
        subject.Amount = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("8rE", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("8rE", 0, false)]
    public void Validation_AllAreRequiredPriceIdentifierCode2(string priceIdentifierCode2, decimal unitPrice2, bool isValidExpected)
    {
        var subject = new CDD_CreditDebitAdjustmentDetail();
        subject.AdjustmentReasonCode = "o9";
        subject.CreditDebitFlagCode = "x";
        subject.PriceIdentifierCode2 = priceIdentifierCode2;
        if (unitPrice2 > 0)
            subject.UnitPrice2 = unitPrice2;
        subject.Amount = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}