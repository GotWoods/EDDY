using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:q:w";

		var expected = new E082_PartyIdentificationDetails()
		{
			PartyIdentifier = "O",
			CodeListIdentificationCode = "q",
			CodeListResponsibleAgencyCode = "w",
		};

		var actual = Map.MapComposite<E082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredPartyIdentifier(string partyIdentifier, bool isValidExpected)
	{
		var subject = new E082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdentifier = partyIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
