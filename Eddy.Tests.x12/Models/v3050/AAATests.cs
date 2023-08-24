using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class AAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AAA*w*EB*Uz*x";

		var expected = new AAA_RequestValidation()
		{
			YesNoConditionOrResponseCode = "w",
			AgencyQualifierCode = "EB",
			RejectReasonCode = "Uz",
			FollowUpActionCode = "x",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
