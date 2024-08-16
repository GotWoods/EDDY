using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PNA+y+++M+8+++++";

		var expected = new PNA_PartyName()
		{
			PartyQualifier = "y",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCoded = "M",
			NameStatusCoded = "8",
			NameComponentDetails = null,
			NameComponentDetails2 = null,
			NameComponentDetails3 = null,
			NameComponentDetails4 = null,
			NameComponentDetails5 = null,
		};

		var actual = Map.MapObject<PNA_PartyName>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new PNA_PartyName();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
