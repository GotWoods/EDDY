using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class FIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FII+l+++O";

		var expected = new FII_FinancialInstitutionInformation()
		{
			PartyQualifier = "l",
			AccountIdentification = null,
			InstitutionIdentification = null,
			CountryCoded = "O",
		};

		var actual = Map.MapObject<FII_FinancialInstitutionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new FII_FinancialInstitutionInformation();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
