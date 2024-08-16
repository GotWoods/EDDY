using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E082Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:7:x";

		var expected = new E082_PartyIdentificationDetails()
		{
			PartyIdIdentification = "t",
			CodeListQualifier = "7",
			CodeListResponsibleAgencyCoded = "x",
		};

		var actual = Map.MapComposite<E082_PartyIdentificationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredPartyIdIdentification(string partyIdIdentification, bool isValidExpected)
	{
		var subject = new E082_PartyIdentificationDetails();
		//Required fields
		//Test Parameters
		subject.PartyIdIdentification = partyIdIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
