using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G93Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G93*W*2*Ck*J*e*9QP*W*o";

		var expected = new G93_PriceBracketIdentification()
		{
			PriceBracketIdentifier = "W",
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "Ck",
			FreeFormDescription = "J",
			TransportationMethodTypeCode = "e",
			PriceIdentifierCode = "9QP",
			ActionCode = "W",
			YesNoConditionOrResponseCode = "o",
		};

		var actual = Map.MapObject<G93_PriceBracketIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "Ck", true)]
	[InlineData(0, "Ck", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G93_PriceBracketIdentification();
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
