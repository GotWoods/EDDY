using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CD3Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "CD3*v*1*tt*vOm*AA*o*BB*rB7uKz7B2W43mf*CC*O6afIf6MkW8akj*DD*EE*FFF*41";

        var expected = new CD3_CartonPackageDetail()
        {
            WeightQualifier = "v",
            Weight = 1,
            Zone = "tt",
            ServiceStandard = "vOm",
            ServiceLevelCode = "AA",
            PickupOrDeliveryCode = "o",
            RateValueQualifier = "BB",
            AmountCharged = "rB7uKz7B2W43mf",
            RateValueQualifier2 = "CC",
            AmountCharged2 = "O6afIf6MkW8akj",
            ServiceLevelCode2 = "DD",
            ServiceLevelCode3 = "EE",
            PaymentMethodCode = "FFF",
            CountryCode = "41",
        };

        var actual = Map.MapObject<CD3_CartonPackageDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
    {
        var subject = new CD3_CartonPackageDetail();
        subject.WeightQualifier = weightQualifier;
        if (weight > 0)
            subject.Weight = weight;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredRateValueQualifier(string rateValueQualifier, string amountCharged, bool isValidExpected)
    {
        var subject = new CD3_CartonPackageDetail();
        subject.RateValueQualifier = rateValueQualifier;
        subject.AmountCharged = amountCharged;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredRateValueQualifier2(string rateValueQualifier2, string amountCharged2, bool isValidExpected)
    {
        var subject = new CD3_CartonPackageDetail();
        subject.RateValueQualifier2 = rateValueQualifier2;
        subject.AmountCharged2 = amountCharged2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBServiceLevelCode2(string serviceLevelCode2, string serviceLevelCode, bool isValidExpected)
    {
        var subject = new CD3_CartonPackageDetail();
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
        var subject = new CD3_CartonPackageDetail();
        subject.ServiceLevelCode3 = serviceLevelCode3;
        subject.ServiceLevelCode2 = serviceLevelCode2;
        if (serviceLevelCode2 != "")
            subject.ServiceLevelCode = "AB";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBCountryCode(string countryCode, string serviceLevelCode, bool isValidExpected)
    {
        var subject = new CD3_CartonPackageDetail();
        subject.CountryCode = countryCode;
        subject.ServiceLevelCode = serviceLevelCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}
