using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TD5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "TD5*s*R*Gf*J*q*bq*w*P*n7*Ub*3*1E*NU*dh*Xp";

        var expected = new TD5_CarrierDetailsRoutingSequenceTransitTime()
        {
            RoutingSequenceCode = "s",
            IdentificationCodeQualifier = "R",
            IdentificationCode = "Gf",
            TransportationMethodTypeCode = "J",
            Routing = "q",
            ShipmentOrderStatusCode = "bq",
            LocationQualifier = "w",
            LocationIdentifier = "P",
            TransitDirectionCode = "n7",
            TransitTimeDirectionQualifier = "Ub",
            TransitTime = 3,
            ServiceLevelCode = "1E",
            ServiceLevelCode2 = "NU",
            ServiceLevelCode3 = "dh",
            CountryCode = "Xp",
        };

        var actual = Map.MapObject<TD5_CarrierDetailsRoutingSequenceTransitTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.IdentificationCodeQualifier = identificationCodeQualifier;
        subject.IdentificationCode = identificationCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.LocationQualifier = locationQualifier;
        subject.LocationIdentifier = locationIdentifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 1, true)]
    [InlineData("v1", 0, false)]
    public void Validation_ARequiresBTransitTimeDirectionQualifier(string transitTimeDirectionQualifier, decimal transitTime, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.TransitTimeDirectionQualifier = transitTimeDirectionQualifier;
        if (transitTime > 0)
            subject.TransitTime = transitTime;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.ServiceLevelCode2 = serviceLevelCode2;
        subject.ServiceLevelCode = serviceLevelCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBServiceLevelCode3(string serviceLevelCode3, string serviceLevelCode2, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.ServiceLevelCode3 = serviceLevelCode3;
        subject.ServiceLevelCode2 = serviceLevelCode2;
        if (subject.ServiceLevelCode2 != "")
            subject.ServiceLevelCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBCountryCode(string countryCode, string serviceLevelCode, bool isValidExpected)
    {
        var subject = new TD5_CarrierDetailsRoutingSequenceTransitTime();
        subject.CountryCode = countryCode;
        subject.ServiceLevelCode = serviceLevelCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}