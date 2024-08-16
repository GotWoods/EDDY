using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D17A;
using Eddy.Edifact.Models.D17A.Composites;

namespace Eddy.Edifact.Tests.Models.D17A;

public class NAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAA+t++e++a+e+8+4+E";

		var expected = new NAA_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "t",
			PartyIdentificationDetails = null,
			NameAndAddressDescription = "e",
			PartyName = null,
			StreetAndNumberOrPostOfficeBoxIdentifier = "a",
			CityName = "e",
			CountrySubdivisionIdentifier = "8",
			PostalIdentificationCode = "4",
			CountryIdentifier = "E",
		};

		var actual = Map.MapObject<NAA_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAA_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
