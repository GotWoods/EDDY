using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "y:b:p";

		var expected = new C082_PartyIdentificationDetails()
		{
			PartyIdIdentification = "y",
			CodeListQualifier = "b",
			CodeListResponsibleAgencyCoded = "p",
		};

		var actual = Map.MapComposite<C082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredPartyIdIdentification(string partyIdIdentification, bool isValidExpected)
	{
		var subject = new C082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdIdentification = partyIdIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
