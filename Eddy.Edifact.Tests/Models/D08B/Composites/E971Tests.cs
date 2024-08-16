using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B.Composites;

public class E971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "A:Z:w:o:b";

		var expected = new E971_FreeTextQualification()
		{
			TextSubjectCodeQualifier = "A",
			InformationTypeCode = "Z",
			StatusDescriptionCode = "w",
			PartyName = "o",
			LanguageNameCode = "b",
		};

		var actual = Map.MapComposite<E971_FreeTextQualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredTextSubjectCodeQualifier(string textSubjectCodeQualifier, bool isValidExpected)
	{
		var subject = new E971_FreeTextQualification();
		//Required fields
		//Test Parameters
		subject.TextSubjectCodeQualifier = textSubjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
