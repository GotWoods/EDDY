using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C522Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "R:2:T:H:3";

		var expected = new C522_Instruction()
		{
			InstructionTypeCodeQualifier = "R",
			InstructionDescriptionCode = "2",
			CodeListIdentificationCode = "T",
			CodeListResponsibleAgencyCode = "H",
			InstructionDescription = "3",
		};

		var actual = Map.MapComposite<C522_Instruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredInstructionTypeCodeQualifier(string instructionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C522_Instruction();
		//Required fields
		//Test Parameters
		subject.InstructionTypeCodeQualifier = instructionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
