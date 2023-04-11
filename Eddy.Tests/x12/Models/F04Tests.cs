using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F04Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "F04*4*j*s*3*x*q*1*E*2*P";

        var expected = new F04_WeightVolumeLoss
        {
            Weight = 4,
            WeightUnitCode = "j",
            WeightQualifier = "s",
            Weight2 = 3,
            WeightUnitCode2 = "x",
            WeightQualifier2 = "q",
            Volume = 1,
            VolumeUnitQualifier = "E",
            Volume2 = 2,
            VolumeUnitQualifier2 = "P"
        };

        var actual = Map.MapObject<F04_WeightVolumeLoss>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(0, 3, true)]
    [InlineData(4, 0, false)]
    public void Validation_ARequiresBWeight(decimal weight, decimal weight2, bool isValidExpected)
    {
        var subject = new F04_WeightVolumeLoss();
        if (weight > 0)
            subject.Weight = weight;
        if (weight2 > 0)
            subject.Weight2 = weight2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(1, "E", true)]
    [InlineData(0, "E", false)]
    [InlineData(1, "", false)]
    public void Validation_AllAreRequiredVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
    {
        var subject = new F04_WeightVolumeLoss();
        if (volume > 0)
        {
            subject.Volume = volume;
            subject.Volume2 = volume;
            subject.VolumeUnitQualifier2 = "E";
        }
        subject.VolumeUnitQualifier = volumeUnitQualifier;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(0, 2, true)]
    [InlineData(1, 0, false)]
    public void Validation_ARequiresBVolume(decimal volume, decimal volume2, bool isValidExpected)
    {
        var subject = new F04_WeightVolumeLoss();
        if (volume > 0)
        {
            subject.Volume = volume;
            subject.VolumeUnitQualifier = "E";
        }
        if (volume2 > 0)
        {
            subject.Volume2 = volume2;
            subject.VolumeUnitQualifier2 = "E";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData(0, "", true)]
    [InlineData(2, "P", true)]
    [InlineData(0, "P", false)]
    [InlineData(2, "", false)]
    public void Validation_AllAreRequiredVolume2(decimal volume2, string volumeUnitQualifier2, bool isValidExpected)
    {
        var subject = new F04_WeightVolumeLoss();
        if (volume2 > 0)
            subject.Volume2 = volume2;
        subject.VolumeUnitQualifier2 = volumeUnitQualifier2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}