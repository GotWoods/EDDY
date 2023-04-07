using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class FOBTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "FOB*YK*M*t*4J*NFz*8*l*vG*N";

        var expected = new FOB_RelatedInstructions()
        {
            ShipmentMethodOfPaymentCode = "YK",
            LocationQualifier = "M",
            Description = "t",
            TransportationTermsQualifierCode = "4J",
            TransportationTermsCode = "NFz",
            LocationQualifier2 = "8",
            Description2 = "l",
            RiskOfLossCode = "vG",
            Description3 = "N",
        };

        var actual = Map.MapObject<FOB_RelatedInstructions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("YK", true)]
    public void Validatation_RequiredShipmentMethodOfPaymentCode(string shipmentMethodOfPaymentCode, bool isValidExpected)
    {
        var subject = new FOB_RelatedInstructions();
        subject.ShipmentMethodOfPaymentCode = shipmentMethodOfPaymentCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBDescription(string description, string locationQualifier, bool isValidExpected)
    {
        var subject = new FOB_RelatedInstructions();
        subject.ShipmentMethodOfPaymentCode = "YK";
        subject.Description = description;
        subject.LocationQualifier = locationQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "123", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBTransportationTermsQualifierCode(string transportationTermsQualifierCode, string transportationTermsCode, bool isValidExpected)
    {
        var subject = new FOB_RelatedInstructions();
        subject.ShipmentMethodOfPaymentCode = "YK";
        subject.TransportationTermsQualifierCode = transportationTermsQualifierCode;
        subject.TransportationTermsCode = transportationTermsCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBDescription2(string description2, string locationQualifier2, bool isValidExpected)
    {
        var subject = new FOB_RelatedInstructions();
        subject.ShipmentMethodOfPaymentCode = "YK";
        subject.Description2 = description2;
        subject.LocationQualifier2 = locationQualifier2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBRiskOfLossCode(string riskOfLossCode, string description3, bool isValidExpected)
    {
        var subject = new FOB_RelatedInstructions();
        subject.ShipmentMethodOfPaymentCode = "YK";
        subject.RiskOfLossCode = riskOfLossCode;
        subject.Description3 = description3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}