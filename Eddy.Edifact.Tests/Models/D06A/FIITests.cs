using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class FIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FII+t+++l";

		var expected = new FII_FinancialInstitutionInformation()
		{
			PartyFunctionCodeQualifier = "t",
			AccountHolderIdentification = null,
			InstitutionIdentification = null,
			CountryIdentifier = "l",
		};

		var actual = Map.MapObject<FII_FinancialInstitutionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new FII_FinancialInstitutionInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
