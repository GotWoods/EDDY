using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "E:s:Z:w:8";

		var expected = new E971_FreeTextQualification()
		{
			TextSubjectCodeQualifier = "E",
			InformationTypeCode = "s",
			StatusDescriptionCode = "Z",
			PartyName = "w",
			LanguageNameCode = "8",
		};

		var actual = Map.MapComposite<E971_FreeTextQualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTextSubjectCodeQualifier(string textSubjectCodeQualifier, bool isValidExpected)
	{
		var subject = new E971_FreeTextQualification();
		//Required fields
		//Test Parameters
		subject.TextSubjectCodeQualifier = textSubjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
