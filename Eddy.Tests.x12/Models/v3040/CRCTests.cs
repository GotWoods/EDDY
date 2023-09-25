using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRC*Ae*a*60*aH*3u*XD*lG";

		var expected = new CRC_ConditionsIndicator()
		{
			CodeCategory = "Ae",
			YesNoConditionOrResponseCode = "a",
			ConditionIndicator = "60",
			ConditionIndicator2 = "aH",
			ConditionIndicator3 = "3u",
			ConditionIndicator4 = "XD",
			ConditionIndicator5 = "lG",
		};

		var actual = Map.MapObject<CRC_ConditionsIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ae", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.YesNoConditionOrResponseCode = "a";
		subject.ConditionIndicator = "60";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "Ae";
		subject.ConditionIndicator = "60";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("60", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "Ae";
		subject.YesNoConditionOrResponseCode = "a";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
