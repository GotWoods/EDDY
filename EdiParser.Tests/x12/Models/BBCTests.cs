using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

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
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validatation_RequiredClaimTypeCode(string claimTypeCode, bool isValidExpected)
	{
		var subject = new BBC_LegalClaims();
		subject.ClaimTypeCode = claimTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
