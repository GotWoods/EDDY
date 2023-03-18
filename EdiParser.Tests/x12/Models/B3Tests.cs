using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class B3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        //                0  1     2           3     4 5   6      7    8   9     10   11
        string x12Line = "B3**2509121213*8000281336*PP**20110813*18304**20110801*017*XXXX";

        var expected = new B3_BeginningSegmentForCarriersInvoice()
        {
            InvoiceNumber = "2509121213",
            ShipmentIdentificationNumber = "8000281336",
            ShipmentMethodofPaymentCode = "PP",
            Date = "20110813",
            NetAmountDue = "18304",
            DeliveryDate = "20110801",
            DateTimeQualifier = "017",
            StandardCarrierAlphaCode = "XXXX",
        };

        var actual = Map.MapObject<B3_BeginningSegmentForCarriersInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

        Assert.Equivalent(expected, actual);
    }



    [Theory]
    [InlineData("123", "PP", "20030430", "123", "SCAC", true)]
    [InlineData(null, "PP", "20030430", "123", "SCAC", false)]
    [InlineData("123", null, "20030430", "123", "SCAC", false)]
    [InlineData("123", "PP", null, "123", "SCAC", false)]
    [InlineData("123", "PP", "20030430", null, "SCAC", false)]
    [InlineData("123", "PP", "20030430", "123", null, false)]
    public void Validation_MandatoryFields(string invoiceNumber, string shipmentMethodOfPaymentCode, string date, string netAmountDue, string scac, bool isValidExpected)
    {
        var subject = new B3_BeginningSegmentForCarriersInvoice();
        subject.InvoiceNumber = invoiceNumber;
        subject.ShipmentMethodofPaymentCode = shipmentMethodOfPaymentCode;
        subject.Date = date;
        subject.NetAmountDue = netAmountDue;
        subject.StandardCarrierAlphaCode = scac;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}