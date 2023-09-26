using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MS6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MS6*4*Y*4";

		var expected = new MS6_ShipmentQuantityAndWeight()
		{
			Quantity = 4,
			WeightQualifier = "Y",
			Weight = 4,
		};

		var actual = Map.MapObject<MS6_ShipmentQuantityAndWeight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new MS6_ShipmentQuantityAndWeight();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightQualifier) || !string.IsNullOrEmpty(subject.WeightQualifier) || subject.Weight > 0)
		{
			subject.WeightQualifier = "Y";
			subject.Weight = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Y", 4, true)]
	[InlineData("Y", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredWeightQualifier(string weightQualifier, decimal weight, bool isValidExpected)
	{
		var subject = new MS6_ShipmentQuantityAndWeight();
		//Required fields
		subject.Quantity = 4;
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
