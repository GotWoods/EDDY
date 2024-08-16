using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FTX+f+X+++y+n";

		var expected = new FTX_FreeText()
		{
			TextSubjectCodeQualifier = "f",
			FreeTextFunctionCode = "X",
			TextReference = null,
			TextLiteral = null,
			LanguageNameCode = "y",
			FreeTextFormatCode = "n",
		};

		var actual = Map.MapObject<FTX_FreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredTextSubjectCodeQualifier(string textSubjectCodeQualifier, bool isValidExpected)
	{
		var subject = new FTX_FreeText();
		//Required fields
		//Test Parameters
		subject.TextSubjectCodeQualifier = textSubjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
