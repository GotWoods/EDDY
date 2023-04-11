using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G94Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G94*kD*c";

		var expected = new G94_PromotionConditions()
		{
			PromotionConditionQualifier = "kD",
			OptionNumber = "c",
		};

		var actual = Map.MapObject<G94_PromotionConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredOptionNumber(string optionNumber, bool isValidExpected)
	{
		var subject = new G94_PromotionConditions();
		subject.OptionNumber = optionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
