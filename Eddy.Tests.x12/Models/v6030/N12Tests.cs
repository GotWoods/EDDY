using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class N12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N12*U*";

		var expected = new N12_EquipmentEnvironment()
		{
			FuelTypeCode = "U",
			CompositeUnitOfMeasure = null,
		};

		var actual = Map.MapObject<N12_EquipmentEnvironment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredFuelTypeCode(string fuelTypeCode, bool isValidExpected)
	{
		var subject = new N12_EquipmentEnvironment();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		subject.FuelTypeCode = fuelTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
