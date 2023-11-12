using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G93Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G93*g*7*My*2*2*vGw";

		var expected = new G93_PriceBracketIdentification()
		{
			PriceBracketIdentifier = "g",
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "My",
			FreeFormDescription = "2",
			TransportationMethodTypeCode = "2",
			PriceIdentifierCode = "vGw",
		};

		var actual = Map.MapObject<G93_PriceBracketIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "My", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "My", false)]
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
