using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FOR+a+4+O+i+";

		var expected = new FOR_Formula()
		{
			FormulaTypeQualifier = "a",
			ObjectIdentifier = "4",
			FormulaName = "O",
			FreeTextValue = "i",
			FormulaComplexity = null,
		};

		var actual = Map.MapObject<FOR_Formula>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredFormulaTypeQualifier(string formulaTypeQualifier, bool isValidExpected)
	{
		var subject = new FOR_Formula();
		//Required fields
		//Test Parameters
		subject.FormulaTypeQualifier = formulaTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
