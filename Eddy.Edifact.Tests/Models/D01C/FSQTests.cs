using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class FSQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FSQ+C+I+f+1+v";

		var expected = new FSQ_FormulaSequence()
		{
			FormulaSequenceCodeQualifier = "C",
			FormulaSequenceOperandCode = "I",
			SequencePositionIdentifier = "f",
			FormulaSequenceName = "1",
			FreeText = "v",
		};

		var actual = Map.MapObject<FSQ_FormulaSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredFormulaSequenceCodeQualifier(string formulaSequenceCodeQualifier, bool isValidExpected)
	{
		var subject = new FSQ_FormulaSequence();
		//Required fields
		//Test Parameters
		subject.FormulaSequenceCodeQualifier = formulaSequenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
