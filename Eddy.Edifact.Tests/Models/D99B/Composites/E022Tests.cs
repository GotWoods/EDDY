using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E022Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "O:V";

		var expected = new E022_InstructionInformation()
		{
			InstructionDescriptionCode = "O",
			InstructionTypeCodeQualifier = "V",
		};

		var actual = Map.MapComposite<E022_InstructionInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredInstructionDescriptionCode(string instructionDescriptionCode, bool isValidExpected)
	{
		var subject = new E022_InstructionInformation();
		//Required fields
		//Test Parameters
		subject.InstructionDescriptionCode = instructionDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
