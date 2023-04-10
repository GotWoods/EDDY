using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models.Elements;

public class C001Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "J4*4*2*Xh*3*6*fy*6*7*sL*9*8*JZ*9*8";

        var expected = new C001_CompositeUnitOfMeasure()
        {
            UnitOrBasisForMeasurementCode = "J4",
            Exponent = 4,
            Multiplier = 2,
            UnitOrBasisForMeasurementCode2 = "Xh",
            Exponent2 = 3,
            Multiplier2 = 6,
            UnitOrBasisForMeasurementCode3 = "fy",
            Exponent3 = 6,
            Multiplier3 = 7,
            UnitOrBasisForMeasurementCode4 = "sL",
            Exponent4 = 9,
            Multiplier4 = 8,
            UnitOrBasisForMeasurementCode5 = "JZ",
            Exponent5 = 9,
            Multiplier5 = 8,
        };

        var actual = Map.MapObject<C001_CompositeUnitOfMeasure>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("J4", true)]
    public void Validatation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
    {
        var subject = new C001_CompositeUnitOfMeasure();
        subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}