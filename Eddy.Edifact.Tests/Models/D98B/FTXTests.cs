using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class FTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FTX+i+5+++1+i";

		var expected = new FTX_FreeText()
		{
			TextSubjectQualifier = "i",
			TextFunctionCoded = "5",
			TextReference = null,
			TextLiteral = null,
			LanguageCoded = "1",
			TextFormattingCoded = "i",
		};

		var actual = Map.MapObject<FTX_FreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredTextSubjectQualifier(string textSubjectQualifier, bool isValidExpected)
	{
		var subject = new FTX_FreeText();
		//Required fields
		//Test Parameters
		subject.TextSubjectQualifier = textSubjectQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
