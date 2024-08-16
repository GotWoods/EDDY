using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:J:a";

		var expected = new C082_PartyIdentificationDetails()
		{
			PartyIdentifier = "x",
			CodeListIdentificationCode = "J",
			CodeListResponsibleAgencyCode = "a",
		};

		var actual = Map.MapComposite<C082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPartyIdentifier(string partyIdentifier, bool isValidExpected)
	{
		var subject = new C082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdentifier = partyIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
