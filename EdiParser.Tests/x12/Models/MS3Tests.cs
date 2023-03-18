using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class MS3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "MS3*QH*M*a9*g*Ig";

        var expected = new MS3_InterlineInformation()
        {
            StandardCarrierAlphaCode = "QH",
            RoutingSequenceCode = "M",
            CityName = "a9",
            TransportationMethodTypeCode = "g",
            StateOrProvinceCode = "Ig",
        };

        var actual = Map.MapObject<MS3_InterlineInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
    {
        var subject = new MS3_InterlineInformation();
        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
        subject.RoutingSequenceCode = "12";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredRoutingSequenceCode(string routingSequenceCode, bool isValidExpected)
    {
        var subject = new MS3_InterlineInformation();
        subject.RoutingSequenceCode = routingSequenceCode;
        subject.StandardCarrierAlphaCode = "1234";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
    {
        var subject = new MS3_InterlineInformation();
        subject.StandardCarrierAlphaCode = "1234";
        subject.RoutingSequenceCode = "12";

        subject.StateOrProvinceCode = stateOrProvinceCode;
        subject.CityName = cityName;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}