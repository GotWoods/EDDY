using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class NAMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "NAM+s+++w+R+";

		var expected = new NAM_PartyName()
		{
			PartyQualifier = "s",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCoded = "w",
			NameStatusCoded = "R",
			NameComponentDetails = null,
		};

		var actual = Map.MapObject<NAM_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new NAM_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
