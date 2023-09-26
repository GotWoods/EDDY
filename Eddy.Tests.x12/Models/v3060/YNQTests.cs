using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class YNQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "YNQ*gw*s*ZH*l*B*2*o*o*A*E";

		var expected = new YNQ_YesNoQuestion()
		{
			ConditionIndicator = "gw",
			YesNoConditionOrResponseCode = "s",
			DateTimePeriodFormatQualifier = "ZH",
			DateTimePeriod = "l",
			FreeFormMessageText = "B",
			FreeFormMessageText2 = "2",
			FreeFormMessageText3 = "o",
			CodeListQualifierCode = "o",
			IndustryCode = "A",
			FreeFormMessageText4 = "E",
		};

		var actual = Map.MapObject<YNQ_YesNoQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZH";
			subject.DateTimePeriod = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZH", "l", true)]
	[InlineData("ZH", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "s";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("A", "o", true)]
	[InlineData("A", "", false)]
	[InlineData("", "o", true)]
	public void Validation_ARequiresBCodeListQualifierCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "s";
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ZH";
			subject.DateTimePeriod = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
