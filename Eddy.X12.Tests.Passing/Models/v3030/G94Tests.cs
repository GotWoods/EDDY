using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G94Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G94*JA*U";

		var expected = new G94_PromotionConditions()
		{
			PromotionConditionQualifier = "JA",
			OptionNumber = "U",
		};

		var actual = Map.MapObject<G94_PromotionConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JA", true)]
	public void Validation_RequiredPromotionConditionQualifier(string promotionConditionQualifier, bool isValidExpected)
	{
		var subject = new G94_PromotionConditions();
		//Required fields
		subject.OptionNumber = "U";
		//Test Parameters
		subject.PromotionConditionQualifier = promotionConditionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredOptionNumber(string optionNumber, bool isValidExpected)
	{
		var subject = new G94_PromotionConditions();
		//Required fields
		subject.PromotionConditionQualifier = "JA";
		//Test Parameters
		subject.OptionNumber = optionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
