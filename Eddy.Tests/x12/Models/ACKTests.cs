using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ACKTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ACK*RH*9*vF*DI8*8jlR59aM*n*7F*F*LP*0*2Y*5*zm*2*ei*H*IB*O*aU*k*3I*n*hc*T*Lj*k*qP*1*n";

        var expected = new ACK_LineItemAcknowledgment
        {
            LineItemStatusCode = "RH",
            Quantity = 9,
            UnitOrBasisForMeasurementCode = "vF",
            DateTimeQualifier = "DI8",
            Date = "8jlR59aM",
            RequestReferenceNumber = "n",
            ProductServiceIDQualifier = "7F",
            ProductServiceID = "F",
            ProductServiceIDQualifier2 = "LP",
            ProductServiceID2 = "0",
            ProductServiceIDQualifier3 = "2Y",
            ProductServiceID3 = "5",
            ProductServiceIDQualifier4 = "zm",
            ProductServiceID4 = "2",
            ProductServiceIDQualifier5 = "ei",
            ProductServiceID5 = "H",
            ProductServiceIDQualifier6 = "IB",
            ProductServiceID6 = "O",
            ProductServiceIDQualifier7 = "aU",
            ProductServiceID7 = "k",
            ProductServiceIDQualifier8 = "3I",
            ProductServiceID8 = "n",
            ProductServiceIDQualifier9 = "hc",
            ProductServiceID9 = "T",
            ProductServiceIDQualifier10 = "Lj",
            ProductServiceID10 = "k",
            AgencyQualifierCode = "qP",
            SourceSubqualifier = "1",
            IndustryCode = "n"
        };

        var actual = Map.MapObject<ACK_LineItemAcknowledgment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("RH", true)]
    public void Validatation_RequiredLineItemStatusCode(string lineItemStatusCode, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = lineItemStatusCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(9, "vF", true)]
    [InlineData(0, "vF", false)]
    [InlineData(9, "", false)]
    public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        if (quantity > 0)
            subject.Quantity = quantity;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "8jlR59aM", true)]
    [InlineData("DI8", "", false)]
    public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string date, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.DateTimeQualifier = dateTimeQualifier;
        subject.Date = date;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("7F", "F", true)]
    [InlineData("", "F", false)]
    [InlineData("7F", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier = productServiceIDQualifier;
        subject.ProductServiceID = productServiceID;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("LP", "0", true)]
    [InlineData("", "0", false)]
    [InlineData("LP", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
        subject.ProductServiceID2 = productServiceID2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("2Y", "5", true)]
    [InlineData("", "5", false)]
    [InlineData("2Y", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
        subject.ProductServiceID3 = productServiceID3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("zm", "2", true)]
    [InlineData("", "2", false)]
    [InlineData("zm", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
        subject.ProductServiceID4 = productServiceID4;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("ei", "H", true)]
    [InlineData("", "H", false)]
    [InlineData("ei", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier5(string productServiceIDQualifier5, string productServiceID5, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier5 = productServiceIDQualifier5;
        subject.ProductServiceID5 = productServiceID5;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("IB", "O", true)]
    [InlineData("", "O", false)]
    [InlineData("IB", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier6(string productServiceIDQualifier6, string productServiceID6, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier6 = productServiceIDQualifier6;
        subject.ProductServiceID6 = productServiceID6;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("aU", "k", true)]
    [InlineData("", "k", false)]
    [InlineData("aU", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier7(string productServiceIDQualifier7, string productServiceID7, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier7 = productServiceIDQualifier7;
        subject.ProductServiceID7 = productServiceID7;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("3I", "n", true)]
    [InlineData("", "n", false)]
    [InlineData("3I", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier8(string productServiceIDQualifier8, string productServiceID8, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier8 = productServiceIDQualifier8;
        subject.ProductServiceID8 = productServiceID8;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("hc", "T", true)]
    [InlineData("", "T", false)]
    [InlineData("hc", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier9(string productServiceIDQualifier9, string productServiceID9, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier9 = productServiceIDQualifier9;
        subject.ProductServiceID9 = productServiceID9;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("Lj", "k", true)]
    [InlineData("", "k", false)]
    [InlineData("Lj", "", false)]
    public void Validation_AllAreRequiredProductServiceIDQualifier10(string productServiceIDQualifier10, string productServiceID10, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.ProductServiceIDQualifier10 = productServiceIDQualifier10;
        subject.ProductServiceID10 = productServiceID10;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("qP", "1", true)]
    [InlineData("", "1", false)]
    [InlineData("qP", "", false)]
    public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string sourceSubqualifier, bool isValidExpected)
    {
        var subject = new ACK_LineItemAcknowledgment();
        subject.LineItemStatusCode = "RH";
        subject.AgencyQualifierCode = agencyQualifierCode;
        subject.SourceSubqualifier = sourceSubqualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}