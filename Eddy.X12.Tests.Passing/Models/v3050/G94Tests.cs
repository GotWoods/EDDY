using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G94Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G94*8c*h";

		var expected = new G94_PromotionConditions()
		{
			PromotionConditionQualifier = "8c",
			OptionNumber = "h",
		};

		var actual = Map.MapObject<G94_PromotionConditions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredOptionNumber(string optionNumber, bool isValidExpected)
	{
		var subject = new G94_PromotionConditions();
		//Required fields
		//Test Parameters
		subject.OptionNumber = optionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
