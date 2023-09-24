using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W76*4*5*b5*6*nl*1";

		var expected = new W76_TotalShippingOrder()
		{
			QuantityOrdered = 4,
			Weight = 5,
			UnitOfMeasurementCode = "b5",
			Volume = 6,
			UnitOfMeasurementCode2 = "nl",
			EquivalentWeight = 1,
		};

		var actual = Map.MapObject<W76_TotalShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		//Required fields
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
