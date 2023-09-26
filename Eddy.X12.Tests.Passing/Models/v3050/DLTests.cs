using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DL*w*c*i*K*s*8*9*P*L*o*Y";

		var expected = new DL_AutoClaimDetailLabor()
		{
			ActionCode = "w",
			LaborHours = "c",
			LaborHours2 = "i",
			YesNoConditionOrResponseCode = "K",
			Amount = "s",
			Number = 8,
			Number2 = 9,
			YesNoConditionOrResponseCode2 = "P",
			YesNoConditionOrResponseCode3 = "L",
			YesNoConditionOrResponseCode4 = "o",
			YesNoConditionOrResponseCode5 = "Y",
		};

		var actual = Map.MapObject<DL_AutoClaimDetailLabor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new DL_AutoClaimDetailLabor();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
