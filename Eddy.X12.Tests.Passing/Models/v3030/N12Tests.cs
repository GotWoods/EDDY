using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class N12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N12*o*oY";

		var expected = new N12_EquipmentEnvironment()
		{
			FuelType = "o",
			UnitOrBasisForMeasurementCode = "oY",
		};

		var actual = Map.MapObject<N12_EquipmentEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredFuelType(string fuelType, bool isValidExpected)
	{
		var subject = new N12_EquipmentEnvironment();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "oY";
		//Test Parameters
		subject.FuelType = fuelType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oY", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new N12_EquipmentEnvironment();
		//Required fields
		subject.FuelType = "o";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
