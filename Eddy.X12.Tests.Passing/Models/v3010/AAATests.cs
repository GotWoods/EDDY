using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AAA*1*1P*bN*d";

		var expected = new AAA_RequestValidation()
		{
			ValidityCode = "1",
			AssociationQualifierCode = "1P",
			RejectReasonCode = "bN",
			FollowUpActionCode = "d",
		};

		var actual = Map.MapObject<AAA_RequestValidation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredValidityCode(string validityCode, bool isValidExpected)
	{
		var subject = new AAA_RequestValidation();
		subject.ValidityCode = "1";
		subject.ValidityCode = validityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
