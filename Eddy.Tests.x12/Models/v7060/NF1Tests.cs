using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.Tests.Models.v7060;

public class NF1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NF1*6*9*YB";

		var expected = new NF1_NutritionFactsPanel()
		{
			NutritionFactsTableNFTFormatType = "6",
			Quantity = 9,
			ConditionIndicatorCode = "YB",
		};

		var actual = Map.MapObject<NF1_NutritionFactsPanel>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredNutritionFactsTableNFTFormatType(string nutritionFactsTableNFTFormatType, bool isValidExpected)
	{
		var subject = new NF1_NutritionFactsPanel();
		//Required fields
		subject.Quantity = 9;
		//Test Parameters
		subject.NutritionFactsTableNFTFormatType = nutritionFactsTableNFTFormatType;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new NF1_NutritionFactsPanel();
		//Required fields
		subject.NutritionFactsTableNFTFormatType = "6";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
