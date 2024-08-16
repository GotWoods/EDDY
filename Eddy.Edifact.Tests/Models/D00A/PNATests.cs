using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PNATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PNA+2+++z+1++++++N";

		var expected = new PNA_PartyIdentification()
		{
			PartyFunctionCodeQualifier = "2",
			IdentificationNumber = null,
			PartyIdentificationDetails = null,
			NameTypeCode = "z",
			NameStatusCoded = "1",
			NameComponentDetails = null,
			NameComponentDetails2 = null,
			NameComponentDetails3 = null,
			NameComponentDetails4 = null,
			NameComponentDetails5 = null,
			ActionRequestNotificationDescriptionCode = "N",
		};

		var actual = Map.MapObject<PNA_PartyIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredPartyFunctionCodeQualifier(string partyFunctionCodeQualifier, bool isValidExpected)
	{
		var subject = new PNA_PartyIdentification();
		//Required fields
		//Test Parameters
		subject.PartyFunctionCodeQualifier = partyFunctionCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
