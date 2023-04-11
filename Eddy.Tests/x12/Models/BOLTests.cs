using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BOLTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "BOL*9IwR*nv*cuFL3ClomExWlyMbaghJzNStwtNV9D*j19jWsm1*hV6GFbyY*pKae0o16sOz7o1xevuTBnYOQrwQVxWtdmP8lBvWBY04ec9EhC4chmuofaXrOYIyJ4LQ2ywjrvfSU35u7*u*8*hc*1I*tVI";

        var expected = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading()
        {
            StandardCarrierAlphaCode = "9IwR",
            ShipmentMethodOfPaymentCode = "nv",
            ShipmentIdentificationNumber = "cuFL3ClomExWlyMbaghJzNStwtNV9D",
            Date = "j19jWsm1",
            Time = "hV6GFbyY",
            ReferenceIdentification = "pKae0o16sOz7o1xevuTBnYOQrwQVxWtdmP8lBvWBY04ec9EhC4chmuofaXrOYIyJ4LQ2ywjrvfSU35u7",
            StatusReportRequestCode = "u",
            SectionSevenCode = "8",
            CustomsDocumentationHandlingCode = "hc",
            ShipmentMethodOfPaymentCode2 = "1I",
            CurrencyCode = "tVI",
        };

        var actual = Map.MapObject<BOL_BeginningSegmentForTheMotorCarrierBillOfLading>(x12Line, MapOptionsForTesting.x12DefaultEndsWithTilde);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("9IwR", true)]
    public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
    {
        var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
        subject.ShipmentMethodOfPaymentCode = "nv";
        subject.ShipmentIdentificationNumber = "cuFL3ClomExWlyMbaghJzNStwtNV9D";
        subject.Date = "j19jWsm1";
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("nv", true)]
    public void Validation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
    {
        var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
        subject.StandardCarrierAlphaCode = "9IwR";
        subject.ShipmentIdentificationNumber = "cuFL3ClomExWlyMbaghJzNStwtNV9D";
        subject.Date = "j19jWsm1";
        subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("cuFL3ClomExWlyMbaghJzNStwtNV9D", true)]
    public void Validation_RequiredShipmentIdentificationNumber(string shipmentIdentificationNumber, bool isValidExpected)
    {
        var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
        subject.StandardCarrierAlphaCode = "9IwR";
        subject.ShipmentMethodOfPaymentCode = "nv";
        subject.Date = "j19jWsm1";
        subject.ShipmentIdentificationNumber = shipmentIdentificationNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("j19jWsm1", true)]
    public void Validation_RequiredDate(string date, bool isValidExpected)
    {
        var subject = new BOL_BeginningSegmentForTheMotorCarrierBillOfLading();
        subject.StandardCarrierAlphaCode = "9IwR";
        subject.ShipmentMethodOfPaymentCode = "nv";
        subject.ShipmentIdentificationNumber = "cuFL3ClomExWlyMbaghJzNStwtNV9D";
        subject.Date = date;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}