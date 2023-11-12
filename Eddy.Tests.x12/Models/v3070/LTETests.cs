using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LTETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LTE*h*V*U*Y";

		var expected = new LTE_LetterOfRecommendationEvaluation()
		{
			CodeListQualifierCode = "h",
			IndustryCode = "V",
			Description = "U",
			RatingSummaryValueCode = "Y",
		};

		var actual = Map.MapObject<LTE_LetterOfRecommendationEvaluation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "V", true)]
	[InlineData("h", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new LTE_LetterOfRecommendationEvaluation();
		//Required fields
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		//At Least one
		subject.Description = "U";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("V", "U", true)]
	[InlineData("V", "", true)]
	[InlineData("", "U", true)]
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
			subject.CodeListQualifierCode = "h";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
