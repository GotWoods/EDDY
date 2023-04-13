using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PO3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "PO3*Oe*qt0rbDcS*Hnw*1*cT*3*41*C";

        var expected = new PO3_AdditionalItemDetail
        {
            ChangeReasonCode = "Oe",
            Date = "qt0rbDcS",
            PriceIdentifierCode = "Hnw",
            UnitPrice = 1,
            BasisOfUnitPriceCode = "cT",
            Quantity = 3,
            UnitOrBasisForMeasurementCode = "41",
            Description = "C"
        };

        var actual = Map.MapObject<PO3_AdditionalItemDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Oe", true)]
    public void Validation_RequiredChangeReasonCode(string changeReasonCode, bool isValidExpected)
    {
        var subject = new PO3_AdditionalItemDetail();
        subject.Quantity = 3;
        subject.UnitOrBasisForMeasurementCode = "41";
        subject.ChangeReasonCode = changeReasonCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", "", true)]
    [InlineData(1, "Hnw", "", true)]
    [InlineData(1, "", "Hn", true)]
    [InlineData(1, "", "", false)]
    public void Validation_IfOneSpecifiedThenOneMoreRequired_UnitPrice(decimal unitPrice, string priceIdentifierCode, string basisOfUnitPriceCode, bool isValidExpected)
    {
        var subject = new PO3_AdditionalItemDetail();
        subject.ChangeReasonCode = "Oe";
        subject.Quantity = 3;
        subject.UnitOrBasisForMeasurementCode = "41";
        if (unitPrice > 0)
            subject.UnitPrice = unitPrice;
        subject.PriceIdentifierCode = priceIdentifierCode;
        subject.BasisOfUnitPriceCode = basisOfUnitPriceCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(3, true)]
    public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
    {
        var subject = new PO3_AdditionalItemDetail();
        subject.ChangeReasonCode = "Oe";
        subject.UnitOrBasisForMeasurementCode = "41";
        if (quantity > 0)
            subject.Quantity = quantity;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("41", true)]
    public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new PO3_AdditionalItemDetail();
        subject.ChangeReasonCode = "Oe";
        subject.Quantity = 3;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}