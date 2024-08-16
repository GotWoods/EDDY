using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B;

public class FIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FII+p+++Z";

		var expected = new FII_FinancialInstitutionInformation()
		{
			PartyQualifier = "p",
			AccountHolderIdentification = null,
			InstitutionIdentification = null,
			CountryCoded = "Z",
		};

		var actual = Map.MapObject<FII_FinancialInstitutionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new FII_FinancialInstitutionInformation();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
