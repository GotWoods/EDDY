using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class C082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:W:n";

		var expected = new C082_PartyIdentificationDetails()
		{
			PartyIdentification = "Y",
			CodeListQualifier = "W",
			CodeListResponsibleAgencyCoded = "n",
		};

		var actual = Map.MapComposite<C082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredPartyIdentification(string partyIdentification, bool isValidExpected)
	{
		var subject = new C082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdentification = partyIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
