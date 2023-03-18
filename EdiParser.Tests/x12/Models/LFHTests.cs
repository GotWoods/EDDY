using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class LFHTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "LFH*sDG*5LJaYNgTX8KzKk5qwlCsqDG5z*IK9LYJDRJZXJEVW909JEjYNVC*N*so*6*7*hPzFxTcC";

        var expected = new LFH_FreeFormHazardousMaterialInformation()
        {
            HazardousMaterialShipmentInformationQualifier = "sDG",
            HazardousMaterialShipmentInformation = "5LJaYNgTX8KzKk5qwlCsqDG5z",
            HazardousMaterialShipmentInformation2 = "IK9LYJDRJZXJEVW909JEjYNVC",
            HazardZoneCode = "N",
            UnitOrBasisForMeasurementCode = "so",
            Quantity = 6,
            Quantity2 = 7,
            Date = "hPzFxTcC",
        };

        var actual = Map.MapObject<LFH_FreeFormHazardousMaterialInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("sDG", true)]
    public void Validatation_RequiredHazardousMaterialShipmentInformationQualifier(string hazardousMaterialShipmentInformationQualifier, bool isValidExpected)
    {
        var subject = new LFH_FreeFormHazardousMaterialInformation();
        subject.HazardousMaterialShipmentInformationQualifier = hazardousMaterialShipmentInformationQualifier;
        subject.HazardousMaterialShipmentInformation = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("5LJaYNgTX8KzKk5qwlCsqDG5z", true)]
    public void Validatation_RequiredHazardousMaterialShipmentInformation(string hazardousMaterialShipmentInformation, bool isValidExpected)
    {
        var subject = new LFH_FreeFormHazardousMaterialInformation();
        subject.HazardousMaterialShipmentInformation = hazardousMaterialShipmentInformation;
        subject.HazardousMaterialShipmentInformationQualifier = "ABC";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", 0, true)]
    [InlineData("v1", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("v1", 0, false)]
    public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
    {
        var subject = new LFH_FreeFormHazardousMaterialInformation();
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        subject.HazardousMaterialShipmentInformationQualifier = "ABC";
        subject.HazardousMaterialShipmentInformation = "AB";
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}