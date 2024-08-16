using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "q:U:E";

		var expected = new E082_PartyIdentificationDetails()
		{
			PartyIdentification = "q",
			CodeListQualifier = "U",
			CodeListResponsibleAgencyCoded = "E",
		};

		var actual = Map.MapComposite<E082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredPartyIdentification(string partyIdentification, bool isValidExpected)
	{
		var subject = new E082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdentification = partyIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
