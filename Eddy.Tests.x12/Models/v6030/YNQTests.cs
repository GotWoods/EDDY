using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class YNQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "YNQ*ls*E*uq*Z*D*V*Y*p*E*F";

		var expected = new YNQ_YesNoQuestion()
		{
			ConditionIndicatorCode = "ls",
			YesNoConditionOrResponseCode = "E",
			DateTimePeriodFormatQualifier = "uq",
			DateTimePeriod = "Z",
			FreeFormMessageText = "D",
			FreeFormMessageText2 = "V",
			FreeFormMessageText3 = "Y",
			CodeListQualifierCode = "p",
			IndustryCode = "E",
			FreeFormMessageText4 = "F",
		};

		var actual = Map.MapObject<YNQ_YesNoQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "uq";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uq", "Z", true)]
	[InlineData("uq", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "E";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "p", true)]
	[InlineData("E", "", false)]
	[InlineData("", "p", true)]
	public void Validation_ARequiresBCodeListQualifierCode(string industryCode, string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new YNQ_YesNoQuestion();
		//Required fields
		subject.YesNoConditionOrResponseCode = "E";
		//Test Parameters
		subject.IndustryCode = industryCode;
		subject.CodeListQualifierCode = codeListQualifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "uq";
			subject.DateTimePeriod = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
