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
		string x12Line = "AAA*u*5W*3Z*w";

		var expected = new AAA_RequestValidation()
		{
			ValidityCode = "u",
			AgencyQualifierCode = "5W",
			RejectReasonCode = "3Z",
			FollowUpActionCode = "w",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredValidityCode(string validityCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.ValidityCode = "u";
		subject.ValidityCode = validityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
