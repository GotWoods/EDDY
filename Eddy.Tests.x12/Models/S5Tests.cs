using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "S5*1*kJ*2*a*3*vg*4*n*g*i2opyX*u";

        var expected = new S5_StopOffDetails()
        {
            StopSequenceNumber = 1,
            StopReasonCode = "kJ",
            Weight = 2,
            WeightUnitCode = "a",
            NumberOfUnitsShipped = 3,
            UnitOrBasisForMeasurementCode = "vg",
            Volume = 4,
            VolumeUnitQualifier = "n",
            Description = "g",
            StandardPointLocationCode = "i2opyX",
            AccomplishCode = "u",
        };

        var actual = Map.MapObject<S5_StopOffDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
    {
        var subject = new S5_StopOffDetails();
        subject.StopReasonCode = "12";
        if (stopSequenceNumber > 0)
            subject.StopSequenceNumber = stopSequenceNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
    {
        var subject = new S5_StopOffDetails();
        subject.StopSequenceNumber = 1;
        subject.StopReasonCode = stopReasonCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "1", true)]
    [InlineData(0, "1", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredWeight(decimal weight, string weightUnitCode, bool isValidExpected)
    {
        var subject = new S5_StopOffDetails();
        subject.StopSequenceNumber = 1;
        subject.StopReasonCode = "12";
        if (weight > 0)
            subject.Weight = weight;
        subject.WeightUnitCode = weightUnitCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "v2", true)]
    [InlineData(0, "v2", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new S5_StopOffDetails();
        subject.StopSequenceNumber = 1;
        subject.StopReasonCode = "12";
        if (numberOfUnitsShipped > 0)
            subject.NumberOfUnitsShipped = numberOfUnitsShipped;
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "1", true)]
    [InlineData(0, "1", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
    {
        var subject = new S5_StopOffDetails();
        subject.StopSequenceNumber = 1;
        subject.StopReasonCode = "12";
        if (volume > 0)
            subject.Volume = volume;
        subject.VolumeUnitQualifier = volumeUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}