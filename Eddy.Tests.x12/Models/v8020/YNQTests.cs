using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class YNQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "YNQ*00*a*8Q*e*9*L*Z*3*K*k";

		var expected = new YNQ_YesNoQuestion()
		{
			ConditionIndicatorCode = "00",
			YesNoConditionOrResponseCode = "a",
			DateTimePeriodFormatQualifier = "8Q",
			DateTimePeriod = "e",
			FreeFormMessageText = "9",
			FreeFormMessageText2 = "L",
			FreeFormMessageText3 = "Z",
			CodeListQualifierCode = "3",
			IndustryCode = "K",
			FreeFormMessageText4 = "k",
		};

		var actual = Map.MapObject<YNQ_YesNoQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8Q";
			subject.DateTimePeriod = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8Q", "e", true)]
	[InlineData("8Q", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "a";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "3", true)]
	[InlineData("K", "", false)]
	[InlineData("", "3", true)]
	public void Validation_ARequiresBIndustryCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "a";
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "8Q";
			subject.DateTimePeriod = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
