using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTE*m*e*5*j";

		var expected = new LTE_LetterOfRecommendationEvaluation()
		{
			CodeListQualifierCode = "m",
			IndustryCode = "e",
			Description = "5",
			RatingSummaryValueCode = "j",
		};

		var actual = Map.MapObject<LTE_LetterOfRecommendationEvaluation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("m", "e", true)]
	[InlineData("", "e", false)]
	[InlineData("m", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new LTE_LetterOfRecommendationEvaluation();
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("e","5", true)]
	[InlineData("", "5", true)]
	[InlineData("e", "", true)]
	public void Validation_AtLeastOneIndustryCode(string industryCode, string description, bool isValidExpected)
	{
		var subject = new LTE_LetterOfRecommendationEvaluation();
		subject.IndustryCode = industryCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
