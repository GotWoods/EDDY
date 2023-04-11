using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AOLTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AOL*Kq*l*n*3*F*R*1*Yr";

        var expected = new AOL_AnimalObservationLocation
        {
            ObservationTypeCode = "Kq",
            Description = "l",
            TissueOrSpecimenDispositionCode = "n",
            YesNoConditionOrResponseCode = "3",
            SubLocation = "F",
            SubLocation2 = "R",
            SubLocation3 = "1",
            SurfaceLayerPositionCode = "Yr"
        };

        var actual = Map.MapObject<AOL_AnimalObservationLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Kq", true)]
    public void Validatation_RequiredObservationTypeCode(string observationTypeCode, bool isValidExpected)
    {
        var subject = new AOL_AnimalObservationLocation();
        subject.Description = "l";
        subject.ObservationTypeCode = observationTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("l", true)]
    public void Validatation_RequiredDescription(string description, bool isValidExpected)
    {
        var subject = new AOL_AnimalObservationLocation();
        subject.ObservationTypeCode = "Kq";
        subject.Description = description;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}