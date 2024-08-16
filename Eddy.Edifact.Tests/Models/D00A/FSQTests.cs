using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FSQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FSQ+Q+Z+g+q+4";

		var expected = new FSQ_FormulaSequence()
		{
			FormulaSequenceCodeQualifier = "Q",
			FormulaSequenceOperandCode = "Z",
			SequencePositionIdentifier = "g",
			FormulaSequenceName = "q",
			FreeTextValue = "4",
		};

		var actual = Map.MapObject<FSQ_FormulaSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredFormulaSequenceCodeQualifier(string formulaSequenceCodeQualifier, bool isValidExpected)
	{
		var subject = new FSQ_FormulaSequence();
		//Required fields
		//Test Parameters
		subject.FormulaSequenceCodeQualifier = formulaSequenceCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
