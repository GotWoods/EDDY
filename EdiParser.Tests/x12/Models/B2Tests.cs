using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class B2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "B2**XXXX**9999955559**PP";

        var expected = new B2_BeginningSegmentForShipmentInformationTransaction()
        {
            //TariffServiceCode = "",
            StandardCarrierAlphaCode = "XXXX",
            //StandardPointLocationCode = "",
            ShipmentIdentificationNumber = "9999955559",
            //WeightUnitCode = '',
            ShipmentMethodOfPaymentCode = "PP"
        };

        var actual = Map.MapObject<B2_BeginningSegmentForShipmentInformationTransaction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

        //Assert
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("PP", true)]
    public void Validation_ShipmentMethodOfPaymentCodeIsRequired(string methodOfPayment, bool isValidExpected)
    {
        var subject = new B2_BeginningSegmentForShipmentInformationTransaction();
        subject.ShipmentMethodOfPaymentCode = methodOfPayment;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}