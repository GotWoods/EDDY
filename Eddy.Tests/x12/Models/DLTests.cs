using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DL*W*j*5*v*Q*9*5*z*s*i*G";

		var expected = new DL_AutoClaimDetailLabor()
		{
			ActionCode = "W",
			LaborHours = "j",
			LaborHours2 = "5",
			YesNoConditionOrResponseCode = "v",
			Amount = "Q",
			Number = 9,
			Number2 = 5,
			YesNoConditionOrResponseCode2 = "z",
			YesNoConditionOrResponseCode3 = "s",
			YesNoConditionOrResponseCode4 = "i",
			YesNoConditionOrResponseCode5 = "G",
		};

		var actual = Map.MapObject<DL_AutoClaimDetailLabor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validatation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DL_AutoClaimDetailLabor();
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
