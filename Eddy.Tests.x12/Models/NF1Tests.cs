using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class NF1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF1*Q*4*Cu";

		var expected = new NF1_NutritionFactsPanel()
		{
			NutritionFactsTableNFTFormatType = "Q",
			Quantity = 4,
			ConditionIndicatorCode = "Cu",
		};

		var actual = Map.MapObject<NF1_NutritionFactsPanel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredNutritionFactsTableNFTFormatType(string nutritionFactsTableNFTFormatType, bool isValidExpected)
	{
		var subject = new NF1_NutritionFactsPanel();
		subject.Quantity = 4;
		subject.NutritionFactsTableNFTFormatType = nutritionFactsTableNFTFormatType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new NF1_NutritionFactsPanel();
		subject.NutritionFactsTableNFTFormatType = "Q";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
