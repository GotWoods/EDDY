using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class R3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "R3*Xd*3*mD*2*4luCSj*8*X2FpiQof*m*L*0u*VQ*qW";

        var expected = new R3_RouteInformationMotor()
        {
            StandardCarrierAlphaCode = "Xd",
            RoutingSequenceCode = "3",
            CityName = "mD",
            TransportationMethodTypeCode = "2",
            StandardPointLocationCode = "4luCSj",
            InvoiceNumber = "8",
            Date = "X2FpiQof",
            Amount = "m",
            FreeFormDescription = "L",
            ServiceLevelCode = "0u",
            ServiceLevelCode2 = "VQ",
            ServiceLevelCode3 = "qW",
        };

        var actual = Map.MapObject<R3_RouteInformationMotor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
    {
        var subject = new R3_RouteInformationMotor();
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        subject.RoutingSequenceCode = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
    {
        var subject = new R3_RouteInformationMotor();
        subject.RoutingSequenceCode = routingSequenceCode;
        subject.StandardCarrierAlphaCode = "1234";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("V1", "v2", true)]
    [InlineData("", "v2", false)]
    public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode, string serviceLevelCode2, bool isValidExpected)
    {
        var subject = new R3_RouteInformationMotor();
        subject.StandardCarrierAlphaCode = "1234";
        subject.RoutingSequenceCode = "12";

        subject.ServiceLevelCode = serviceLevelCode;
        subject.ServiceLevelCode2 = serviceLevelCode2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v1", false)]
    public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode2, string serviceLevelCode3, bool isValidExpected)
    {
        var subject = new R3_RouteInformationMotor();
        subject.StandardCarrierAlphaCode = "1234";
        subject.RoutingSequenceCode = "12";

        if (!string.IsNullOrWhiteSpace(serviceLevelCode2))
            subject.ServiceLevelCode = "v1";

        subject.ServiceLevelCode2 = serviceLevelCode2;
        subject.ServiceLevelCode3 = serviceLevelCode3;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}