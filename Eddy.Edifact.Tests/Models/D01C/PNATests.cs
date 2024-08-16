using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class PNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PNA+x+++D+S++++++F";

		var expected = new PNA_PartyIdentification()
		{
			PartyFunctionCodeQualifier = "x",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCode = "D",
			NameStatusCode = "S",
			NameComponentDetails = null,
			NameComponentDetails2 = null,
			NameComponentDetails3 = null,
			NameComponentDetails4 = null,
			NameComponentDetails5 = null,
			ActionRequestNotificationDescriptionCode = "F",
		};

		var actual = Map.MapObject<PNA_PartyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new PNA_PartyIdentification();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
