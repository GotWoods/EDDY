using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class YNQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "YNQ*8i*V*u6*h*f*k*h*h*5*4";

		var expected = new YNQ_YesNoQuestion()
		{
			ConditionIndicatorCode = "8i",
			YesNoConditionOrResponseCode = "V",
			DateTimePeriodFormatQualifier = "u6",
			DateTimePeriod = "h",
			FreeFormMessageText = "f",
			FreeFormMessageText2 = "k",
			FreeFormMessageText3 = "h",
			CodeListQualifierCode = "h",
			IndustryCode = "5",
			FreeFormMessageText4 = "4",
		};

		var actual = Map.MapObject<YNQ_YesNoQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("u6", "h", true)]
	[InlineData("", "h", false)]
	[InlineData("u6", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		subject.YesNoConditionOrResponseCode = "V";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "h", true)]
	[InlineData("5", "", false)]
	public void Validation_ARequiresBIndustryCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		subject.YesNoConditionOrResponseCode = "V";
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
