using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IV1Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "IV1*Z*7*1*N*o7";

        var expected = new IV1_LaneEstimates
        {
            VolumeUnitQualifier = "Z",
            Volume = 7,
            Number = 1,
            TransportationMethodTypeCode = "N",
            UnitOfTimePeriodOrIntervalCode = "o7"
        };

        var actual = Map.MapObject<IV1_LaneEstimates>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("Z", 7, true)]
    [InlineData("", 7, false)]
    [InlineData("Z", 0, false)]
    public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
    {
        var subject = new IV1_LaneEstimates();
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        if (volume > 0)
            subject.Volume = volume;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("", 7, true)]
    [InlineData("o7", 0, false)]
    public void Validation_ARequiresBUnitOfTimePeriodOrIntervalCode(string unitOfTimePeriodOrIntervalCode, decimal volume, bool isValidExpected)
    {
        var subject = new IV1_LaneEstimates();
        subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
        if (volume > 0)
        {
            subject.Volume = volume;
            subject.VolumeUnitQualifier = "A";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }
}