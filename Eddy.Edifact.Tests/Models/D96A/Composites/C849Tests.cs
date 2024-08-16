using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C849Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Z:v";

		var expected = new C849_PartiesToInstruction()
		{
			PartyEnactingInstructionIdentification = "Z",
			RecipientOfTheInstructionIdentification = "v",
		};

		var actual = Map.MapComposite<C849_PartiesToInstruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredPartyEnactingInstructionIdentification(string partyEnactingInstructionIdentification, bool isValidExpected)
	{
		var subject = new C849_PartiesToInstruction();
		//Required fields
		//Test Parameters
		subject.PartyEnactingInstructionIdentification = partyEnactingInstructionIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
