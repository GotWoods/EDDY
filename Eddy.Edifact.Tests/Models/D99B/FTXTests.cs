using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FTX+z+g+++7+j";

		var expected = new FTX_FreeText()
		{
			TextSubjectCodeQualifier = "z",
			TextFunctionCoded = "g",
			TextReference = null,
			TextLiteral = null,
			LanguageNameCode = "7",
			TextFormattingCoded = "j",
		};

		var actual = Map.MapObject<FTX_FreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredTextSubjectCodeQualifier(string textSubjectCodeQualifier, bool isValidExpected)
	{
		var subject = new FTX_FreeText();
		//Required fields
		//Test Parameters
		subject.TextSubjectCodeQualifier = textSubjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
