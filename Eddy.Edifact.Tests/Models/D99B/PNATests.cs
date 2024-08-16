using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class PNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PNA+x+++H+P++++++O";

		var expected = new PNA_PartyIdentification()
		{
			PartyFunctionCodeQualifier = "x",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCoded = "H",
			NameStatusCoded = "P",
			NameComponentDetails = null,
			NameComponentDetails2 = null,
			NameComponentDetails3 = null,
			NameComponentDetails4 = null,
			NameComponentDetails5 = null,
			ActionRequestNotificationDescriptionCode = "O",
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
