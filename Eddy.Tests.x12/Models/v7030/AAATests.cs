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
		string x12Line = "AAA*v*Aa*v0*p*Xt";

		var expected = new AAA_RequestValidation()
		{
			YesNoConditionOrResponseCode = "v",
			AgencyQualifierCode = "Aa",
			RejectReasonCode = "v0",
			FollowUpActionCode = "p",
			ErrorReasonCode = "Xt",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.YesNoConditionOrResponseCode = "v";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
