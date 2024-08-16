using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class NAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAA+e++I++Y+V+m+w+O";

		var expected = new NAA_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "e",
			PartyIdentificationDetails = null,
			NameAndAddressDescription = "I",
			PartyName = null,
			StreetAndNumberOrPostOfficeBoxIdentifier = "Y",
			CityName = "V",
			CountrySubEntityNameCode = "m",
			PostalIdentificationCode = "w",
			CountryNameCode = "O",
		};

		var actual = Map.MapObject<NAA_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAA_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
