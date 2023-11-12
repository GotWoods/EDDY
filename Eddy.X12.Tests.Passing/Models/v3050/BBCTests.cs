using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BBCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BBC*d*M";

		var expected = new BBC_LegalClaims()
		{
			ClaimTypeCode = "d",
			Description = "M",
		};

		var actual = Map.MapObject<BBC_LegalClaims>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredClaimTypeCode(string claimTypeCode, bool isValidExpected)
	{
		var subject = new BBC_LegalClaims();
		//Required fields
		//Test Parameters
		subject.ClaimTypeCode = claimTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
