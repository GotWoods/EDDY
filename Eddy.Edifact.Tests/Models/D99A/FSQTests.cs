using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class FSQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FSQ+O+c+E+s+e";

		var expected = new FSQ_FormulaSequence()
		{
			FormulaSequenceQualifier = "O",
			FormulaSequenceOperandIdentification = "c",
			SequenceNumber = "E",
			FormulaSequenceName = "s",
			FreeText = "e",
		};

		var actual = Map.MapObject<FSQ_FormulaSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredFormulaSequenceQualifier(string formulaSequenceQualifier, bool isValidExpected)
	{
		var subject = new FSQ_FormulaSequence();
		//Required fields
		//Test Parameters
		subject.FormulaSequenceQualifier = formulaSequenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
