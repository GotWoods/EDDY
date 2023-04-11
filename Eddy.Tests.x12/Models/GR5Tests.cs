using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GR5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "GR5*hz*6g*8*4T*cfu";

        var expected = new GR5_LoadingDetails
        {
            SpecialHandlingCode = "hz",
            SurfaceLayerPositionCode = "6g",
            MeasurementValue = 8,
            UnitOrBasisForMeasurementCode = "4T",
            StatusReasonCode = "cfu"
        };

        var actual = Map.MapObject<GR5_LoadingDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("hz", true)]
    public void Validation_RequiredSpecialHandlingCode(string specialHandlingCode, bool isValidExpected)
    {
        var subject = new GR5_LoadingDetails();
        subject.SpecialHandlingCode = specialHandlingCode;
        subject.SurfaceLayerPositionCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("6g", 8, true)]
    [InlineData("", 8, true)]
    [InlineData("6g", 0, true)]
    public void Validation_AtLeastOneSurfaceLayerPositionCode(string surfaceLayerPositionCode, decimal measurementValue, bool isValidExpected)
    {
        var subject = new GR5_LoadingDetails();
        subject.SpecialHandlingCode = "hz";
        subject.SurfaceLayerPositionCode = "AB";
        subject.SurfaceLayerPositionCode = surfaceLayerPositionCode;
        if (measurementValue > 0)
        {
            subject.MeasurementValue = measurementValue;
            subject.UnitOrBasisForMeasurementCode = "AA";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(8, "4T", true)]
    [InlineData(0, "4T", false)]
    [InlineData(8, "", false)]
    public void Validation_AllAreRequiredMeasurementValue(decimal measurementValue, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new GR5_LoadingDetails();
        subject.SpecialHandlingCode = "hz";
        if (measurementValue > 0)
            subject.MeasurementValue = measurementValue;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        if (unitOrBasisForMeasurementCode != "")
            subject.MeasurementValue = 1;

        subject.SurfaceLayerPositionCode = "AB";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}