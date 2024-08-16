using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C522Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "L:S:q:e:V";

		var expected = new C522_Instruction()
		{
			InstructionQualifier = "L",
			InstructionCoded = "S",
			CodeListQualifier = "q",
			CodeListResponsibleAgencyCoded = "e",
			Instruction = "V",
		};

		var actual = Map.MapComposite<C522_Instruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredInstructionQualifier(string instructionQualifier, bool isValidExpected)
	{
		var subject = new C522_Instruction();
		//Required fields
		//Test Parameters
		subject.InstructionQualifier = instructionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
