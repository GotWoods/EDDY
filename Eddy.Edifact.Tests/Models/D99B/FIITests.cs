using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FII+i+++a";

		var expected = new FII_FinancialInstitutionInformation()
		{
			PartyFunctionCodeQualifier = "i",
			AccountHolderIdentification = null,
			InstitutionIdentification = null,
			CountryNameCode = "a",
		};

		var actual = Map.MapObject<FII_FinancialInstitutionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new FII_FinancialInstitutionInformation();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
