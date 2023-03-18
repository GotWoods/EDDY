using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class H1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "H1*2lC0*z*t*UD*f*X*55*TP*4";

        var expected = new H1_HazardousMaterial()
        {
            HazardousMaterialCode = "2lC0",
            HazardousMaterialClassCode = "z",
            HazardousMaterialCodeQualifier = "t",
            HazardousMaterialDescription = "UD",
            HazardousMaterialContact = "f",
            HazardousMaterialsPage = "X",
            FlashpointTemperature = 55,
            UnitOrBasisForMeasurementCode = "TP",
            PackingGroupCode = "4",
        };

        var actual = Map.MapObject<H1_HazardousMaterial>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("1234", true)]
    public void Validatation_RequiredHazardousMaterialCode(string hazardousMaterialCode, bool isValidExpected)
    {
        var subject = new H1_HazardousMaterial();
        subject.HazardousMaterialCode = hazardousMaterialCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(55, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(55, "", false)]
    public void Validation_AllAreRequiredFlashpointTemperature(int flashpointTemperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new H1_HazardousMaterial();
        subject.HazardousMaterialCode = "1234";
        if (flashpointTemperature > 0)
            subject.FlashpointTemperature = flashpointTemperature;

        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}