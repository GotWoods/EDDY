using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class FORTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FOR+t+b+m+p+";

		var expected = new FOR_Formula()
		{
			FormulaTypeQualifier = "t",
			IdentityNumber = "b",
			FormulaName = "m",
			FreeText = "p",
			FormulaComplexity = null,
		};

		var actual = Map.MapObject<FOR_Formula>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredFormulaTypeQualifier(string formulaTypeQualifier, bool isValidExpected)
	{
		var subject = new FOR_Formula();
		//Required fields
		//Test Parameters
		subject.FormulaTypeQualifier = formulaTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
