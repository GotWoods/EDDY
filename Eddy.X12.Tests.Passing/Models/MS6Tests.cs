using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MS6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS6*6*3*7*3A";

		var expected = new MS6_ShipmentQuantityAndWeight()
		{
			Quantity = 6,
			WeightQualifier = "3",
			Weight = 7,
			UnitOrBasisForMeasurementCode = "3A",
		};

		var actual = Map.MapObject<MS6_ShipmentQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MS6_ShipmentQuantityAndWeight();
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
