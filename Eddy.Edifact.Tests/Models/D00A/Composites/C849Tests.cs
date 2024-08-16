using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C849Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "o:e";

		var expected = new C849_PartiesToInstruction()
		{
			EnactingPartyIdentifier = "o",
			InstructionReceivingPartyIdentifier = "e",
		};

		var actual = Map.MapComposite<C849_PartiesToInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredEnactingPartyIdentifier(string enactingPartyIdentifier, bool isValidExpected)
	{
		var subject = new C849_PartiesToInstruction();
		//Required fields
		//Test Parameters
		subject.EnactingPartyIdentifier = enactingPartyIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
