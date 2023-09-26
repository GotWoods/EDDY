using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G32Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G32*9*U*7*fFppYy";

		var expected = new G32_SurveyQuestionResponse()
		{
			Number = 9,
			YesNoConditionOrResponseCode = "U",
			MonetaryAmount = 7,
			Date = "fFppYy",
		};

		var actual = Map.MapObject<G32_SurveyQuestionResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new G32_SurveyQuestionResponse();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
