using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRC*Oc*V*GH*P8*A5*ly*t3";

		var expected = new CRC_ConditionsIndicator()
		{
			CodeCategory = "Oc",
			YesNoConditionOrResponseCode = "V",
			ConditionIndicatorCode = "GH",
			ConditionIndicatorCode2 = "P8",
			ConditionIndicatorCode3 = "A5",
			ConditionIndicatorCode4 = "ly",
			ConditionIndicatorCode5 = "t3",
		};

		var actual = Map.MapObject<CRC_ConditionsIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Oc", true)]
	public void Validatation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		subject.YesNoConditionOrResponseCode = "V";
		subject.ConditionIndicatorCode = "GH";
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		subject.CodeCategory = "Oc";
		subject.ConditionIndicatorCode = "GH";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GH", true)]
	public void Validatation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		subject.CodeCategory = "Oc";
		subject.YesNoConditionOrResponseCode = "V";
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
