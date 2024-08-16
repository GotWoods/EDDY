using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E971Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "9:g:8:M:E";

		var expected = new E971_FreeTextQualification()
		{
			TextSubjectCodeQualifier = "9",
			InformationTypeIdentification = "g",
			StatusDescriptionCode = "8",
			PartyName = "M",
			LanguageNameCode = "E",
		};

		var actual = Map.MapComposite<E971_FreeTextQualification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredTextSubjectCodeQualifier(string textSubjectCodeQualifier, bool isValidExpected)
	{
		var subject = new E971_FreeTextQualification();
		//Required fields
		//Test Parameters
		subject.TextSubjectCodeQualifier = textSubjectCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
