using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class NADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAD+U+++++h+L+Y+m";

		var expected = new NAD_NameAndAddress()
		{
			PartyQualifier = "U",
			PartyIdentificationDetails = null,
			NameAndAddress = null,
			PartyName = null,
			Street = null,
			CityName = "h",
			CountrySubEntityIdentification = "L",
			PostcodeIdentification = "Y",
			CountryCoded = "m",
		};

		var actual = Map.MapObject<NAD_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new NAD_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
