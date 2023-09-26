using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PLDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PLD*5*b*Y*7";

		var expected = new PLD_PalletInformation()
		{
			QuantityOfPalletsShipped = 5,
			PalletExchangeCode = "b",
			WeightUnitCode = "Y",
			Weight = 7,
		};

		var actual = Map.MapObject<PLD_PalletInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityOfPalletsShipped(int quantityOfPalletsShipped, bool isValidExpected)
	{
		var subject = new PLD_PalletInformation();
		//Required fields
		//Test Parameters
		if (quantityOfPalletsShipped > 0) 
			subject.QuantityOfPalletsShipped = quantityOfPalletsShipped;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.WeightUnitCode) || !string.IsNullOrEmpty(subject.WeightUnitCode) || subject.Weight > 0)
		{
			subject.WeightUnitCode = "Y";
			subject.Weight = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Y", 7, true)]
	[InlineData("Y", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredWeightUnitCode(string weightUnitCode, decimal weight, bool isValidExpected)
	{
		var subject = new PLD_PalletInformation();
		//Required fields
		subject.QuantityOfPalletsShipped = 5;
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		if (weight > 0) 
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
