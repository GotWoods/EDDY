using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "3:I:j";

		var expected = new C082_PartyIdentificationDetails()
		{
			PartyIdentifier = "3",
			CodeListIdentificationCode = "I",
			CodeListResponsibleAgencyCode = "j",
		};

		var actual = Map.MapComposite<C082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredPartyIdentifier(string partyIdentifier, bool isValidExpected)
	{
		var subject = new C082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdentifier = partyIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
