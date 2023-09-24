using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C067Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "2*R*S*6*v*m*4*6*g*6*7*V";

        var expected = new C067_CompositeProductWeightBasis()
        {
            UnitWeight = 2,
            WeightQualifier = "R",
            WeightUnitCode = "S",
            UnitWeight2 = 6,
            WeightQualifier2 = "v",
            WeightUnitCode2 = "m",
            UnitWeight3 = 4,
            WeightQualifier3 = "6",
            WeightUnitCode3 = "g",
            UnitWeight4 = 6,
            WeightQualifier4 = "7",
            WeightUnitCode4 = "V",
        };

        var actual = Map.MapObject<C067_CompositeProductWeightBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(2, true)]
    public void Validation_RequiredUnitWeight(decimal unitWeight, bool isValidExpected)
    {
        var subject = new C067_CompositeProductWeightBasis();
        subject.WeightQualifier = "R";
        subject.WeightUnitCode = "S";
        if (unitWeight > 0)
            subject.UnitWeight = unitWeight;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("R", true)]
    public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
    {
        var subject = new C067_CompositeProductWeightBasis();
        subject.UnitWeight = 2;
        subject.WeightUnitCode = "S";
        subject.WeightQualifier = weightQualifier;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("S", true)]
    public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
    {
        var subject = new C067_CompositeProductWeightBasis();
        subject.UnitWeight = 2;
        subject.WeightQualifier = "R";
        subject.WeightUnitCode = weightUnitCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}