using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class NAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAA+t++a++i+u+M+d+J";

		var expected = new NAA_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "t",
			PartyIdentificationDetails = null,
			NameAndAddressDescription = "a",
			PartyName = null,
			StreetAndNumberOrPostOfficeBoxIdentifier = "i",
			CityName = "u",
			CountrySubdivisionIdentifier = "M",
			PostalIdentificationCode = "d",
			CountryIdentifier = "J",
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
