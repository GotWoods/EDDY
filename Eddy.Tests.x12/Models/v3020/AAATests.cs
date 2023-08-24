using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class AAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AAA*U*1s*FR*1";

		var expected = new AAA_RequestValidation()
		{
			ValidityCode = "U",
			AgencyQualifierCode = "1s",
			RejectReasonCode = "FR",
			FollowUpActionCode = "1",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredValidityCode(string validityCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.ValidityCode = validityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
