using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class NADTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAD+W+++++s++2+0";

		var expected = new NAD_NameAndAddress()
		{
			PartyFunctionCodeQualifier = "W",
			PartyIdentificationDetails = null,
			NameAndAddress = null,
			PartyName = null,
			Street = null,
			CityName = "s",
			CountrySubEntityDetails = null,
			PostalIdentificationCode = "2",
			CountryNameCode = "0",
		};

		var actual = Map.MapObject<NAD_NameAndAddress>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new NAD_NameAndAddress();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
