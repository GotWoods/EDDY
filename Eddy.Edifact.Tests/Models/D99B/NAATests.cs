using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class NAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAA+0++x++D+m+F+P+R";

		var expected = new NAA_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "0",
			PartyIdentificationDetails = null,
			NameAndAddressLine = "x",
			PartyName = null,
			StreetAndNumberPOBox = "D",
			CityName = "m",
			CountrySubEntityNameCode = "F",
			PostalIdentificationCode = "P",
			CountryNameCode = "R",
		};

		var actual = Map.MapObject<NAA_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAA_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
