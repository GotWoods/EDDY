using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class NADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAD+q+++++g++W+5";

		var expected = new NAD_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "q",
			PartyIdentificationDetails = null,
			NameAndAddress = null,
			PartyName = null,
			Street = null,
			CityName = "g",
			CountrySubdivisionDetails = null,
			PostalIdentificationCode = "W",
			CountryIdentifier = "5",
		};

		var actual = Map.MapObject<NAD_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAD_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
