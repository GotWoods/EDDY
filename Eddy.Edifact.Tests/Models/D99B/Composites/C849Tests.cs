using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C849Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "g:8";

		var expected = new C849_PartiesToInstruction()
		{
			PartyEnactingInstructionIdentification = "g",
			InstructionReceivingPartyIdentifier = "8",
		};

		var actual = Map.MapComposite<C849_PartiesToInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredPartyEnactingInstructionIdentification(string partyEnactingInstructionIdentification, bool isValidExpected)
	{
		var subject = new C849_PartiesToInstruction();
		//Required fields
		//Test Parameters
		subject.PartyEnactingInstructionIdentification = partyEnactingInstructionIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
