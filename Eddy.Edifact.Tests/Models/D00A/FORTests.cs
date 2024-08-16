using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FOR+q+3+S+5+";

		var expected = new FOR_Formula()
		{
			FormulaTypeCodeQualifier = "q",
			ObjectIdentifier = "3",
			FormulaName = "S",
			FreeTextValue = "5",
			FormulaComplexity = null,
		};

		var actual = Map.MapObject<FOR_Formula>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredFormulaTypeCodeQualifier(string formulaTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new FOR_Formula();
		//Required fields
		//Test Parameters
		subject.FormulaTypeCodeQualifier = formulaTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
