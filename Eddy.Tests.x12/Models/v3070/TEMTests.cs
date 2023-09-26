using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TEM*2*9*s*5";

		var expected = new TEM_PickUpTotals()
		{
			Quantity = 2,
			Quantity2 = 9,
			WeightUnitCode = "s",
			Weight = 5,
		};

		var actual = Map.MapObject<TEM_PickUpTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(2, 9, true)]
	[InlineData(2, 0, true)]
	[InlineData(0, 9, true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new TEM_PickUpTotals();
		//Required fields
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		if (quantity2 > 0) 
			subject.Quantity2 = quantity2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "s";
			subject.Weight = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("s", 5, true)]
	[InlineData("s", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new TEM_PickUpTotals();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.Quantity = 2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
