using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class N12Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "N12*X*";

        var expected = new N12_EquipmentEnvironment
        {
            FuelTypeCode = "X",
            CompositeUnitOfMeasure = null
        };

        var actual = Map.MapObject<N12_EquipmentEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("X", true)]
    public void Validation_RequiredFuelTypeCode(string fuelTypeCode, bool isValidExpected)
    {
        var subject = new N12_EquipmentEnvironment();
        subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
        subject.FuelTypeCode = fuelTypeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("AA", true)]
    public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
    {
        var subject = new N12_EquipmentEnvironment();
        subject.FuelTypeCode = "X";
        if (compositeUnitOfMeasure != "")
            subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}