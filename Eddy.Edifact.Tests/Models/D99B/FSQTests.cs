using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FSQTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FSQ+V+o+J+D+8";

		var expected = new FSQ_FormulaSequence()
		{
			FormulaSequenceQualifier = "V",
			FormulaSequenceOperandIdentification = "o",
			SequenceNumber = "J",
			FormulaSequenceName = "D",
			FreeTextValue = "8",
		};

		var actual = Map.MapObject<FSQ_FormulaSequence>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredFormulaSequenceQualifier(string formulaSequenceQualifier, bool isValidExpected)
	{
		var subject = new FSQ_FormulaSequence();
		//Required fields
		//Test Parameters
		subject.FormulaSequenceQualifier = formulaSequenceQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
