using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BBCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BBC*M*K";

		var expected = new BBC_LegalClaims()
		{
			ClaimTypeCode = "M",
			Description = "K",
		};

		var actual = Map.MapObject<BBC_LegalClaims>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredClaimTypeCode(string claimTypeCode, bool isValidExpected)
	{
		var subject = new BBC_LegalClaims();
		subject.ClaimTypeCode = claimTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
