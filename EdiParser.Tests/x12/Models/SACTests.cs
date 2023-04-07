using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class SACTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "SAC*A*f6bC*sx*D*8*n*9*3*IU*5*6*8B*o*C*z*Et";

        var expected = new SAC_ServicePromotionAllowanceOrChargeInformation()
        {
            AllowanceOrChargeIndicatorCode = "A",
            ServicePromotionAllowanceOrChargeCode = "f6bC",
            AgencyQualifierCode = "sx",
            AgencyServicePromotionAllowanceOrChargeCode = "D",
            Amount = "8",
            AllowanceChargePercentQualifier = "n",
            PercentDecimalFormat = 9,
            Rate = 3,
            UnitOrBasisForMeasurementCode = "IU",
            Quantity = 5,
            Quantity2 = 6,
            AllowanceOrChargeMethodOfHandlingCode = "8B",
            ReferenceIdentification = "o",
            OptionNumber = "C",
            Description = "z",
            LanguageCode = "Et",
        };

        var actual = Map.MapObject<SAC_ServicePromotionAllowanceOrChargeInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("A", true)]
    public void Validatation_RequiredAllowanceOrChargeIndicatorCode(string allowanceOrChargeIndicatorCode, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = allowanceOrChargeIndicatorCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", "", false)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_AtLeastOneServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, string agencyQualifierCode, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
        subject.AgencyQualifierCode = agencyQualifierCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", true)]
    [InlineData("", "v2", false)]
    [InlineData("v1", "", false)]
    public void Validation_AllAreRequiredAgencyQualifierCode(string agencyQualifierCode, string agencyServicePromotionAllowanceOrChargeCode, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.AgencyQualifierCode = agencyQualifierCode;
        subject.AgencyServicePromotionAllowanceOrChargeCode = agencyServicePromotionAllowanceOrChargeCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredAllowanceChargePercentQualifier(string allowanceChargePercentQualifier, decimal percentDecimalFormat, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.AllowanceChargePercentQualifier = allowanceChargePercentQualifier;
        if (percentDecimalFormat > 0)
            subject.PercentDecimalFormat = percentDecimalFormat;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(0, 1, true)]
    [InlineData(1, 0, false)]
    public void Validation_ARequiresBQuantity2(decimal quantity2, decimal quantity, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        if (quantity2 > 0)
            subject.Quantity2 = quantity2;
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBOptionNumber(string optionNumber, string referenceIdentification, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.OptionNumber = optionNumber;
        subject.ReferenceIdentification = referenceIdentification;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", false)]
    public void Validation_ARequiresBLanguageCode(string languageCode, string description, bool isValidExpected)
    {
        var subject = new SAC_ServicePromotionAllowanceOrChargeInformation();
        subject.AllowanceOrChargeIndicatorCode = "A";
        subject.LanguageCode = languageCode;
        subject.Description = description;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}