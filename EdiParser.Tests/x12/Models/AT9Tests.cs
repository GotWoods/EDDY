using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AT9Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "AT9*7723*1*3*l*V*9*R*5";

        var expected = new AT9_TrailerOrContainerDimensionAndWeight
        {
            EquipmentLength = 7723,
            Height = 1,
            Width = 3,
            WeightQualifier = "l",
            WeightUnitCode = "V",
            Weight = 9,
            VolumeUnitQualifier = "R",
            Volume = 5
        };

        var actual = Map.MapObject<AT9_TrailerOrContainerDimensionAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("R", 5, true)]
    [InlineData("", 5, false)]
    [InlineData("R", 0, false)]
    public void Validation_AllAreRequiredVolumeUnitQualifier(string volumeUnitQualifier, decimal volume, bool isValidExpected)
    {
        var subject = new AT9_TrailerOrContainerDimensionAndWeight();
        subject.VolumeUnitQualifier = volumeUnitQualifier;
        if (volume > 0)
            subject.Volume = volume;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }
}