using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class FORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FOR+E+I+l+m+";

		var expected = new FOR_Formula()
		{
			FormulaTypeCodeQualifier = "E",
			ObjectIdentifier = "I",
			FormulaName = "l",
			FreeText = "m",
			FormulaComplexity = null,
		};

		var actual = Map.MapObject<FOR_Formula>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredFormulaTypeCodeQualifier(string formulaTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new FOR_Formula();
		//Required fields
		//Test Parameters
		subject.FormulaTypeCodeQualifier = formulaTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
