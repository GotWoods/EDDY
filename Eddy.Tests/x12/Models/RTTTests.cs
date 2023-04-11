using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RTTTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "RTT*tL*1";

        var expected = new RTT_FreightRateInformation()
        {
            RateValueQualifier = "tL",
            FreightRate = 1,
        };

        var actual = Map.MapObject<RTT_FreightRateInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("tL", true)]
    public void Validatation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
    {
        var subject = new RTT_FreightRateInformation();
        subject.FreightRate = 1m;
        subject.RateValueQualifier = rateValueQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
    {
        var subject = new RTT_FreightRateInformation();
        subject.RateValueQualifier = "RT";
        if (freightRate > 0)
            subject.FreightRate = freightRate;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}