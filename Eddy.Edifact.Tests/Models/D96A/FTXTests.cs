using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class FTXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FTX+I+m+++b";

		var expected = new FTX_FreeText()
		{
			TextSubjectQualifier = "I",
			TextFunctionCoded = "m",
			TextReference = null,
			TextLiteral = null,
			LanguageCoded = "b",
		};

		var actual = Map.MapObject<FTX_FreeText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredTextSubjectQualifier(string textSubjectQualifier, bool isValidExpected)
	{
		var subject = new FTX_FreeText();
		//Required fields
		//Test Parameters
		subject.TextSubjectQualifier = textSubjectQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
