using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class CRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRC*6X*Y*Ov*wr*mS*Te*ir";

		var expected = new CRC_ConditionsIndicator()
		{
			CodeCategory = "6X",
			YesNoConditionOrResponseCode = "Y",
			ConditionIndicator = "Ov",
			ConditionIndicator2 = "wr",
			ConditionIndicator3 = "mS",
			ConditionIndicator4 = "Te",
			ConditionIndicator5 = "ir",
		};

		var actual = Map.MapObject<CRC_ConditionsIndicator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6X", true)]
	public void Validation_RequiredCodeCategory(string codeCategory, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.YesNoConditionOrResponseCode = "Y";
		subject.ConditionIndicator = "Ov";
		//Test Parameters
		subject.CodeCategory = codeCategory;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "6X";
		subject.ConditionIndicator = "Ov";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ov", true)]
	public void Validation_RequiredConditionIndicator(string conditionIndicator, bool isValidExpected)
	{
		var subject = new CRC_ConditionsIndicator();
		//Required fields
		subject.CodeCategory = "6X";
		subject.YesNoConditionOrResponseCode = "Y";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
