using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C522Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:s:O:k:N";

		var expected = new C522_Instruction()
		{
			InstructionTypeCodeQualifier = "j",
			InstructionDescriptionCode = "s",
			CodeListIdentificationCode = "O",
			CodeListResponsibleAgencyCode = "k",
			InstructionDescription = "N",
		};

		var actual = Map.MapComposite<C522_Instruction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredInstructionTypeCodeQualifier(string instructionTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C522_Instruction();
		//Required fields
		//Test Parameters
		subject.InstructionTypeCodeQualifier = instructionTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
