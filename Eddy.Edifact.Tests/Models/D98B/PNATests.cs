using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class PNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PNA+1+++2+U++++++b";

		var expected = new PNA_PartyIdentification()
		{
			PartyQualifier = "1",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCoded = "2",
			NameStatusCoded = "U",
			NameComponentDetails = null,
			NameComponentDetails2 = null,
			NameComponentDetails3 = null,
			NameComponentDetails4 = null,
			NameComponentDetails5 = null,
			ActionRequestNotificationCoded = "b",
		};

		var actual = Map.MapObject<PNA_PartyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredPartyQualifier(string partyQualifier, bool isValidExpected)
	{
		var subject = new PNA_PartyIdentification();
		//Required fields
		//Test Parameters
		subject.PartyQualifier = partyQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
