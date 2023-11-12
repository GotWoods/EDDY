using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TEM*5*2*2*7*Su";

		var expected = new TEM_PickUpTotals()
		{
			Quantity = 5,
			Quantity2 = 2,
			WeightUnitCode = "2",
			Weight = 7,
			CommodityCharacteristicCodes = "Su",
		};

		var actual = Map.MapObject<TEM_PickUpTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 2, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 2, true)]
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
			subject.WeightUnitCode = "2";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2", 7, true)]
	[InlineData("2", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new TEM_PickUpTotals();
		//Required fields
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		//At Least one
		subject.Quantity = 5;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
