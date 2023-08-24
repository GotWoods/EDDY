using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class AAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AAA*k*F8*gy*D*kt";

		var expected = new AAA_RequestValidation()
		{
			YesNoConditionOrResponseCode = "k",
			AgencyQualifierCode = "F8",
			RejectReasonCode = "gy",
			FollowUpActionCode = "D",
			ErrorReasonCode = "kt",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
