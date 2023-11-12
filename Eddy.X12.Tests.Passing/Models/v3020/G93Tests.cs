using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G93Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G93*s*1*np*m";

		var expected = new G93_PriceBracketIdentification()
		{
			PriceBracketIdentifier = "s",
			Quantity = 1,
			UnitOfMeasurementCode = "np",
			FreeFormDescription = "m",
		};

		var actual = Map.MapObject<G93_PriceBracketIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "np", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "np", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G93_PriceBracketIdentification();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
