using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TEMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TEM*4*8*B*7*Ke";

		var expected = new TEM_PickupTotals()
		{
			Quantity = 4,
			Quantity2 = 8,
			WeightUnitCode = "B",
			Weight = 7,
			CommodityCharacteristicCodes = "Ke",
		};

		var actual = Map.MapObject<TEM_PickupTotals>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(4,8, true)]
	[InlineData(0, 8, true)]
	[InlineData(4, 0, true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, decimal quantity2, bool isValidExpected)
	{
		var subject = new TEM_PickupTotals();
		if (quantity > 0)
		subject.Quantity = quantity;
		if (quantity2 > 0)
		subject.Quantity2 = quantity2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("B", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("B", 0, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new TEM_PickupTotals();
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0)
		subject.Weight = weight;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
