using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G32Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G32*6*q*6*3AOZzYsx*7";

		var expected = new G32_SurveyQuestionResponse()
		{
			Number = 6,
			YesNoConditionOrResponseCode = "q",
			MonetaryAmount = 6,
			Date = "3AOZzYsx",
			Description = "7",
		};

		var actual = Map.MapObject<G32_SurveyQuestionResponse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumber(int number, bool isValidExpected)
	{
		var subject = new G32_SurveyQuestionResponse();
		if (number > 0)
		subject.Number = number;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
