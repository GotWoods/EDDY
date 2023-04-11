using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C073Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "N*V3*6*R*dT*6*a*NR*7*r*j0*7*O*Fm*1*F*4U*6*g*ys*5*F*SC*5*x*xJ*5*E*cK*3";

        var expected = new C073_CompositeGrapeVarietalSequence()
        {
            AssignedIdentification = "N",
            GrapeVarietalCode = "V3",
            MeasurementValue = 6,
            AssignedIdentification2 = "R",
            GrapeVarietalCode2 = "dT",
            MeasurementValue2 = 6,
            AssignedIdentification3 = "a",
            GrapeVarietalCode3 = "NR",
            MeasurementValue3 = 7,
            AssignedIdentification4 = "r",
            GrapeVarietalCode4 = "j0",
            MeasurementValue4 = 7,
            AssignedIdentification5 = "O",
            GrapeVarietalCode5 = "Fm",
            MeasurementValue5 = 1,
            AssignedIdentification6 = "F",
            GrapeVarietalCode6 = "4U",
            MeasurementValue6 = 6,
            AssignedIdentification7 = "g",
            GrapeVarietalCode7 = "ys",
            MeasurementValue7 = 5,
            AssignedIdentification8 = "F",
            GrapeVarietalCode8 = "SC",
            MeasurementValue8 = 5,
            AssignedIdentification9 = "x",
            GrapeVarietalCode9 = "xJ",
            MeasurementValue9 = 5,
            AssignedIdentification10 = "E",
            GrapeVarietalCode10 = "cK",
            MeasurementValue10 = 3,
        };

        var actual = Map.MapObject<C073_CompositeGrapeVarietalSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("N", true)]
    public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
    {
        var subject = new C073_CompositeGrapeVarietalSequence();
        subject.AssignedIdentification = assignedIdentification;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}