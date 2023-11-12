using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class N12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N12*k*A1";

		var expected = new N12_EquipmentEnvironment()
		{
			FuelType = "k",
			UnitOfMeasurementCode = "A1",
		};

		var actual = Map.MapObject<N12_EquipmentEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredFuelType(string fuelType, bool isValidExpected)
	{
		var subject = new N12_EquipmentEnvironment();
		//Required fields
		subject.UnitOfMeasurementCode = "A1";
		//Test Parameters
		subject.FuelType = fuelType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A1", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new N12_EquipmentEnvironment();
		//Required fields
		subject.FuelType = "k";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
