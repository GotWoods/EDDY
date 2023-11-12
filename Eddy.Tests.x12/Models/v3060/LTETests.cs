using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTE*k*7*d*A";

		var expected = new LTE_LetterOfRecommendationEvaluation()
		{
			CodeListQualifierCode = "k",
			IndustryCode = "7",
			Description = "d",
			RatingSummaryValueCode = "A",
		};

		var actual = Map.MapObject<LTE_LetterOfRecommendationEvaluation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("k", "7", true)]
	[InlineData("k", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new LTE_LetterOfRecommendationEvaluation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//At Least one
		subject.Description = "d";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("7", "d", true)]
	[InlineData("7", "", true)]
	[InlineData("", "d", true)]
	public void Validation_AtLeastOneIndustryCode(string industryCode, string description, bool isValidExpected)
	{
		var subject = new LTE_LetterOfRecommendationEvaluation();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "k";
			subject.IndustryCode = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
