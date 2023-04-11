using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class ADVTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "ADV*ob*GV*6*9*V*FR*9";

        var expected = new ADV_AdvertisingDemographicInformation
        {
            AgencyQualifierCode = "ob",
            ServiceCharacteristicsQualifier = "GV",
            RangeMinimum = 6,
            RangeMaximum = 9,
            Category = "V",
            ServiceCharacteristicsQualifier2 = "FR",
            MeasurementValue = 9
        };

        var actual = Map.MapObject<ADV_AdvertisingDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("ob", true)]
    public void Validation_RequiredAgencyQualifierCode(string agencyQualifierCode, bool isValidExpected)
    {
        var subject = new ADV_AdvertisingDemographicInformation();
        subject.ServiceCharacteristicsQualifier = "GV";
        subject.AgencyQualifierCode = agencyQualifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("GV", true)]
    public void Validation_RequiredServiceCharacteristicsQualifier(string serviceCharacteristicsQualifier, bool isValidExpected)
    {
        var subject = new ADV_AdvertisingDemographicInformation();
        subject.AgencyQualifierCode = "ob";
        subject.ServiceCharacteristicsQualifier = serviceCharacteristicsQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("FR", 9, true)]
    [InlineData("", 9, false)]
    [InlineData("FR", 0, false)]
    public void Validation_AllAreRequiredServiceCharacteristicsQualifier2(string serviceCharacteristicsQualifier2, decimal measurementValue, bool isValidExpected)
    {
        var subject = new ADV_AdvertisingDemographicInformation();
        subject.AgencyQualifierCode = "ob";
        subject.ServiceCharacteristicsQualifier = "GV";
        subject.ServiceCharacteristicsQualifier2 = serviceCharacteristicsQualifier2;
        if (measurementValue > 0)
            subject.MeasurementValue = measurementValue;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}