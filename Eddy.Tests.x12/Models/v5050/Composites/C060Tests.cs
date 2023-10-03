using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050;
using Eddy.x12.Models.v5050.Composites;

namespace Eddy.x12.Tests.Models.v5050.Composites;

public class C060Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "v*i";

		var expected = new C060_QuestionAndAnswer()
		{
			AssignedIdentification = "v",
			YesNoConditionOrResponseCode = "i",
		};

		var actual = Map.MapObject<C060_QuestionAndAnswer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredAssignedIdentification(string assignedIdentification, bool isValidExpected)
	{
		var subject = new C060_QuestionAndAnswer();
		//Required fields
		subject.YesNoConditionOrResponseCode = "i";
		//Test Parameters
		subject.AssignedIdentification = assignedIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new C060_QuestionAndAnswer();
		//Required fields
		subject.AssignedIdentification = "v";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
