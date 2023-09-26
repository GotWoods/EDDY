using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G93Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G93*t*6*95*h*R*6iv*9*B";

		var expected = new G93_PriceBracketIdentification()
		{
			PriceBracketIdentifier = "t",
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "95",
			FreeFormDescription = "h",
			TransportationMethodTypeCode = "R",
			PriceIdentifierCode = "6iv",
			ActionCode = "9",
			YesNoConditionOrResponseCode = "B",
		};

		var actual = Map.MapObject<G93_PriceBracketIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "95", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "95", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G93_PriceBracketIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
