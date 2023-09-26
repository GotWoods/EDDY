using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRC*WN*P*q0*wp*id*aB*Et";

		var expected = new CRC_ConditionsIndicator()
		{
			CodeCategory = "WN",
			YesNoConditionOrResponseCode = "P",
			ConditionIndicatorCode = "q0",
			ConditionIndicatorCode2 = "wp",
			ConditionIndicatorCode3 = "id",
			ConditionIndicatorCode4 = "aB",
			ConditionIndicatorCode5 = "Et",
		};

		var actual = Map.MapObject<CRC_ConditionsIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WN", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.YesNoConditionOrResponseCode = "P";
		subject.ConditionIndicatorCode = "q0";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "WN";
		subject.ConditionIndicatorCode = "q0";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q0", true)]
	public void Validation_RequiredConditionIndicatorCode(string conditionIndicatorCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "WN";
		subject.YesNoConditionOrResponseCode = "P";
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
