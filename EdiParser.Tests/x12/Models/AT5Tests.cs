using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AT5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AT5*KDC*Sg6KVCtucy**zs*9*5";

        var expected = new AT5_BillOfLadingHandlingRequirements()
        {
            SpecialHandlingCode = "KDC",
            SpecialServicesCode = "Sg6KVCtucy",
            //SpecialHandlingDescription = "7oc2iHc3ezlK5yeNZrVp6HPLz0a2Ld",
            UnitOrBasisForMeasurementCode = "zs",
            Temperature = 9,
            Temperature2 = 5,
        };

        var actual = Map.MapObject<AT5_BillOfLadingHandlingRequirements>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", false)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_OnlyOneOfSpecialHandlingCode(string specialHandlingCode, string specialHandlingDescription, bool isValidExpected)
    {
        var subject = new AT5_BillOfLadingHandlingRequirements();
        subject.SpecialHandlingCode = specialHandlingCode;
        subject.SpecialHandlingDescription = specialHandlingDescription;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", "", true)]
    [InlineData("v1", "v2", false)]
    [InlineData("", "v2", true)]
    [InlineData("v1", "", true)]
    public void Validation_OnlyOneOfSpecialServicesCode(string specialServicesCode, string specialHandlingDescription, bool isValidExpected)
    {
        var subject = new AT5_BillOfLadingHandlingRequirements();
        subject.SpecialServicesCode = specialServicesCode;
        subject.SpecialHandlingDescription = specialHandlingDescription;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
    }
    [Theory]
    [InlineData("", 0, 0, true)]
    [InlineData("AB", 0, 0, false)]
    [InlineData("AB", 1, 0, true)]
    [InlineData("AB", 0, 1, true)]
    [InlineData("AB", 1, 1, true)]
    public void Validation_NEWUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal temperature, decimal temperature2, bool isValidExpected)
    {
        var subject = new AT5_BillOfLadingHandlingRequirements();
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        if (temperature > 0)
            subject.Temperature = temperature;
        if (temperature2 > 0)
            subject.Temperature2 = temperature2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOne);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(1, "", false)]
    public void Validation_ARequiresBTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new AT5_BillOfLadingHandlingRequirements();
        if (temperature > 0)
            subject.Temperature = temperature;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;


        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(1, "", false)]
    public void Validation_ARequiresBTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new AT5_BillOfLadingHandlingRequirements();
        if (temperature2 > 0)
            subject.Temperature2 = temperature2;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}